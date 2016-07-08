using NUnit.Framework;
using AssemblyCSharp;

[TestFixture]
public class VersionManagerTest {
	
    [Test]
	public void GetVersion_ShouldNotIncrementRevision()
	{
		var currVersion = "2.5.0";
		var vm = new VersionManager(currVersion);
		var result = vm.GetVersion();

		Assert.AreEqual(result, "2.5.0");
	}

	[Test]
	public void GetIncrementedVersion_ShouldIncrementRevision()
	{
		var currVersion = "1.0.0";
		var vm = new VersionManager(currVersion);
		var result = vm.GetIncrementedVersion();

		Assert.AreEqual(result, "1.0.1");
	}	

	[Test]
	public void GetIncrementedVersion_ShouldIncrementRevisionWhenRevisionIsTwoDigitsLong()
	{
		var currVersion = "1.3.19";
		var vm = new VersionManager(currVersion);
		var result = vm.GetIncrementedVersion();

		Assert.AreEqual(result, "1.3.20");
	}


	[Test]
	public void IncrementBundleVersion_ShouldIncrementRevision()
	{
		var currVersion = "2.0.5";
		var vm = new VersionManager(currVersion);

		for (int i = 0; i < 30; i++)
		{
			vm.IncrementCommitVersion();
		}

		Assert.AreEqual(vm.GetVersion(), "2.0.35");
	}

	[Test]
	public void IncrementBundleVersion_ShouldAddCommitVersionIfOnlyMajorAndMinor()
	{
		var currVersion = "2.1";
		var vm = new VersionManager(currVersion);

		vm.IncrementCommitVersion();

		Assert.AreEqual(vm.GetVersion(), "2.1.1");
	}
}
