using System.Collections.ObjectModel;
using System.Linq;
using ProcedureGenerator.Core.DataAccess;
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
		 	return tables;
		 }
	}
}