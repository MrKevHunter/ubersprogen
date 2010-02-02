namespace ProcedureGenerator.Core.Domain
{
   public class Procedure
   {
      public string Body { get; set; }

      public string Name { get; set; }

      public string FileName
      {
         get { return Name + ".sql"; }
      }
   }
}