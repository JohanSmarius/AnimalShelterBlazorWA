using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalShelterBlazorWA.Shared;

namespace AnimalShelterBlazorWA.Client.Services
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        
        Task Add(Product product);
        
        Task Update(Product product);
        
        Task Delete(Product product);
        
        Task<List<Product>> GetAllProducts();
    }
}