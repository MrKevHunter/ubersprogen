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
      public void CanCreateADeleteProcedureWithNoCountOff()
      {
         Table table = GetTable();
         var deleteProcedure = new DeleteProcedure();
         Procedure procedure = deleteProcedure.Generate(table, new ProcedureConfiguration());
      	Assert.That(procedure.Body, Is.Not.StringContaining("SET NOCOUNT ON"));
      }   
		
		[Test]
      public void CanCreateADeleteProcedureWithNoCountOn()
      {
         Table table = GetTable();
         var deleteProcedure = new DeleteProcedure();
         Procedure procedure = deleteProcedure.Generate(table, new ProcedureConfiguration(){SetNoCountOn = true});
			Assert.That(procedure.Body, Is.StringContaining("SET NOCOUNT ON"));
      }

      [Test]
      public void CanCreateAFkSelectProcedure()
      {
         Table table = GetTable();
         var foreignKeyProcedure = new ForeignKeyProcedure();
			List<Procedure> procedures = foreignKeyProcedure.GenerateProcedures(table, new ProcedureConfiguration()).ToList();
         Assert.That(procedures.Count , Is.EqualTo(4));

      }

      [Test]
      public void CanCreateUpdateProcedure()
      {
         Table table = GetTable();
         var procedure = new UpdateProcedure();
			Procedure generate = procedure.Generate(table, new ProcedureConfiguration());
      }

      [Test]
      public void CanCreateAInsertProcedure()
      {
         Table table = GetTable();
         var procedure = new InsertProcedure();
			Procedure generate = procedure.Generate(table, new ProcedureConfiguration());
      }

      [Test]
      public void CanCreateASelectProcedure()
      {
         Table table = GetTable();
         var procedure = new SelectProcedure();
			Procedure generate = procedure.Generate(table, new ProcedureConfiguration());
      }
   }
}