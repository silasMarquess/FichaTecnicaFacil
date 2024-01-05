using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Entidades
{
    public class Pedido
    {
        public string CodigoPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public double Desconto { get; set; }
        public DateTime PrazoEntregada { get; set; }
        public DateTime? DataFechamento { get; set; }
        public statusPedido Status { get; set; }

        public TipoPag Pagamento { get; set; }

        public string NomeCLiente { get; set; }
        public string TelefoneCliente { get; set; }

        public List<Pagamento> ListaPagamento { get; private set; } = new List<Pagamento>();

        public List<Receita> ListaReceita { get; private set; } = new List<Receita>();
        public Pedido()
        {

        }

        public Pedido(string codigoPedido, DateTime dataPedido, double desconto, DateTime prazoEntregada, DateTime? dataFechamento, statusPedido status, string nomeCLiente, string telefoneCliente)
        {
            CodigoPedido = codigoPedido;
            DataPedido = dataPedido;
            Desconto = desconto;
            PrazoEntregada = prazoEntregada;
            DataFechamento = dataFechamento;
            Status = status;
            NomeCLiente = nomeCLiente;
            TelefoneCliente = telefoneCliente;
        }

        public Pedido(string codigoPedido, DateTime dataPedido, double desconto, DateTime prazoEntregada, DateTime? dataFechamento, statusPedido status, string nomeCLiente, string telefoneCliente, TipoPag pagamento)
        {
            CodigoPedido = codigoPedido;
            DataPedido = dataPedido;
            Desconto = desconto;
            PrazoEntregada = prazoEntregada;
            DataFechamento = dataFechamento;
            Status = status;
            NomeCLiente = nomeCLiente;
            TelefoneCliente = telefoneCliente;
            Pagamento = pagamento;
        }

        public double CalculaTotalPedido()
        {
            double total = 0;
            foreach (Receita r in ListaReceita)
            {
                total += r.CalcularTotalReceita(r.GastosGerais, r.ValorMaoObra, r.MargemLucro);
            }
            string totalS = total.ToString("F2");
            return double.Parse(totalS);
        }

        public double CalculaTotalLiquidoPedido(double desconto)
        {
            if (desconto > CalculaTotalPedido()) throw new DomainException("Erro: Desconto não pode ser maior do que valor total");
            double valor = this.CalculaTotalPedido();
            return this.CalculaTotalPedido() - desconto;
        }




        public void AddReceita(Receita receita)
        {
            ListaReceita.Add(receita);
        }

        public void AddPagamento(Pagamento pag)
        {
            ListaPagamento.Add(pag);
        }

    }
}
