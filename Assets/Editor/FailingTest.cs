using System;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class FailingTest
	{
		[Test]
		[Ignore("Temporary, should be removed")]
		public void ShouldFail()
		{
			Assert.Fail();
		}
	}
}

