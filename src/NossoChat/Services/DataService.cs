using NossoChat.Models;

namespace NossoChat.Services
{
    public class DataService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public DataService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<User> GetUser(User user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user, _jsonSerializerOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("users", content);

                if (response.IsSuccessStatusCode)
                {
                    var userContent = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<User>(userContent, _jsonSerializerOptions)
                           ?? throw new InvalidOperationException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new User();
        }

        public async Task<IList<Chat>> GetChats()
        {
            try
            {
                var response = await _httpClient.GetAsync("chats");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IList<Chat>>(content, _jsonSerializerOptions)
                        ?? throw new InvalidOperationException();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return Enumerable.Empty<Chat>().ToList();
        }
    }
}