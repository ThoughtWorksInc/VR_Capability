@echo off
REM Windows build script calls osx/linux build script via Git bash.
"C:\Program Files\Git\bin\sh.exe" ./build.sh
if "%errorlevel%" neq "0" (
    exit /b %errorlevel%
)