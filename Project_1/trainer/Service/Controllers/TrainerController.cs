using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : Controller
    {

        [HttpGet("City/{city}")]
        public IActionResult FindCity([FromRoute] string city)
        {
            FindTrainerLogic findTrainerLogic = new FindTrainerLogic();
            var q = findTrainerLogic.UsingCity(city);
            return Ok(q);

        }

        [HttpGet("Skill/{skill}")]
        public IActionResult FindSkill([FromRoute] string skill)
        {
            FindTrainerLogic findTrainerLogic = new FindTrainerLogic();
            var q = findTrainerLogic.UsingSkill(skill);
            return Ok(q);
        }

        [HttpGet("Certification/{cert}")]
        public IActionResult FindCertification([FromRoute] string cert)
        {
            FindTrainerLogic findTrainerLogic = new FindTrainerLogic();
            var q = findTrainerLogic.UsingCertification(cert);
            return Ok(q);
        }
    }

}

