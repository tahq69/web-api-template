$root = (Get-Item $PSScriptRoot).Parent.FullName;

function Write-Log ($message) {
	$time = $(Get-Date -Format 'yyyy-MM-DD HH:mm:ss')
	Write-Host "[${time}] ${message}"
}

function Get-All-Files (
	[string] $path = $PWD,
	$exts = @('*.cs')
) {
	foreach ($ext in $exts) {
		foreach ($item in Get-ChildItem -Path "${path}\*" -Include $ext -Recurse -Force) {
			if (-not($item.FullName.Contains("\bin\"))      -and
				-not($item.FullName.Contains("\obj\"))      -and
				-not($item.FullName.Contains("\packages\")) -and
				-not($item.FullName.Contains("\.vs\")       -and
				-not($item.FullName -eq ${path}))
			) {
				$item.FullName.Replace("${path}\", '')
			}
		}
	}
}

function Update-Content ($files) {
	foreach ($file in $files) {
		$path = "$root\$file"
		Write-Log "Updating content of $file..."
		(Get-Content $path) | Foreach-Object {
			$_	-replace $settings.Current.Namespace,   $settings.Target.Namespace `
				-replace $settings.Current.Description, $settings.Target.Description `
				-replace $settings.Current.Name,        $settings.Target.Name
		} | Set-Content $path -Encoding UTF8 | Write-Log "Updating content of $file completed"
	}
}

function Update-Names () {
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
		Write-Log "Renaming dir {0}" -f $_.Name
		Rename-item -Path $_.Name -NewName (
			$_.name -replace $currName, $newName
		)
	} | out-null
}

