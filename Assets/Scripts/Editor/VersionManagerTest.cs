using NUnit.Framework;
using AssemblyCSharp;

[TestFixture]
public class VersionManagerTest {

    [Test]
    public void GetVersion_GivenVersionWithBuildNumber_ShouldNotIncrementRevision()
    {
        var currVersion = "2.5.0";
        var vm = new VersionManager(currVersion);
        var result = vm.GetVersion();

        Assert.AreEqual("2.5.0", result);
    }
    [Test]
    public void GetVersion_GivenVersionWithoutBuildNumber_ShouldNotIncrementRevision()
    {
        var currVersion = "2.5";
        var vm = new VersionManager(currVersion);
        var result = vm.GetVersion();

        Assert.AreEqual("2.5", result);
    }

    [Test]
	public void SetBuildNumber_GivenVersionWithBuildNumber_ShouldUpdateRevision()
	{
		var currVersion = "1.0.0";
		var vm = new VersionManager(currVersion);
        vm.SetBuildNumber("42");
		var result = vm.GetVersion();

		Assert.AreEqual("1.0.42", result);
	}	
    

	[Test]
	public void SetBuildVersion_GivenVersionWithoutBuildNumber_ShouldUpdateRevision()
	{
		var currVersion = "2.1";
		var vm = new VersionManager(currVersion);
        vm.SetBuildNumber("42");
        var result = vm.GetVersion();

        Assert.AreEqual("2.1.42", result);
    }
    
}
