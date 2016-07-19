#/bin/sh 
set -ex

: "${UNITY_PATH:?Need to set UNITY_PATH. See set-local-build-vars-*.sh}"
: "${PROJECT_PATH:=.}"
: "${BUILD_NUMBER:=0}"
: "${LOG_FILENAME:=unity.build.$BUILD_NUMBER.log}"

echo "using UNITY_PATH '$UNITY_PATH'"
echo "using PROJECT_PATH '$PROJECT_PATH'"
echo "using LOG_FILENAME '$LOG_FILENAME'"
echo "using BUILD_NUMBER '$BUILD_NUMBER'"

echo "build.sh : starting..."
"$UNITY_PATH/Unity" -projectPath "$PROJECT_PATH" -logfile "$PROJECT_PATH/$LOG_FILENAME" -executeMethod AndroidBuilder.Build -buildNumber "$BUILD_NUMBER" -runEditorTests -batchmode -nographics -quit
echo "build.sh done"