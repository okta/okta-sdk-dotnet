@{
    RootModule = '.\bin\Okta.Core.Automation.dll'
    ModuleVersion = '1.0.1'
    GUID = 'f6ca9728-563d-4cbc-874e-118b8387b0c2'
    Author = 'Okta'
    CompanyName = 'Okta'
    Copyright = 'Okta, Inc. All rights reserved'
    Description = 'Manage Okta with PowerShell'
    PowerShellVersion = '3.0'
    DotNetFrameworkVersion = '4.0'
    RequiredModules = @()
    RequiredAssemblies = @()
    ScriptsToProcess = @()
    TypesToProcess = @()
    FormatsToProcess = @()
    NestedModules = @()
    FunctionsToExport = @()
    CmdletsToExport = @(
        'Connect-Okta',
        'Get-OktaUser',
        'Set-OktaUser',
        'New-OktaUser',
        'Unlock-OktaUser',
        'Enable-OktaUser',
        'Disable-OktaUser',
        'Delete-OktaUser',
        'Set-OktaUserResetPassword',
        'Get-OktaGroup',
        'New-OktaGroup',
        'Add-OktaGroupMember',
        'Get-OktaGroupMember',
        'Remove-OktaGroupMember',
        'Get-OktaUserGroups',
        'Get-OktaAppUser',
        'Set-OktaAppUser',
        'Remove-OktaAppUser',
        'Enroll-OktaUserFactor',
        'Activate-OktaUserFactor',
        'Get-OktaUserFactor',
        'Reset-OktaUserFactor',
        'Get-OktaEvents',
        'Get-OktaApp'
        )
    VariablesToExport = @()
    AliasesToExport = @()
    ModuleList = @()
    FileList = @(".\bin\Okta.Core.Automation.dll")

PrivateData = @{
    # PSData is module packaging and gallery metadata embedded in PrivateData
    # It's for rebuilding PowerShellGet (and PoshCode) NuGet-style packages
    # We had to do this because it's the only place we're allowed to extend the manifest
    # https://connect.microsoft.com/PowerShell/feedback/details/421837
    PSData = @{
        # The primary categorization of this module (from the TechNet Gallery tech tree).
        Category = "Identity"

        # Keyword tags to help users find this module via navigations and search.
        Tags = @('okta', 'sdk', 'api', 'authentication' , 'identity', 'management')

        # The web address of an icon which can be used in galleries to represent this module
        IconUri = "https://www.okta.com/sites/all/themes/Okta/images/logo.png"

        # The web address of this module's project or support homepage.
        ProjectUri = "https://github.com/okta/okta-sdk-dotnet/blob/legacy/Okta.Core.Automation/README.md"

        # The web address of this module's license. Points to a page that's embeddable and linkable.
        LicenseUri = "https://github.com/okta/okta-sdk-dotnet/blob/master/LICENSE"

        # Indicates this is a pre-release/testing version of the module.
        IsPrerelease = 'False'
		}
	}
}
