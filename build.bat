SET PROJECT_PATH=%cd%

taskkill /im Unity.exe

mkdir "%PROJECT_PATH%\Deployments"

"C:\Program Files\Unity\Editor\Unity" ^
-projectPath "%PROJECT_PATH%" ^
-logfile "unity.build.log" ^
-executeMethod Runner.Start ^
-buildNumber "42" ^
-batchmode ^
-nographics ^
-runEditorTests ^
-quit