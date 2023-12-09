using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Controler;
using FichaTecnicaFacil.Entidades;
using System.Windows.Forms;

namespace FichaTecnicaFacil.Views
{
   
    public partial class AbriCaixa : Form
    {
        private caixaCadControl _control;
        public AbriCaixa()
        {
            InitializeComponent();
            txtHorarioAberturaCaixa.Text = DateTime.Now.ToShortTimeString();
            _control = new caixaCadControl(this);
            txtDataAberturaCaixa.Text = DateTime.Now.ToShortDateString();
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dataNow = DateTime.Now;
            txtHorarioAberturaCaixa.Text = dataNow.ToLongTimeString();
        }

        private void btnAbriCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                //construir caixa
                Caixa c = new Caixa();
                c.codigoCaixa = _control.GenerateCodigoReceita();
                c.HoraAbert = DateTime.Now;
                c.ValorInicio = double.Parse(txtValorIncicoCaixa.Text);
                c.statusCaixa = Entidades.enums.statusCaixa.CAIXA_ABERTO;
                _control.CadastradaCaixa(c);
                MessageBox.Show("Caixa Cadastrado Aberto com sucesso !");

            }catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AbriCaixa_Load(object sender, EventArgs e)
        {

        }
    }
}
