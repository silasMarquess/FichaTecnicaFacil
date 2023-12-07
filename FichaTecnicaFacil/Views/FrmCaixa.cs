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
    public partial class FrmCaixa : Form
    {
        private caixaControler _control;
        public FrmCaixa()
        {
            InitializeComponent();
            _control = new caixaControler(this);
        }

        public FrmCaixa(Form1Controler form)
        {
            InitializeComponent();
            _control = new caixaControler(this, form);
            _control.pai = form;
            form._form.Visible = false;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip_OpcoesMovimentacao_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbriCaixa form = new AbriCaixa();
            form.ShowDialog();
        }

        private void FrmCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            _control.FechaFormulario();
        }
    }
}
