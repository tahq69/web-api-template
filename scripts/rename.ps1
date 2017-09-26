. .\scripts\help.ps1
. .\scripts\settings.ps1

Write-Log "Starting to rename project."

# Check that user has configured settings.ps1 file
$isNameDefault = $settings.Target.Name -eq 'Name'
$isDescriptionDefault = $settings.Target.Description -eq 'Description'
$isNamespaceDefault = $settings.Target.Namespace -eq 'Namespace.Default'

if ($isNameDefault -or $isDescriptionDefault -or $isNamespaceDefault) {
	## Stop if no changes made in settings
	throw 'Update "settings.ps1" Target section before run this script'
}

# Update file content
$files = Get-All-Files $root $settings.UpdateFiles
Update-Content $files

# Commit content update
git add .
git commit -m $settings.GitUpdateMessage

# Update file/folder names
Update-Names

# Commit file/folder name update
git add .
git commit -m $settings.GitMoveMessage
