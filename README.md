# A c# demo project searchfight

## You can compare many words againts google and bing search engines
```
./Version1/searchfight.exe java "java script" .net   
java: bing: 23400000 google: 873000000  
java script: bing: 42000000 google: 4310000000  
net: bing: 125000000 google: 19900000000  
bing winner: net  
google winner: net  
Total winner: net  
```
## Development 

### Architecture 

Based on onion architecture 

![onion architecture](https://github.com/gcvalderrama/searchfight/blob/master/onion.png)

### Dependencies
```
Nuget 
Visual Studio 2017 
```
### Process

* Nuget restore 
* Execute build.ps1 
* To review Unit Test Coverage use coverage.ps1
* Sample here [Unit Test Coverage](http://htmlpreview.github.com/?https://github.com/gcvalderrama/searchfight/blob/master/Tests/UniTestCoverage/ReportUnitCover/index.htm)
 






