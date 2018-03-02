#Connect-PnPOnline -Url https://folkis2017.sharepoint.com/sites/TimClassic -UseWebLogin
Connect-PnPOnline -Url https://folkis2017.sharepoint.com/sites/TimClassic -Credentials Folkis2017


New-PnPList -Title "Calculator" -Template GenericList

$list = Get-PnPList -Identity "Calculator"


Add-PnPField -List $list -DisplayName "Number 1" -InternalName "calcnum1" -Type Number -Id D41F4492-23D9-487C-ACA3-2D8F9CA41E00
Add-PnPField -List $list -DisplayName "Operator" -InternalName "calcOperator" -Type choice -Id C320C22B-F4AD-47B8-BD8B-983E41C60F16 -Choices "plus","minus","devided","multipy"
Add-PnPField -List $list -DisplayName "Number 2" -InternalName "calcnum2" -Type Number -Id D9F13862-3861-4710-A945-0F17619C25E8
Add-PnPField -List $list -DisplayName "Result" -InternalName "calcResult" -Type Number -Id 70521561-FE64-408C-8D9F-7567768F2993



New-PnPList -Title "Name" -Template GenericList
$list2 = Get-PnPList -Identity "Name"

Add-PnPField -List $list2 -DisplayName "First Name" -InternalName "FName" -Type text -Id D41F4492-23D9-487C-ACA3-2D8F9CA41E00
Add-PnPField -List $list2 -DisplayName "Last Name" -InternalName "LName" -Type text -Id C320C22B-F4AD-47B8-BD8B-983E41C60F16 -Choices "plus","minus","devided","multipy"
Add-PnPField -List $list2 -DisplayName "Full Name" -InternalName "FullName" -Type text -Id D9F13862-3861-4710-A945-0F17619C25E8
