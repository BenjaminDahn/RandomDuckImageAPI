using DuckAPI.Models;
using System.Text.Json;


namespace DuckAPI.Services
{
    public class DuckAPIService
    {
        private readonly HttpClient _httpClient; //Allows requests to be made to the duck API

        public DuckAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse> GetResponseAsync()  //call API to return the image
        {
            string url = "https://random-d.uk/api/random";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) //success = status code 200
            {
                var stream = await response.Content.ReadAsStreamAsync();  //receive the stream

                var responseData = await JsonSerializer.DeserializeAsync<APIResponse>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return responseData;

            }
            else
            {
                return null;
            }
        }
    }


}
