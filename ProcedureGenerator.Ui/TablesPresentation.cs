namespace ProcedureGenerator.Ui
{
	public class TablesPresentation
	{
		public bool Selected { get; set; }

		public string TableName { get; set; }

		public bool HasPrimaryKey { get; set; }

		public bool HasForeignKey { get; set; }
	}
}