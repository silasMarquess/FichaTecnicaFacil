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
            if (caixasAberto.Count > 0) throw new DomainException("Ja existe um caixa aberto. Feche o primeiro, depois abra um novo");
            DBConexao.ModifyOperation(CaixaDAO.InsertCaixa, c);
            
        }

        public void ValidaAberturaCaixa()
        {
            if (_form.txtValorIncicoCaixa.Text == string.Empty) throw new DomainException("Valor não pode ser vazio");
        }

       
    }
}
