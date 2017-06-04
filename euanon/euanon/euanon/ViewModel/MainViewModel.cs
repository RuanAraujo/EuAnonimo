using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon.ViewModel
{
     
    public class MainViewModel : BaseViewModel
    {
        public Command About;
        public MainViewModel()
        {
            About = new Command(() => aboutPage());
        }

        async void aboutPage()
        {
            await DisplayAlert("Sobre nós!", "Poste anonimamente seus poemas/poesias ou reflexões!\n\n Versão: 0.1", "OK");
        }
    }
}
