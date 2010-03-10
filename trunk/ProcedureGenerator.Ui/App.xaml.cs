using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ProcedureGenerator.Ui.Services;
using ProcedureGenerator.Ui.View;
using ProcedureGenerator.Ui.ViewModel;

namespace ProcedureGenerator.Ui
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainView window = new MainView();

			var viewModel = new MainViewModel(new DbTableService(), new ProcedureGeneratorService());
         
			// Allow all controls in the window to 
			// bind to the ViewModel by setting the 
			// DataContext, which propagates down 
			// the element tree.
			window.ViewModel = viewModel;
			window.DataContext = viewModel;
			window.btnLoadTables.Click += viewModel.LoadTables;
			window.btnGenerate.Click += viewModel.GenerateStoredProcedures;
			window.btnSelect.Click += viewModel.SelectAllTables;
			window.btnSelectNone.Click += viewModel.SelectNoTables;
			window.btnCancel.Click += viewModel.CancelProcess;
			window.btnSelectAllWithPk.Click += viewModel.SelectAllWithPk;
			window.btnSelectAllWithFk.Click += viewModel.SelectAllWithFk;
			window.btnSelectAllWithAny.Click += viewModel.SelectAllWithAnyKey;
			window.Show();
		}
   }
}
