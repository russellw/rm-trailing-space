MSBuild.exe rm-trailing-space.sln /p:Configuration=Debug /p:Platform="Any CPU"
if errorlevel 1 goto :eof
echo trailing yes >test-yes.txt
echo trailing no>test-no.txt
bin\Debug\rm-trailing-space *.txt
type test-yes.txt
