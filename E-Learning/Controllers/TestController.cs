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
    public class TestController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TestController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsTest = _context.Tests.ToList();
            return Ok(dsTest);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Test = _context.Tests.SingleOrDefault(te => te.Idtest == id);
            if (Test != null)
            {
                return Ok(Test);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Testmodel model)
        {
            try
            {
                var Test = new Test
                {
                    Nametest = model.Nametest,
                    Content = model.Content,
                    Time = model.Time,
                    Createdate = model.Createdate,
                    Score = model.Score,
                    Status = model.Status,
                    Idsubject = model.Idsubject,
                };

                _context.Add(Test);
                _context.SaveChanges();
                return Ok(Test);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Testmodel model)
        {
            var Test = _context.Tests.SingleOrDefault(te => te.Idtest == id);
            if (Test != null)
            {
                Test.Nametest = model.Nametest;
                Test.Content = model.Content;
                Test.Time = model.Time;
                Test.Createdate = model.Createdate;
                Test.Score = model.Score;
                Test.Status = model.Status;
                Test.Idsubject = model.Idsubject;
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
                var Test = _context.Tests.SingleOrDefault(te => te.Idtest == id);
                if (Test != null)
                {
                    _context.Remove(Test);
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
