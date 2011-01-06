namespace ProcedureGenerator.Core.ProcedureGenerators
{
	public class SelectProcedure : SelectByIdProcedure
	{
		protected override string ProcedureName
		{
			get
			{
				return string.Format("sp{0}SelectAll", Table.Name);
			}
		}

		protected override string ProcedureTemplatePath
		{
			get
			{
				return "/Velocity/Select/SelectAll.Vm";
			}
		}
	}
}