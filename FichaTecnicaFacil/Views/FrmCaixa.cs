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
          
        }

        private void FrmCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            _control.FechaFormulario();
        }

        private void FrmCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                _control.getNumCaixasAbertos();

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataIn = dta_In.Value;
                DateTime dataOut = dta_Out.Value;
                _control.MostraListaCaixas(new DateTime(dataIn.Year, dataIn.Month, dataIn.Day), new DateTime(dataOut.Year, dataOut.Month, dataOut.Day));

            }catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                _control.FechamentoCaixa();
            }catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
