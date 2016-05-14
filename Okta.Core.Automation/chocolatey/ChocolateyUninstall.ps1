$packageName = 'Okta.Core.Automation'
$folder = "$($Home)\Documents\WindowsPowerShell\Modules\$($packageName)"

try {
	Remove-Item "$($folder)" -recurse -force
} catch {
	throw
	}