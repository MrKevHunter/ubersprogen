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
using ProcedureGenerator.Ui.Dto;
using ProcedureGenerator.Ui.Extensions;

namespace ProcedureGenerator.Ui.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private readonly BackgroundWorker _worker = new BackgroundWorker();
		private bool _inProgress;
		private int _progressPercentage;

		private ObservableCollection<TableDto> _tables = new ObservableCollection<TableDto>();

		public ObservableCollection<TableDto> Tables
		{
			get { return _tables; }
			set { _tables = value; }
		}


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

		public bool InProgress
		{
			get { return _inProgress; }
			set
			{
				_inProgress = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("InProgress"));
			}
		}

		public int ProgressPercentage
		{
			get { return _progressPercentage; }
			set
			{
				_progressPercentage = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("ProgressPercentage"));
			}
		}

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

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

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
				            		IsChecked = false,
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
			_worker.WorkerReportsProgress = true;

			InProgress = true;
			_worker.ProgressChanged += (o, args) => { ProgressPercentage = args.ProgressPercentage; };
			_worker.RunWorkerCompleted += WorkerCompleted;
			_worker.DoWork += CreateProcedureWorker;

			_worker.RunWorkerAsync();
		}

		private void CreateProcedureWorker(object s, DoWorkEventArgs args)
		{
			if (_worker.CancellationPending)
			{
				args.Cancel = true;
				return;
			}
			List<TableDto> tablesPresentations = Tables.Where(presentation => presentation.IsChecked).ToList();
			int total = tablesPresentations.Count;
			int count = 0;
			foreach (TableDto tablesPresentation in tablesPresentations)
			{
				Generate(tablesPresentation);
				count++;
				_worker.ReportProgress(Convert.ToInt32(((decimal) count/total)*100));
			}
			_worker.ReportProgress(100);
		}

		public void SelectAllTables(object sender, RoutedEventArgs e)
		{
			if(Tables!=null)
			{
				Tables.Each(x => x.IsChecked = true);
			}

		}
	}
}