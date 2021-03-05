using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryNUintWithExcel.Tests
{
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
}
