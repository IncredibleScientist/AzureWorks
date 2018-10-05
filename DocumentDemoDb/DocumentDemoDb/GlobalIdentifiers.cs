using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DocumentDemoDb
{
    public static class GlobalIdentifiers
    {

       
        public static string EndPoint = "<URI obained from portal>";
            //(alternate)Environment.GetEnvironmentVariable("EndPointOfDb");
        public static string AuthKey ="<Primary key from portal>";
            //Environment.GetEnvironmentVariable("AuthKey");
        public static string MyLinkCollection = "<dbs/your db name/colls/your coloum name/>";
            //Environment.GetEnvironmentVariable("MyLinkCollection");

    }
}
