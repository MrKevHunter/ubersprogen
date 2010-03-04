using System.Collections.ObjectModel;
using ProcedureGenerator.Ui.Dto;

namespace ProcedureGenerator.Ui.Services
{
	public interface IDbTableService
	{
		ObservableCollection<TableDto> GetTables(string connectionString);
	}
}