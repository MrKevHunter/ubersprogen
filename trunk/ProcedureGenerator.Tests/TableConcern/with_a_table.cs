using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using ProcedureGenerator.Core;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Tests.TableConcern
{
   public abstract class with_a_table
   {
      protected static Table table;
      Establish context = () =>
                             {
                                table = null;
                             };
   }
}