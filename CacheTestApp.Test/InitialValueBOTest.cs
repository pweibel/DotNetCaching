using System;
using NUnit.Framework;

namespace CacheTestApp.Test
{
	[TestFixture]
	public class InitialValueBOTest
	{
		[Test]
		public void TestGetValue()
		{
			// Arrange
			IInitialValue boInitialValue = new InitialValueBO();
			string strKey = "Test";
			string strValue = "TestResult";
			boInitialValue.SetValue(strKey, strValue);

			// Act
			string strResult = boInitialValue.GetValue<string>(strKey);

			// Assert
			Assert.AreEqual(strValue, strResult);
		}

		[Test]
		public void TestGetValue_With_Two_Queries()
		{
			// Arrange
			IInitialValue boInitialValue = new InitialValueBO();
			string strKey = "Test";
			string strValue = "TestResult" + DateTime.Now;
			boInitialValue.SetValue(strKey, strValue);

			// Act
			string strResult1 = boInitialValue.GetValue<string>(strKey);
			string strResult2 = boInitialValue.GetValue<string>(strKey);

			// Assert
			Assert.AreEqual(strValue, strResult1);
			Assert.AreEqual(strValue, strResult2);
		}
	}
}
