using euanon.Helpers;
using euanon.Model;
using euanon.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class DescubraViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }
        private Azure _client;
        public Command RefreshCommand { get; set; }
        public Command GenerateContactsCommand { get; set; }
        public Command CleanLocalDataCommand { get; set; }

        public DescubraViewModel()
        {
            RefreshCommand = new Command(() => Load());
            CleanLocalDataCommand = new Command(() => cleanLocalData());
            Posts = new ObservableCollection<Post>();
            _client = new Azure();

        }


        async Task cleanLocalData()
        {
            await _client.CleanData();
        }

        public async void Load()
        {
            IsBusy = true;
            var result = await _client.GetPosts();

            Posts.Clear();

            foreach (var item in result)
            {
                Posts.Add(item);
            }
            IsBusy = false;
        }

    }
}
