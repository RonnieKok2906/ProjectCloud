using ProjectCloud.Models;
using System.Threading.Tasks;

namespace ProjectCloud.Repositories
{
    public interface IAccountRepository : IBaseRepository
    {
        Task<bool> InsertAccountToDBAsync(Account account);
        Task<Account> GetAccountFromDBAsync(string accountId);
    }
}
