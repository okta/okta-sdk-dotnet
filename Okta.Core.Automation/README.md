## System Requirements

In order to install the official Okta PowerShell module, you must either:

i. Run Windows 10
ii. Install the [Windows Management Framework 5.0](https://www.microsoft.com/en-us/download/details.aspx?id=50395) [for Windows 7 Service Pack 1, Windows 8.1, Windows Server 2008 R2 SP1, Windows Server 2012, Windows Server 2012 R2]

## Installation

To install the Okta PowerShell Module, open a PowerShell prompt as an administrator and run the following 

`Install-Module -Name Okta.Core.Automation`


## Uninstallation

To uninstall the Okta PowerShell Module:

In a PowerShell prompt, run 

`Get-InstalledModule -Name Okta.Core.Automation | Uninstall-Module`

## Usage

```powershell
# Import the module
Import-Module Okta.Core.Automation

# Connect to Okta
Connect-Okta -Token "your-token" -FullDomain "https://your-subdomain.okta.com"

# Get All Users
Get-OktaUser

# Get Paginated Users (2 at a time)
$totalUsers = 0
    $params = @{limit = 2}
    do {
        $page = Get-OktaUser @params
        $users = $page.Results
        foreach ($user in $users) {
            Write-Host $user.profile.login $user.credentials.provider.type
        }
        $totalUsers += $users.count
        $params = @{Url = $page.NextPage}
    } while ($page.NextPage)
    "$totalUsers users found."

# Get a user by Id
Get-OktaUser 00u5xcvjyg5RPSTDo0h7

# Get a user by username
Get-OktaUser brandon@company.com

# Get a user by username (simplified when there is only one brandon@... user)
Get-OktaUser brandon

# Get user(s) by filter (cf. https://developer.okta.com/docs/api/resources/users.html#list-users-with-a-filter)
get-oktauser -filter 'profile.firstName eq "Brandon"'

Note: profile property names and values are case-sensitive

# Get user(s) by query (on first name, last name or email cf. https://developer.okta.com/docs/api/resources/users.html#find-users)
$users = get-oktauser -query b
foreach ($user in $users) {
    Write-Host $user.profile.firstName $user.profile.lastName $user.profile.email 
}

# Create User with login, first name, last name, email address and mobile phone (without sending an activation email). 
Note: The MobilePhone parameter is optional
$newUser = New-OktaUser -Login brandon@company.com -Email brandon.walsh@company.com -FirstName Brandon -LastName Walsh -MobilePhone "+1 855 123 4567"

# Create user and send an activation email
$newUser = New-OktaUser -Login brandon@company.com -Email brandon.walsh@company.com -FirstName Brandon -LastName Walsh -Activate $true

#Enable user (without sending an activation email)
$ al = Enable-OktaUser $newUser
$al.AbsoluteUri #link to the activation url to be sent to the user to activate user account

#Enable user (by sending an activation email)
Enable-OktaUser $newUser -SendEmail $true

#Disable user
Disable-OktaUser

#Update Okta User
$user = Get-OktaUser brandon
$user.Profile.MobilePhone = "123-456-7890"
Set-OktaUser $user

#Get password reset link
Set-OktaUserResetPassword $user.id

#Send password reset email
Set-OktaUserResetPassword $user.id $true

#Unlock User
Syntax:
Unlock-OktaUser $user.id
Unlock-OktaUser -User $u

#Get group
Syntax: Get-OktaGroup GroupID|GroupName
Examples:
Get-OktaGroup "Finance Controllers"
Get-OktaGroup 00g5xcup98euejh1b0h7

#Create new group
Syntax: 
New-OktaGroup -Name <GroupName> -Description <GroupDescription>
Example: 
New-OktaGroup "Finance Controllers" "The list of finance controller users"

#Get Events
Syntax:
Get-OktaEvents -StartDate yyyy-MM-ddTHH:mm:ss -Filter <filter>
Note: StartDate and Filter cannot be used together. If Filter is necessary , we recommend using a 'published gt' filter (cf. https://developer.okta.com/docs/api/resources/events.html#filters)
Examples:
get-oktaevents -filter 'published gt "2017-01-10T10:23:59.000Z"'
get-oktaevents -filter 'published gt "2017-01-10T10:23:59.000Z" and action.objectType eq "core.user_auth.login_failed"'

$newUser.Profile.FirstName = "Old"
Set-OktaUser $newUser
```

### Available Command List
```powershell
Connect-Okta
Get-OktaUser
Set-OktaUser
New-OktaUser
Unlock-OktaUser
Enable-OktaUser
Disable-OktaUser
```

### Troubleshooting
##### Exception of type 'Okta.Core.Automation' was thrown
The module throws this exception if your request was unable to be completed. To determine the reason, use the PowerShell global variable `$error`. For example:
* To see a human-readable version of the last error, use `$error[0].Exception.ErrorSummary`
* To see the last error code, use `$error[0].Exception.ErrorCode`. This is useful when automatically handling different exceptions in a long script.

##### This assembly is built by a runtime newer than the currently loaded runtime and cannot be loaded
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