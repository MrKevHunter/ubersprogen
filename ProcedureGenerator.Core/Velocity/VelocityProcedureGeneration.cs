using System;
using System.Collections.Generic;
using System.IO;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Core.Velocity
{
	public class VelocityProcedureGeneration : ITextGenerator
	{
		private readonly string _path;
		private readonly string _owner = "dbo";
		private readonly Table _table;
		private readonly ProcedureConfiguration _procConfig;
		private readonly string _procedureName;
		private VelocityContext _context;

		public VelocityProcedureGeneration(string path, string procedureName)
			: this(path, procedureName, null, new ProcedureConfiguration())
		{
		}

		public VelocityProcedureGeneration(string path, string procedureName, Table table, ProcedureConfiguration procConfig)
		{
			_path = path;
			_context = new VelocityContext();
			_table = table;
			_procConfig = procConfig;
			_procedureName = procedureName;
		}

		public string Execute()
		{
			var velocity = new VelocityEngine();

			var props = new ExtendedProperties();
			velocity.Init(props);

			_context.Put("procedureName", _procedureName);
			_context.Put("now", DateTime.Now.ToLongDateString());
			_context.Put("table", _table);
			_context.Put("procConfig", _procConfig);
			var writer = new StringWriter();
			velocity.GetTemplate(_path).Merge(_context, writer);
			return writer.GetStringBuilder().ToString();
		}

		public void AddKeys(KeyValuePair<string, object> kvp)
		{
			_context.Put(kvp.Key, kvp.Value);
		}
	}
}