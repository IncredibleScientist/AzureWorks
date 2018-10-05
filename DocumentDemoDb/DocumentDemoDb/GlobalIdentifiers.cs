using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DocumentDemoDb
{
    public static class GlobalIdentifiers
    {

       
        public static string EndPoint = Environment.GetEnvironmentVariable("EndPointOfDb");
        public static string AuthKey = Environment.GetEnvironmentVariable("AuthKey");
        public static string MyLinkCollection = Environment.GetEnvironmentVariable("MyLinkCollection");

    }
}
