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

			Console.ReadLine();
		}
	}
}
