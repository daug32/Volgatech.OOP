$dir = "./bin/Debug/net6.0";
$exe = "Replacer.exe";
$tests = "../../../TestFiles/"

Push-Location $dir

$command = "$tests/1.txt $tests/1.output.txt Repeat REPLACED"
Invoke-Expression "& `"./$exe`" $command"

$command = "$tests/2.txt $tests/2.output.txt Repeat REPLACED"
Invoke-Expression "& `"./$exe`" $command"

$command = "$tests/3.txt $tests/3.output.txt Repeat REPLACED"
Invoke-Expression "& `"./$exe`" $command"

$command = "$tests/4.txt $tests/4.output.txt : COLUMN"
Invoke-Expression "& `"./$exe`" $command"

$command = "$tests/5.txt $tests/5.output.txt long-long REPLACED"
Invoke-Expression "& `"./$exe`" $command"

$command = "$tests/6.txt $tests/6.output.txt `"`" REPLACED"
Invoke-Expression "& `"./$exe`" $command"

Pop-Location