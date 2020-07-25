
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

public class RegexCompilationTest
{
    public static void RegexToAssembly(List<RegexCompilationInfo> rcilist, string name)
    {
        var comparr = new RegexCompilationInfo[rcilist.Count];
        var asmname = new AssemblyName(string.Format("{0}, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null", name));
        rcilist.CopyTo(comparr);
        Regex.CompileToAssembly(comparr, asmname);
    }

    public static void Main(string[] args)
    {
        string name;
        string rxname;
        string rxtext;
        var rcilist = new List<RegexCompilationInfo>();
        if(args.Length > 1)
        {
            name = args[0];
            for(var i=1; i<args.Length; i++)
            {
                rxtext = args[i];
                rxname = string.Format("rx{0}", i);
                var rci = new RegexCompilationInfo(
                    rxtext,
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant,
                    rxname,
                    "Utilities.RegularExpressions",
                    true
                );
                rcilist.Add(rci);
                Console.WriteLine("added '{0}'", rxname);
            }
            Console.WriteLine("now compiling to assembly '{0}' ...", name);
            RegexToAssembly(rcilist, name);
            Console.WriteLine("done");
        }
        else
        {
            Console.WriteLine("usage: <name-of-assembly> <regex> [<another-regex ...>]");
        }
    }
}
