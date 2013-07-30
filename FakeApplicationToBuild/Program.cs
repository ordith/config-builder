using System;
using System.Configuration;

namespace FakeApplicationToBuild
{
	class Program
	{
		static void Main(string[] args)
		{
			var exampleValue = ConfigurationManager.AppSettings["ReplaceMeResult"];

			Console.WriteLine("After building, 'ReplaceMeResult' should have a value.");
			Console.WriteLine("ReplaceMeResult: {0}", exampleValue);

			var exampleValue2 = ConfigurationManager.AppSettings["ReplaceMe2Result"];
			Console.WriteLine("After building, 'ReplaceMe2Result' should have a value plus some extra text due to the template.");
			Console.WriteLine("ReplaceMe2Result: {0}", exampleValue2);

			Console.ReadLine();
		}
	}
}
