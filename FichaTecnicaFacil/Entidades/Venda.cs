using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnicaFacil.Entidades
{
    class Venda
    {
        public Pedido Pedido { get; set; }
        public Receita Receita { get; set; }

        public Venda()
        {

        }

        public Venda(Pedido pedido, Receita receita)
        {
            Pedido = pedido;
            Receita = receita;
        }



    }
}
