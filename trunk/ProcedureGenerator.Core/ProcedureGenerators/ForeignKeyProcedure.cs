using System;
using System.Collections.Generic;
using System.Text;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.Velocity;

namespace ProcedureGenerator.Core.ProcedureGenerators
{
   public class ForeignKeyProcedure : GenerateProcedureBase , IGenerateMultipleProcedure
   {
      private Column _foreignKey;
      protected override string ProcedureName
      {
         get
         {
            return string.Format("sp{0}SelectBy{1}", Table.Name, Table.PrimaryKey);
         }
      }

      protected override string ProcedureTemplatePath
      {
         get
         {
            return "/velocity/Select/SelectByFk.vm";
         }
      }


      public IEnumerable<Procedure> GenerateProcedures(Table t)
      {
         Table = t;
         foreach (Column foreignKey in t.ForeignKeys)
         {
            _foreignKey = foreignKey;
            yield return Generate(t);

         }

      }

      protected override string GenerateBody()
      {
         var procedureGeneration = new VelocityProcedureGeneration(ProcedureTemplatePath,
                                                          string.Format("sp{0}SelectBy{1}", Table.Name,
                                                                        _foreignKey), Owner, Table);
         procedureGeneration.AddKeys(new KeyValuePair<string, object>("key", _foreignKey));
         return procedureGeneration.Execute();
      }
   }
}