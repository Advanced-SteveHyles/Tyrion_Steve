<#
$strString = "Hello World"
write-host $strString

$strString = "No longer"
write-host $strString

$test = "is this a string?"
write-host $test

ipconfig | findstr "Broadband"
write-host $test

ipconfig | findstr "disconnected"

ipconfig | findstr "disconnected" | format-table


write-host "raw list"
rem get-service | format-list

write-host "raw table"
rem get-service | format-table 

write-host "formatted table"
rem get-service | format-table -property *

rem get-service | format-table
#>

Get-WmiObject -class Win32_processor | format-table 

$env:username
[System.Security.Principal.WindowsIdentity]::GetCurrent().Name


[system.environment]::MachineName
Get-WMIObject Win32_ComputerSystem  | format-table

Function Get-VComputerName {return [system.environment]::MachineName}


Get-VComputerName

write-host "Computername = " $(Get-VComputerName)


function Add-Numbers
{
	$args[0] + $args[1]
}

$(Add-Numbers 1 50)