$exe = "../Debug/Inverse.exe";
 
for ($i = 1; $i -lt 8; $i++)
{
	$command = "$i.txt";
	Write-Output "Running $command";
	Invoke-Expression "& `"./$exe`" $command";
	Write-Output "";
}