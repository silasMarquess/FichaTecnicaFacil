using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FichaTecnicaFacil.Controler;

namespace FichaTecnicaFacil.Views
{
    public partial class FrmFichaTecnica : Form
    {
        private FichaTecnicaControl _control;
        public FrmFichaTecnica()
        {
            InitializeComponent();
        }

        public FrmFichaTecnica(Form1Controler control)
        {
            InitializeComponent();
            _control = new FichaTecnicaControl(this, control);
            control._form.Visible = false;
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btn_Maxmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_fecharJanela_Click(object sender, EventArgs e)
        {
          
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmFichaTecnica_FormClosed(object sender, FormClosedEventArgs e)
        {
            _control.ClosedOperation();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
