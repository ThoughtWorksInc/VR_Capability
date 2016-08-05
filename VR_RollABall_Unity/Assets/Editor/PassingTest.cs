using System;
using NUnit.Framework;

namespace AssemblyCSharp
{
	public class PassingTest
	{
		[Test]
		public void ShouldPass()
		{
			Assert.Pass();
		}
	}
}

