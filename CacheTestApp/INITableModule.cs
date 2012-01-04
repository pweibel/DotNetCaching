using System;

namespace CacheTestApp
{
	public class INITableModule
	{
		public string GetValue(string strKey)
		{
			return strKey + DateTime.Now;
		}

		public void SetValue(string strKey, object value)
		{
			Console.WriteLine("Write into DB: Key: {0}, Value: {1}", strKey, value);
		}
	}
}