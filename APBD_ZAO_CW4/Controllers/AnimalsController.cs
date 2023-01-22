using APBD_ZAO_CW4.DAL;
using APBD_ZAO_CW4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APBD_ZAO_CW4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public AnimalsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult GetAnimals([FromQuery] string orderBy)
        {
            return Ok(_dbService.GetAnimals(orderBy));
        }

        [HttpPost]
        public IActionResult PostAnimal([FromBody] Animal animal)
        {
            _dbService.CreateAnimal(animal);

            return Ok("Added new Animal");
        }

        [HttpPut("{idAnimal}")]
        public IActionResult PutAnima([FromRoute] int idAnimal, [FromBody] Animal animal)
        {
            if (_dbService.CheckAnimalById(idAnimal) == false) { 
            return NotFound("Animal not found");
        }
            else {
                _dbService.ChangeAnimal(idAnimal, animal);
                return Ok("Animal changed");
            }
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal([FromRoute] int idAnimal)
        {
            if (_dbService.CheckAnimalById(idAnimal) == false)
            {
                return NotFound("Animal not found");
            }
            else
            {
                _dbService.DeleteAnimal(idAnimal);
                return Ok("Animal deleted");
            }
        }


    }
}
