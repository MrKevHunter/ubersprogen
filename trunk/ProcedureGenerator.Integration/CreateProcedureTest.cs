using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.ProcedureGenerators;

namespace ProcedureGenerator.Integration
{
   [TestFixture]
   public class CreateProcedureTest
   {
      private Table GetTable()
      {
         var tableBuilder = new TableBuilder();
         return tableBuilder.BuildMeATableFromThis(new SchemaDataContext(), "Product");
      }

      [Test]
      public void CanCreateADeleteProcedure()
      {
         Table table = GetTable();
         var deleteProcedure = new DeleteProcedure();
         Procedure procedure = deleteProcedure.Generate(table);

      }

      [Test]
      public void CanCreateAFkSelectProcedure()
      {
         Table table = GetTable();
         var foreignKeyProcedure = new ForeignKeyProcedure();
         List<Procedure> procedures = foreignKeyProcedure.GenerateProcedures(table).ToList();
         Assert.That(procedures.Count , Is.EqualTo(4));

      }

      [Test]
      public void CanCreateUpdateProcedure()
      {
         Table table = GetTable();
         var procedure = new UpdateProcedure();
         Procedure generate = procedure.Generate(table);
      }

      [Test]
      public void CanCreateAInsertProcedure()
      {
         Table table = GetTable();
         var procedure = new InsertProcedure();
         Procedure generate = procedure.Generate(table);
      }

      [Test]
      public void CanCreateASelectProcedure()
      {
         Table table = GetTable();
         var procedure = new SelectProcedure();
         Procedure generate = procedure.Generate(table);
      }
   }
}