#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using AssemblyCSharp;

public class Runner : MonoBehaviour
{
	public static void Start() 
	{
		DeployToAndroid();
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
		PlayerSettings.bundleVersion = vm.GetIncrementedVersion();

		version = PlayerSettings.bundleVersion;
#endif
		return version;
	}
}
