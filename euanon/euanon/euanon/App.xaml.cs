﻿using euanon.Helpers;
using euanon.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace euanon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Settings.IsLoggedIn)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new LoginFace());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
