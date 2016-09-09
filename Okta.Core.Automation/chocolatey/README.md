To update the package in Chocolatey:
* Build the project using the Release settings
* Run cpack in the `chocolatey` directory
* Test the package using `choco install okta.core.automation -fdvy -s "%cd%"` in cmd.exe