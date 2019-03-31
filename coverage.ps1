param(	
	$Mode = "Debug"    
) 

$msbuildpath = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"
$ncover = "./packages/OpenCover.4.7.922/tools/OpenCover.Console.exe"
$nreport = "./packages/ReportGenerator.4.0.15/tools/net47/ReportGenerator.exe"
$nunit = "./packages/NUnit.Runners.Net4.2.6.4/tools/nunit-console.exe"

$CurrentDirectory =  (Split-Path $MyInvocation.MyCommand.Path -parent)

$NUnitProject = './Tests/Searchfight.UnitTest/Searchfight.UnitTest.csproj'

& $msbuildpath $NUnitProject /t:build /p:Configuration=$Mode /p:DefineConstants="CODE_ANALYSIS" /verbosity:quiet

if ($lastexitcode -gt 0){
	exit $lastexitcode
}

$output_build = join-path $CurrentDirectory "\Tests\UniTestCoverage\"

if (test-path $output_build ) {
    Remove-Item -recurse -force $output_build/*
}  
else
{
    mkdir  $output_build
}

$tmp_result_cover = join-path $output_build 'UnitTestCoverage.xml'         

& $ncover -register:user "-target:$nunit" "-targetargs:/noshadow /framework:4.5  $NUnitProject" -output:"$tmp_result_cover"     

$output_report = join-path $output_build "ReportUnitCover" 

& $nreport -reports:$tmp_result_cover -targetdir:$output_report