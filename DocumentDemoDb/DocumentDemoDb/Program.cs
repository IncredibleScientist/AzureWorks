using Microsoft.Azure.Documents.Client;
using System;

namespace DocumentDemoDb
{
    class Program:DeleteDocument
    {
        static void Main(string[] args)
        {
         
            DocumentClient Client = new DocumentClient(new Uri(GlobalIdentifiers.EndPoint), GlobalIdentifiers.AuthKey);
          
            for (; ; )
            {
                Console.WriteLine("1:Create  Document \t 2:Read all Documents \t 3:Update Document \t 4:Delete Document \n Enter Your Choice");
               String Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "1":
                        String IdToInsert = Guid.NewGuid().ToString();
                        Console.WriteLine("Enter name");
                        String NameToInsert = Console.ReadLine();
                        Console.WriteLine("Enter Age");
                        int AgeToInsert = Convert.ToInt32(Console.ReadLine());

                        CreateCosmosDocument(Client, IdToInsert, NameToInsert, AgeToInsert);
                        break;

                    case "2":
                        GetEmployees(Client);
                        break;

                    case "3":
                        Console.WriteLine("Enter Id");
                        String IdToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter name");
                        String NameToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter Age");
                        int AgeToUpdate = Convert.ToInt32(Console.ReadLine());
                        UpdateCosmosDocument(Client, IdToUpdate, NameToUpdate, AgeToUpdate);
                        break;

                    case "4":
                        Console.WriteLine("Enter Id");
                        String IdToDelete = Console.ReadLine();
                        DeleteDocumentFromCosmos(Client, IdToDelete);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }

        }
    }
}
