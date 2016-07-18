: "${UNITY_HOME:?Need to set UNITY_HOME}"
: "${PROJECT_PATH:=.}"
: "${LOG_FILENAME:=unity.build.log}"
: "${BUILD_NUMBER:=0}"

"$UNITY_HOME/Unity" -projectPath "$PROJECT_PATH" -logfile "$PROJECT_PATH/$LOG_FILENAME" -executeMethod AndroidBuilder.Build -buildNumber "$BUILD_NUMBER" -batchmode -nographics -quit