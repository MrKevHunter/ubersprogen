using ProcedureGenerator.Core.Velocity;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class DeleteProcedure : GenerateProcedureBase
   {
      protected override string ProcedureTemplatePath
      {
         get { return "/velocity/Delete/ProcedureDelete.vm"; }
      }

      protected override string ProcedureName
      {
         get { return string.Format("sp{0}Delete", Table.Name); }
      }


   }
}