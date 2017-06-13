using euanon.Helpers;
using euanon.Services;
using euanon.View;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        public bool MostrarDica { get; set; }
        ICommand loginCommand;

        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;
        }
        private async Task ExecuteLoginCommandAsync()
        {
            try
            {
                if(await LoginAsync())
                {
                    IsBusy = true;
                    if (MostrarDica)
                    {
                        Application.Current.MainPage = new DicasPage();
                        var mainPage = new DicasPage();
                        await navigation.PushAsync(mainPage);
                    }
                    else
                    {
                        Application.Current.MainPage = new MainPage();
                        var mainPage = new MainPage();
                        await navigation.PushAsync(mainPage);
                    }
                    
                    
                    RemovePageFromStack();
                    IsBusy = false;

                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(LoginFace))
                    navigation.RemovePage(page);
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
            {
                MostrarDica = false;
                return Task.FromResult(true);
            }
            MostrarDica = true;    
            return azureService.LoginAsync();
        }
    }
}
