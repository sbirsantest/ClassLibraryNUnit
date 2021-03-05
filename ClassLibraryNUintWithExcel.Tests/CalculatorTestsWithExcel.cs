using ExcelDataReader;
using NUnit.Framework;
using System.Data;
using System.IO;

namespace ClassLibraryNUintWithExcel.Tests
{
	public static class ExcelHelper
	{
		public static DataSet _dataSet;

		public static DataSet LoadTestDataFromExcel()
		{
			using (var stream = File.Open(@"TestFiles\CalculatorTestData.xlsx", FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					_dataSet = reader.AsDataSet();
				}
			}

			return _dataSet;
		}
	}

	public class CalculatorTestsWithExcel
	{
		[OneTimeSetUp]
		public void TestFixtureSetUp()
		{
			// Setup once per fixture
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			var testData = ExcelHelper.LoadTestDataFromExcel();
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}
	}
}