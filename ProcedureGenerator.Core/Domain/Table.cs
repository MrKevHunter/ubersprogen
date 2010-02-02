using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProcedureGenerator.Core.Domain
{
	public class Table : IEquatable<Table>
	{
		public string Name { get; set; }

		public Column PrimaryKey { get; set; }

		public string Schema { get; set; }

		public IEnumerable<Column> Columns { get; set; }

		public int NumberOfColumns
		{
			get { return Columns.Count(); }
		}

		public int NumberOfNonIdentityColumns
		{
			get
			{
				return NonIdentityColumns.Count();
			}
		}

		public IEnumerable<Column> NonIdentityColumns
		{
			get
			{
				return from column in Columns
				       where column.IsIdentity == false
				       select column;
			}
		}

		public IEnumerable<Column> ForeignKeys
		{
			get
			{
				return from column in Columns
				       where column.IsForeignKey
				       select column;
			}
		}

		#region IEquatable<Table> Members

		public bool Equals(Table other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Name, Name);
		}

		#endregion

		public IEnumerable<Column> GetColumnsOfType(SqlDbType columnType)
		{
			return from column in Columns
			       where column.ColumnType == columnType
			       select column;
		}


		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Table)) return false;
			return Equals((Table) obj);
		}

		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}

		public static bool operator ==(Table left, Table right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Table left, Table right)
		{
			return !Equals(left, right);
		}
	}
}