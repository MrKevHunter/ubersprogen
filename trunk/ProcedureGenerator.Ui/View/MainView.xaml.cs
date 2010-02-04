﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.ProcedureGenerators;
using ProcedureGenerator.Core.Extensions;

namespace ProcedureGenerator.Ui.View
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : Window
	{
		private ObservableCollection<TableDto> AvailableTables = new ObservableCollection<TableDto>();
		private BackgroundWorker worker = new BackgroundWorker();
		private string OutputPath;
		public MainView()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadConnectionStrings();
		}

		private void LoadConnectionStrings()
		{
			connectionStrings.Items.Clear();
			foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
			{
				connectionStrings.Items.Add(connectionString.Name);
			}
		}

		private string connectionString;
		private void LoadTableList()
		{
			lbTables.ItemsSource = null;
			try
			{
				Cursor = Cursors.Wait;
				connectionString = ConfigurationManager.ConnectionStrings[connectionStrings.SelectedValue.ToString()].ConnectionString;
				var schemaDataContext = new SchemaDataContext(connectionString);
				foreach (
					TABLE table in
						schemaDataContext.TABLEs.Where(table => table.TABLE_TYPE == "BASE TABLE").OrderBy(
							table1 => table1.TABLE_NAME))
				{
					AvailableTables.Add(new TableDto() { Selected = true, TableName = table.TABLE_NAME,HasPrimaryKey = false, HasForeignKey = true});
				}
				lbTables.ItemsSource = AvailableTables;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Failed to load the list of table names");
			}
			finally
			{
				Cursor = Cursors.Arrow;
			}
		}

		private void btnSelectAll_Click(object sender, RoutedEventArgs e)
		{
			foreach (TableDto tablesPresentation in AvailableTables)
			{
				tablesPresentation.Selected = true;
			}
		}

		private void btnSelectNone_Click(object sender, RoutedEventArgs e)
		{
			foreach (object item in lbTables.ItemsSource)
			{
				((TableDto)item).Selected = false;
			}
		}

		private void textBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
		}

		private class Procedures
		{
			public bool Select;
			public bool SelectById;
			public bool SelectByFk;
			public bool Insert;
			public bool Update;
			public bool Delete;


		}

		private void btnGenerate_Click(object sender, RoutedEventArgs e)
		{
			btnGenerate.IsEnabled = false;
			progBar.Visibility = Visibility.Visible;
			worker.WorkerReportsProgress = true;
			OutputPath = textBox1.Text;
			Procedures p = new Procedures()
			               	{
			               		Delete = (bool)chkDelete.IsChecked,
			               		Insert = (bool)chkInsert.IsChecked,
			               		Select = (bool)chkSelect.IsChecked,
			               		SelectByFk = (bool)chkSelectByFk.IsChecked,
			               		SelectById = (bool)chkPrimaryKey.IsChecked,
			               		Update = (bool)chkUpdate.IsChecked
			               	};

			progBar.Maximum = 100;
			worker.ProgressChanged += delegate(object o, ProgressChangedEventArgs args)
			                          	{
			                          		if (args.ProgressPercentage < progBar.Maximum)
			                          		{
			                          			progBar.Value = args.ProgressPercentage;
			                          		}
			                          	};
			worker.RunWorkerCompleted += WorkerCompleted;
			worker.DoWork += delegate(object s, DoWorkEventArgs args)
			                 	{
			                 		if (worker.CancellationPending)
			                 		{
			                 			args.Cancel = true;
			                 			return;
			                 		}
			                 		List<TableDto> tablesPresentations =
			                 			AvailableTables.Where(presentation => presentation.Selected).ToList();
			                 		int total = tablesPresentations.Count;
			                 		int count = 0;
			                 		foreach (TableDto tablesPresentation in tablesPresentations)
			                 		{
			                 			Generate(tablesPresentation, p);
			                 			count++;
			                 			worker.ReportProgress(Convert.ToInt32(((decimal)count / total) * 100));
			                 		}
			                 		worker.ReportProgress(100);
			                 	};

			worker.RunWorkerAsync();
		}

		void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			btnGenerate.IsEnabled = true;
			try
			{
				object result = e.Result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.GetInnermostException().ToString());
			}
			finally
			{
				progBar.Visibility = Visibility.Hidden;	
			}
		}

		private void Generate(TableDto tablesPresentation, Procedures procedures)
		{
			Table table = new TableBuilder().BuildMeATableFromThis(new SchemaDataContext(connectionString), tablesPresentation.TableName);
			if (procedures.Delete)
				BuildAndWrite(table, new DeleteProcedure());

			if (procedures.Insert)
				BuildAndWrite(table, new InsertProcedure());

			if (procedures.Select)
				BuildAndWrite(table, new SelectAllProcedure());

			if (procedures.SelectById)
				BuildAndWrite(table, new SelectProcedure());

			if (procedures.SelectByFk)
				BuildAndWrite(table, (IGenerateMultipleProcedure)new ForeignKeyProcedure());

			if (procedures.Update)
				BuildAndWrite(table, new UpdateProcedure());
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

		private void loadTables_Click(object sender, RoutedEventArgs e)
		{
			LoadTableList();
		}
	}
}