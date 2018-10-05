using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDemoDb
{
    class Employee
    { 
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }

    }
}
