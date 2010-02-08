using System.ComponentModel;

namespace ProcedureGenerator.Ui.Dto
{
	public class TableDto:INotifyPropertyChanged 
	{
		private bool _isChecked;
		public bool IsChecked
		{
			get { return _isChecked; }
			set
			{
				_isChecked = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
				}
			}
		}

		public string TableName { get; set; }

		public bool HasPrimaryKey { get; set; }

		public bool HasForeignKey { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
	}
}