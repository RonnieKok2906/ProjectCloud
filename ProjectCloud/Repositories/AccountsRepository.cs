using MongoDB.Bson;
using MongoDB.Driver;
using ProjectCloud.Models;
using System;
using System.Threading.Tasks;

namespace ProjectCloud.Repositories
{
    public class AccountsRepository : BaseRepository, IAccountRepository
    {
        //private readonly IMongoCollection<Account> accountCollection;

        public AccountsRepository(string databaseName, string collectionName, string databaseUrl) : base(databaseName, collectionName, databaseUrl)
        {

        }

        public async Task<bool> InsertAccountToDBAsync(Account account)
        {
            try
            {
                account.AccountId = $"{Guid.NewGuid().ToString()}";
                await this.accountCollection.InsertOneAsync(account);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<Account> GetAccountFromDBAsync(string accountId)
        {
            BsonDocument filter = new BsonDocument("account_id", accountId);

            IAsyncCursor<Account> result = await this.accountCollection.FindAsync<Account>(filter);

            return result.FirstOrDefault();
        }
    }
}
