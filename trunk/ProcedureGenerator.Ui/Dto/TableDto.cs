namespace ProcedureGenerator.Ui.Dto
{
	public class TableDto
	{
		public bool IsChecked { get; set; }

		public string TableName { get; set; }

		public bool HasPrimaryKey { get; set; }

		public bool HasForeignKey { get; set; }
	}
}