using System;

namespace ProcedureGenerator.Core.Extensions
{
	public static class ExceptionExtension
	{
		public static Exception GetInnermostException(this Exception e)
		{
			while (e.InnerException != null)
			{
				e = e.InnerException;
			}
			return e;
		}
	}
}