using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCloud.Models;
using ProjectCloud.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCloud.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private IAccountRepository accountRepository;

        public AccountsController()
        {
            this.accountRepository = new AccountsRepository("account", "accounts", "localhost");
        }

        // GET: api/accounts
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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
