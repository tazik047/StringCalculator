using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
	public static class SimpleStringCalculator
	{
		public static int Add(string parameters)
		{
			if (string.IsNullOrEmpty(parameters))
			{
				return 0;
			}

			var separators = new string[] { ",", "\n" };

			if (parameters.StartsWith("//"))
			{
				var delimetrPattern = Regex.Split(parameters, "\n\\d")[0];
				separators = new[] { delimetrPattern.Substring(2) };
				parameters = parameters.Substring(delimetrPattern.Length + 1);
			}

			var numbers = parameters
				.Split(separators, StringSplitOptions.None)
				.Select(s => Convert.ToInt32(s));

			if (numbers.Any(x => x < 0))
			{
				var negativeNumbers = numbers.Where(x => x < 0);
				throw new ArgumentException("negatives not allowed: " + GetMessage(negativeNumbers));
			}
			var result = numbers.Sum();

			return result;
		}

		private static string GetMessage(IEnumerable<int> list)
		{

			var result = "";
			foreach (var item in list)
			{
				result += item + ",";

			}
			return result.Substring(0, result.Length - 1);
		}
	}
}