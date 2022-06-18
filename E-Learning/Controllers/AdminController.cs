using E_Learning.Data;
using E_Learning.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsAdmin = _context.Admins.ToList();
            return Ok(dsAdmin);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Admin = _context.Admins.SingleOrDefault(ad => ad.Idadmin == id);
            if (Admin != null)
            {
                return Ok(Admin);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Adminmodel model)
        {
            try
            {
                var Admin = new Admin
                {
                    Nameadmin = model.Nameadmin,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    Idaccount = model.Idaccount,

                };

                _context.Add(Admin);
                _context.SaveChanges();
                return Ok(Admin);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Adminmodel model)
        {
            var Admin = _context.Admins.SingleOrDefault(ad => ad.Idadmin == id);
            if (Admin != null)
            {
                Admin.Nameadmin = model.Nameadmin;
                Admin.Phone = model.Phone;
                Admin.Gender = model.Gender;
                Admin.Idaccount = model.Idaccount;
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
                var Admin = _context.Admins.SingleOrDefault(ad => ad.Idadmin == id);
                if (Admin != null)
                {
                    _context.Remove(Admin);
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
