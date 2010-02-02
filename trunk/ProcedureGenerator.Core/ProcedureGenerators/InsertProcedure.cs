using System;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class InsertProcedure : GenerateProcedureBase
   {
      protected override string ProcedureName
      {
         get
         {
            return string.Format("sp{0}Insert", Table.Name);
         }
      }

      protected override string ProcedureTemplatePath
      {
         get
         {
            return "/velocity/Insert/InsertProcedure.vm";
         }
      }
   }
}