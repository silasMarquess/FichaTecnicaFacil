using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Views;
using System.Windows.Forms;

namespace FichaTecnicaFacil.Controler
{
   public class Form1Controler
    {
        public Form1 _form;

        public Form1Controler(Form1 form)
        {
            _form = form;
        }

        public void OpenFormLoja()
        {

        }

        public void OpenFormFichaTecnica()
        {
            FrmFichaTecnica form = new FrmFichaTecnica(this);
            form.ShowDialog();
        }

        public void OpenFormCaixa()
        {

        }


    }
}
