@echo off

%~dp0bin\quadeq -RegServer
regsvr32 /s %~dp0bin\quadeqps.dll
regsvr32 /s %~dp0bin\finance.dll
regsvr32.exe /s %~dp0aircargo.wsc
@call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\vcvarsall.bat" x86_amd64
echo.
:done
