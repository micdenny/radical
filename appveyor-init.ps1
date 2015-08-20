$checkVersion = "$Env:APPVEYOR_BUILD_VERSION" -match "(?<major>[0-9]+)\.(?<minor>[0-9])+\.(?<patch>([0-9]+))(-(?<prerelease>[a-zA-Z0-9]+))?(\+(?<build>([0-9]+)))?"
$major = $matches['major'] -as [int]
$minor = $matches['minor'] -as [int]
$patch = $matches['patch'] -as [int]
$prerelease = $matches['prerelease']
$build = $matches['build'] -as [int]
      
$assemblyVersion = "$major.$minor.$patch.0"
$assemblyFileVersion = "$major.$minor.$patch.$build"
$assemblyInformationalVersion = "$Env:APPVEYOR_BUILD_VERSION"
if ($prerelease) {
$packageVersion = "$major.$minor.$patch-$prerelease"
} else {
$packageVersion = "$major.$minor.$patch"
}
      
Set-AppveyorBuildVariable -Name "assembly_major" -Value "$major"
Set-AppveyorBuildVariable -Name "assembly_minor" -Value "$minor"
Set-AppveyorBuildVariable -Name "assembly_patch" -Value "$patch"
Set-AppveyorBuildVariable -Name "assembly_prerelease" -Value "$prerelease"
Set-AppveyorBuildVariable -Name "assembly_build" -Value "$build"
      
Set-AppveyorBuildVariable -Name "assembly_version" -Value "$assemblyVersion"
Set-AppveyorBuildVariable -Name "assembly_file_version" -Value "$assemblyFileVersion"
Set-AppveyorBuildVariable -Name "assembly_informational_version" -Value "$assemblyInformationalVersion"
Set-AppveyorBuildVariable -Name "package_version" -Value "$packageVersion"
      
Write-Host "Assembly Version: $assemblyVersion"
Write-Host "Assembly File Version: $assemblyFileVersion"
Write-Host "Assembly Informational Version: $assemblyInformationalVersion"
Write-Host "Package Version: $packageVersion"