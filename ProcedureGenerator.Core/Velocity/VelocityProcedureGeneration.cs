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
      private readonly string _procedureName;
      private VelocityContext _context;

      public VelocityProcedureGeneration(string path, string procedureName) :this(path,procedureName,"",null)
      {
      }

      public VelocityProcedureGeneration(string path, string procedureName, string owner, Table table)
      {
         _path = path;
         _context = new VelocityContext();
         _owner = owner;
         _table = table;
         _procedureName = procedureName;
      }

      public string Execute()
      {
         var velocity = new VelocityEngine();

         var props = new ExtendedProperties();
         velocity.Init(props);

  
         _context.Put("procedureName", _procedureName);
         _context.Put("owner", _owner);
         _context.Put("now", DateTime.Now.ToLongDateString());
         _context.Put("table", _table);
			
         var writer = new StringWriter();
         velocity.GetTemplate(_path).Merge(_context, writer);
         return writer.GetStringBuilder().ToString();
      }

      public void AddKeys(KeyValuePair<string,object> kvp)
      {
         _context.Put(kvp.Key, kvp.Value);
      }
   }
}