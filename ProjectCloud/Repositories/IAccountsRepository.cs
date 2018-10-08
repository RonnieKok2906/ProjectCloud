using System.Threading.Tasks;

namespace ProjectCloud
{
    public interface IAccountsRepository : IBaseRepository
    {
        Task<bool> InsertAccountAsync(Account account);
        Task<Account> GetAccountAsync(string accountId);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(string accountId);
    }
}
