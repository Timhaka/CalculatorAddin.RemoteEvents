#Connect-PnPOnline -Url https://folkis2017.sharepoint.com/sites/TimClassic -UseWebLogin
Connect-PnPOnline -Url https://folkis2017.sharepoint.com/sites/TimClassic -Credentials Folkis2017

New-PnPList -Title "Name" -Template GenericList
$list2 = Get-PnPList -Identity "Name"

Add-PnPField -List $list2 -DisplayName "First Name" -InternalName "FName" -Type text -Id D41F4492-23D9-487C-ACA3-2D8F9CA41E00
Add-PnPField -List $list2 -DisplayName "Last Name" -InternalName "LName" -Type text -Id C320C22B-F4AD-47B8-BD8B-983E41C60F16 
Add-PnPField -List $list2 -DisplayName "Full Name" -InternalName "FullName" -Type text -Id D9F13862-3861-4710-A945-0F17619C25E8


$flds = Get-PnPField -Identity FullName

$flds.ReadOnlyField
$flds.Update();