using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public double PrecoEmbalagem { get; set; }
        public double ConteudoEmbalagem { get; set; }
        public UN Un { get; set; }
        public string Descricao { get; set; }

        public Produto(int iD, double precoEmbalagem, double conteudoEmbalagem, UN un, string descricao)
        {
            Id = iD;
            PrecoEmbalagem = precoEmbalagem;
            ConteudoEmbalagem = conteudoEmbalagem;
            Un = un;
            Descricao = descricao;
        }


        public override bool Equals(object obj)
        {
            bool teste = false;
            Produto outro= (Produto)obj;

            if (outro.Id== this.Id)
            {
                teste = true;
            }
            return teste;
        }

        public Produto()
        {

        }


    }
}
