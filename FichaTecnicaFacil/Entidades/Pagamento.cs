using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Entidades
{
    public class Pagamento
    {
        public int Id { get; set; }
        public TipoPag Tipo { get; set; }
        public double Valor { get; set; }

        public Pagamento()
        {

        }

        public Pagamento(int id, TipoPag tipo, double valor)
        {
            Id = id;
            Tipo = tipo;
            Valor = valor;
        }
    }
}
