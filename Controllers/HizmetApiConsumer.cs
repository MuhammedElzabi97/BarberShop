using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using WebProjesi.Models;

namespace HizmetApiConsumer
{
    public class HizmetApiClient
    {
        private readonly HttpClient _httpClient;

        public HizmetApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<IEnumerable<Hizmet>> GetAllHizmetlerAsync()
        {
            var response = await _httpClient.GetAsync("api/HizmetApi");
            response.EnsureSuccessStatusCode();

            var hizmetler = await response.Content.ReadFromJsonAsync<IEnumerable<Hizmet>>();
            return hizmetler ?? new List<Hizmet>();
        }

        public async Task<Hizmet> GetHizmetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/HizmetApi/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Hizmet not found with ID {id}");
            }

            var hizmet = await response.Content.ReadFromJsonAsync<Hizmet>();
            return hizmet!;
        }

        public async Task<Hizmet> CreateHizmetAsync(Hizmet yeniHizmet)
        {
            var response = await _httpClient.PostAsJsonAsync("api/HizmetApi", yeniHizmet);
            response.EnsureSuccessStatusCode();

            var createdHizmet = await response.Content.ReadFromJsonAsync<Hizmet>();
            return createdHizmet!;
        }

        public async Task UpdateHizmetAsync(int id, Hizmet guncelHizmet)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/HizmetApi/{id}", guncelHizmet);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteHizmetAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/HizmetApi/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
