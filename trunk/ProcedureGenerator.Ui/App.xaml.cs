using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
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

			var viewModel = new MainViewModel();
         
			// Allow all controls in the window to 
			// bind to the ViewModel by setting the 
			// DataContext, which propagates down 
			// the element tree.
			window.DataContext = viewModel;
			window.btnLoadTables.Click += viewModel.LoadTables;
			window.btnGenerate.Click += viewModel.GenerateStoredProcedures;
			window.btnSelectAll.Click += viewModel.SelectAllTables;
			window.Show();
		}
   }
}
