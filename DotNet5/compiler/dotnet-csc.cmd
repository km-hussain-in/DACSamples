@echo off
setlocal

rem set dotnethome=%~dp0
for /f "usebackq delims=" %%i  in (`where dotnet.exe`) do set dotnethome=%%~dpi
for /f %%i  in ('dotnet --version') do set sdkver=%%i
for /f "tokens=2" %%i in ('dotnet --list-runtimes ^| find "Microsoft.NETCore.App"') do set fwkver=%%i
set dotnetlib=%dotnethome%shared\Microsoft.NETCore.App\%fwkver%

if "%1" == "" goto :help
if exist %temp%\csc-%fwkver%.rsp goto :compile
(
	echo -r:"%dotnetlib%\netstandard.dll"
	echo -r:"%dotnetlib%\Microsoft.CSharp.dll"
) > %temp%\csc-%fwkver%.rsp
for %%f in ("%dotnetlib%\System.*.dll") do echo -r:"%%f" >> %temp%\csc-%fwkver%.rsp

:compile
set prog=%~n1
dotnet "%dotnethome%sdk\%sdkver%\Roslyn\bincore\csc.dll" -d:NETCOREAPP -nologo @%temp%\csc-%fwkver%.rsp %*
if %errorlevel% == 0 (
    if exist %prog%.exe (
	if not exist %prog%.runtimeconfig.json (
	    (
		echo {
  		echo   "runtimeOptions": {
    		echo     "framework": {
      		echo       "name": "Microsoft.NETCore.App",
      		echo       "version": "%fwkver%"
    		echo     }
  		echo   }
		echo }
	    ) > %prog%.runtimeconfig.json
	)
	rem if not exist %prog%.bat echo @dotnet %prog%.exe %%* > %prog%.bat
    )
)

goto done
:help
dotnet "%dotnethome%sdk\%sdkver%\Roslyn\bincore\csc.dll" -help
:done


