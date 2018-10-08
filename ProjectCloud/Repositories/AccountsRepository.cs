using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace ProjectCloud
{
    public class AccountsRepository : BaseRepository, IAccountsRepository
    {
        public AccountsRepository(string databaseName, string collectionName, string databaseUrl) : base(databaseName, collectionName, databaseUrl)
        {

        }

        public async Task<bool> InsertAccountAsync(Account account)
        {
            try
            {
                account.ID = ObjectId.GenerateNewId();
                account.AccountId = $"{Guid.NewGuid().ToString()}";
                await this.accountCollection.InsertOneAsync(account);

                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<Account> GetAccountAsync(string accountId)
        {
            try
            {
                BsonDocument filter = new BsonDocument("account_id", accountId);

                IAsyncCursor<Account> result = await this.accountCollection.FindAsync<Account>(filter);

                return result.FirstOrDefault();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            try
            {
                Account accountFromDB = await this.GetAccountAsync(account.AccountId);

                if (accountFromDB != null)
                {
                    account.ID = accountFromDB.ID;

                    FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(a => a.AccountId, account.AccountId);

                    ReplaceOneResult result = await accountCollection.ReplaceOneAsync(filter, account);

                    if (result.IsAcknowledged)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAccountAsync(string accountId)
        {
            try
            {
                //ObjectId objectId = ObjectId.Parse(accountId);
                DeleteResult result = await this.accountCollection.DeleteOneAsync<Account>(a => a.AccountId == accountId);

                if (result.IsAcknowledged)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
