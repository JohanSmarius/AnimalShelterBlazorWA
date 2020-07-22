using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Shared;
using AnimalShelterBlazorWA.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterBlazorWA.Server.Controllers
{
    [Authorize]
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
        public IEnumerable<Animal> Get()
        {
            return _context.Animals.ToArray();
        }


        [HttpGet("{Id}")]
        public Animal Get(int id)
        {
            return _context.Animals.SingleOrDefault(a => a.Id == id);
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

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Animal animal)
        {
            var animalInStore = _context.Animals.SingleOrDefault(a => a.Id == animal.Id);

            if (animalInStore != null)
            {
                animalInStore.Name = animal.Name;
                animalInStore.AnimalKind = animal.AnimalKind;
                animalInStore.DateOfBirth = animal.DateOfBirth;
                animalInStore.EstimatedAge = animal.EstimatedAge;
                animalInStore.Gender = animal.Gender;
                animalInStore.PictureUrl = animal.PictureUrl;

                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
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
