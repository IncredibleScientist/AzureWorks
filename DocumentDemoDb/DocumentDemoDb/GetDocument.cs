using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentDemoDb
{
    class GetDocument
    {
       
        public  static Document GetDocumentById(DocumentClient Client, string Id)
        {
            return Client.CreateDocumentQuery(GlobalIdentifiers.MyLinkCollection)
                   .Where(e => e.Id == Id)
                   .AsEnumerable()
                   .First();
        }
    }
}
