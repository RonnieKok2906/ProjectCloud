using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectCloud
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private IAccountRepository accountRepository;

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
                if (await accountRepository.InsertAccountToDBAsync(account))
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }

        // GET: api/accounts/accountId=
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string accountId)
        {
            if (!string.IsNullOrEmpty(accountId))
            {
                Account account = await accountRepository.GetAccountFromDBAsync(accountId);

                if (account != null)
                {
                    return Json(account);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            else
            {
                return StatusCode(400);
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/accounts/accountId=
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string accountId)
        {
            if (!string.IsNullOrEmpty(accountId))
            {
                if (await accountRepository.DeleteAccountFromDBAsync(accountId))
                {
                    return StatusCode(202);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
