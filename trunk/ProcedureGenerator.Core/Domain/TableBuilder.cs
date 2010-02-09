using System.Collections.Generic;
using System.Linq;
using ProcedureGenerator.Core.DataAccess;

namespace ProcedureGenerator.Core.Domain
{
	public class TableBuilder
	{
		public Table BuildMeATableFromThis(SchemaDataContext context, string tableName)
		{
			var table = new Table();
			IEnumerable<COLUMN> columns = GetColumns(context, tableName);

			IEnumerable<CONSTRAINT_COLUMN_USAGE> foreignKeyList = GetForeignKeyList(context, tableName);

			table.Columns = columns.ToList().ConvertAll(c => new ColumnFactory().BuildColumn(c, foreignKeyList,GetIdentityColumns(context,tableName)));

			table.PrimaryKey = GetPrimaryKey(context, tableName);

			table.Name = tableName;

			table.Schema = GetSchema(context, tableName);

			return table;
		}

		private string GetSchema(SchemaDataContext context, string tableName)
		{
			return (from table in context.TABLEs
			        where table.TABLE_NAME == tableName
			        select table.TABLE_SCHEMA).First();
		}

		private IEnumerable<CONSTRAINT_COLUMN_USAGE> GetForeignKeyList(SchemaDataContext context, string tableName)
		{
			return (from constraintColumnUsage in context.CONSTRAINT_COLUMN_USAGEs
			        join tableConstraint in context.TABLE_CONSTRAINTs
			        	on constraintColumnUsage.CONSTRAINT_NAME equals tableConstraint.CONSTRAINT_NAME
			        where constraintColumnUsage.TABLE_NAME == tableName
			              && tableConstraint.CONSTRAINT_TYPE == "FOREIGN KEY"
			        select constraintColumnUsage);
		}

		private IEnumerable<all_column> GetIdentityColumns(SchemaDataContext context, string tableName)
		{
			return from table in context.systables
			       join column in context.all_columns on table.object_id equals column.object_id
			       where table.name == tableName
			             && column.is_identity
			       select column;
		}


		private Column GetPrimaryKey(SchemaDataContext context, string tableName)
		{
			return new ColumnFactory().BuildColumn((from tableConstraint in context.TABLE_CONSTRAINTs
			                                        join columnConstraint in context.CONSTRAINT_COLUMN_USAGEs
			                                        	on tableConstraint.CONSTRAINT_NAME equals columnConstraint.CONSTRAINT_NAME
			                                        join column in context.COLUMNs
			                                        	on columnConstraint.COLUMN_NAME equals column.COLUMN_NAME
			                                        where tableConstraint.CONSTRAINT_TYPE.Contains("PRIMARY KEY")
			                                              && tableConstraint.TABLE_NAME == tableName
			                                        select column).FirstOrDefault());
		}

		private IEnumerable<COLUMN> GetColumns(SchemaDataContext context, string tableName)
		{
			return from column in context.COLUMNs
			       where column.TABLE_NAME.ToUpper() == tableName.ToUpper()
			       orderby column.COLUMN_NAME
			       select column;
		}
	}
}