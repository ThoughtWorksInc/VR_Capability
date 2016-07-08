namespace AssemblyCSharp
{
	public class VersionManager
	{
		private string _version;

		public VersionManager(string currentVersion)
		{
			_version = currentVersion;
		}

		public void IncrementCommitVersion()
		{
			var versionParticles = _version.Split('.');
			var major = versionParticles[0];
			var minor = versionParticles[1];
			var commit = 0;
			var commitVersion = 0;

			if (versionParticles.Length == 2)
			{
				commitVersion = 1;
			}
			else if (int.TryParse(versionParticles[2], out commit))
			{
				commitVersion = commit + 1;
			}

			_version = major + "." + minor + "." + commitVersion;
		}

		public string GetIncrementedVersion()
		{
			IncrementCommitVersion();
			return _version;
		}

		public string GetVersion()
		{
			return _version;
		}
	}
}

