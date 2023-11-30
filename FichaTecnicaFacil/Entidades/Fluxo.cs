using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Entidades
{
    class Fluxo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public tipoFluxo Tipo { get; set; }
        public DateTime Horario { get; set; }
        public DateTime data { get; set; }

        public Caixa Caixa { get; set; }

        public Fluxo()
        {

        }

        public Fluxo(int id, string descricao, double valor, tipoFluxo tipo, DateTime horario, DateTime data, Caixa caixa)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
            Horario = horario;
            this.data = data;
            Caixa = caixa;
        }
    }
}
