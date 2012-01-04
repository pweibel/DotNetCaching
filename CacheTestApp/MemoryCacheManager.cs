using System;
using System.Runtime.Caching;

namespace CacheTestApp
{
	public class MemoryCacheManager : ICacheManager
	{
		#region Properties
		private static MemoryCache Cache { get; set; }
		#endregion

		#region Constructors
		static MemoryCacheManager()
		{
			Cache = MemoryCache.Default;
		}
		#endregion

		#region Public Methods
		public T GetValue<T>(string strKey)
		{
			if (string.IsNullOrEmpty(strKey)) throw new ArgumentNullException("strKey");

			T value = (T) Cache[strKey];

			return value;
		}

		public void SetValue<T>(string strKey, T value)
		{
			if(Cache.Contains(strKey))
			{
				Cache[strKey] = value;
			}
			else
			{
				CacheItemPolicy policy = new CacheItemPolicy();
				Cache.Add(strKey, value, policy);
			}
		}
		#endregion
	}
}
