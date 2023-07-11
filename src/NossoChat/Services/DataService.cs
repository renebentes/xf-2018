using NossoChat.Models;

namespace NossoChat.Services
{
    public class DataService
    {
        private const string BaseUrl = "https://xf-2018.azurewebsites.net/";
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

        public async Task<bool> AddChat(Chat chat)
        {
            try
            {
                var json = JsonSerializer.Serialize(chat, _jsonSerializerOptions);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                using var response = await _httpClient.PostAsync("chats", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> AddMessage(Message message)
        {
            try
            {
                var json = JsonSerializer.Serialize(message, _jsonSerializerOptions);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                using var response = await _httpClient.PostAsync($"chats/{message.ChatId}/messages", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Message>> GetChatMessages(int chatId)
        {
            try
            {
                using var response = await _httpClient.GetAsync($"chats/{chatId}/messages");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IList<Message>>(content, _jsonSerializerOptions)
                        ?? throw new InvalidOperationException();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return Enumerable.Empty<Message>().ToList();
        }

        public async Task<IList<Chat>> GetChats()
        {
            try
            {
                using var response = await _httpClient.GetAsync("chats");
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

        public async Task<User> GetUser(User user)
        {
            try
            {
                using var response = await _httpClient.GetAsync($"users/?username={user.Username}&password={user.Password}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var users = JsonSerializer.Deserialize<IList<User>>(content, _jsonSerializerOptions);

                    return users.SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return new User();
        }

        public async Task<bool> RemoveChat(Chat chat)
        {
            try
            {
                using var response = await _httpClient.DeleteAsync($"chats/{chat.Id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> RemoveMessage(Message message)
        {
            try
            {
                using var response = await _httpClient.DeleteAsync($"chats/{message.ChatId}/messages/{message.Id}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> RenameChat(Chat chat)
        {
            try
            {
                var json = JsonSerializer.Serialize(chat, _jsonSerializerOptions);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                using var response = await _httpClient.PutAsync($"chats/{chat.Id}", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
