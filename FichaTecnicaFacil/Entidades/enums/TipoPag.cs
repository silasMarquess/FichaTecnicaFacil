using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnicaFacil.Entidades.enums
{
    public enum TipoPag:int
    {
        DINHEIRO = 0,
        PIX = 1,
        Á_PRAZO = 2,
        C_CRÉDITO = 3,
        C_DÉBITO = 4,
        NÃO_PAGO=5
    }
}
