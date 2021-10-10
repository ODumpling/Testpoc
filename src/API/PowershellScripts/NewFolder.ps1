param (
[string]$folderpath
)

New-Item -Path $folderpath -ItemType Directory

Write-Output "folder path $folderpath has been created";