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
    public class ScoreController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ScoreController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsScore = _context.Scorelearnings.ToList();
            return Ok(dsScore);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Score = _context.Scorelearnings.SingleOrDefault(sc => sc.Idscore == id);
            if (Score != null)
            {
                return Ok(Score);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Scoremodel model)
        {
            try
            {
                var Score = new Scorelearning
                {
                   Scorediligence = model.Scorediligence,
                   Scoreoral = model.Scoreoral,
                   Score15min = model.Score15min,
                   Scorecorfficient2 = model.Scorecorfficient2,
                   Scorecorfficient3 = model.Scorecorfficient3,
                   Mediumscore = model.Mediumscore,
                   Totalscore = model.Totalscore,
                   Result = model.Result,
                   Updatedate = model.Updatedate,
                   Idstudent = model.Idstudent,
                   Idsubject = model.Idsubject

                };

                _context.Add(Score);
                _context.SaveChanges();
                return Ok(Score);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Scoremodel model)
        {
            var Score = _context.Scorelearnings.SingleOrDefault(sc => sc.Idscore == id);
            if (Score != null)
            {
                Score.Scorediligence = model.Scorediligence;
                Score.Scoreoral = model.Scoreoral;
                Score.Score15min = model.Score15min;
                Score.Scorecorfficient2 = model.Scorecorfficient2; ;
                Score.Scorecorfficient3 = model.Scorecorfficient3;
                Score.Mediumscore = model.Mediumscore;
                Score.Totalscore = model.Totalscore;
                Score.Result = model.Result;
                Score.Updatedate = model.Updatedate; 
                Score.Idstudent = model.Idstudent;
                Score.Idsubject = model.Idsubject;
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
                var Score = _context.Scorelearnings.SingleOrDefault(sc => sc.Idscore == id);
                if (Score != null)
                {
                    _context.Remove(Score);
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
