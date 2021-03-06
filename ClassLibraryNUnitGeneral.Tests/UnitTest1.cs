using NUnit.Framework;
using System;
using System.Collections.Generic;


[SetUpFixture]
class AssemblyLevelSetup
{

	[OneTimeSetUp]
	public void AssemblySetup()
	{
		;
	}


	[OneTimeTearDown]
	public void AssemblyTearDown()
	{
		;
	}
}


namespace ClassLibraryNUnitGeneral.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			;
		}

		[TearDown]
		public void TearDown()
		{
			;
		}

		[TestCase(1, 1)]
		public void Test2(int actual, int expected)
		{
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}