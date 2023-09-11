using NossoChat.Models;
using Xamarin.Essentials;

namespace NossoChat.Services;

public static class SettingsService
{
    public static void SaveUser(User user)
        => Preferences.Set("USER", JsonSerializer.Serialize(user));

    public static User GetUser()
    {
        string savedUser = Preferences.Get("USER", string.Empty);
        return string.IsNullOrEmpty(savedUser) ? new User() : JsonSerializer.Deserialize<User>(savedUser) ?? throw new InvalidOperationException();
    }
}
