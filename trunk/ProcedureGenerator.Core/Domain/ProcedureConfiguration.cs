namespace ProcedureGenerator.Core.Domain
{
	public class ProcedureConfiguration
	{
		private string isolationLevel;
		public bool SetNoCountOn { get; set; }

		public string IsolationLevel
		{
			get
			{
				if (string.IsNullOrEmpty(isolationLevel))
					return "";

				return "SET TRANSACTION ISOLATION LEVEL " + isolationLevel;
			}
			set { isolationLevel = value; }
		}
	}
}