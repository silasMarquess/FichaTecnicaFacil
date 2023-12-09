using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.Entidades;
using FichaTecnicaFacil.DAO;
using FichaTecnicaFacil.Views;

namespace FichaTecnicaFacil.Controler
{
    class caixaCadControl
    {
        private AbriCaixa _form;

        public caixaCadControl(AbriCaixa form)
        {
            this._form = form;
        }

        public void CadastradaCaixa(Caixa c)
        {
            ValidaAberturaCaixa();
            List<Caixa> caixasAberto = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixaAberto);
            DBConexao.ModifyOperation(CaixaDAO.InsertCaixa, c);
            
        }

        public void ValidaAberturaCaixa()
        {
            if (_form.txtValorIncicoCaixa.Text == string.Empty) throw new DomainException("Valor não pode ser vazio");
        }

        public string GenerateCodigoReceita()
        {
            Random rd = new Random();
            int numeros = rd.Next();
            string codigo = "CA" + numeros.ToString().Substring(0, 4);
            bool teste = DBConexao.ValidateOperation(CaixaDAO.VerificaCodigoCaixa, codigo);

            while (teste)
            {
                numeros = rd.Next();
                codigo = numeros.ToString().Substring(0, 4);
            }
            return codigo;
        }

    }
}
