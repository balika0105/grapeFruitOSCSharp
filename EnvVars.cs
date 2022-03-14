using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace GrapeFruitCSharp
{
    //MS bullsh*t
    #pragma warning disable CA2211
    #pragma warning disable IDE1006

    public class EnvVars
    {
        public static string currentUser;
        public static string currentWorkingDirectory;
        public static string home;
        public static string hostname;

        //Do we have an initialized FS
        public static bool isFS = false;

        public const string path = "";
        public static string varPath = "";

        public static void appendPath(string appendInput) {
            varPath = path + appendInput;
        }
    }
}
