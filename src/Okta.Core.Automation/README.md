## System Requirements

In order to install the official Okta PowerShell module, you must either:

i. Run Windows 10    
ii. Install the [Windows Management Framework 5.0](https://www.microsoft.com/en-us/download/details.aspx?id=50395) [for Windows 7 Service Pack 1, Windows 8.1, Windows Server 2008 R2 SP1, Windows Server 2012, Windows Server 2012 R2]. __Important note__: it might be necessary to install .NET Framework 4.5 beforehand.

## Installation

To install the Okta PowerShell Module, open a PowerShell prompt as an administrator and run the following: 

`Install-Module -Name Okta.Core.Automation`

## Update

To update an older version to the most recent version of the Okta PowerShell Module, open a PowerShell prompt as an administrator and run the following: 

`Update-Module -Name Okta.Core.Automation`


## Uninstallation

To uninstall the Okta PowerShell Module open a PowerShell prompt as an administrator and run the following: 

`Get-InstalledModule -Name Okta.Core.Automation | Uninstall-Module`

## Usage

```powershell
# Import the module
Import-Module Okta.Core.Automation

# Connect to Okta
Syntax:
Connect-Okta -Token "your-token" -FullDomain "https://your-subdomain.okta.com"

# Get all users
Get-OktaUser

# Get user by id
Get-OktaUser 00u5xcvjyg5RPSTDo0h7

# Get user by username
Get-OktaUser brandon@company.com

# Get user by username (simplified when there is only one brandon@... user)
Get-OktaUser brandon

# Get user(s) by filter (cf. https://developer.okta.com/docs/api/resources/users.html#list-users-with-a-filter)
Get-OktaUser -Filter 'profile.firstName eq "Brandon"'

Note: profile property names and values are case-sensitive

# Get user(s) by query (on first name, last name or email cf. https://developer.okta.com/docs/api/resources/users.html#find-users)
$users = get-oktauser -query b
foreach ($user in $users) {
    Write-Host $user.profile.firstName $user.profile.lastName $user.profile.email 
}

# Create user
Syntax:
New-OktaUser -Login <userLogin@domain.com> -Email <userEmail> -FirstName <firstName> -LastName <lastName> -MobilePhone[optional] <phoneNumber> -Activate <$true|$false>
Examples:
$newUser = New-OktaUser -Login brandon@company.com -Email brandon.walsh@company.com -FirstName Brandon -LastName Walsh 
$newUser = New-OktaUser -Login brandon@company.com -Email brandon.walsh@company.com -FirstName Brandon -LastName Walsh -MobilePhone "+1 855 123 4567"
$newUser = New-OktaUser -Login brandon@company.com -Email brandon.walsh@company.com -FirstName Brandon -LastName Walsh -Activate $true #Creates a user and sends an activation email


# Enable user (without sending an activation email)
Syntax:
Enable-OktaUser <user>
Example:
$newUser = New-OktaUser brandon@company.com -Email brandon.walsh@company.com -FirstName Brandon -LastName Walsh
$al = Enable-OktaUser $newUser
Note: $al.AbsoluteUri is the link to the activation url to be sent to the user to activate user account

# Enable user (and sends an activation email)
Enable-OktaUser $newUser -SendEmail $true

# Deactivate user
Syntax:
Disable-OktaUser -Id <userId> -User <user>
Examples:
Disable-OktaUser brandon
$u = Get-OktaUser brandon
Disable-OktaUser -User $u

# Update user
Syntax:
Set-OktaUser <user>
Example:
$user = Get-OktaUser brandon
$user.Profile.MobilePhone = "123-456-7890"
Set-OktaUser $user

# Get password reset link
Syntax:
Set-OktaUserResetPassword $user.id

# Send password reset email
Syntax:
Set-OktaUserResetPassword $user.id $true

# Unlock user
Syntax:
Unlock-OktaUser $user.id
Unlock-OktaUser -User $user

# Get group
Syntax:
Get-OktaGroup GroupID|GroupName
Examples:
Get-OktaGroup "Finance Controllers"
Get-OktaGroup 00g5xcup98euejh1b0h7

# Create group
Syntax: 
New-OktaGroup -Name <GroupName> -Description <GroupDescription>[optional]
Examples: 
New-OktaGroup "Finance Controllers"
New-OktaGroup "Finance Controllers" "The list of finance controller users"

# Add member to group
Syntax:
Add-OktaGroupMember -IdOrName GroupID|GroupName -UserIdOrLogin UserIdOrLogin
Examples:
Add-OktaGroupMember "Finance Controllers" brandon
Add-OktaGroupMember "Finance Controllers" brandon@company.com
$g = Get-OktaGroup "Finance Controllers"
$u = get-OktaUser brandon
Add-OktaGroupMember $g.Id $u.Id

# Get group members
Syntax: 
Get-OktaGroupMember GroupID|GroupName
Examples:
Get-OktaGroupMember "Finance Controllers"
Get-OktaGroupMember 00g5xcup98euejh1b0h7

# Remove group member
Syntax: 
Remove-OktaGroupMember -IdOrName GroupID|GroupName -UserIdOrLogin UserIdOrName
Examples:
Remove-OktaGroupMember "Finance Controllers" brandon
$g = Get-OktaGroup "Finance Controllers"
$u = get-OktaUser brandon
Remove-OktaGroupMember $g.Id $u.Id

# Get user's groups
Syntax: 
Get-OktaUserGroups -IdOrLogin UserId
Example:
$groups = Get-OktaUserGroups brandon
foreach ($g in $groups) {
    Write-Host $g.Profile.Name $g.Profile.Description 
}

# Add user to an application
Syntax:
Set-OktaAppUser -AppId <appId> -UserId <userId>
Example:
$user = Get-OktaUser brandon
$appUser = Set-OktaAppUser 0oa6bh33a79OzGTmA0h7 $user.Id

# Get users assigned to an application
Syntax:
Get-OktaAppUser -AppId <appId> -UserId <userId>
Examples:
$appUsers = Get-OktaAppUser 0oa6bh33a79OzGTmA0h7
foreach ($u in $appUsers) {
    Write-Host $u.Id $u.Credentials.Username $u.Profile.Email 
}

# Remove user from an application
Syntax:
Remove-OktaAppUser -AppId <appId> -UserId <userId>
Example:
$user = Get-OktaUser brandon
Remove-OktaAppUser 0oa6bh33a79OzGTmA0h7 $user.Id

# List user second factors
Syntax:
Get-OktaUserFactor -IdOrLogin <userId> -FactorId <factorId>[optional]
Examples:
Get-OktaUserFactor brandon #retrieves all second factors for user brandon
Get-OktaUserFactor brandon clf98xuddpMItO4Bs0h7 #retrieves unique factor with id=clf98xuddpMItO4Bs0h7 (for user brandon)

# Delete user second factor
Syntax:
Reset-OktaUserFactor -IdOrLogin <userId> -FactorId <factorId>[optional]
Examples:
Reset-OktaUserFactor brandon #deletes all second factors for user brandon
Get-OktaUserFactor brandon clf98xuddpMItO4Bs0h7 #retrieves unique factor with id=clf98xuddpMItO4Bs0h7 (for user brandon)

# Enroll second factor (currently only supported with text/SMS and voice call factors)
Syntax:
Enroll-OktaUserFactor -IdOrLogin <userId> -FactorType <okta_sms|okta_call> -PhoneNumber "123 456 7890" -PhoneExtension "1234"
Example:
$factor = Enroll-OktaUserFactor brandon okta_sms "415 583 3872"

# Activate SMS or voice call factor
Syntax:
Activate-OktaUserFactor -IdOrLogin <userId> -FactorId <factorId> -PassCode <code received by SMS or voice call>
Example:
$factor = Enroll-OktaUserFactor brandon okta_sms "415 583 3872"
Activate-OktaUserFactor brandon $factor.Id <passcode>

# Get system events
Syntax:
Get-OktaEvents -StartDate yyyy-MM-ddTHH:mm:ss -Filter <filter>
Note: StartDate and Filter cannot be used together. If Filter is necessary , we recommend using a 'published gt' filter (cf. https://developer.okta.com/docs/api/resources/events.html#filters)
Examples:
Get-OktaEvents -filter 'published gt "2017-01-10T10:23:59.000Z"'
Get-OktaEvents -filter 'published gt "2017-01-10T10:23:59.000Z" and action.objectType eq "core.user_auth.login_failed"'
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
Set-OktaUserResetPassword
Get-OktaGroup
New-OktaGroup
Add-OktaGroupMember
Get-OktaGroupMember
Remove-OktaGroupMember
Get-OktaUserGroups
Get-OktaAppUser
Set-OktaAppUser
Remove-OktaAppUser
Enroll-OktaUserFactor
Activate-OktaUserFactor
Get-OktaUserFactor
Reset-OktaUserFactor
Get-OktaEvents
```

### Troubleshooting
##### Exception of type 'Okta.Core.Automation' was thrown
The module throws this exception if your request was unable to be completed. To determine the reason, use the PowerShell global variable `$error`. For example:
* To see a human-readable version of the last error, use `$error[0].Exception.ErrorSummary`.
* To see the last error code, use `$error[0].Exception.ErrorCode`. This is useful when automatically handling different exceptions in a long script.

##### This assembly is built by a runtime newer than the currently loaded runtime and cannot be loaded
This module depends on .NET 4 which isn't enabled by default in most versions of Windows. To fix this issue:

1.   Navigate to your PowerShell directory. It should be _C:\Windows\System32\WindowsPowerShell\v1.0_, but if it's not, it can be found by typing `$PSHome` in a PowerShell terminal.
2.   Create a PowerShell.Exe.config (powershell_ise.exe.config if using the PowerShell Integrated Scripting Environment) file with the following contents:

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