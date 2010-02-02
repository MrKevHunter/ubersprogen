namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class SelectAllProcedure : SelectProcedure
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