$root = (Get-Item $PSScriptRoot).Parent;

function Write-Log ($message) {
	$time = $(Get-Date -Format 'yyyy-MM-DD HH:mm:ss')
	Write-Host "[${time}] ${message}"
}

function Get-All-Files (
	[string] $path = $PWD,
	[string] $ext = '*.cs'
) {
	foreach ($item in Get-ChildItem -Path "${path}\*" -Include $ext -Recurse -Force)
	{
		$item.FullName.Replace("${path}\", '')
	}
}
