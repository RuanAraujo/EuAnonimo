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
        //public Post postSelecionado { get; set; }
        private Azure _client;
        public Command<Post> ItemCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command GenerateContactsCommand { get; set; }
        public Command CleanLocalDataCommand { get; set; }

        public DescubraViewModel()
        {
            RefreshCommand = new Command(() => Load());
            Posts = new ObservableCollection<Post>();
            ItemCommand = new Command<Post>(Item);
            _client = new Azure();
            Inicio();
        }
        public async void Item(Post post)
        {
            await DisplayAlert(post.Titulo, post.Texto, "OK");
        }
        public async void Inicio()
        {
            await Load();
        }

        public async Task Load()
        {
            IsBusy = true;
            var result = await _client.GetPosts();

            Posts.Clear();

            foreach (var item in result.Reverse())
            {
                Posts.Add(item);
            }
            IsBusy = false;
        }
        
    }
}
