using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class Batch
{
	public static void RunUnitTests()
	{
		VersionManagerTest vmt = new VersionManagerTest();
		vmt.GetVersion_ShouldNotIncrementRevision();
		vmt.GetIncrementedVersion_ShouldIncrementRevision();
		vmt.GetIncrementedVersion_ShouldIncrementRevisionWhenRevisionIsTwoDigitsLong();
		vmt.IncrementBundleVersion_ShouldAddCommitVersionIfOnlyMajorAndMinor();
		vmt.IncrementBundleVersion_ShouldIncrementRevision();
	}

	public static void RunUnitTests_Reflection()
	{
		//Assumption: cannot run parameterized tests.
		//Assumption: test class should have parameterless constructor.
		var emptyParams = new object[] { };
		foreach (var testClass in getTestAssemblies().SelectMany<Assembly, Type>(getTestClasses)) {
			var tests = getTestMethods(testClass).ToArray();
			if (tests.Length > 0) { 
				var instance = Activator.CreateInstance(testClass);
				foreach (var test in tests) {
					Debug.WriteLine("Running test.", test.Name);
					test.Invoke(instance, emptyParams);
				}
			}
		}
	}

	private static IEnumerable<Assembly> getTestAssemblies()
	{
		yield return typeof(Batch).Assembly;
	}

	private static IEnumerable<System.Type> getTestClasses(Assembly a) {
		return a
			.GetTypes()
			.Where(t => t.GetCustomAttributes(typeof(NUnit.Framework.TestFixtureAttribute), true).Any());
	}

	private static IEnumerable<MethodInfo> getTestMethods(Type t)
	{
		return t
			.GetMethods()
			.Where(m => m.GetCustomAttributes(typeof(NUnit.Framework.TestAttribute), true).Any());
	}
}
