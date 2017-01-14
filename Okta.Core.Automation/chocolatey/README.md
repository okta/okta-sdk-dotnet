To update the package in Chocolatey:
* Build the project using the Release settings
* Run cpack in the `chocolatey` directory
* Test the package using `choco install okta.core.automation -fdvy -s "%cd%"` in cmd.exe

To update the package with PowerShellGet (new method):
* Install PowerShellGet:

`Install-Module –Name PowerShellGet –Force`

From the Okta.Core.Automation folder in a PowerShell console, run (you only need to run this once):

`Register-PSRepository -name local -SourceLocation .\psgallery`

* Publish the Okta PowerShell module locally:

`Publish-Module -path .\ -Repository local`

* Publish the Okta PowerShell module to www.powershellgallery.com:

`Get-PSRepository
Publish-Module -path .\ -Repository PSGallery -NugetApiKey <your_api_key>`

* To debug the PowerShell module edit the Okta.Core.Automation project properties and in the Debug tab, set:
- Start external program to `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
- Command line arguments to `-noexit -command "&{ import-module .\Okta.Core.Automation.dll -verbose}"`


