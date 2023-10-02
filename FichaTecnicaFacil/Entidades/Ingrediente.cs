using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnicaFacil.Entidades
{
    public class Ingrediente
    {

        public int Id { get; set; }
        public double Qtde { get; set; }
        public Produto Produto { get; set; }

        public Ingrediente()
        {

        }

        public Ingrediente(int id, double qtde, Produto produto)
        {
            Id = id;
            Qtde = qtde;
            Produto = produto;
        }

        public double CalculaCustoIngrediente()
        {
            double conteudoInformado = Qtde;
            double valorEmb = Produto.PrecoEmbalagem;
            double ConteudoEmbalagem = Produto.ConteudoEmbalagem;
            double CustoIngrediente = (conteudoInformado * valorEmb) / ConteudoEmbalagem;
            return CustoIngrediente;

        }
    }
}
