using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDemoDb
{
    class UpdateDocument:ReadAllDocuments
    {

      
        GetDocument GetDocument = new GetDocument();
        protected  static void UpdateCosmosDocument(DocumentClient Client, String Id, String Name, int Age)
        {
            // Update a Document
            var employeeToUpdate =
                  Client.CreateDocumentQuery<Employee>(GlobalIdentifiers.MyLinkCollection)
                        .Where(e => e.Id == Id)
                        .AsEnumerable()
                        .FirstOrDefault();

                Document doc = GetDocument.GetDocumentById(Client, employeeToUpdate.Id);
                Employee employeUpdated = employeeToUpdate;
                employeUpdated.Age = Age;
                employeUpdated.Name = Name;
                Task updateEmployee = Client.ReplaceDocumentAsync(doc.SelfLink,
                    employeUpdated);
                Task.WaitAll(updateEmployee);

           
            var EmployeeDetail =
               Client.CreateDocumentQuery<Employee>
               (GlobalIdentifiers.MyLinkCollection)
                   .Where(e => e.Id == employeeToUpdate.Id)
                   .AsEnumerable().First();


            Console.WriteLine("-------- Read a updated document---------");
            Console.WriteLine(EmployeeDetail.Id);
            Console.WriteLine(EmployeeDetail.Name);
            Console.WriteLine(EmployeeDetail.Age);
            Console.WriteLine("-------------------------------");
        }

      
    }
}
