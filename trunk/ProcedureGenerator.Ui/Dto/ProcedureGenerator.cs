using System;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.ProcedureGenerators;

namespace ProcedureGenerator.Ui.Dto
{
	public static class ProcedureGenerators
	{
		public static ProcedureGenerator Delete = new ProcedureGenerator("Delete",new DeleteProcedure());
		public static ProcedureGenerator Insert = new ProcedureGenerator("Insert", new InsertProcedure());
		public static ProcedureGenerator Update = new ProcedureGenerator("Update", new UpdateProcedure());
		public static ProcedureGenerator Select = new ProcedureGenerator("Select", new SelectProcedure());
		public static ProcedureGenerator SelectById = new ProcedureGenerator("SelectById", new SelectByIdProcedure());
		public static ProcedureGenerator SelectByFk = new ProcedureGenerator("Delete", new SelectByIdProcedure());

		public class ProcedureGenerator
		{
			public string Name { get; private set;}
			public IGenerateProcedure GenerateProcedure { get; private set;}

			public ProcedureGenerator(string name, IGenerateProcedure generateProcedure)
			{
				Name = name;
				GenerateProcedure = generateProcedure;
				ExecuteProcedure = (table, configuration) => GenerateProcedure.Generate(table, configuration);
			}

			public Func<Table, ProcedureConfiguration, Procedure> ExecuteProcedure;
		}

	}
}