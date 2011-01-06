using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ProcedureGenerator.Core.Domain;
using ProcedureGenerator.Ui.Dto;

namespace ProcedureGenerator.Ui.ViewModel
{
	public interface IMainViewModel
	{
		ObservableCollection<TableDto> Tables { get; set; }
		bool SetNoCountOn { get; set; }
		string ConnectionStringKey { get; set; }
		string OutputPath { get; set; }
		string IsolationLevel { get; set; }
		string Schema { get; set; }
		ObservableCollection<object> ConnectionStrings { get; }
		bool InProgress { get; set; }
		int ProgressPercentage { get; set; }
		bool Select { get; set; }
		bool SelectById { get; set; }
		bool SelectByFk { get; set; }
		bool Insert { get; set; }
		bool Update { get; set; }
		bool Delete { get; set; }
		event PropertyChangedEventHandler PropertyChanged;
		void GetListOfTablesFromDatabase();
		void LoadTables(object sender, RoutedEventArgs e);
		void GenerateStoredProcedures(object sender, RoutedEventArgs e);
		void SelectAllTables(object sender, RoutedEventArgs e);
		void SelectNoTables(object sender, RoutedEventArgs e);
		ProcedureConfiguration GetProcedureConfig();
		void CancelProcess(object sender, RoutedEventArgs e);
		void SelectAllWithPk(object sender, RoutedEventArgs e);
		void SelectAllWithFk(object sender, RoutedEventArgs e);
		void SelectAllWithAnyKey(object sender, RoutedEventArgs e);
	}
}