using System;

namespace CacheTestApp
{
	public class InitialValueBO : IInitialValue
	{
		#region Properties
		private ICacheManager Cache { get; set; }
		#endregion

		#region Constructors
		public InitialValueBO() : this(new MemoryCacheManager())
		{
		}

		public InitialValueBO(ICacheManager manager)
		{
			this.Cache = manager;
		}
		#endregion

		#region Publics
		public T GetValue<T>(string strKey)
		{
			T value = this.Cache.GetValue<T>(strKey);

			if (value == null)
			{
				INITableModule tmINI = new INITableModule();
				string strValue = tmINI.GetValue(strKey);
				this.Cache.SetValue(strKey, strValue);

				value = ConvertType<T>(strValue);
			}

			return value;
		}

		public void SetValue<T>(string strKey, T value)
		{
			this.Cache.SetValue<T>(strKey, value);
			INITableModule tmINI = new INITableModule();
			tmINI.SetValue(strKey, value);
		}
		#endregion

		#region Privates
		private static T ConvertType<T>(string strValue)
		{
			T value;

			try
			{
				value = (T) Convert.ChangeType(strValue, typeof (T));
			}
			catch
			{
				value = default(T);
			}

			return value;
		}
		#endregion
	}
}