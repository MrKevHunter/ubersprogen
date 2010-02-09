using System.Collections.Generic;
using System.Data;
using System.Linq;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.Exceptions;

namespace ProcedureGenerator.Core
{
   public class ColumnFactory
   {
      private static readonly IDictionary<string, SqlDbType> typeMap = new Dictionary<string, SqlDbType>
                                                                          {
                                                                             {"char", SqlDbType.Char},
                                                                             {"int", SqlDbType.Int},
                                                                             {"nchar", SqlDbType.NChar},
                                                                             {"decimal", SqlDbType.Decimal},
                                                                             {"datetime", SqlDbType.DateTime},
                                                                             {"bit",SqlDbType.Bit},
                                                                             {"nvarchar",SqlDbType.NVarChar},
                                                                             {"uniqueidentifier",SqlDbType.UniqueIdentifier},
                                                                             {"smallint",SqlDbType.SmallInt},
                                                                             {"money",SqlDbType.Money},
                                                                             {"xml",SqlDbType.Xml},
                                                                             {"tinyint",SqlDbType.TinyInt},
                                                                             {"varchar",SqlDbType.VarChar}   ,
                                                                             {"varbinary",SqlDbType.VarBinary},
                                                                             {"smallmoney",SqlDbType.SmallMoney},
                                                                             {"numeric",SqlDbType.Decimal},
																									  {"smalldatetime",SqlDbType.SmallDateTime},
																									  {"ntext",SqlDbType.NText},
																									  {"float",SqlDbType.Float},
																									  {"bigint",SqlDbType.BigInt},
																									  {"Xml",SqlDbType.Xml}
                                                                          };


      public Column BuildColumn(COLUMN c, IEnumerable<CONSTRAINT_COLUMN_USAGE> foreignKeyList, IEnumerable<all_column> identityColumns)
      {
			if (c == null) return null;

         Column column = new Column
                                 {
                                    Name = c.COLUMN_NAME,
                                    ColumnType = GetColumnType(c.DATA_TYPE),
                                    Length = c.CHARACTER_MAXIMUM_LENGTH.ToString(),
                                 };
         if(foreignKeyList.Any(usage => usage.COLUMN_NAME == column.Name))
            column.IsForeignKey = true;

			if(identityColumns.Any(x => x.name == column.Name))
				column.IsIdentity = true;

         return column;
      }

       public Column BuildColumn(COLUMN c)
       {
          return BuildColumn(c, new List<CONSTRAINT_COLUMN_USAGE>(),new List<all_column>());
       }

      private SqlDbType GetColumnType(string type)
      {
         if (typeMap.ContainsKey(type))
            return typeMap[type];

         throw new UnMappedSqlTypeException(type);
      }
   }
}