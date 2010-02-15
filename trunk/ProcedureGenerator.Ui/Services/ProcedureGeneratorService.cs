using System.IO;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.ProcedureGenerators;
using ProcedureGenerator.Ui.Dto;
using ProcedureGenerator.Ui.ViewModel;

namespace ProcedureGenerator.Ui.Services
{
	public class ProcedureGeneratorService
	{
		private MainViewModel _model;

		public void GenerateProcedures(MainViewModel model, TableDto tableDto)
		{
			_model = model;
			Table table = new TableBuilder().BuildMeATableFromThis(new SchemaDataContext(_model.ConnectionString),
																		 tableDto.TableName);
			if (model.Delete)
				BuildAndWrite(table, new DeleteProcedure());

			if (model.Insert)
				BuildAndWrite(table, new InsertProcedure());

			if (model.Select)
				BuildAndWrite(table, new SelectProcedure());

			if (model.SelectById)
				BuildAndWrite(table, new SelectByIdProcedure());

			if (model.SelectByFk)
				BuildAndWrite(table, (IGenerateMultipleProcedure)new ForeignKeyProcedure());

			if (model.Update)
				BuildAndWrite(table, new UpdateProcedure());
		}

		private void BuildAndWrite(Table table, IGenerateMultipleProcedure generator)
		{
			
			foreach (Procedure procedure in generator.GenerateProcedures(table, _model.GetProcedureConfig()))
			{
				File.WriteAllText(Path.Combine(_model.OutputPath, procedure.FileName), procedure.Body);
			}
		}

		private void BuildAndWrite(Table table, IGenerateProcedure generator)
		{
			Procedure procedure = generator.Generate(table, _model.GetProcedureConfig());
			File.WriteAllText(Path.Combine(_model.OutputPath, procedure.FileName), procedure.Body);
		}
	}
}