@echo %TIME% - INFO: Preparation started
@rem Checking environment started

@rem MS
@if "%VS110COMNTOOLS%"=="" goto error_no_VS110COMNTOOLSDIR

@if not exist "%VS110COMNTOOLS%..\..\VC\vcvarsall.bat" goto error_no_VCVARSALLFILE

@if not exist "%VS110COMNTOOLS%..\IDE\MSTest.exe" goto error_no_MSTest
@set MSTEST_PATH="%VS110COMNTOOLS%..\IDE\MSTest.exe"

@for /F "tokens=1,2*" %%i in ('reg query HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0 /v MSBuildToolsPath') DO (
	@if "%%i"=="MSBuildToolsPath" (
		@SET "NET40DIR=%%k"
	)
)

@if not "%NET40DIR%"=="" goto check_msbuild_exists
@rem Fall back if we can't get path to MSBuild from registry
@if not exist "%SystemRoot%\Microsoft.NET\Framework\v4.0.30319" goto error_no_NET40DIR
@set NET40DIR=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319

:check_msbuild_exists
@if not exist %NET40DIR%\MSBuild.exe goto error_no_MSBUILDFILE
@rem MSBUILD_OPTIONS=/clp::PerformanceSummary;Summary;Verbosity=normal
@set MSBUILD_PATH=%NET40DIR%\MSBuild.exe
@echo INFO: MSBUILD_OPTIONS=%MSBUILD_OPTIONS%
@echo INFO: MSBUILD_PATH=%MSBUILD_PATH%


@rem CD to the directory of this bat file
@cd /d %~dp0
@set SOLUTION_FILE=Okta.sln

@if not exist "%SOLUTION_FILE%" goto error_no_ADAGENTSOLUTION

@set SOLUTION_CONF=Release

@if "%BUILD_NUMBER%"=="" set BUILD_NUMBER="devbuild"
@rem Checking environment done

@rem Setting up started

@call "%VS110COMNTOOLS%..\..\VC\vcvarsall.bat"

@rem Setting up done
@echo %TIME% - INFO: Preparation done

@rem Build started

@rem Build solution started
@echo %TIME% - INFO: MSBuild started...

@set PLATFORM="Any Cpu"
@echo %TIME% - INFO: Building %SOLUTION_CONF% %PLATFORM%
@%MSBUILD_PATH% %SOLUTION_FILE% %MSBUILD_OPTIONS% /t:Clean /p:Configuration=%SOLUTION_CONF%;Platform=%PLATFORM%

@%MSBUILD_PATH% %SOLUTION_FILE% %MSBUILD_OPTIONS% %BUILD_CONSTANT% /t:Build /p:Configuration=%SOLUTION_CONF%;Platform=%PLATFORM%
@set BUILD_MSBUILD_STATUS=%ERRORLEVEL%
@if not %BUILD_MSBUILD_STATUS%==0 goto error_build_msbuild_failed

@echo %TIME% - INFO: MSBuild done
@rem Build solution done


@echo %TIME% - INFO: MSTest started...
@set TEST_RESULTS_DIR=TestResults\
@if not exist %TEST_RESULTS_DIR% mkdir %TEST_RESULTS_DIR%
@set TEST_RESULTS_FILE=%TEST_RESULTS_DIR%buildresults.trx
del /f /q %TEST_RESULTS_FILE%
@%MSTEST_PATH% %SOULUTION_FILE% /nologo /testcontainer:"Okta.Core.Tests\bin\%SOLUTION_CONF%\Okta.Core.Tests.dll" /resultsfile:%TEST_RESULTS_FILE%
@set BUILD_MSTEST_STATUS=%ERRORLEVEL%
@if not %BUILD_MSTEST_STATUS%==0 goto error_build_mstest_failed

@echo %TIME% - INFO: MSTest done


@echo Starting the NuGet package build
cd Okta.Core
nuget pack OktaSdk.nuspec

@rem Return to the directory of this bat file
cd /d %~dp0

@echo Completed the NuGet package build


@rem Build done
goto end

@rem Error handling

:error_no_VS110COMNTOOLSDIR
@echo ERROR: Cannot determine the location of the VS Common Tools folder.
@goto end_error

:error_no_VCVARSALLFILE
@echo ERROR: MSVC 2010 variable set batch file doesn't exists.
@goto end_error

:error_no_MSTest
@echo ERROR: MSTest is not installed.
@goto end_error

:error_no_NET40DIR
@echo ERROR: Cannot determine the location of the .NET 4.0 folder.
@goto end_error

:error_no_MSBUILDFILE
@echo ERROR: MsBuild executable file doesn't exists.
@goto end_error

:error_no_7ZIPDIR
@echo ERROR: Cannot determine the location of the 7 Zip folder.
@goto end_error

:error_no_7ZIPFILE
@echo ERROR: 7-Zip command line executable file doesn't exists.
@goto end_error

:error_no_INSTALLMATEFILE
@echo ERROR: Tarma InstallMate Builder executable file doesn't exists.
@goto end_error

:error_no_ANT
@echo ERROR: Apache Ant doesn't exist.
@goto end_error

:error_no_ADAGENTSOLUTION
@echo ERROR: OKTA AD AGENT Solution file doesn't exists.
@goto end_error

:error_no_AD_AGNET_HOME
@echo ERROR: OKTA AD AGENT home directory could not be found.
@goto end_error

:error_no_OKTA_INSTALLER_DIR
@echo ERROR: Cannot determine the location of the OKTA Installer folder.
@goto end_error

:error_no_OKTA_INSTALLER_FILE
@echo ERROR: Cannot find the location of the OKTA Installer file.
@goto end_error

:error_build_install_failed
@echo ERROR: Installer build failed.
@goto end_error

:error_build_7zip_failed
@echo ERROR: 7-Zip build failed.
@goto end_error

:error_build_ant_failed
@echo ERROR: ant build number setting failed.
@goto end_error

:error_build_msbuild_failed
@echo ERROR: MSBuild build failed.
@goto end_error

:error_build_mstest_failed
@echo ERROR: MSTest failed.
@goto end_error

:error_dist_dir_creation_failed
@echo ERROR: mkdir of %DIST_DIR% failed.
@goto end_error

:error_zip_dir_creation_failed
@echo ERROR: mkdir of %ZIP_DIR% failed.
@goto end_error

:error_zip_source_copy_failed
@echo ERROR: xcopy of artifacts to %ZIP_DIR% failed.
@goto end_error

:end_error
exit /b 1

@rem Existing
:end
