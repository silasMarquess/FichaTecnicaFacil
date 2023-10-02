using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Views;
using FichaTecnicaFacil.Views.subviews;
using System.Windows.Forms;

namespace FichaTecnicaFacil.Controler
{
    public class FichaTecnicaControl
    {
        private FrmFichaTecnica _form;
        private Form1Controler _formPai;

        public FichaTecnicaControl(FrmFichaTecnica form, Form1Controler formPai)
        {
            _form = form;
            _formPai = formPai;
        }

        internal void ClosedOperation()
        {
            _form.Close();
            _formPai._form.Visible = true;
        }

        public void CadastrarIngrediente()
        {

        }
    }
}
