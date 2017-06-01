using euanon.Authetication;
using euanon.Helpers;
using euanon.Model;
using euanon.Services;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace euanon.Services
{
    public class AzureService
    {
        List<User> identities = null;
        public static readonly string AppUrl = "http://euanonimo.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;
        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar seu login, tente novamente!", "OK");
                });
                return false;
            }
            else
            {
                identities = await Client.InvokeApiAsync<List<User>>("/.auth/me");
                var identities2 = await Client.InvokeApiAsync("/.auth/me");
                var name = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;

                var userToken = identities[0].AccessToken;

                var requestUrl = $"https://graph.facebook.com/v2.9/me/?fields=picture.type(large)&access_token={userToken}";
                    //"https://graph.facebook.com/v2.9/me?fields=id,name,picture.type(large){userToken}";
                    //$"me/?fields=picture&access_token={userToken}";

                var httpClient = new HttpClient();

                var userJson = await httpClient.GetStringAsync(requestUrl);

                var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;

                Settings.UserName = name;
                Settings.UserImage = facebookProfile.Picture.Data.Url;
            }
            return true;
        }
        public async Task LogoutAsync()
        {

            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            await auth.LogoutAsync(Client);
            await Client.LogoutAsync();

            Settings.UserId = string.Empty;
            Settings.AuthToken = string.Empty;
            Settings.UserImage = string.Empty;
            Settings.UserName = string.Empty;
        }

    }
}
