using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace IOTHubBlazor.DAL
{
    public class MongoDB
    {
        public MongoDB()
        {
            //const string connectionUri = "mongodb+srv://localhost:27017/?connectionTimeoutMS=60000&tls=true";


            var settings = new MongoClientSettings()
            {
                Scheme = ConnectionStringScheme.MongoDB,
                Server = new MongoServerAddress("localhost", 27017),
                ConnectTimeout = new TimeSpan(0, 0, 60),
            };
            
            MongoClient dbClient = new MongoClient(settings);

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

            IMongoDatabase MongoDB = dbClient.GetDatabase("bookstore");

            Console.WriteLine(MongoDB);

            //MongoDB.CreateCollection("Reee");

            Console.WriteLine(MongoDB);

        }
    }
}