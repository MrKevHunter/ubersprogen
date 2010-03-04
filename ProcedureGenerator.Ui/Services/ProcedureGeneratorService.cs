using System.Collections.Generic;
using System.IO;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.ProcedureGenerators;
using ProcedureGenerator.Ui.Dto;
using ProcedureGenerator.Ui.ViewModel;

namespace ProcedureGenerator.Ui.Services
{
	public class ProcedureGeneratorService : IProcedureGeneratorService
	{
		private MainViewModel _model;

		public IEnumerable<Procedure> GenerateProcedures(MainViewModel model, TableDto tableDto)
		{
			_model = model;
			Table table = new TableBuilder().BuildMeATableFromThis(new SchemaDataContext(_model.ConnectionString),
																		 tableDto.TableName);
			if (model.Delete)
				yield return BuildAndWrite(table, new DeleteProcedure());

			if (model.Insert)
				yield return BuildAndWrite(table, new InsertProcedure());

			if (model.Select)
				yield return BuildAndWrite(table, new SelectProcedure());

			if (model.SelectById)
				yield return BuildAndWrite(table, new SelectByIdProcedure());

			if (model.SelectByFk)
				foreach (var proc	 in BuildAndWrite(table, (IGenerateMultipleProcedure)new ForeignKeyProcedure()))
				{
					yield return proc;
				}

			if (model.Update)
				yield return BuildAndWrite(table, new UpdateProcedure());
		}

		private IEnumerable<Procedure> BuildAndWrite(Table table, IGenerateMultipleProcedure generator)
		{
			return generator.GenerateProcedures(table, _model.GetProcedureConfig());
		}

		private Procedure BuildAndWrite(Table table, IGenerateProcedure generator)
		{
			 return generator.Generate(table, _model.GetProcedureConfig());
		}
	}
}