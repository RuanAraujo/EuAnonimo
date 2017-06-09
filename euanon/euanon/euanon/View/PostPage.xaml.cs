﻿using euanon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace euanon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            BindingContext = new PostViewModel();
        }
        public void limparCampos()
        {
            edtTexto.Text = string.Empty;
            etrTitulo.Text = string.Empty;
        }
    }
}