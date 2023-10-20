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
        public DateTime DataFechamento { get; set; }
        public statusPedido Status { get; set; }

        public string NomeCLiente { get; set; }
        public string TelefoneCliente { get; set; }

        public List<Pagamento> ListaPagamento { get; private set; } = new List<Pagamento>();

        public List<Receita> ListaReceita { get; private set; } = new List<Receita>();
        public Pedido()
        {

        }

        public Pedido(string codigoPedido, DateTime dataPedido, double desconto, DateTime prazoEntregada, DateTime dataFechamento, statusPedido status, string nomeCLiente, string telefoneCliente)
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

        public double CalculaTotalPedido()
        {
            double total = 0;
            foreach (Receita r in ListaReceita)
            {
             //   total += r.CalculaValorReceita();
            }
            return total + Desconto;
        }

        public void AddReceita(Receita receita)
        {
            if (ListaReceita.Contains(receita))
            {
                throw new DomainException("Receita ja Existe !");
            }
            ListaReceita.Add(receita);
        }

        public void AddPagamento(Pagamento pag)
        {
            ListaPagamento.Add(pag);
        }

    }
}
