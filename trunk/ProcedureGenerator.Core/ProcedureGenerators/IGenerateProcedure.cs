using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public interface IGenerateProcedure
   {
      Procedure Generate(Table t, ProcedureConfiguration procedureConfig);
   }
}