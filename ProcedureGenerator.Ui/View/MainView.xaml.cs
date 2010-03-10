using System;
using System.Windows;
using System.Windows.Input;
using ProcedureGenerator.Ui.ViewModel;

namespace ProcedureGenerator.Ui.View
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();
		}

		public static readonly RoutedCommand NoCountSetOn = new RoutedCommand();
		public static readonly RoutedCommand NoCountSetOff = new RoutedCommand();

		public IMainViewModel ViewModel { get; set; }


		private void OnNoCountSetOn(object sender, ExecutedRoutedEventArgs e)
		{
#warning should move to josh smiths command sink
			ViewModel.SetNoCountOn = true;
		}

		private void OnNoCountSetOff(object sender, ExecutedRoutedEventArgs e)
		{
			ViewModel.SetNoCountOn = false;
		}
	}
}