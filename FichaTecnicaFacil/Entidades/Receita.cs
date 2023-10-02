using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnicaFacil.Entidades
{
    public class Receita
    {
        public string Id { get; set; }
        public string Rendimento { get; set; }
        public double MargemLucro { get; set; }
        public double ValorMaoObra { get; set; }
        public DateTime Validade { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double GastosGerais { get; set; }

        public List<Ingrediente> ListaIngrediente { get; private set; } = new List<Ingrediente>();

        public Receita(string id, string rendimento, double margemLucro, double valorMaoObra, DateTime validade, string descricao, DateTime data, double gastosGerais)
        {
            Id = id;
            Rendimento = rendimento;
            MargemLucro = margemLucro;
            ValorMaoObra = valorMaoObra;
            Validade = validade;
            Descricao = descricao;
            Data = data;
            GastosGerais = gastosGerais;
        }

        public Receita()
        {

        }


        public void AddIngrediente(Ingrediente ing)
        {
            ListaIngrediente.Add(ing);
        }
        public double CalculaValorReceita()
        {
            double custoIngredientes = 0;
            foreach (Ingrediente i in ListaIngrediente)
            {
                custoIngredientes += i.CalculaCustoIngrediente();
            }
            double gastosGerais = this.GastosGerais;
            double ValorMaoObra = this.ValorMaoObra;
            double margemLucro = this.MargemLucro;
            double valorReceita = custoIngredientes + gastosGerais + ValorMaoObra;
            return valorReceita;
        }
    }
}
