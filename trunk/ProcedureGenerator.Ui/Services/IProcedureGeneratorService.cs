using System.Collections.Generic;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Ui.Dto;
using ProcedureGenerator.Ui.ViewModel;

namespace ProcedureGenerator.Ui.Services
{
	public interface IProcedureGeneratorService
	{
		IEnumerable<Procedure> GenerateProcedures(MainViewModel model, TableDto tableDto);
	}
}