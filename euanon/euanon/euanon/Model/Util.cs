using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euanon.Model
{
    public class Util
    {
        public string Imagem { get; set; }
        public string selecionaImagem(string categoria)
        {
            if (categoria == "Amor")
                Imagem = "heart.png";
            else if (categoria == "Carinho")
                Imagem = "afeicao.png";
            else if (categoria == "Reflexao")
                Imagem = "reflexao.png";
            else if (categoria == "Amizade")
                Imagem = "amizade.png";
            return Imagem;
        }
    }
}
