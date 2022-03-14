using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace GrapeFruitCSharp
{
    public class SystemVars
    {
        public const string systemName = "GrapeFruit OS CSharp";
        public const string systemVersion = "0.0.1";
        public const string systemBuild = systemVersion + "CSharpTest";

        //Is the system currently running as a live CD
        //Uncomment the appropriate line
        public const bool isLive = true;
        //public const bool isLive = false;

        //Is this a closed build
        public const bool isTestBuild = true;

        //People who helped me make the OS
        public const string credits = "System made by Balázs Markgruber (https://www.github.com/balika0105)" +
            "\nDevelopment framework: Cosmos (https://github.com/CosmosOS/Cosmos)" +
            "\nGraphics drivers provided by Codsie OS (https://github.com/Codsie/CodsieOS)";
    }
}
