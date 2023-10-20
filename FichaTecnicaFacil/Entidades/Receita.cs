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
        public string Validade { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double GastosGerais { get; set; }

        public List<Ingrediente> ListaIngrediente { get; private set; } = new List<Ingrediente>();

        public Receita(string id, string rendimento, double margemLucro, double valorMaoObra, string validade, string descricao, DateTime data, double gastosGerais)
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

        public override int GetHashCode()
        {
            return Descricao.GetHashCode();
        }

        public void AddIngrediente(Ingrediente ing)
        {
            if (ListaIngrediente.Contains(ing)) {

                int index = ListaIngrediente.IndexOf(ing);
                ListaIngrediente[index].Qtde = ing.Qtde;
                throw new DomainException("Quantidade Atualizada !");
            } 
            ListaIngrediente.Add(ing);
        }
        public double CalculaCustoReceita(double gastosGerais, double ValorMaoObra)
        {
            double custoIngredientes = this.getTotalIngrdiente();
            double valorReceita = custoIngredientes + gastosGerais + ValorMaoObra;
            return valorReceita;
        }

        public double CalculaCustoReceita(double gastosGerais, double ValorMaoObra,double totalIngrediente)
        {
            double valorReceita = totalIngrediente + gastosGerais + ValorMaoObra;
            return valorReceita;
        }

        public double CalcularTotalReceita(double gastosGerais, double ValorMaoObra,double margemLucro)
        {
            return this.CalculaCustoReceita(gastosGerais, ValorMaoObra) + this.CalculaCustoReceita(gastosGerais, ValorMaoObra) * margemLucro * 0.01;
        }

        public double CalcularTotalReceita(double gastosGerais, double ValorMaoObra, double margemLucro, double totalIngrediente)
        {
            return this.CalculaCustoReceita(gastosGerais, ValorMaoObra,totalIngrediente) + this.CalculaCustoReceita(gastosGerais, ValorMaoObra,totalIngrediente) * margemLucro * 0.01;
        }

        public double CalcularTotalReceitaValorReal(double gastosGerais, double ValorMaoObra, double margemLucro)
        {
            return this.CalculaCustoReceita(gastosGerais, ValorMaoObra) + margemLucro;
        }

        public override bool Equals(object obj)
        {
            bool teste = false;
            Receita outro = (Receita)obj;
            if (outro.Id == this.Id)
            {
                teste = true;
            }
            return teste;
        }

        public double getTotalIngrdiente()
        {
            double custoIngredientes = 0;
            foreach (Ingrediente i in ListaIngrediente)
            {
                custoIngredientes += i.CalculaCustoIngrediente();
            }
            return custoIngredientes;
        }
    }
}
