using euanon.Model;
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
    public class PostViewModel : BaseViewModel
    {
        public List<string> Categorias { get; set; }
        public bool Entendi { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Categoria { get; set; }
        ICommand postCommand;
        public ICommand PostCommand => postCommand ?? (postCommand = new Command(async () => await ExecutePostCommand()));
        Azure azure;
        Post post;
        public PostViewModel()
        {
            listarCategorias();
            azure = new Azure();
            Entendi = false;
        }

        async Task ExecutePostCommand()
        {
            if (IsBusy)
                return;
            if (verificaCampos())
            {
                await DisplayAlert("ERRO", "Verifique os campos e tente novamente!", "OK");
                return;
            }
                
            IsBusy = true;
            post = new Post();
            post.Categoria = this.Categoria;
            post.Titulo = this.Titulo;
            post.Texto = this.Texto;

            //await DisplayAlert("Postando..", "Estamos postando " + this.Titulo + " Aguarde", "Ok");
            azure.AddPost(post);
            
            IsBusy = false;
            await DisplayAlert("Postado", this.Titulo + " Postado", "Ok");

            this.Titulo = string.Empty;
            this.Texto = string.Empty;
            this.Categoria = null;
            

        }
        public bool verificaCampos()
        {
            if(Titulo == null || Texto == null || Categoria == null || Entendi == false)
            {
                 return true;
            }
            return false;      
        }

        public void listarCategorias()
        {
            Categorias = new List<string>();
            Categorias.Add("Amor");
            Categorias.Add("Reflexao");
            Categorias.Add("Amizade");
            Categorias.Add("Carinho");
        }
       
        

    }
}
