using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AnimalShelterBlazorWA.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace AnimalShelterBlazorWA.Client.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Animal>($"api/animal/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            
            throw new InvalidOperationException("This code should not be reached");
        }

        public async Task Add(Animal animal)
        {
            try
            {
                await _httpClient.PostAsJsonAsync<Animal>("api/Animal", animal);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

        }

        public async Task Update(Animal animal)
        {
            try
            {
                await _httpClient.PutAsJsonAsync<Animal>($"api/Animal/{animal.Id}", animal);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task Delete(Animal animal)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/animal/{animal.Id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

        }

        public async Task<List<Animal>> GetAllAnimalsInShelter()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Animal[]>("api/Animal");
                return response.ToList();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            
            throw new InvalidOperationException("This code should not be reached");
        }
    }
}