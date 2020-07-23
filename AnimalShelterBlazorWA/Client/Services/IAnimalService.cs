using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalShelterBlazorWA.Shared;

namespace AnimalShelterBlazorWA.Client.Services
{
    public interface IAnimalService
    {
        Task<Animal> GetAnimal(int id);
        
        Task Add(Animal animal);
        
        Task Update(Animal animal);
        
        Task Delete(Animal animal);
        Task<List<Animal>> GetAllAnimalsInShelter();
    }
}