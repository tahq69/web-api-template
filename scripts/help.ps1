$root = (Get-Item $PSScriptRoot).Parent;

function Write-Log ($message) {
	$time = $(Get-Date -Format 'yyyy-MM-DD HH:mm:ss')
	Write-Host $('[{0}] {1}' -f $time, $message)
}

function Get-All-Files ([string]$path = $PWD, $results) {
	foreach ($item in Get-ChildItem $path) {
		if (Test-Path $item.FullName -PathType Container) {
			Get-All-Files $item.FullName $results
		} else {
			$results = $item
		}
	}
}