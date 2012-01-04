namespace CacheTestApp
{
	public interface IInitialValue
	{
		T GetValue<T>(string strKey);
		void SetValue<T>(string strKey, T value);
	}
}