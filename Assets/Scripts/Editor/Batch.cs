public class Batch {

    public static void RunUnitTests()
    {
		VersionManagerTest vmt = new VersionManagerTest();
		vmt.GetVersion_ShouldNotIncrementRevision();
		vmt.GetIncrementedVersion_ShouldIncrementRevision();
		vmt.GetIncrementedVersion_ShouldIncrementRevisionWhenRevisionIsTwoDigitsLong();
		vmt.IncrementBundleVersion_ShouldAddCommitVersionIfOnlyMajorAndMinor();
		vmt.IncrementBundleVersion_ShouldIncrementRevision();
    }
}
