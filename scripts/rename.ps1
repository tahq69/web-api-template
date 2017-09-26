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

$files = Get-All-Files $root $settings.UpdateFiles
Update-Content $files

cd ..

git add .
git commit -m $settings.GitUpdateMessage

cd scripts
