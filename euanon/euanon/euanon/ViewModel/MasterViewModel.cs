using euanon.Helpers;
using euanon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class MasterViewModel : BaseViewModel
    {
        AzureService azureService;
        public Command LogoutCommand { get; }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _userImage;

        public string UserImage
        {
            get { return _userImage; }
            set { SetProperty(ref _userImage, value); }
        }
       
        string name;
        INavigation navigation;
        public MasterViewModel(INavigation navi)
        {
            navigation = navi;
            azureService = DependencyService.Get<AzureService>();
            LogoutCommand =  new Command(LogoutAsync);
            UserImage = Settings.UserImage;
            name = Settings.UserName;
            UserName = "Olá "+ name + ", Seja bem vindo!";
        }

        public async void LogoutAsync()
        {
            await azureService.LogoutAsync();

            Application.Current.MainPage = new NavigationPage(new LoginFace());
            var mainPage = new LoginFace();

            await navigation.PushAsync(mainPage);
            RemovePageFromStack();

        }
        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(MainPage))
                    navigation.RemovePage(page);
            }
        }
    }
}
