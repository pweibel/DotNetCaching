using System;

namespace CacheTestApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IInitialValue boInitialValue = new InitialValueBO();
			string strKey = "Test";

			string value1 = boInitialValue.GetValue<string>(strKey);
			string value2 = boInitialValue.GetValue<string>(strKey);

			Console.WriteLine("Value 1: {0}, Value 2: {1}", value1, value2);
			Console.Read();
		}
	}
}