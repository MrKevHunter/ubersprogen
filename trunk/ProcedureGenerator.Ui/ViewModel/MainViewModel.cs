using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Ui.Dto;
using ProcedureGenerator.Ui.Extensions;
using ProcedureGenerator.Ui.Services;

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

		public bool SetNoCountOn { get; set;}

		public string ConnectionStringKey { get; set; }

		public string OutputPath { get; set; }

		public string IsolationLevel { get; set;}

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

		internal string ConnectionString
		{
			get { return ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString; }
		}

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public void GetListOfTablesFromDatabase()
		{
			new DbTableService().GetTables(ConnectionString).Each(x => Tables.Add(x));
		}

		public void LoadTables(object sender, RoutedEventArgs e)
		{
			GetListOfTablesFromDatabase();
		}

		private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			InProgress = false;
		}

		public void GenerateStoredProcedures(object sender, RoutedEventArgs e)
		{
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
				new ProcedureGeneratorService().GenerateProcedures(this, tablesPresentation);
				count++;
				_worker.ReportProgress(Convert.ToInt32(((decimal) count/total)*100));
			}
			_worker.ReportProgress(100);
		}

		public void SelectAllTables(object sender, RoutedEventArgs e)
		{
			if (Tables != null)
			{
				Tables.Each(x => x.IsChecked = true);
			}
		}

		public void SelectNoTables(object sender, RoutedEventArgs e)
		{
			if (Tables != null)
			{
				Tables.Each(x => x.IsChecked = false);
			}
		}

		public ProcedureConfiguration GetProcedureConfig()
		{
			return new ProcedureConfiguration(){SetNoCountOn = SetNoCountOn,IsolationLevel = IsolationLevel};
		}
	}
}