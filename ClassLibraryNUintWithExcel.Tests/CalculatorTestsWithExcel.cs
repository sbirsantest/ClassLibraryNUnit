using ClassLibraryNUnit;
using ExcelDataReader;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

[SetUpFixture]
public class ExcelHelper
{
	private static DataSet _dataSet;

	private static List<ClassLibraryNUintWithExcel.Tests.CalculatorTestData> _calculatorAddTestData;

	private static List<ClassLibraryNUintWithExcel.Tests.CalculatorTestData> _calculatorSubtarctTestData;

	public static List<ClassLibraryNUintWithExcel.Tests.CalculatorTestData> CalculatorAddTestData
	{
		get
		{
			if (_calculatorAddTestData == null)
			{
				SetAddTestData();
			}
			return _calculatorAddTestData;
		}
		set { _calculatorAddTestData = value; }
	}

	public static List<ClassLibraryNUintWithExcel.Tests.CalculatorTestData> CalculatorSubtarctTestData
	{
		//get { return _calculatorSubtarctTestData; }
		get
		{
			if (_calculatorSubtarctTestData == null)
			{
				SetSubtractTestData();
			}
			return _calculatorSubtarctTestData;
		}

		set { _calculatorSubtarctTestData = value; }
	}

	////[OneTimeSetUp]
	//public static void AssemblySetup()
	//{
	//	try
	//	{
	//		LoadTestDataFromExcel();
	//		SetAddTestData();
	//	}
	//	catch (Exception)
	//	{
	//		throw;
	//	}
	//}

	private static void LoadTestDataFromExcel()
	{
		try
		{
			if (_dataSet == null)
			{
				System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

				using (var stream = File.Open(@"TestFiles\CalculatorTestData.xlsx", FileMode.Open, FileAccess.Read))
				{
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						_dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
						{
							ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
							{
								UseHeaderRow = true
							}
						});
					}
				}
			}
		}
		catch (Exception)
		{
			throw;
		}
	}

	private static void SetAddTestData()
	{
		try
		{
			if (_dataSet == null)
			{
				LoadTestDataFromExcel();
			}

			if (_calculatorAddTestData == null)
			{
				var addTestDataTable = _dataSet?.Tables["AddTestData"];

				if (addTestDataTable != null)
				{
					_calculatorAddTestData = (from testDataRow in addTestDataTable.AsEnumerable()
													  select
													  new ClassLibraryNUintWithExcel.Tests.CalculatorTestData
														 (
															 Convert.ToInt32(testDataRow["InputData1"]),
															 Convert.ToInt32(testDataRow["InputData2"]),
															 Convert.ToInt32(testDataRow["ExpectedResult"])
														 )
									 ).ToList();
				}
			}
		}
		catch (Exception)
		{
			throw;
		}
	}

	private static void SetSubtractTestData()
	{
		try
		{
			if (_dataSet == null)
			{
				LoadTestDataFromExcel();
			}

			if (_calculatorSubtarctTestData == null)
			{
				var addTestDataTable = _dataSet?.Tables["SubtractTestData"];

				if (addTestDataTable != null)
				{
					_calculatorSubtarctTestData = (from testDataRow in addTestDataTable.AsEnumerable()
															 select
															 new ClassLibraryNUintWithExcel.Tests.CalculatorTestData
																(
																	Convert.ToInt32(testDataRow["InputData1"]),
																	Convert.ToInt32(testDataRow["InputData2"]),
																	Convert.ToInt32(testDataRow["ExpectedResult"])
																)
									 ).ToList();
				}
			}
		}
		catch (Exception)
		{
			throw;
		}
	}
}


namespace ClassLibraryNUintWithExcel.Tests
{
	public class CalculatorFactoryAddTestCases : List<TestCaseData>
	{
		public CalculatorFactoryAddTestCases()
		{
			try
			{
				foreach (var item in ExcelHelper.CalculatorAddTestData)
				{
					Add(new TestCaseData(item));
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	public class CalculatorFactorySubtarctTestCases : List<TestCaseData>
	{
		public CalculatorFactorySubtarctTestCases()
		{
			try
			{
				foreach (var item in ExcelHelper.CalculatorSubtarctTestData)
				{
					Add(new TestCaseData(item));
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	public class CalculatorFactoryTestCases
	{
		public static IEnumerable AddTestCases
		{
			get
			{
				foreach (var item in ExcelHelper.CalculatorAddTestData)
				{
					yield return item;
				}
			}
		}

		public static IEnumerable SubtractTestCases
		{
			get
			{
				foreach (var item in ExcelHelper.CalculatorSubtarctTestData)
				{
					yield return new TestCaseData(item);
				}
			}
		}
	}

	public class CalculatorTestsWithExcel
	{
		private Calculator _calculator;

		[OneTimeSetUp]
		public void TestFixtureSetUp()
		{
			// Setup once per fixture
		}

		[SetUp]
		public void Setup()
		{
			_calculator = new Calculator();
		}

		[TearDown]
		public void TearDown()
		{
			//_calculator.Dispose();
			_calculator = null;
		}

		[Test]
		[Ignore("")]
		public void Add_ShouldReturn5()
		{
			var result = _calculator.Add(2, 3);
			Assert.That(result, Is.EqualTo(5));
		}

		[TestCaseSource(typeof(CalculatorFactoryTestCases), nameof(CalculatorFactoryTestCases.AddTestCases))]
		public void Calculator_Add1_ShouldReturnExpectedResult(CalculatorTestData ctd)
		{
			var result = _calculator.Add(ctd.A, ctd.B);
			Assert.That(result, Is.EqualTo(ctd.Result));
		}

		[TestCaseSource(typeof(CalculatorFactoryAddTestCases))] 
		public void Calculator_Add2_ShouldReturnExpectedResult(CalculatorTestData ctd)
		{
			var result = _calculator.Add(ctd.A, ctd.B);
			Assert.That(result, Is.EqualTo(ctd.Result));
		}

		[TestCaseSource(typeof(CalculatorFactoryTestCases), nameof(CalculatorFactoryTestCases.SubtractTestCases))]
		public void Calculator_Subtract_ShouldReturnExpectedResult(CalculatorTestData ctd)
		{
			var result = _calculator.Subtract(ctd.A, ctd.B);
			Assert.That(result, Is.EqualTo(ctd.Result));
		}

		[TestCaseSource(typeof(CalculatorFactorySubtarctTestCases))] 
		public void Calculator_Subtract2_ShouldReturnExpectedResult(CalculatorTestData ctd)
		{
			var result = _calculator.Subtract(ctd.A, ctd.B);
			Assert.That(result, Is.EqualTo(ctd.Result));
		}
	}
}