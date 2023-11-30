using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Entidades
{
    class Caixa
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
    }
}
