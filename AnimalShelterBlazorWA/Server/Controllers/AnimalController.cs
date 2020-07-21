using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Shared;
using AnimalShelterBlazorWA.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterBlazorWA.Server.Controllers
{
 //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Animal> Get()
        {
            return _context.Animals.ToArray();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == id);

            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult<Animal> Add(Animal newAnimal)
        {
            var addedAnimal = _context.Animals.Add(newAnimal);
            _context.SaveChanges();

            return Ok(addedAnimal.Entity);
        }


    }
}
