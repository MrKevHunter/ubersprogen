using System.Collections.Generic;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public interface IGenerateMultipleProcedure
   {
      IEnumerable<Procedure> GenerateProcedures(Table t, ProcedureConfiguration procConfig);
   }
}