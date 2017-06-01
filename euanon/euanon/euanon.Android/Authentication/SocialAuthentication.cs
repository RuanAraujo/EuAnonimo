using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using euanon.Helpers;
using Xamarin.Forms;
using euanon.Droid.Authentication;
using euanon.Authetication;
using Android.Webkit;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace euanon.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> paramameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                //TODO: Log error
                throw;
            }
        }

        public  async Task LogoutAsync(MobileServiceClient client, IDictionary<string, string> parameters = null)
        {
            try
            {
                CookieManager.Instance.RemoveAllCookie();
                await client.LogoutAsync();
            }
            catch (Exception)
            {
                // TODO: Log error
                throw;
            }
        }
    }
}