using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Ui.Services
{
	public class FilePerProcedureWriter : IProcedureFileWriter, IProgressReporter
	{
		private readonly string outputPath;


		public FilePerProcedureWriter(string outputPath)
		{
			this.outputPath = outputPath;
		}

		#region IProcedureFileWriter Members

		public void WriteProcedures(IEnumerable<Procedure> procs)
		{
			int Total = procs.Count();
			int counter = 0;
			foreach (Procedure procedure in procs)
			{
				File.WriteAllText(Path.Combine(outputPath, procedure.FileName), procedure.Body);
				PercentComplete = ++counter/Total*100;
			}
		}

		#endregion

		#region IProgressReporter Members

		public decimal PercentComplete { get; private set; }

		#endregion
	}
}