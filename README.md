
This little program wraps [CompileToAssembly](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.compiletoassembly), to compile regular expressions into an assembly file.  
It's deliberately fairly bare-boned, not least because `CompileToAssembly` doesn't offer much in terms of customization.

Usage:

    ./main.exe foo '\.txt$'

This would create an assembly named `foo.dll`, containing the namespace `Utilities.RegularExpressions`, and the classes `rx1`, `rx1Factory`, and `rx1Runner`. The name of each compiled regular expression is thusly `rx1`, `rx2`, `rx3` ..., and so on.

In conjunction with a C# decompiler, this is a great way to study regular expressions (and their state machines therein), which is what I primarily use it for. 

