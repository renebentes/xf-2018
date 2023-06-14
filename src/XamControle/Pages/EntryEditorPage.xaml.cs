using Xamarin.Forms;

namespace XamControle.Pages;

public partial class EntryEditorPage : ContentPage
{
    public EntryEditorPage()
    {
        InitializeComponent();

        Idade.TextChanged += (s, e) =>
        {
            Duplicado.Text = Idade.Text;
        };

        Comentario.Completed += (s, e) =>
        {
            QuantidadeCaracteres.Text = Comentario.Text.Length.ToString();
        };
    }
}
