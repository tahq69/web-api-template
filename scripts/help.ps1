$root = (Get-Item $PSScriptRoot).Parent.FullName;

function Write-Log ($message) {
	$time = $(Get-Date -Format 'yyyy-MM-DD HH:mm:ss')
	Write-Host "[${time}] ${message}"
}

function Get-All-Files (
	[string] $path = $PWD,
	[string] $ext = '*.cs'
) {
	foreach ($item in Get-ChildItem -Path "${path}\*" -Include $ext -Recurse -Force) {
		if (-not($item.FullName.Contains("\bin\")) -and
			-not($item.FullName.Contains("\obj\")) -and
			-not($item.FullName.Contains("\packages\")) -and
			-not($item.FullName.Contains("\.vs\"))
		) {
			Write-Log $item.FullName
			$item.FullName.Replace("${path}\", '')
		}
	}
}

function Update-Content ($files) {
	#foreach ($file in $files) {
	#	$fullFile = "${root}\${file}"
	#	
	#	Write-Log "$root : $file : $fullFile"

	#	(Get-Content $fullFile).replace($settings.Current.Namespace, $settings.Target.Namespace) | Set-Content $fullFile
	#}
}
