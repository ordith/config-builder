using System.Collections.Generic;
using System.Linq;

namespace ConfigBuilderTask
{
	public static class StringExtensions
	{
		public static IEnumerable<string> Trim(this IEnumerable<string> strings)
		{
			return strings.Select(s => s.Trim());
		}
	}
}
