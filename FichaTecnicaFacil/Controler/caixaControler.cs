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
    class caixaControler
    {
        public FrmCaixa _form;
        public Form1Controler pai;

        public caixaControler(FrmCaixa form)
        {
            _form = form;
        }
        public caixaControler(FrmCaixa form, Form1Controler formPai)
        {
            _form = form;
            this.pai = formPai;
        }

        public void FechaFormulario()
        {
            _form.Close();
            pai._form.Visible = true;
        }
    
    }
}
