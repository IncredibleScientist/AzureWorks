using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MSGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
           
Console.BackgroundColor = ConsoleColor.Red;

          
            GetDataAsync().GetAwaiter().GetResult();
            Console.ReadKey();
            Console.Clear();
        }

        static async Task GetDataAsync()
        {
            
            Console.BackgroundColor = ConsoleColor.Red;
            //Path of the file
            string Path = @"File location";

            byte[] Data = System.IO.File.ReadAllBytes(Path);
            Stream Stream = new MemoryStream(Data);

            PublicClientApplication clientApp = new PublicClientApplication(ConfigurationManager.AppSettings["ClientID"].ToString());
            GraphServiceClient graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0/", new DelegateAuthenticationProvider(async (requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await GetTokenAsync(clientApp));

            }));
            #region smallfile
            // small file upload
            //   var current = await graphClient.Me.Drive.Root.ItemWithPath("Team2.JPG").Content.Request().PutAsync<DriveItem>(Stream);
           
            //var x = await graphClient.Me.Request().GetAsync();
            #endregion

            var uploadSession = await graphClient.Drive.Root.ItemWithPath("file name ").CreateUploadSession().Request().PostAsync();
            

            var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.

            var provider = new ChunkedUploadProvider(uploadSession, graphClient, Stream, maxChunkSize);

            // Setup the chunk request necessities
            var chunkRequests = provider.GetUploadChunkRequests();
            var readBuffer = new byte[maxChunkSize];
            var trackedExceptions = new List<Exception>();


            DriveItem itemResult = null;

            //upload the chunks
            foreach (var request in chunkRequests)
            {
                var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);

                if (result.UploadSucceeded)
                {
                    itemResult = result.ItemResponse;
                }
            }
            Console.WriteLine("file uploaded");

            var Id = itemResult.Id;


            Console.WriteLine($"ID is\t{Id}");
            var permission = graphClient.Me.Drive.Items[Id].CreateLink(/*"view", "anonymous"*/"Permission").Request().PostAsync().Result;
            var ShareId = "https://1drv.ms/" + permission.ShareId;
            Console.WriteLine($"Sharing Link \t{ShareId}");


            //var delete = graphClient.Me.Drive.Items[Id].Request().DeleteAsync();
            //Console.WriteLine("deleted");

            //    / me / drive / root / children
           

            Console.WriteLine("enter Email Id");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var EmailId = Console.ReadLine();
            if (EmailId != "")
            {
                Console.WriteLine("Enter Subject");
                var Subject = Console.ReadLine();
                Console.WriteLine("Enter Body");
                var MainBody = Console.ReadLine();
                var BodyMergerd = MainBody + "\n" + ShareId;

                // Prepare the recipient list
                string[] Splitter = { ";" };
                var SplitRecipientsList = EmailId.Split(Splitter, StringSplitOptions.RemoveEmptyEntries);
                List<Recipient> recipientList = new List<Recipient>();

                foreach (string Recipient in SplitRecipientsList)
                {
                    recipientList.Add(new Recipient { EmailAddress = new EmailAddress { Address = Recipient.Trim() } });
                }
                var email = new Message
                {
                    Body = new ItemBody
                    {
                        Content = BodyMergerd,


                        ContentType = BodyType.Html,
                    },
                    Subject = Subject,
                    ToRecipients = recipientList,

                };

                await graphClient.Me.SendMail(email, true).Request().PostAsync();
                Console.WriteLine("sent");
            }
            else
            {
                Console.WriteLine("invalid or no email id");
                Console.ReadKey();
            }
                
        }
        static async Task<string> GetTokenAsync(PublicClientApplication clientApp)
        {
            //need to pass scope of activity to get token  
            string[] Scopes = { "User.read", "Files.ReadWrite", "Mail.Send" };
            string token = null;
            AuthenticationResult authResult = await clientApp.AcquireTokenAsync(Scopes);
            token = authResult.AccessToken;
            return token;
        }
    }
}
