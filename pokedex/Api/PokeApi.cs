using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Pokedex.Api
{
    public class PokeApi
    {
        private readonly HttpClient _apiClient;

        public PokeApi()
        {
            _apiClient = new HttpClient
            {
                BaseAddress = new Uri(Endpoint.BaseUrl)
            };
        }

        public async Task<Result<TResult>> Get<TResult>(string endpoint) where TResult : class
        {
            var res = await _apiClient.GetAsync(endpoint);
            var body = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
            {
                // todo: map here the API errors
                return new Result<TResult>.Failure
                {
                    Errors = new List<string> { "API errors" }
                };
            }
            
            var value = JsonSerializer.Deserialize<TResult>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return new Result<TResult>.Success
            {
                Value = value!
            };
        }
    }
}