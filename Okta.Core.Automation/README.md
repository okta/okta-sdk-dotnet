Make sure the dependencies are alongside Okta.Core.Automation.dll:
Okta.Core.dll
Newtonsoft.Json.dll
System.Net.Http.dll

You may need to upgrade your powershell .NET framework to 4 or higher

```powershell
# Import the module
Import-Module "Okta.Core.Automation.dll" -Verbose

# Connect
Connect-Okta -Token "your-token" -Subdomain "your-subdomain"
Connect-Okta -Token "your-token" -FullDomain "uri"

# Manage Users
$user = Get-OktaUser administrator1@clouditude.net
$newUser = New-OktaUser -Login newguy@asdf.com -Email newguy@asdf.com -FirstName New -LastName Guy
Unlock-OktaUser $newUser
Enable-OktaUser $newUser
Disable-OktaUser $newUser

$newUser.FirstName = Old
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