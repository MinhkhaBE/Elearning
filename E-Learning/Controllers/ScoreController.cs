using E_Learning.Data;
using E_Learning.Interfaces;
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
        private readonly IRepository _ElearRepository;

        public ScoreController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllScore());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Score = _ElearRepository.GetByIdScore(id);
                if (Score != null)
                {
                    return Ok(Score);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(Scorelearning model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewScore(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Scoremodel score)
        {
            if (id != score.Idscore)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdScore(score);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _ElearRepository.DeleteByIdScore(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
