using Machine.Specifications;
using ProcedureGenerator.Core.ProcedureGenerators;

namespace ProcedureGenerator.Tests.DeleteProcedureConcern
{
   public abstract class with_the_delete_procedure_generator
   {
      protected static DeleteProcedure ProcedureGenerator;
      Establish context = () =>
      {
         ProcedureGenerator = null;
      };
   }
}