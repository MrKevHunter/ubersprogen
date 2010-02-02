using System;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class UpdateProcedure : GenerateProcedureBase
   {
      protected override string ProcedureName
      {
         get { return string.Format("sp{0}Update",Table.Name); }
      }

      protected override string ProcedureTemplatePath
      {
         get
         {
            return "/velocity/Update/UpdateProcedure.vm";
         }
      }
   }
}