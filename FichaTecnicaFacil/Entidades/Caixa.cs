using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Entidades
{
   public class Caixa
    {
        public string codigoCaixa { get; set; }
        public DateTime HoraAbert { get; set; }
        public DateTime HoraFechamento { get; set; }
        public double ValorInicio { get; set; }
        public double TotalEntrada { get; set; }
        public double TotalSaida { get; set; }
        public double ValorFechamento { get; set; }
        public double ValorQuebra { get; set; }
        public statusCaixa statusCaixa { get; set; }

        private List<Fluxo> ListaFluxo { get; set; } = new List<Fluxo>();

        public Caixa()
        {
                
        }

        public Caixa(string codigoCaixa, DateTime horaAbert, DateTime horaFechamento, double valorInicio, double totalEntrada, double totalSaida, double valorFechamento, double valorQuebra, statusCaixa statusCaixa)
        {
            this.codigoCaixa = codigoCaixa;
            HoraAbert = horaAbert;
            HoraFechamento = horaFechamento;
            ValorInicio = valorInicio;
            TotalEntrada = totalEntrada;
            TotalSaida = totalSaida;
            ValorFechamento = valorFechamento;
            ValorQuebra = valorQuebra;
            this.statusCaixa = statusCaixa;
        }


        public void AddFluxo(Fluxo f)
        {
            ListaFluxo.Add(f);
        }

        public List<Fluxo> getListaMovimentacoes()
        {
            return this.ListaFluxo;
        }

        public double getTotalEntradaPix()
        {
            double soma = 0;
            foreach(Fluxo f in ListaFluxo)
            {
                if(f.Tipo==tipoFluxo.FLUXO_ENTRADA && f.Natureza == TipoPag.PIX)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }


        public double getEntradaGeral()
        {
            double soma = 0;
            soma = getTotalEntradaPix() + getTotalEntradaEspecie() + getTotalEntradaCartaoCredito() + getTotalEntradaCartaoDebito();
            return soma;
        }

        public double getTotalSaida()
        {
            double soma = 0;
            soma = getTotalSaidaPix() + getTotalSaidaEspecie() + getTotalSaidaCartaoCredito() + getTotalSaidaCartaoDebito();
            return soma;
        }

        public double getDiferenca()
        {
            double dif = getEntradaGeral() - getTotalSaida();
            return dif;
        }

        public double getTotalEntradaCartaoCredito()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_ENTRADA && f.Natureza == TipoPag.C_CRÉDITO)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }

        public double getTotalEntradaCartaoDebito()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_ENTRADA && f.Natureza == TipoPag.C_DÉBITO)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }

        public double getTotalEntradaEspecie()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_ENTRADA && f.Natureza == TipoPag.DINHEIRO)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }


        public double getTotalSaidaPix()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_SAIDA && f.Natureza == TipoPag.PIX)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }

        public double getTotalSaidaCartaoCredito()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_SAIDA && f.Natureza == TipoPag.C_CRÉDITO)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }

        public double getTotalSaidaCartaoDebito()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_SAIDA && f.Natureza == TipoPag.C_CRÉDITO)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }

        public double getTotalSaidaEspecie()
        {
            double soma = 0;
            foreach (Fluxo f in ListaFluxo)
            {
                if (f.Tipo == tipoFluxo.FLUXO_SAIDA && f.Natureza == TipoPag.DINHEIRO)
                {
                    soma += f.Valor;
                }
            }
            return soma;
        }
    }
}
