﻿using euanon.Helpers;
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
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;


        ICommand loginCommand;

        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;
        }
        private async Task ExecuteLoginCommandAsync()
        {
            //if (/*IsBusy || */!(await LoginAsync()))
            //    return;
            //else
            //{
            //    //var mainPage = new MainPage();

            //    //await navigation.PushAsync(mainPage);

            //    RemovePageFromStack();

            //}
            //try
            //{
            //    if (await LoginAsync())
            //    {
            //        await PushAsync<MainViewModel>();
            //        RemovePageFromStack();
            //    }
            //}
            //catch (System.Exception)
            //{
            //    throw;
            //}
            try
            {
                if(await LoginAsync())
                {

                    Application.Current.MainPage = new MainPage();
                    var mainPage = new MainPage();

                    await navigation.PushAsync(mainPage);
                    RemovePageFromStack();
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
                return Task.FromResult(true);
            return azureService.LoginAsync();
        }
    }
}
