using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ProcedureGenerator.Core.DataAccess;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Core.ProcedureGenerators;

namespace ProcedureGenerator.Ui
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private ObservableCollection<TablesPresentation> AvailableTables = new ObservableCollection<TablesPresentation>();
		private BackgroundWorker worker = new BackgroundWorker();
		private string OutputPath;
		public Window1()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadTableList();
		}

		private void LoadTableList()
		{
			try
			{
				var schemaDataContext = new SchemaDataContext();
				foreach (
					TABLE table in
						schemaDataContext.TABLEs.Where(table => table.TABLE_TYPE == "BASE TABLE").OrderBy(
							table1 => table1.TABLE_NAME))
				{
					AvailableTables.Add(new TablesPresentation() { Selected = true, TableName = table.TABLE_NAME });
				}
				lbTables.ItemsSource = AvailableTables;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Failed to load the list of table names");
			}
		}

		private void btnSelectAll_Click(object sender, RoutedEventArgs e)
		{
			foreach (TablesPresentation tablesPresentation in AvailableTables)
			{
				tablesPresentation.Selected = true;
			}
		}

		private void btnSelectNone_Click(object sender, RoutedEventArgs e)
		{
			foreach (object item in lbTables.ItemsSource)
			{
				((TablesPresentation)item).Selected = false;
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

			worker.ProgressChanged += delegate(object o, ProgressChangedEventArgs args)
												  {
													  progressBar1.Maximum = 100;
													  progressBar1.Value = args.ProgressPercentage;
												  };
			worker.DoWork += delegate(object s, DoWorkEventArgs args)
									  {
										  if (worker.CancellationPending)
										  {
											  args.Cancel = true;
											  return;
										  }
										  List<TablesPresentation> tablesPresentations =
											  AvailableTables.Where(presentation => presentation.Selected).ToList();
										  int total = tablesPresentations.Count;
										  int count = 0;
										  foreach (TablesPresentation tablesPresentation in tablesPresentations)
										  {
											  Generate(tablesPresentation, p);
											  count++;
											  worker.ReportProgress(Convert.ToInt32(((decimal)count / total) * 100));
										  }
									  };

			worker.RunWorkerAsync();
		}

		private void Generate(TablesPresentation tablesPresentation, Procedures procedures)
		{
			Table table = new TableBuilder().BuildMeATableFromThis(new SchemaDataContext(), tablesPresentation.TableName);
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
	}
}