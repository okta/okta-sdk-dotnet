$packageName = 'Okta.Core.Automation'
$folder = "$($Home)\Documents\WindowsPowerShell\Modules\$($packageName)"

try {
	Remove-Item "$($folder)" -recurse -force
	Write-ChocolateySuccess $packageName
} catch {
	Write-ChocolateyFailure $packageName "$($_.Exception.Message)"
	throw
}