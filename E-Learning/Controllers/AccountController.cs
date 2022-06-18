using E_Learning.Data;
using E_Learning.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsAccount = _context.Accounts.ToList();
            return Ok(dsAccount);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Account = _context.Accounts.SingleOrDefault(acc => acc.Idaccount == id);
            if (Account != null)
            {
                return Ok(Account);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Accountmodel model)
        {
            try
            {
                var Account = new Account
                {
                    User = model.User,
                    Password = model.Password,
                    Gmail = model.Gmail,
                    Phone = model.Phone,
                    Type = model.Type,
                    Createdate = model.Createdate
                };
                _context.Add(Account);
                _context.SaveChanges();
                return Ok(Account);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Accountmodel model)
        {
            var Account = _context.Accounts.SingleOrDefault(acc => acc.Idaccount == id);
            if (Account != null)
            {
                Account.User = model.User;
                Account.Password = model.Password;
                Account.Gmail = model.Gmail;
                Account.Phone = model.Phone;
                Account.Type = model.Type;
                Account.Createdate = model.Createdate;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var Account = _context.Accounts.SingleOrDefault(acc => acc.Idaccount == id);
                if (Account != null)
                {
                    _context.Remove(Account);
                    _context.SaveChanges();
                    return Ok();

                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
