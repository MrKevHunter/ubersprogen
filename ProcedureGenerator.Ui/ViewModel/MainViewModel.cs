using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.Extensions;
using ProcedureGenerator.Core.ProcedureGenerators;

namespace ProcedureGenerator.Ui.ViewModel
{
	public class MainViewModel
	{
		private readonly BackgroundWorker worker = new BackgroundWorker();

		private ObservableCollection<TableDto> _tables = new ObservableCollection<TableDto>();
		public ObservableCollection<TableDto> Tables
		{
			get { return _tables; }
			set { _tables = value; }
		}


		public ObservableCollection<TableDto> Tables1 { get; set;}

		public string ConnectionStringKey { get; set; }

		public string OutputPath { get; set; }

		public ObservableCollection<object> ConnectionStrings
		{
			get
			{
				var connectionStrings = new ObservableCollection<object>();
				foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
				{
					connectionStrings.Add(connectionString.Name);
				}
				return connectionStrings;
			}
		}

		public bool InProgress { get; set; }

		public int ProgressPercentage { get; set; }

		public bool Select { get; set; }
		public bool SelectById { get; set; }
		public bool SelectByFk { get; set; }
		public bool Insert { get; set; }
		public bool Update { get; set; }
		public bool Delete { get; set; }

		private string ConnectionString
		{
			get { return ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString; }
		}

		public void GetListOfTablesFromDatabase()
		{

			var schemaDataContext = new SchemaDataContext(ConnectionString);
			foreach (
				TABLE table in
					schemaDataContext.TABLEs.Where(table => table.TABLE_TYPE == "BASE TABLE").OrderBy(
						table1 => table1.TABLE_NAME))
			{
				_tables.Add(new TableDto
				           	{
				           		Selected = true,
				           		TableName = table.TABLE_NAME,
				           		HasPrimaryKey = false,
				           		HasForeignKey = true
				           	});
			}
			
		}



		private void BuildAndWrite(Table table, IGenerateMultipleProcedure generator)
		{
			foreach (Procedure procedure in generator.GenerateProcedures(table))
			{
				File.WriteAllText(Path.Combine(OutputPath, procedure.FileName), procedure.Body);
			}
		}

		private void BuildAndWrite(Table table, IGenerateProcedure generator)
		{
			Procedure procedure = generator.Generate(table);
			File.WriteAllText(Path.Combine(OutputPath, procedure.FileName), procedure.Body);
		}

		private void Generate(TableDto tablesPresentation)
		{
			Table table = new TableBuilder().BuildMeATableFromThis(new SchemaDataContext(ConnectionString),
			                                                       tablesPresentation.TableName);
			if (Delete)
				BuildAndWrite(table, new DeleteProcedure());

			if (Insert)
				BuildAndWrite(table, new InsertProcedure());

			if (Select)
				BuildAndWrite(table, new SelectAllProcedure());

			if (SelectById)
				BuildAndWrite(table, new SelectProcedure());

			if (SelectByFk)
				BuildAndWrite(table, (IGenerateMultipleProcedure) new ForeignKeyProcedure());

			if (Update)
				BuildAndWrite(table, new UpdateProcedure());
		}

		public void LoadTables(object sender, RoutedEventArgs e)
		{
			GetListOfTablesFromDatabase();
		}

		private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//btnGenerate.IsEnabled = true;
			InProgress = false;
			try
			{
				object result = e.Result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.GetInnermostException().ToString());
			}
		}

		public void GenerateStoredProcedures(object sender, RoutedEventArgs e)
		{
			//		btnGenerate.IsEnabled = false;
			//		progBar.Visibility = Visibility.Visible;
			worker.WorkerReportsProgress = true;

			InProgress = true;
			worker.ProgressChanged += (o, args) => { ProgressPercentage = args.ProgressPercentage; };
			worker.RunWorkerCompleted += WorkerCompleted;
			worker.DoWork += delegate(object s, DoWorkEventArgs args)
			                 	{
			                 		if (worker.CancellationPending)
			                 		{
			                 			args.Cancel = true;
			                 			return;
			                 		}
			                 		List<TableDto> tablesPresentations =
			                 			Tables.Where(presentation => presentation.Selected).ToList();
			                 		int total = tablesPresentations.Count;
			                 		int count = 0;
			                 		foreach (TableDto tablesPresentation in tablesPresentations)
			                 		{
			                 			Generate(tablesPresentation);
			                 			count++;
			                 			worker.ReportProgress(Convert.ToInt32(((decimal) count/total)*100));
			                 		}
			                 		worker.ReportProgress(100);
			                 	};

			worker.RunWorkerAsync();
		}
	}
}