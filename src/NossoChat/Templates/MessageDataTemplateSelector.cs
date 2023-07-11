using NossoChat.Models;
using NossoChat.Services;
using Xamarin.Forms;

namespace NossoChat.Templates;

public class MessageDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate DefaultMessageTemplate
        => new(typeof(DefaultMessageTemplate));

    public DataTemplate OwnMessageTemplate
        => new(typeof(OwnMessageTemplate));

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is Message message)
        {
            var loggedUser = PreferenceService.GetUser();

            if (message.UserId == loggedUser.Id)
            {
                return OwnMessageTemplate;
            }
        }

        return DefaultMessageTemplate;
    }
}
