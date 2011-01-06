using System.Collections.Generic;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.Velocity;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
	public class ForeignKeyProcedure : GenerateProcedureBase, IGenerateMultipleProcedure
	{
		private Column _foreignKey;
		protected override string ProcedureName
		{
			get
			{
				return string.Format("sp{0}SelectBy{1}", Table.Name, _foreignKey);
			}
		}

		protected override string ProcedureTemplatePath
		{
			get
			{
				return "/velocity/Select/SelectByFk.vm";
			}
		}

		private ProcedureConfiguration procConfig;

		public IEnumerable<Procedure> GenerateProcedures(Table t, ProcedureConfiguration procConfig)
		{
			this.procConfig = procConfig;
			Table = t;
			foreach (var foreignKey in t.ForeignKeys)
			{
				_foreignKey = foreignKey;
				yield return Generate(t, procConfig);
			}
		}

		protected override string GenerateBody()
		{
			var procedureGeneration = new VelocityProcedureGeneration(ProcedureTemplatePath,
																			 string.Format("sp{0}SelectBy{1}", Table.Name,
																								_foreignKey), Table, procConfig);
			procedureGeneration.AddKeys(new KeyValuePair<string, object>("key", _foreignKey));
			return procedureGeneration.Execute();
		}
	}
}