using System;
using System.Data;

namespace ProcedureGenerator.Core.Domain
{
   public class Column : IEquatable<Column>
   {
      public string Name { get; set;}

      public SqlDbType ColumnType { get; set;}

      public bool IsIdentity { get; set;}

      private string _length;
      public string Length
      {
         get
         {
            if (string.IsNullOrEmpty(_length))
            {
               return "";
            }
            return "(" + _length + ")";
         }
         set { _length = value; }
      }

      public bool IsForeignKey { get; set; }

      public bool Equals(Column other)
      {
         if (ReferenceEquals(null, other)) return false;
         if (ReferenceEquals(this, other)) return true;
         return Equals(other.Name, Name);
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != typeof (Column)) return false;
         return Equals((Column) obj);
      }

      public override string ToString()
      {
         return Name;
      }

      public override int GetHashCode()
      {
         return Name.GetHashCode();
      }

      public static bool operator ==(Column left, Column right)
      {
         return Equals(left, right);
      }

      public static bool operator !=(Column left, Column right)
      {
         return !Equals(left, right);
      }
   }
}