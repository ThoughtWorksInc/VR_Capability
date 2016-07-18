using System;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class FailingTest
	{
		[Test]
		public void ShouldFail()
		{
			Assert.Fail();
		}
	}
}

