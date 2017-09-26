. .\help.ps1
. .\settings.ps1

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
$currName = $settings.Current.Namespace
$newName = $settings.Target.Namespace
$namePattern = "*{0}*" -f $currName

## Rename all files in a repository
Get-ChildItem -Path $namePattern -File -Recurse | % {
	Rename-Item -Path $_.PSPath -NewName (
		$_.name -replace $currName, $newName
	)
} | out-null

## And only then rename folder, to avoid missing files
Get-ChildItem -Path $namePattern -Directory | ForEach-Object -Process {
	Rename-item -Path $_.Name -NewName (
		$_.name -replace $currName, $newName
	)
} | out-null

# Commit file/folder name update
git add .
git commit -m $settings.GitMoveMessage
