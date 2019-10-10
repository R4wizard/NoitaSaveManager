$msBuildExe = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe";
$makeNsisExe = "C:\Program Files (x86)\NSIS\makensis.exe";

function Build-NSM {
	Clean-Up
	Build-Solution "NoitaSaveManager.sln"
	Delete-Xml-And-Pdb
	Copy-License
	Create-Release-Installer
	Create-Release-Zip

	Write-Host "!!! Build Completed !!!" -foregroundcolor yellow
	pause
}

<# ---------------------------------------------------------------------------------------------------- #>

function Clean-Up
{
    Remove-Item -Path release -Recurse
    New-Item -Name release -ItemType directory
}

function Build-Solution
{
    param
    (
        [parameter(Mandatory=$true)]
        [String] $path
    )
	
    process
    {
		Write-Host "Restoring NuGet packages" -foregroundcolor green
		.\nuget.exe restore "$($path)"

		Write-Host "Cleaning $($path)" -foregroundcolor green
		& "$($msBuildExe)" "$($path)" /p:Configuration=Release /t:Clean /m

        Write-Host "Building $($path)" -foregroundcolor green
        & "$($msBuildExe)" "$($path)" /p:Configuration=Release /t:Build /m
    }
}

function Delete-Xml-And-Pdb
{
	Write-Host "Removing XML and PDB files" -foregroundcolor green
	rm "NoitaSaveManager\bin\Release\*.xml"
	rm "NoitaSaveManager\bin\Release\*.pdb"
}

function Copy-License
{
	Write-Host "Copying GPL license" -foregroundcolor green
	Copy-Item -Path LICENSE -Destination "NoitaSaveManager\bin\Release"
}

function Create-Release-Installer
{
	Write-Host "Creating 'install.exe' release file" -foregroundcolor green
    & "$($makeNsisExe)" NoitaSaveManager.nsi
}

function Create-Release-Zip
{
	Write-Host "Creating 'NoitaSaveManager.zip' release file" -foregroundcolor green
    Compress-Archive -Path NoitaSaveManager\bin\Release\* -CompressionLevel Optimal -DestinationPath .\release\NoitaSaveManager.zip
}

Build-NSM