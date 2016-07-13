namespace AssemblyCSharp
{
	public class VersionManager
	{
	    private readonly string _major;
		private readonly string _minor;
		private string _build;

		public VersionManager(string currentVersion)
		{
		    var versionParticles = currentVersion.Split('.');
            _major = versionParticles[0];
            _minor = versionParticles[1];
            if(versionParticles.Length==3)
                _build = versionParticles[2];
        }

		public string GetVersion()
		{
            if(_build==null)
                return string.Join(".", new[] { _major, _minor });
            return string.Join(".", new []{_major, _minor, _build});
		}

	    public void SetBuildNumber(string buildVersion)
	    {
	        _build = buildVersion;
	    }
	}
}

