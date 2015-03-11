# choco install Okta.Core.Automation -source '%cd%'

$packageName = 'Okta.Core.Automation'
$folder = "$($Home)\Documents\WindowsPowerShell\Modules\$($packageName)"

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
Set-Location $scriptPath

# http://andyarismendi.blogspot.com/2012/02/unblocking-files-with-powershell.html
function Unblock-File {
    [cmdletbinding(DefaultParameterSetName="ByName", SupportsShouldProcess=$True)]
    param (
        [parameter(Mandatory=$true, ParameterSetName="ByName", Position=0)] [string] $FilePath,
        [parameter(Mandatory=$true, ParameterSetName="ByInput", ValueFromPipeline=$true)] $InputObject
    )
    begin {
        Add-Type -Namespace Win32 -Name PInvoke -MemberDefinition @"
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363915(v=vs.85).aspx
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFile(string name);
        public static int Win32DeleteFile(string filePath) {
            bool is_gone = DeleteFile(filePath); return Marshal.GetLastWin32Error();}
 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetFileAttributes(string lpFileName);
        public static bool Win32FileExists(string filePath) {return GetFileAttributes(filePath) != -1;}
"@
    }
    process {
        switch ($PSCmdlet.ParameterSetName) {
            'ByName'  {$input_paths = Resolve-Path -Path $FilePath | ? {[IO.File]::Exists($_.Path)} | Select -Exp Path}
            'ByInput' {if ($InputObject -is [System.IO.FileInfo]) {$input_paths = $InputObject.FullName}}
        }
        $input_paths | % {     
            if ([Win32.PInvoke]::Win32FileExists($_ + ':Zone.Identifier')) {
                if ($PSCmdlet.ShouldProcess($_)) {
                    $result_code = [Win32.PInvoke]::Win32DeleteFile($_ + ':Zone.Identifier')
                    if ([Win32.PInvoke]::Win32FileExists($_ + ':Zone.Identifier')) {
                        Write-Error ("Failed to unblock '{0}' the Win32 return code is '{1}'." -f $_, $result_code)
                    }
                }
            }
        }
    }
}

try {
	nuget install Okta.Core.Client -pre

	if(Test-Path -Path .\packages) {
		# Copy the Okta.Core.Client
		Copy-Item .\packages\Okta.Core.Client*\lib\* .\bin\

		# Copy all the files from the net40 folders to bin
		Copy-Item .\packages\*\*\net40\* .\bin\

		# Remove packages
		Remove-Item .\packages -recurse -force
	}
	else {
		# Copy the Okta.Core.Client
		Copy-Item .\Okta.Core.Client*\lib\* .\bin\

		# Copy all the files from the net40 folders to bin
		Copy-Item .\*\*\net40\* .\bin\
	}

	# Copy all the files to the Modules location
	if(!(Test-Path -Path "$($folder)")) {
		New-Item -ItemType directory -Path "$($folder)"
	}

	# Copy the psd1
	Copy-Item .\Okta.Core.Automation.psd1 "$($folder)"

	# Copy all the dlls
	if(!(Test-Path -Path "$($folder)\bin")) {
		New-Item -ItemType directory -Path "$($folder)\bin"
	}
	Copy-Item .\bin\* "$($folder)\bin"

	# Unblock all the dlls
	Get-ChildItem "$($folder)\bin" | Unblock-File

	# the following is all part of error handling
	Write-ChocolateySuccess "$($packageName)"
} catch {
	Write-ChocolateyFailure "$packageName" "$($_.Exception.Message)"
	throw
}