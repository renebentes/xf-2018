using NossoChat.Models;
using Xamarin.Forms;

namespace NossoChat.Services;

public static class PreferenceService
{
    public static void SaveUser(User user)
        => Application.Current.Properties["USER"] = JsonSerializer.Serialize(user);

    public static User GetUser()
        => Application.Current.Properties.TryGetValue("USER", out var user) && user is not null
            ? JsonSerializer.Deserialize<User>((string)user) ?? throw new InvalidOperationException()
            : new User();
}
