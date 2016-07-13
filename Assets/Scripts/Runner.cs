
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using AssemblyCSharp;

public class Runner : MonoBehaviour
{
    private static string _buildNumber = "1";

    public static void Start()
    {
        _buildNumber = GetBuildNumberFromCommandLineArgs();
        DeployToAndroid();
    }

    private static string GetBuildNumberFromCommandLineArgs()
    {
        var arguments = Environment.GetCommandLineArgs();
        var index = Array.IndexOf(arguments, "-buildNumber");
        if (arguments.Length == 0 || index == -1)
        {
            throw new ArgumentException("Could not find argument 'buildNumber' in command line.");
        }
        return arguments[index + 1];
    }

    public static void DeployToAndroid()
	{
		#if UNITY_EDITOR

		var outputPath = GetOutputFolder() + GetAppName("apk");
		string[] scenes = { "Assets/Scenes/MiniGame.unity" };
		BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, BuildOptions.Development);

		#endif
	}

	static string GetOutputFolder()
	{
		var outputPath = "";
#if UNITY_EDITOR
		var applicationPath = Application.dataPath;
		var deploymentFolder = "/../Deployments/";

		outputPath = applicationPath + deploymentFolder;
#endif
		return outputPath;
	}

	static string GetAppName(string extension)
	{
		var appName = "";
#if UNITY_EDITOR
		appName = PlayerSettings.productName + "-" + GetVersion() + "." + extension;
#endif
		return appName;
	}

	static string GetVersion()
	{
		var version = "";
#if UNITY_EDITOR
		VersionManager vm = new VersionManager(PlayerSettings.bundleVersion);
	    vm.SetBuildNumber(_buildNumber);
		PlayerSettings.bundleVersion = vm.GetVersion();
		version = PlayerSettings.bundleVersion;
#endif
		return version;
	}
}
