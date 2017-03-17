# install Okta.Core.Automation -source '%cd%'

$packageName = 'Okta.Core.Automation'
$folder = "$($Home)\Documents\WindowsPowerShell\Modules\$($packageName)"

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
Set-Location $scriptPath

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
