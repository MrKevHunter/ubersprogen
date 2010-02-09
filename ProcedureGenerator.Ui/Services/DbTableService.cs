using System;
using System.Collections.ObjectModel;
using System.Linq;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Ui.Dto;

namespace ProcedureGenerator.Ui.Services
{
	public class DbTableService
	{
		public ObservableCollection<TableDto> GetTables(string connectionString)
		{
			var schemaDataContext = new SchemaDataContext(connectionString);
			var tables = new ObservableCollection<TableDto>();
			foreach (
				TABLE table in
					schemaDataContext.TABLEs.Where(table => table.TABLE_TYPE == "BASE TABLE").OrderBy(
						table1 => table1.TABLE_NAME))
			{
				tables.Add(new TableDto
				           	{
				           		IsChecked = false,
				           		TableName = table.TABLE_NAME,
				           		HasPrimaryKey = false,
				           		HasForeignKey = true
				           	});
			}

			foreach (var dto in tables)
			{
				dto.HasPrimaryKey = HasTableAPrimaryKey(dto.TableName,connectionString);
				dto.HasForeignKey = HasTableAnyForeignKeys(dto.TableName, connectionString);
			}

			return tables;
		}

		private bool HasTableAnyForeignKeys(string name, string s)
		{
			return new TableBuilder().GetForeignKeyList(new SchemaDataContext(s), name).Any();
		}

		private bool HasTableAPrimaryKey(string name,string connectionString)
		{
			return new TableBuilder().GetPrimaryKey(new SchemaDataContext(connectionString), name) != null;
		}
	}
}