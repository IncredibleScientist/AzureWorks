using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DocumentDemoDb
{
    public static class GlobalIdentifiers
    {


        public static string EndPoint = "<Document Db End Point obtained from Portal>";
        //Environment.GetEnvironmentVariable("EndPointOfDb");
        public static string AuthKey = "<Document Db connection String from Portal>";
            //Environment.GetEnvironmentVariable("AuthKey");
        public static string MyLinkCollection = "dbs/your Db name/colls/your coloumn name/";
            //Environment.GetEnvironmentVariable("MyLinkCollection");

    }
}
