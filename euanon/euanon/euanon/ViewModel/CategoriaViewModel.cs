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
    public class CategoriaViewModel : BaseViewModel
    {
        public string Categoria { get; set; }
        public ObservableCollection<Post> Posts { get; set; }
        //public Post postSelecionado { get; set; }
        private Azure _client;
        public Command<Post> ItemCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command GenerateContactsCommand { get; set; }
        public Command CleanLocalDataCommand { get; set; }

        public CategoriaViewModel(string cate)
        {
            Categoria = cate;
            Title = Categoria;
            RefreshCommand = new Command(() => Load());
            Posts = new ObservableCollection<Post>();
            ItemCommand = new Command<Post>(Item);
            _client = new Azure();
            Load();
        }
        public CategoriaViewModel()
        {

        }

        public async void Item(Post post)
        {
            await DisplayAlert(post.Titulo, post.Texto, "OK");
        }

        public async void Load()
        {
            IsBusy = true;
            var result = await _client.GetPosts();

            Posts.Clear();

            foreach (var item in result.Reverse())
            {
                if(item.Categoria == Categoria)
                    Posts.Add(item);
            }
            IsBusy = false;
        }
    }
}
