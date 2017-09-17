. .\help.ps1
. .\settings.ps1

Write-Log "Starting to rename project."

$isNameDefault = $settings.Target.Name -eq 'Name'
$isDescriptionDefault = $settings.Target.Description -eq 'Description'
$isNamespaceDefault = $settings.Target.Namespace -eq 'Namespace.Default'

<# TODO: return this block, when complete functionality
if ($isNameDefault -or $isDescriptionDefault -or $isNamespaceDefault) {
	throw 'Update "settings.ps1" Target section before run this script'
}
#>

$csFiles = Get-All-Files $root.FullName '*.cs'
$projFiles = Get-All-Files $root.FullName '*.csproj'
$configFiles = Get-All-Files $root.FullName '*.config'
$slnFiles = Get-All-Files $root.FullName '*.sln'

