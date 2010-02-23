﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcedureGenerator.Core.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="AdventureWorks")]
	public partial class SchemaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public SchemaDataContext() : 
				base(global::ProcedureGenerator.Core.Properties.Settings.Default.AdventureWorksConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SchemaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SchemaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SchemaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SchemaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<COLUMN> COLUMNs
		{
			get
			{
				return this.GetTable<COLUMN>();
			}
		}
		
		public System.Data.Linq.Table<CONSTRAINT_COLUMN_USAGE> CONSTRAINT_COLUMN_USAGEs
		{
			get
			{
				return this.GetTable<CONSTRAINT_COLUMN_USAGE>();
			}
		}
		
		public System.Data.Linq.Table<REFERENTIAL_CONSTRAINT> REFERENTIAL_CONSTRAINTs
		{
			get
			{
				return this.GetTable<REFERENTIAL_CONSTRAINT>();
			}
		}
		
		public System.Data.Linq.Table<VIEW> VIEWs
		{
			get
			{
				return this.GetTable<VIEW>();
			}
		}
		
		public System.Data.Linq.Table<TABLE> TABLEs
		{
			get
			{
				return this.GetTable<TABLE>();
			}
		}
		
		public System.Data.Linq.Table<TABLE_CONSTRAINT> TABLE_CONSTRAINTs
		{
			get
			{
				return this.GetTable<TABLE_CONSTRAINT>();
			}
		}
		
		public System.Data.Linq.Table<systable> systables
		{
			get
			{
				return this.GetTable<systable>();
			}
		}
		
		public System.Data.Linq.Table<all_column> all_columns
		{
			get
			{
				return this.GetTable<all_column>();
			}
		}
	}
	
	[Table(Name="INFORMATION_SCHEMA.COLUMNS")]
	public partial class COLUMN
	{
		
		private string _TABLE_CATALOG;
		
		private string _TABLE_SCHEMA;
		
		private string _TABLE_NAME;
		
		private string _COLUMN_NAME;
		
		private System.Nullable<int> _ORDINAL_POSITION;
		
		private string _COLUMN_DEFAULT;
		
		private string _IS_NULLABLE;
		
		private string _DATA_TYPE;
		
		private System.Nullable<int> _CHARACTER_MAXIMUM_LENGTH;
		
		private System.Nullable<int> _CHARACTER_OCTET_LENGTH;
		
		private System.Nullable<byte> _NUMERIC_PRECISION;
		
		private System.Nullable<short> _NUMERIC_PRECISION_RADIX;
		
		private System.Nullable<int> _NUMERIC_SCALE;
		
		private System.Nullable<short> _DATETIME_PRECISION;
		
		private string _CHARACTER_SET_CATALOG;
		
		private string _CHARACTER_SET_SCHEMA;
		
		private string _CHARACTER_SET_NAME;
		
		private string _COLLATION_CATALOG;
		
		private string _COLLATION_SCHEMA;
		
		private string _COLLATION_NAME;
		
		private string _DOMAIN_CATALOG;
		
		private string _DOMAIN_SCHEMA;
		
		private string _DOMAIN_NAME;
		
		public COLUMN()
		{
		}
		
		[Column(Storage="_TABLE_CATALOG", DbType="NVarChar(128)")]
		public string TABLE_CATALOG
		{
			get
			{
				return this._TABLE_CATALOG;
			}
			set
			{
				if ((this._TABLE_CATALOG != value))
				{
					this._TABLE_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_SCHEMA", DbType="NVarChar(128)")]
		public string TABLE_SCHEMA
		{
			get
			{
				return this._TABLE_SCHEMA;
			}
			set
			{
				if ((this._TABLE_SCHEMA != value))
				{
					this._TABLE_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string TABLE_NAME
		{
			get
			{
				return this._TABLE_NAME;
			}
			set
			{
				if ((this._TABLE_NAME != value))
				{
					this._TABLE_NAME = value;
				}
			}
		}
		
		[Column(Storage="_COLUMN_NAME", DbType="NVarChar(128)")]
		public string COLUMN_NAME
		{
			get
			{
				return this._COLUMN_NAME;
			}
			set
			{
				if ((this._COLUMN_NAME != value))
				{
					this._COLUMN_NAME = value;
				}
			}
		}
		
		[Column(Storage="_ORDINAL_POSITION", DbType="Int")]
		public System.Nullable<int> ORDINAL_POSITION
		{
			get
			{
				return this._ORDINAL_POSITION;
			}
			set
			{
				if ((this._ORDINAL_POSITION != value))
				{
					this._ORDINAL_POSITION = value;
				}
			}
		}
		
		[Column(Storage="_COLUMN_DEFAULT", DbType="NVarChar(4000)")]
		public string COLUMN_DEFAULT
		{
			get
			{
				return this._COLUMN_DEFAULT;
			}
			set
			{
				if ((this._COLUMN_DEFAULT != value))
				{
					this._COLUMN_DEFAULT = value;
				}
			}
		}
		
		[Column(Storage="_IS_NULLABLE", DbType="VarChar(3)")]
		public string IS_NULLABLE
		{
			get
			{
				return this._IS_NULLABLE;
			}
			set
			{
				if ((this._IS_NULLABLE != value))
				{
					this._IS_NULLABLE = value;
				}
			}
		}
		
		[Column(Storage="_DATA_TYPE", DbType="NVarChar(128)")]
		public string DATA_TYPE
		{
			get
			{
				return this._DATA_TYPE;
			}
			set
			{
				if ((this._DATA_TYPE != value))
				{
					this._DATA_TYPE = value;
				}
			}
		}
		
		[Column(Storage="_CHARACTER_MAXIMUM_LENGTH", DbType="Int")]
		public System.Nullable<int> CHARACTER_MAXIMUM_LENGTH
		{
			get
			{
				return this._CHARACTER_MAXIMUM_LENGTH;
			}
			set
			{
				if ((this._CHARACTER_MAXIMUM_LENGTH != value))
				{
					this._CHARACTER_MAXIMUM_LENGTH = value;
				}
			}
		}
		
		[Column(Storage="_CHARACTER_OCTET_LENGTH", DbType="Int")]
		public System.Nullable<int> CHARACTER_OCTET_LENGTH
		{
			get
			{
				return this._CHARACTER_OCTET_LENGTH;
			}
			set
			{
				if ((this._CHARACTER_OCTET_LENGTH != value))
				{
					this._CHARACTER_OCTET_LENGTH = value;
				}
			}
		}
		
		[Column(Storage="_NUMERIC_PRECISION", DbType="TinyInt")]
		public System.Nullable<byte> NUMERIC_PRECISION
		{
			get
			{
				return this._NUMERIC_PRECISION;
			}
			set
			{
				if ((this._NUMERIC_PRECISION != value))
				{
					this._NUMERIC_PRECISION = value;
				}
			}
		}
		
		[Column(Storage="_NUMERIC_PRECISION_RADIX", DbType="SmallInt")]
		public System.Nullable<short> NUMERIC_PRECISION_RADIX
		{
			get
			{
				return this._NUMERIC_PRECISION_RADIX;
			}
			set
			{
				if ((this._NUMERIC_PRECISION_RADIX != value))
				{
					this._NUMERIC_PRECISION_RADIX = value;
				}
			}
		}
		
		[Column(Storage="_NUMERIC_SCALE", DbType="Int")]
		public System.Nullable<int> NUMERIC_SCALE
		{
			get
			{
				return this._NUMERIC_SCALE;
			}
			set
			{
				if ((this._NUMERIC_SCALE != value))
				{
					this._NUMERIC_SCALE = value;
				}
			}
		}
		
		[Column(Storage="_DATETIME_PRECISION", DbType="SmallInt")]
		public System.Nullable<short> DATETIME_PRECISION
		{
			get
			{
				return this._DATETIME_PRECISION;
			}
			set
			{
				if ((this._DATETIME_PRECISION != value))
				{
					this._DATETIME_PRECISION = value;
				}
			}
		}
		
		[Column(Storage="_CHARACTER_SET_CATALOG", DbType="NVarChar(128)")]
		public string CHARACTER_SET_CATALOG
		{
			get
			{
				return this._CHARACTER_SET_CATALOG;
			}
			set
			{
				if ((this._CHARACTER_SET_CATALOG != value))
				{
					this._CHARACTER_SET_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_CHARACTER_SET_SCHEMA", DbType="NVarChar(128)")]
		public string CHARACTER_SET_SCHEMA
		{
			get
			{
				return this._CHARACTER_SET_SCHEMA;
			}
			set
			{
				if ((this._CHARACTER_SET_SCHEMA != value))
				{
					this._CHARACTER_SET_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_CHARACTER_SET_NAME", DbType="NVarChar(128)")]
		public string CHARACTER_SET_NAME
		{
			get
			{
				return this._CHARACTER_SET_NAME;
			}
			set
			{
				if ((this._CHARACTER_SET_NAME != value))
				{
					this._CHARACTER_SET_NAME = value;
				}
			}
		}
		
		[Column(Storage="_COLLATION_CATALOG", DbType="NVarChar(128)")]
		public string COLLATION_CATALOG
		{
			get
			{
				return this._COLLATION_CATALOG;
			}
			set
			{
				if ((this._COLLATION_CATALOG != value))
				{
					this._COLLATION_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_COLLATION_SCHEMA", DbType="NVarChar(128)")]
		public string COLLATION_SCHEMA
		{
			get
			{
				return this._COLLATION_SCHEMA;
			}
			set
			{
				if ((this._COLLATION_SCHEMA != value))
				{
					this._COLLATION_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_COLLATION_NAME", DbType="NVarChar(128)")]
		public string COLLATION_NAME
		{
			get
			{
				return this._COLLATION_NAME;
			}
			set
			{
				if ((this._COLLATION_NAME != value))
				{
					this._COLLATION_NAME = value;
				}
			}
		}
		
		[Column(Storage="_DOMAIN_CATALOG", DbType="NVarChar(128)")]
		public string DOMAIN_CATALOG
		{
			get
			{
				return this._DOMAIN_CATALOG;
			}
			set
			{
				if ((this._DOMAIN_CATALOG != value))
				{
					this._DOMAIN_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_DOMAIN_SCHEMA", DbType="NVarChar(128)")]
		public string DOMAIN_SCHEMA
		{
			get
			{
				return this._DOMAIN_SCHEMA;
			}
			set
			{
				if ((this._DOMAIN_SCHEMA != value))
				{
					this._DOMAIN_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_DOMAIN_NAME", DbType="NVarChar(128)")]
		public string DOMAIN_NAME
		{
			get
			{
				return this._DOMAIN_NAME;
			}
			set
			{
				if ((this._DOMAIN_NAME != value))
				{
					this._DOMAIN_NAME = value;
				}
			}
		}
	}
	
	[Table(Name="INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE")]
	public partial class CONSTRAINT_COLUMN_USAGE
	{
		
		private string _TABLE_CATALOG;
		
		private string _TABLE_SCHEMA;
		
		private string _TABLE_NAME;
		
		private string _COLUMN_NAME;
		
		private string _CONSTRAINT_CATALOG;
		
		private string _CONSTRAINT_SCHEMA;
		
		private string _CONSTRAINT_NAME;
		
		public CONSTRAINT_COLUMN_USAGE()
		{
		}
		
		[Column(Storage="_TABLE_CATALOG", DbType="NVarChar(128)")]
		public string TABLE_CATALOG
		{
			get
			{
				return this._TABLE_CATALOG;
			}
			set
			{
				if ((this._TABLE_CATALOG != value))
				{
					this._TABLE_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_SCHEMA", DbType="NVarChar(128)")]
		public string TABLE_SCHEMA
		{
			get
			{
				return this._TABLE_SCHEMA;
			}
			set
			{
				if ((this._TABLE_SCHEMA != value))
				{
					this._TABLE_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string TABLE_NAME
		{
			get
			{
				return this._TABLE_NAME;
			}
			set
			{
				if ((this._TABLE_NAME != value))
				{
					this._TABLE_NAME = value;
				}
			}
		}
		
		[Column(Storage="_COLUMN_NAME", DbType="NVarChar(128)")]
		public string COLUMN_NAME
		{
			get
			{
				return this._COLUMN_NAME;
			}
			set
			{
				if ((this._COLUMN_NAME != value))
				{
					this._COLUMN_NAME = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_CATALOG", DbType="NVarChar(128)")]
		public string CONSTRAINT_CATALOG
		{
			get
			{
				return this._CONSTRAINT_CATALOG;
			}
			set
			{
				if ((this._CONSTRAINT_CATALOG != value))
				{
					this._CONSTRAINT_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_SCHEMA", DbType="NVarChar(128)")]
		public string CONSTRAINT_SCHEMA
		{
			get
			{
				return this._CONSTRAINT_SCHEMA;
			}
			set
			{
				if ((this._CONSTRAINT_SCHEMA != value))
				{
					this._CONSTRAINT_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string CONSTRAINT_NAME
		{
			get
			{
				return this._CONSTRAINT_NAME;
			}
			set
			{
				if ((this._CONSTRAINT_NAME != value))
				{
					this._CONSTRAINT_NAME = value;
				}
			}
		}
	}
	
	[Table(Name="INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS")]
	public partial class REFERENTIAL_CONSTRAINT
	{
		
		private string _CONSTRAINT_CATALOG;
		
		private string _CONSTRAINT_SCHEMA;
		
		private string _CONSTRAINT_NAME;
		
		private string _UNIQUE_CONSTRAINT_CATALOG;
		
		private string _UNIQUE_CONSTRAINT_SCHEMA;
		
		private string _UNIQUE_CONSTRAINT_NAME;
		
		private string _MATCH_OPTION;
		
		private string _UPDATE_RULE;
		
		private string _DELETE_RULE;
		
		public REFERENTIAL_CONSTRAINT()
		{
		}
		
		[Column(Storage="_CONSTRAINT_CATALOG", DbType="NVarChar(128)")]
		public string CONSTRAINT_CATALOG
		{
			get
			{
				return this._CONSTRAINT_CATALOG;
			}
			set
			{
				if ((this._CONSTRAINT_CATALOG != value))
				{
					this._CONSTRAINT_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_SCHEMA", DbType="NVarChar(128)")]
		public string CONSTRAINT_SCHEMA
		{
			get
			{
				return this._CONSTRAINT_SCHEMA;
			}
			set
			{
				if ((this._CONSTRAINT_SCHEMA != value))
				{
					this._CONSTRAINT_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string CONSTRAINT_NAME
		{
			get
			{
				return this._CONSTRAINT_NAME;
			}
			set
			{
				if ((this._CONSTRAINT_NAME != value))
				{
					this._CONSTRAINT_NAME = value;
				}
			}
		}
		
		[Column(Storage="_UNIQUE_CONSTRAINT_CATALOG", DbType="NVarChar(128)")]
		public string UNIQUE_CONSTRAINT_CATALOG
		{
			get
			{
				return this._UNIQUE_CONSTRAINT_CATALOG;
			}
			set
			{
				if ((this._UNIQUE_CONSTRAINT_CATALOG != value))
				{
					this._UNIQUE_CONSTRAINT_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_UNIQUE_CONSTRAINT_SCHEMA", DbType="NVarChar(128)")]
		public string UNIQUE_CONSTRAINT_SCHEMA
		{
			get
			{
				return this._UNIQUE_CONSTRAINT_SCHEMA;
			}
			set
			{
				if ((this._UNIQUE_CONSTRAINT_SCHEMA != value))
				{
					this._UNIQUE_CONSTRAINT_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_UNIQUE_CONSTRAINT_NAME", DbType="NVarChar(128)")]
		public string UNIQUE_CONSTRAINT_NAME
		{
			get
			{
				return this._UNIQUE_CONSTRAINT_NAME;
			}
			set
			{
				if ((this._UNIQUE_CONSTRAINT_NAME != value))
				{
					this._UNIQUE_CONSTRAINT_NAME = value;
				}
			}
		}
		
		[Column(Storage="_MATCH_OPTION", DbType="VarChar(7)")]
		public string MATCH_OPTION
		{
			get
			{
				return this._MATCH_OPTION;
			}
			set
			{
				if ((this._MATCH_OPTION != value))
				{
					this._MATCH_OPTION = value;
				}
			}
		}
		
		[Column(Storage="_UPDATE_RULE", DbType="VarChar(11)")]
		public string UPDATE_RULE
		{
			get
			{
				return this._UPDATE_RULE;
			}
			set
			{
				if ((this._UPDATE_RULE != value))
				{
					this._UPDATE_RULE = value;
				}
			}
		}
		
		[Column(Storage="_DELETE_RULE", DbType="VarChar(11)")]
		public string DELETE_RULE
		{
			get
			{
				return this._DELETE_RULE;
			}
			set
			{
				if ((this._DELETE_RULE != value))
				{
					this._DELETE_RULE = value;
				}
			}
		}
	}
	
	[Table(Name="INFORMATION_SCHEMA.VIEWS")]
	public partial class VIEW
	{
		
		private string _TABLE_CATALOG;
		
		private string _TABLE_SCHEMA;
		
		private string _TABLE_NAME;
		
		private string _VIEW_DEFINITION;
		
		private string _CHECK_OPTION;
		
		private string _IS_UPDATABLE;
		
		public VIEW()
		{
		}
		
		[Column(Storage="_TABLE_CATALOG", DbType="NVarChar(128)")]
		public string TABLE_CATALOG
		{
			get
			{
				return this._TABLE_CATALOG;
			}
			set
			{
				if ((this._TABLE_CATALOG != value))
				{
					this._TABLE_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_SCHEMA", DbType="NVarChar(128)")]
		public string TABLE_SCHEMA
		{
			get
			{
				return this._TABLE_SCHEMA;
			}
			set
			{
				if ((this._TABLE_SCHEMA != value))
				{
					this._TABLE_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string TABLE_NAME
		{
			get
			{
				return this._TABLE_NAME;
			}
			set
			{
				if ((this._TABLE_NAME != value))
				{
					this._TABLE_NAME = value;
				}
			}
		}
		
		[Column(Storage="_VIEW_DEFINITION", DbType="NVarChar(4000)")]
		public string VIEW_DEFINITION
		{
			get
			{
				return this._VIEW_DEFINITION;
			}
			set
			{
				if ((this._VIEW_DEFINITION != value))
				{
					this._VIEW_DEFINITION = value;
				}
			}
		}
		
		[Column(Storage="_CHECK_OPTION", DbType="VarChar(7)")]
		public string CHECK_OPTION
		{
			get
			{
				return this._CHECK_OPTION;
			}
			set
			{
				if ((this._CHECK_OPTION != value))
				{
					this._CHECK_OPTION = value;
				}
			}
		}
		
		[Column(Storage="_IS_UPDATABLE", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string IS_UPDATABLE
		{
			get
			{
				return this._IS_UPDATABLE;
			}
			set
			{
				if ((this._IS_UPDATABLE != value))
				{
					this._IS_UPDATABLE = value;
				}
			}
		}
	}
	
	[Table(Name="INFORMATION_SCHEMA.TABLES")]
	public partial class TABLE
	{
		
		private string _TABLE_CATALOG;
		
		private string _TABLE_SCHEMA;
		
		private string _TABLE_NAME;
		
		private string _TABLE_TYPE;
		
		public TABLE()
		{
		}
		
		[Column(Storage="_TABLE_CATALOG", DbType="NVarChar(128)")]
		public string TABLE_CATALOG
		{
			get
			{
				return this._TABLE_CATALOG;
			}
			set
			{
				if ((this._TABLE_CATALOG != value))
				{
					this._TABLE_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_SCHEMA", DbType="NVarChar(128)")]
		public string TABLE_SCHEMA
		{
			get
			{
				return this._TABLE_SCHEMA;
			}
			set
			{
				if ((this._TABLE_SCHEMA != value))
				{
					this._TABLE_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string TABLE_NAME
		{
			get
			{
				return this._TABLE_NAME;
			}
			set
			{
				if ((this._TABLE_NAME != value))
				{
					this._TABLE_NAME = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_TYPE", DbType="VarChar(10)")]
		public string TABLE_TYPE
		{
			get
			{
				return this._TABLE_TYPE;
			}
			set
			{
				if ((this._TABLE_TYPE != value))
				{
					this._TABLE_TYPE = value;
				}
			}
		}
	}
	
	[Table(Name="INFORMATION_SCHEMA.TABLE_CONSTRAINTS")]
	public partial class TABLE_CONSTRAINT
	{
		
		private string _CONSTRAINT_CATALOG;
		
		private string _CONSTRAINT_SCHEMA;
		
		private string _CONSTRAINT_NAME;
		
		private string _TABLE_CATALOG;
		
		private string _TABLE_SCHEMA;
		
		private string _TABLE_NAME;
		
		private string _CONSTRAINT_TYPE;
		
		private string _IS_DEFERRABLE;
		
		private string _INITIALLY_DEFERRED;
		
		public TABLE_CONSTRAINT()
		{
		}
		
		[Column(Storage="_CONSTRAINT_CATALOG", DbType="NVarChar(128)")]
		public string CONSTRAINT_CATALOG
		{
			get
			{
				return this._CONSTRAINT_CATALOG;
			}
			set
			{
				if ((this._CONSTRAINT_CATALOG != value))
				{
					this._CONSTRAINT_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_SCHEMA", DbType="NVarChar(128)")]
		public string CONSTRAINT_SCHEMA
		{
			get
			{
				return this._CONSTRAINT_SCHEMA;
			}
			set
			{
				if ((this._CONSTRAINT_SCHEMA != value))
				{
					this._CONSTRAINT_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string CONSTRAINT_NAME
		{
			get
			{
				return this._CONSTRAINT_NAME;
			}
			set
			{
				if ((this._CONSTRAINT_NAME != value))
				{
					this._CONSTRAINT_NAME = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_CATALOG", DbType="NVarChar(128)")]
		public string TABLE_CATALOG
		{
			get
			{
				return this._TABLE_CATALOG;
			}
			set
			{
				if ((this._TABLE_CATALOG != value))
				{
					this._TABLE_CATALOG = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_SCHEMA", DbType="NVarChar(128)")]
		public string TABLE_SCHEMA
		{
			get
			{
				return this._TABLE_SCHEMA;
			}
			set
			{
				if ((this._TABLE_SCHEMA != value))
				{
					this._TABLE_SCHEMA = value;
				}
			}
		}
		
		[Column(Storage="_TABLE_NAME", DbType="NVarChar(128)")]
		public string TABLE_NAME
		{
			get
			{
				return this._TABLE_NAME;
			}
			set
			{
				if ((this._TABLE_NAME != value))
				{
					this._TABLE_NAME = value;
				}
			}
		}
		
		[Column(Storage="_CONSTRAINT_TYPE", DbType="VarChar(11)")]
		public string CONSTRAINT_TYPE
		{
			get
			{
				return this._CONSTRAINT_TYPE;
			}
			set
			{
				if ((this._CONSTRAINT_TYPE != value))
				{
					this._CONSTRAINT_TYPE = value;
				}
			}
		}
		
		[Column(Storage="_IS_DEFERRABLE", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string IS_DEFERRABLE
		{
			get
			{
				return this._IS_DEFERRABLE;
			}
			set
			{
				if ((this._IS_DEFERRABLE != value))
				{
					this._IS_DEFERRABLE = value;
				}
			}
		}
		
		[Column(Storage="_INITIALLY_DEFERRED", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
		public string INITIALLY_DEFERRED
		{
			get
			{
				return this._INITIALLY_DEFERRED;
			}
			set
			{
				if ((this._INITIALLY_DEFERRED != value))
				{
					this._INITIALLY_DEFERRED = value;
				}
			}
		}
	}
	
	[Table(Name="sys.tables")]
	public partial class systable
	{
		
		private string _name;
		
		private int _object_id;
		
		private System.Nullable<int> _principal_id;
		
		private int _schema_id;
		
		private int _parent_object_id;
		
		private string _type;
		
		private string _type_desc;
		
		private System.DateTime _create_date;
		
		private System.DateTime _modify_date;
		
		private bool _is_ms_shipped;
		
		private bool _is_published;
		
		private bool _is_schema_published;
		
		private System.Nullable<int> _lob_data_space_id;
		
		private System.Nullable<int> _filestream_data_space_id;
		
		private int _max_column_id_used;
		
		private bool _lock_on_bulk_load;
		
		private System.Nullable<bool> _uses_ansi_nulls;
		
		private System.Nullable<bool> _is_replicated;
		
		private System.Nullable<bool> _has_replication_filter;
		
		private System.Nullable<bool> _is_merge_published;
		
		private System.Nullable<bool> _is_sync_tran_subscribed;
		
		private bool _has_unchecked_assembly_data;
		
		private System.Nullable<int> _text_in_row_limit;
		
		private System.Nullable<bool> _large_value_types_out_of_row;
		
		public systable()
		{
		}
		
		[Column(Storage="_name", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[Column(Storage="_object_id", DbType="Int NOT NULL")]
		public int object_id
		{
			get
			{
				return this._object_id;
			}
			set
			{
				if ((this._object_id != value))
				{
					this._object_id = value;
				}
			}
		}
		
		[Column(Storage="_principal_id", DbType="Int")]
		public System.Nullable<int> principal_id
		{
			get
			{
				return this._principal_id;
			}
			set
			{
				if ((this._principal_id != value))
				{
					this._principal_id = value;
				}
			}
		}
		
		[Column(Storage="_schema_id", DbType="Int NOT NULL")]
		public int schema_id
		{
			get
			{
				return this._schema_id;
			}
			set
			{
				if ((this._schema_id != value))
				{
					this._schema_id = value;
				}
			}
		}
		
		[Column(Storage="_parent_object_id", DbType="Int NOT NULL")]
		public int parent_object_id
		{
			get
			{
				return this._parent_object_id;
			}
			set
			{
				if ((this._parent_object_id != value))
				{
					this._parent_object_id = value;
				}
			}
		}
		
		[Column(Storage="_type", DbType="Char(2) NOT NULL", CanBeNull=false)]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this._type = value;
				}
			}
		}
		
		[Column(Storage="_type_desc", DbType="NVarChar(60)")]
		public string type_desc
		{
			get
			{
				return this._type_desc;
			}
			set
			{
				if ((this._type_desc != value))
				{
					this._type_desc = value;
				}
			}
		}
		
		[Column(Storage="_create_date", DbType="DateTime NOT NULL")]
		public System.DateTime create_date
		{
			get
			{
				return this._create_date;
			}
			set
			{
				if ((this._create_date != value))
				{
					this._create_date = value;
				}
			}
		}
		
		[Column(Storage="_modify_date", DbType="DateTime NOT NULL")]
		public System.DateTime modify_date
		{
			get
			{
				return this._modify_date;
			}
			set
			{
				if ((this._modify_date != value))
				{
					this._modify_date = value;
				}
			}
		}
		
		[Column(Storage="_is_ms_shipped", DbType="Bit NOT NULL")]
		public bool is_ms_shipped
		{
			get
			{
				return this._is_ms_shipped;
			}
			set
			{
				if ((this._is_ms_shipped != value))
				{
					this._is_ms_shipped = value;
				}
			}
		}
		
		[Column(Storage="_is_published", DbType="Bit NOT NULL")]
		public bool is_published
		{
			get
			{
				return this._is_published;
			}
			set
			{
				if ((this._is_published != value))
				{
					this._is_published = value;
				}
			}
		}
		
		[Column(Storage="_is_schema_published", DbType="Bit NOT NULL")]
		public bool is_schema_published
		{
			get
			{
				return this._is_schema_published;
			}
			set
			{
				if ((this._is_schema_published != value))
				{
					this._is_schema_published = value;
				}
			}
		}
		
		[Column(Storage="_lob_data_space_id", DbType="Int")]
		public System.Nullable<int> lob_data_space_id
		{
			get
			{
				return this._lob_data_space_id;
			}
			set
			{
				if ((this._lob_data_space_id != value))
				{
					this._lob_data_space_id = value;
				}
			}
		}
		
		[Column(Storage="_filestream_data_space_id", DbType="Int")]
		public System.Nullable<int> filestream_data_space_id
		{
			get
			{
				return this._filestream_data_space_id;
			}
			set
			{
				if ((this._filestream_data_space_id != value))
				{
					this._filestream_data_space_id = value;
				}
			}
		}
		
		[Column(Storage="_max_column_id_used", DbType="Int NOT NULL")]
		public int max_column_id_used
		{
			get
			{
				return this._max_column_id_used;
			}
			set
			{
				if ((this._max_column_id_used != value))
				{
					this._max_column_id_used = value;
				}
			}
		}
		
		[Column(Storage="_lock_on_bulk_load", DbType="Bit NOT NULL")]
		public bool lock_on_bulk_load
		{
			get
			{
				return this._lock_on_bulk_load;
			}
			set
			{
				if ((this._lock_on_bulk_load != value))
				{
					this._lock_on_bulk_load = value;
				}
			}
		}
		
		[Column(Storage="_uses_ansi_nulls", DbType="Bit")]
		public System.Nullable<bool> uses_ansi_nulls
		{
			get
			{
				return this._uses_ansi_nulls;
			}
			set
			{
				if ((this._uses_ansi_nulls != value))
				{
					this._uses_ansi_nulls = value;
				}
			}
		}
		
		[Column(Storage="_is_replicated", DbType="Bit")]
		public System.Nullable<bool> is_replicated
		{
			get
			{
				return this._is_replicated;
			}
			set
			{
				if ((this._is_replicated != value))
				{
					this._is_replicated = value;
				}
			}
		}
		
		[Column(Storage="_has_replication_filter", DbType="Bit")]
		public System.Nullable<bool> has_replication_filter
		{
			get
			{
				return this._has_replication_filter;
			}
			set
			{
				if ((this._has_replication_filter != value))
				{
					this._has_replication_filter = value;
				}
			}
		}
		
		[Column(Storage="_is_merge_published", DbType="Bit")]
		public System.Nullable<bool> is_merge_published
		{
			get
			{
				return this._is_merge_published;
			}
			set
			{
				if ((this._is_merge_published != value))
				{
					this._is_merge_published = value;
				}
			}
		}
		
		[Column(Storage="_is_sync_tran_subscribed", DbType="Bit")]
		public System.Nullable<bool> is_sync_tran_subscribed
		{
			get
			{
				return this._is_sync_tran_subscribed;
			}
			set
			{
				if ((this._is_sync_tran_subscribed != value))
				{
					this._is_sync_tran_subscribed = value;
				}
			}
		}
		
		[Column(Storage="_has_unchecked_assembly_data", DbType="Bit NOT NULL")]
		public bool has_unchecked_assembly_data
		{
			get
			{
				return this._has_unchecked_assembly_data;
			}
			set
			{
				if ((this._has_unchecked_assembly_data != value))
				{
					this._has_unchecked_assembly_data = value;
				}
			}
		}
		
		[Column(Storage="_text_in_row_limit", DbType="Int")]
		public System.Nullable<int> text_in_row_limit
		{
			get
			{
				return this._text_in_row_limit;
			}
			set
			{
				if ((this._text_in_row_limit != value))
				{
					this._text_in_row_limit = value;
				}
			}
		}
		
		[Column(Storage="_large_value_types_out_of_row", DbType="Bit")]
		public System.Nullable<bool> large_value_types_out_of_row
		{
			get
			{
				return this._large_value_types_out_of_row;
			}
			set
			{
				if ((this._large_value_types_out_of_row != value))
				{
					this._large_value_types_out_of_row = value;
				}
			}
		}
	}
	
	[Table(Name="sys.all_columns")]
	public partial class all_column
	{
		
		private int _object_id;
		
		private string _name;
		
		private int _column_id;
		
		private byte _system_type_id;
		
		private int _user_type_id;
		
		private short _max_length;
		
		private byte _precision;
		
		private byte _scale;
		
		private string _collation_name;
		
		private System.Nullable<bool> _is_nullable;
		
		private bool _is_ansi_padded;
		
		private bool _is_rowguidcol;
		
		private bool _is_identity;
		
		private bool _is_computed;
		
		private bool _is_filestream;
		
		private System.Nullable<bool> _is_replicated;
		
		private System.Nullable<bool> _is_non_sql_subscribed;
		
		private System.Nullable<bool> _is_merge_published;
		
		private System.Nullable<bool> _is_dts_replicated;
		
		private bool _is_xml_document;
		
		private int _xml_collection_id;
		
		private int _default_object_id;
		
		private int _rule_object_id;
		
		public all_column()
		{
		}
		
		[Column(Storage="_object_id", DbType="Int NOT NULL")]
		public int object_id
		{
			get
			{
				return this._object_id;
			}
			set
			{
				if ((this._object_id != value))
				{
					this._object_id = value;
				}
			}
		}
		
		[Column(Storage="_name", DbType="NVarChar(128)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[Column(Storage="_column_id", DbType="Int NOT NULL")]
		public int column_id
		{
			get
			{
				return this._column_id;
			}
			set
			{
				if ((this._column_id != value))
				{
					this._column_id = value;
				}
			}
		}
		
		[Column(Storage="_system_type_id", DbType="TinyInt NOT NULL")]
		public byte system_type_id
		{
			get
			{
				return this._system_type_id;
			}
			set
			{
				if ((this._system_type_id != value))
				{
					this._system_type_id = value;
				}
			}
		}
		
		[Column(Storage="_user_type_id", DbType="Int NOT NULL")]
		public int user_type_id
		{
			get
			{
				return this._user_type_id;
			}
			set
			{
				if ((this._user_type_id != value))
				{
					this._user_type_id = value;
				}
			}
		}
		
		[Column(Storage="_max_length", DbType="SmallInt NOT NULL")]
		public short max_length
		{
			get
			{
				return this._max_length;
			}
			set
			{
				if ((this._max_length != value))
				{
					this._max_length = value;
				}
			}
		}
		
		[Column(Storage="_precision", DbType="TinyInt NOT NULL")]
		public byte precision
		{
			get
			{
				return this._precision;
			}
			set
			{
				if ((this._precision != value))
				{
					this._precision = value;
				}
			}
		}
		
		[Column(Storage="_scale", DbType="TinyInt NOT NULL")]
		public byte scale
		{
			get
			{
				return this._scale;
			}
			set
			{
				if ((this._scale != value))
				{
					this._scale = value;
				}
			}
		}
		
		[Column(Storage="_collation_name", DbType="NVarChar(128)")]
		public string collation_name
		{
			get
			{
				return this._collation_name;
			}
			set
			{
				if ((this._collation_name != value))
				{
					this._collation_name = value;
				}
			}
		}
		
		[Column(Storage="_is_nullable", DbType="Bit")]
		public System.Nullable<bool> is_nullable
		{
			get
			{
				return this._is_nullable;
			}
			set
			{
				if ((this._is_nullable != value))
				{
					this._is_nullable = value;
				}
			}
		}
		
		[Column(Storage="_is_ansi_padded", DbType="Bit NOT NULL")]
		public bool is_ansi_padded
		{
			get
			{
				return this._is_ansi_padded;
			}
			set
			{
				if ((this._is_ansi_padded != value))
				{
					this._is_ansi_padded = value;
				}
			}
		}
		
		[Column(Storage="_is_rowguidcol", DbType="Bit NOT NULL")]
		public bool is_rowguidcol
		{
			get
			{
				return this._is_rowguidcol;
			}
			set
			{
				if ((this._is_rowguidcol != value))
				{
					this._is_rowguidcol = value;
				}
			}
		}
		
		[Column(Storage="_is_identity", DbType="Bit NOT NULL")]
		public bool is_identity
		{
			get
			{
				return this._is_identity;
			}
			set
			{
				if ((this._is_identity != value))
				{
					this._is_identity = value;
				}
			}
		}
		
		[Column(Storage="_is_computed", DbType="Bit NOT NULL")]
		public bool is_computed
		{
			get
			{
				return this._is_computed;
			}
			set
			{
				if ((this._is_computed != value))
				{
					this._is_computed = value;
				}
			}
		}
		
		[Column(Storage="_is_filestream", DbType="Bit NOT NULL")]
		public bool is_filestream
		{
			get
			{
				return this._is_filestream;
			}
			set
			{
				if ((this._is_filestream != value))
				{
					this._is_filestream = value;
				}
			}
		}
		
		[Column(Storage="_is_replicated", DbType="Bit")]
		public System.Nullable<bool> is_replicated
		{
			get
			{
				return this._is_replicated;
			}
			set
			{
				if ((this._is_replicated != value))
				{
					this._is_replicated = value;
				}
			}
		}
		
		[Column(Storage="_is_non_sql_subscribed", DbType="Bit")]
		public System.Nullable<bool> is_non_sql_subscribed
		{
			get
			{
				return this._is_non_sql_subscribed;
			}
			set
			{
				if ((this._is_non_sql_subscribed != value))
				{
					this._is_non_sql_subscribed = value;
				}
			}
		}
		
		[Column(Storage="_is_merge_published", DbType="Bit")]
		public System.Nullable<bool> is_merge_published
		{
			get
			{
				return this._is_merge_published;
			}
			set
			{
				if ((this._is_merge_published != value))
				{
					this._is_merge_published = value;
				}
			}
		}
		
		[Column(Storage="_is_dts_replicated", DbType="Bit")]
		public System.Nullable<bool> is_dts_replicated
		{
			get
			{
				return this._is_dts_replicated;
			}
			set
			{
				if ((this._is_dts_replicated != value))
				{
					this._is_dts_replicated = value;
				}
			}
		}
		
		[Column(Storage="_is_xml_document", DbType="Bit NOT NULL")]
		public bool is_xml_document
		{
			get
			{
				return this._is_xml_document;
			}
			set
			{
				if ((this._is_xml_document != value))
				{
					this._is_xml_document = value;
				}
			}
		}
		
		[Column(Storage="_xml_collection_id", DbType="Int NOT NULL")]
		public int xml_collection_id
		{
			get
			{
				return this._xml_collection_id;
			}
			set
			{
				if ((this._xml_collection_id != value))
				{
					this._xml_collection_id = value;
				}
			}
		}
		
		[Column(Storage="_default_object_id", DbType="Int NOT NULL")]
		public int default_object_id
		{
			get
			{
				return this._default_object_id;
			}
			set
			{
				if ((this._default_object_id != value))
				{
					this._default_object_id = value;
				}
			}
		}
		
		[Column(Storage="_rule_object_id", DbType="Int NOT NULL")]
		public int rule_object_id
		{
			get
			{
				return this._rule_object_id;
			}
			set
			{
				if ((this._rule_object_id != value))
				{
					this._rule_object_id = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
