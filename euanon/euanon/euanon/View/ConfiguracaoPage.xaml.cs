using euanon.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace euanon.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracaoPage : ContentPage
    {
        public ConfiguracaoPage()
        {
            InitializeComponent();
            BindingContext = new ConfiguracaoViewModel();
        }
    }
}