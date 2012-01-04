namespace CacheTestApp
{
	public interface ICacheManager
	{
		T GetValue<T>(string strKey);
		void SetValue<T>(string strKey, T value);
	}
}