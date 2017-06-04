using euanon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class DescubraViewModel : BaseViewModel
    {
        public Command Mensagem;

        public DescubraViewModel()
        {
            Mensagem = new Command(() => EnviarMensagem());
        }

        async void EnviarMensagem()
        {
            await DisplayAlert("titulo", "Mensagem e tal", "OK");
        }
    }
}
