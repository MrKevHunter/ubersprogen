using System;
using System.Data;
using ProcedureGenerator.Core;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Tests.ColumnConcern
{
   internal static class ColumnMother
   {
      public static Column GetColumn()
      {
         return new Column(){ColumnType = SqlDbType.Int,Name = "CustomerId"};
      }
   }
}