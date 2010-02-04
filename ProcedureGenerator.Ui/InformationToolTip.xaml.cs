using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProcedureGenerator.Ui
{
	/// <summary>
	/// Interaction logic for InformationToolTip.xaml
	/// </summary>
	public partial class InformationToolTip : UserControl
	{
		public InformationToolTip()
		{
			InitializeComponent();
		}

		public string ToolTipTitle
		{
			set
			{
				this.lblTitle.Content = value;
			}
			get { return this.lblTitle.Content.ToString(); }
		}

		public string ToolTipBody
		{
			set
			{
				this.txtBody.Text= value;
			}
			get { return this.txtBody.Text; }
		}
	}
}
