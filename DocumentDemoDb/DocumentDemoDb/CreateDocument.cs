using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDemoDb
{
    public class CreateDocument
    {
        

        protected static void CreateCosmosDocument(DocumentClient client,String Id, string Name, int Age)
        {
            Employee _employee1 = new Employee
            {
                Id = Id,
                Age = Age,
                Name = Name
            };
            Task createEmployee = client.UpsertDocumentAsync
            (GlobalIdentifiers.MyLinkCollection, _employee1);
            Task.WaitAll(createEmployee);
            Console.WriteLine("Document is inserted");
        }
    }
}
