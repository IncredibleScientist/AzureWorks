using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDemoDb
{
    class ReadAllDocuments:CreateDocument
    {
        //static readonly string MyLinkCollection = GlobalIdentifiers.MyLinkCollection;
        protected static Task<List<Employee>> GetEmployees(DocumentClient Client)
        {
            var Manager = Client.CreateDocumentQuery<Employee>
            (GlobalIdentifiers.MyLinkCollection).AsEnumerable();
            foreach (var item in Manager)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Age);
                Console.WriteLine("***********************************************************");
            }
            return Task.Run(() => Manager.ToList());

        }
    }
}
