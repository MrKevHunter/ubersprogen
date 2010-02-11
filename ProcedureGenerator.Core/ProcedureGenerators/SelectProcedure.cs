namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class SelectProcedure : SelectByIdProcedure
   {
      protected override string ProcedureTemplatePath
      {
         get
         {
            return "/Velocity/Select/SelectAll.Vm";
         }
      }
   }
}