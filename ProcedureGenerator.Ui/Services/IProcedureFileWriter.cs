using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Ui.Services
{
	public interface IProcedureFileWriter
	{
		void WriteProcedures(IEnumerable<Procedure> procs);
	}

	public class SingleFileFileWriter : IProcedureFileWriter
	{
		private string outputPath;

		public SingleFileFileWriter(string outputPath)
		{
			this.outputPath = outputPath;
		}

		#region IProcedureFileWriter Members

		public void WriteProcedures(IEnumerable<Procedure> procs)
		{
			string output = procs.Aggregate("", (current, procedure) => current + (procedure + "\n\n"));

			File.WriteAllText(Path.Combine(outputPath, "AllProcs.sql"), output);
		}

		#endregion

		}
	}

