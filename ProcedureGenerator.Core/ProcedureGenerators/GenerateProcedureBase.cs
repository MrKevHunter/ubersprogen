using System;
using System.Text;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.Velocity;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
	public abstract class GenerateProcedureBase : IGenerateProcedure
	{

		protected abstract string ProcedureName { get; }

		protected ProcedureConfiguration ProcConfig { get; set; }

		protected Table Table { get; set; }
		public virtual Procedure Generate(Table t, ProcedureConfiguration procedureConfig)
		{
			ProcConfig = procedureConfig;
			Table = t;
			var sb = new StringBuilder();
			sb.AppendLine(GenerateExistenceCheck());
			sb.AppendLine(GenerateComments());
			sb.AppendLine(GenerateBody());
			return new Procedure { Body = sb.ToString(), Name = ProcedureName };
		}

		protected virtual string GenerateBody()
		{
			var procedureGeneration = new VelocityProcedureGeneration(ProcedureTemplatePath, ProcedureName, Table, ProcConfig);
			return procedureGeneration.Execute();
		}

		protected virtual string GenerateComments()
		{
			const string path = "/velocity/common/comment.vm";
			return new VelocityProcedureGeneration(path, ProcedureName).Execute();
		}

		protected abstract string ProcedureTemplatePath { get; }

		protected virtual string GenerateExistenceCheck()
		{
			const string existenceCheck = "/velocity/common/ProcedureDropExisting.vm";
			var procedureGeneration = new VelocityProcedureGeneration(existenceCheck, ProcedureName, Table, ProcConfig);
			return procedureGeneration.Execute();
		}
	}
}