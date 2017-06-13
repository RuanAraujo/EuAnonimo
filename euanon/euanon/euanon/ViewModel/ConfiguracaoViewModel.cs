using euanon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class ConfiguracaoViewModel : BaseViewModel
    {
        public Command CleanLocalDataCommand { get; set; }
        private Azure _client;


        public ConfiguracaoViewModel()
        {
            CleanLocalDataCommand = new Command(async () => await cleanLocalData());
            _client = new Azure();
        }

        async Task cleanLocalData()
        {
            await _client.CleanData();
            await DisplayAlert("Sucesso!", "Os dados foram limpados com sucesso!", "OK");
        }
    }
}
