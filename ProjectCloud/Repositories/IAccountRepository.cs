using System.Threading.Tasks;

namespace ProjectCloud
{
    public interface IAccountRepository : IBaseRepository
    {
        Task<bool> InsertAccountToDBAsync(Account account);
        Task<Account> GetAccountFromDBAsync(string accountId);
        Task<bool> DeleteAccountFromDBAsync(string accountId);
    }
}
