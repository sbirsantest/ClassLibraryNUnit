using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ConsoleAppNUnit.Tests
{
	public class GeneralTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Is_All()
		{
			string[] arr = new string[] { "abc", "bad", "dba" };
			Assert.That(arr, Is.All.Contains("b"));
		}

		[Test]
		public void Is_Not()
		{
			string[] arr = new string[] { "abc", "bad", "dba" };
			Assert.That(arr, Is.Not.Length.EqualTo(4));
		}

		[Test]
		public void Has_All()
		{
			int[] arr = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(arr, Has.All.GreaterThan(0));
		}

		[Test]
		public void Has_Some()
		{
			string[] arr = new string[] { "abc", "bad", "dba" };
			Assert.That(arr, Has.Some.StartsWith("a"));
		}

		[Test]
		public void Does_Not()
		{
			Assert.That(@"C:\abc.txt", Does.Not.Exist);
		}

		[Test]
		public void Does_EndWith()
		{
			string str = "How are you?";
			Assert.That(str, Does.EndWith("?"));
		}

		[Test]
		public void Is_Or()
		{
			Assert.That(5, Is.LessThan(1).Or.GreaterThan(4));
		}

	}
}
