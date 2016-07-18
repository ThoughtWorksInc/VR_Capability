: "${UNITY_HOME:?Need to set UNITY_HOME. See set-local-build-vars-*.sh}"
: "${PROJECT_PATH:=.}"
: "${LOG_FILENAME:=unity.build.log}"
: "${BUILD_NUMBER:=0}"

echo "build.sh : starting..."
"$UNITY_HOME/Unity" -projectPath "$PROJECT_PATH" -logfile "$PROJECT_PATH/$LOG_FILENAME" -executeMethod AndroidBuilder.Build -buildNumber "$BUILD_NUMBER" -batchmode -nographics -quit
echo "build.sh : end."