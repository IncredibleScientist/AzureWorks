using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDemoDb
{
    class DeleteDocument:UpdateDocument
    {
       
        GetDocument getDocument = new GetDocument();
        protected static void DeleteDocumentFromCosmos(DocumentClient Client, String Id)
        {
            var employeeToDelete =
              Client.CreateDocumentQuery<Employee>(GlobalIdentifiers.MyLinkCollection)
                    .Where(e => e.Id == Id)
                    .AsEnumerable()
                    .First();

            Document DocumenttoDelete = GetDocument.GetDocumentById(Client, employeeToDelete.Id);


            Task DeleteEmployee = Client.DeleteDocumentAsync(DocumenttoDelete.SelfLink);

            Task.WaitAll(DeleteEmployee);
            Console.WriteLine("----List after deleting---");
            var Employees = Client.CreateDocumentQuery<Employee>
         (GlobalIdentifiers.MyLinkCollection).AsEnumerable();
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee.Id);
                Console.WriteLine(employee.Name);
                Console.WriteLine(employee.Age);
                Console.WriteLine("----------------------------------");
            }

        }
      
    }
}
