using euanon.ViewModel;
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
    public partial class LoginFace : ContentPage
    {
        public LoginFace()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}