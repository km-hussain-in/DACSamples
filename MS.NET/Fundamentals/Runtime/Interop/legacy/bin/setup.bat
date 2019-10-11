@echo off

%~dp0quadeq -RegServer
regsvr32 /s %~dp0quadeqps.dll
regsvr32 /s %~dp0finance.dll
regsvr32.exe /s %~dp0..\aircargo.wsc
echo.
:done
