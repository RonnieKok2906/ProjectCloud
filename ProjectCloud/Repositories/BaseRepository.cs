using MongoDB.Driver;
using System;

namespace ProjectCloud
{
    public class BaseRepository: IBaseRepository
    {
        protected MongoClient client;
        protected IMongoDatabase database;
        protected readonly IMongoCollection<Account> accountCollection;

        public BaseRepository(string databaseName, string collectionName, string databaseUrl)
        {
            this.client = new MongoClient(
                new MongoClientSettings
                {
                    Server = new MongoServerAddress("localhost", 27017),
                    ServerSelectionTimeout = TimeSpan.FromSeconds(3)
                });

            this.database = client.GetDatabase(databaseName);
            this.accountCollection = database.GetCollection<Account>(collectionName);
        }
    }
}
