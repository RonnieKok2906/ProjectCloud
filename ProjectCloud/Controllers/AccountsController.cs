using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectCloud
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private IAccountsRepository accountRepository;

        public AccountsController()
        {
            this.accountRepository = new AccountsRepository("account", "accounts", "localhost");
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Account account)
        {
            if (account != null)
            {
                if (await accountRepository.InsertAccountAsync(account))
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(500, "Cannot insert new account.");
                }
            }
            else
            {
                return StatusCode(400, "Invalid format.");
            }
        }

        // GET: api/accounts
        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(string accountId)
        {
            if (!string.IsNullOrEmpty(accountId))
            {
                Account account = await accountRepository.GetAccountAsync(accountId);

                if (account != null)
                {
                    return Json(account);
                }
                else
                {
                    return StatusCode(404, "Account not found.");
                }
            }
            else
            {
                return StatusCode(400, "No account id supplied.");
            }
        }

        // PUT api/accounts
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Account account)
        {
            if (account != null)
            {
                if (await accountRepository.UpdateAccountAsync(account))
                {
                    return StatusCode(202);
                }
                else
                {
                    return StatusCode(500, "Cannot update account.");
                }
            }
            else
            {
                return StatusCode(400, "Invalid format.");
            }
        }

        // DELETE api/accounts
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete(string accountId)
        {
            if (!string.IsNullOrEmpty(accountId))
            {
                if (await accountRepository.DeleteAccountAsync(accountId))
                {
                    return StatusCode(202);
                }
                else
                {
                    return StatusCode(500, "Cannot delete account.");
                }
            }
            else
            {
                return StatusCode(400, "No account id supplied.");
            }
        }
    }
}
