To install:

1.   Install [Chocolatey](https://github.com/chocolatey/chocolatey/wiki/Installation)
2.   In a PowerShell prompt, run "choco install okta.core.automation"

```powershell
# Import the module
Import-Module Okta.Core.Automation

# Connect
Connect-Okta -Token "your-token" -FullDomain "https://your-subdomain.okta.com"

# Manage Users
$user = Get-OktaUser administrator1@clouditude.net
$newUser = New-OktaUser -Login newguy@asdf.com -Email newguy@asdf.com -FirstName New -LastName Guy
Unlock-OktaUser $newUser
Enable-OktaUser $newUser
Disable-OktaUser $newUser

$newUser.Profile.FirstName = "Old"
Set-OktaUser $newUser
```

# Available Command List
```powershell
Connect-Okta
Get-OktaUser
Set-OktaUser
New-OktaUser
Unlock-OktaUser
Enable-OktaUser
Disable-OktaUser
```

# Troubleshooting
#####Exception of type 'Okta.Core.Automation' was thrown
The module throws this exception if your request was unable to be completed. To determine the reason, use the PowerShell global variable `$error`. For example:
* To see a human-readable version of the last error, use `$error[0].Exception.ErrorSummary`
* To see the last error code, use `$error[0].Exception.ErrorCode`. This is useful when automatically handling different exceptions in a long script.

#####This assembly is built by a runtime newer than the currently loaded runtime and cannot be loaded
This module depends on .NET 4 which isn't enabled by default in most versions of Windows. To fix:

1.   Navigate to your PowerShell directory. It should be C:\Windows\System32\WindowsPowerShell\v1.0, but if it's not, it can be found by typing $PSHome in a PowerShell terminal.
2.   Create a PowerShell.Exe.config (powershell_ise.exe.config if using the ISE) file with the following contents:

    ```xml
    <?xml version="1.0"?> 
    <configuration> 
        <startup useLegacyV2RuntimeActivationPolicy="true"> 
            <supportedRuntime version="v4.0.30319"/> 
            <supportedRuntime version="v2.0.50727"/> 
        </startup> 
    </configuration>
    ```

3.   Save and restart the terminal or ISE.