using System;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class SelectByIdProcedure : GenerateProcedureBase
   {
      protected override string ProcedureName
      {
         get
         {
            return string.Format("sp{0}SelectBy{1}", Table.Name,Table.PrimaryKey);
         }
      }

      protected override string ProcedureTemplatePath
      {
         get
         {
            return "/velocity/Select/SelectById.vm";
         }
      }
   }
}