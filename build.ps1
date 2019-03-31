param(	
	$Mode = "Release"    
) 

$msbuildpath = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"

$CurrentDirectory =  (Split-Path $MyInvocation.MyCommand.Path -parent)

$Project = './App/Searchfight/Searchfight.csproj'


$output_build = join-path $CurrentDirectory "\Version1\"

if (test-path $output_build ) {
    Remove-Item -recurse -force $output_build/*
}  
else
{
    mkdir  $output_build
}

& $msbuildpath $Project /t:build /p:Configuration=$Mode /verbosity:quiet /p:OutDir=$output_build
