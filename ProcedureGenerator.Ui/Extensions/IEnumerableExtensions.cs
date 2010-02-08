using System;
using System.Collections.Generic;

namespace ProcedureGenerator.Ui.Extensions
{
	public static class IEnumerableExtensions
	{
		public static void Each<T>(this IEnumerable<T> list, Action<T> action)
		{
			foreach (var item in list)
			{
				action(item);
			}
		}
	}
}