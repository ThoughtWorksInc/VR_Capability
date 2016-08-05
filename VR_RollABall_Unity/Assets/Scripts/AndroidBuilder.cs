using System;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

public class AndroidBuilder : MonoBehaviour
{
    public static void Build()
    {
        var outputPath = GetOutputFolder() + GetOutputFilename();
        Debug.Log("Publishing Android Player in " + outputPath);
#if UNITY_EDITOR
        var scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray();
        BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, BuildOptions.Development);
#endif
    }

    private static string GetOutputFilename()
    {
        var filename = "";
#if UNITY_EDITOR
        filename = PlayerSettings.productName + "-" + PlayerSettings.bundleVersion + "." + GetArgumentFromCommandLine("buildNumber") + ".apk";
#endif
        return filename;
    }


    private static string GetOutputFolder()
    {
        var outputFolder = GetArgumentFromCommandLine("outputFolder", Application.dataPath + "/../");
        if (outputFolder.EndsWith("/") == false) outputFolder += "/";
        return outputFolder;
    }

    private static string GetArgumentFromCommandLine(string parameterName, string defaultValue = null)
    {
        var arguments = Environment.GetCommandLineArgs();
        var index = Array.IndexOf(arguments, "-" + parameterName);
        if (arguments.Length == 0 || index == -1)
        {
            if (defaultValue != null) return defaultValue;
            throw new ArgumentException("Could not find argument '" + parameterName + "' in command line.");
        }
        return arguments[index + 1];
    }
}