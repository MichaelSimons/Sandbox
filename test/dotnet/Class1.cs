using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {
        private static readonly string s_varShaPattern = $"[ \\$](?<{EnvNameGroupName}>(dotnet_|aspnetcore_)sha512)( )*=( )*'(?<{ValueGroupName}>[^'\\s]*)'";

        private static readonly Regex s_downloadUrlRegex = new Regex($"({s_envDownloadUrlPattern})|{s_inlineUrlPattern}");
        
        public Class1()
        {
        }
    }
}
