using ClassLibraryNUnit;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppNUnit.Tests
{

	public class CalculatorFactoryTestCases
	{
		public static IEnumerable AddTestCases
		{
			get
			{
				yield return new TestCaseData(new CalculatorTestData());
				yield return new TestCaseData(new CalculatorTestData(2, 2, 4));
				yield return new TestCaseData(new CalculatorTestData(6, 4, 10));
			}
		}

		public static IEnumerable SubtractTestCases
		{
			get
			{
				yield return new TestCaseData(new CalculatorTestData());
				yield return new TestCaseData(new CalculatorTestData(2, 1, 1));
				yield return new TestCaseData(new CalculatorTestData(10, 7, 3));
			}
		}

	}

	public class CalculatorFactoryAddTestCases: List<TestCaseData>
	{
		public CalculatorFactoryAddTestCases()
		{
			Add(new TestCaseData(new CalculatorTestData()));
			Add(new TestCaseData(new CalculatorTestData(2, 1, 3)));
			Add(new TestCaseData(new CalculatorTestData(6, 7, 13)));
		}
	}

	public class CalculatorFactorySubtractTestCases : List<TestCaseData>
	{
		public CalculatorFactorySubtractTestCases()
		{
			Add(new TestCaseData(new CalculatorTestData()));
			Add(new TestCaseData(new CalculatorTestData(2, 1, 1)));
			Add(new TestCaseData(new CalculatorTestData(10, 7, 3)));
		}
	}

	public class CalculatorTestData
	{
		private readonly int _a;
		private readonly int _b;
		private readonly int _result;


		public int A { get => _a;}
		public int B { get => _b; }
		public int Result { get => _result; }

		public CalculatorTestData()
		{
			_a = 0;
			_b = 0;
			_result = 0;
		}

		public CalculatorTestData(int a, int b, int result)
		{
			_a = a;
			_b = b;
			_result = result;
		}
	}

	public class CalculatorTests
	{
		private Calculator _calculator;

		//static readonly object[] Abc = { new object[] { 2, 3, 5 } };
		static readonly int[][] AddTestCases = { new int[] { 2, 3, 5 }, new int[] { 6, 4, 10 } };


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
			var result  = _calculator.Add(2, 3);
			Assert.That(result, Is.EqualTo(5));
		}

		[TestCase(2, 3, 5)]
		[TestCase(6, 3, 9)]
		[Ignore("")]
		public void Add1_ShouldReturnCorrectValue(int a, int b, int expectedResult)
		{
			var result = _calculator.Add(a, b);
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[TestCaseSource("AddTestCases")]
		[Ignore("")]
		public void Add2_ShouldReturnCorrectValue(int a, int b, int expectedResult)
		{
			var result = _calculator.Add(a, b);
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[TestCaseSource(typeof(CalculatorFactoryTestCases), "AddTestCases")]
		public void Add3_ShouldReturnCorrectValue(CalculatorTestData testData)
		{
			var result = _calculator.Add(testData.A, testData.B);
			Assert.That(result, Is.EqualTo(testData.Result));
		}

		[TestCaseSource(typeof(CalculatorFactoryAddTestCases))]
		public void Add4_ShouldReturnCorrectValue(CalculatorTestData testData)
		{
			var result = _calculator.Add(testData.A, testData.B);
			Assert.That(result, Is.EqualTo(testData.Result));
		}

	}
}