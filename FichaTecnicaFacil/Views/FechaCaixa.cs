using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.DAO;
using FichaTecnicaFacil.Entidades;

namespace FichaTecnicaFacil.Views
{
    public partial class FechaCaixa : Form
    {
        private Caixa _caixa;
        public FechaCaixa()
        {
            InitializeComponent();
        }

        public FechaCaixa(Caixa c)
        {
            InitializeComponent();
            _caixa = c;
            txtCodigoCaixa.Text = c.codigoCaixa;
            txtDataAbertura.Text = c.HoraAbert.ToShortDateString() + " - "+c.HoraAbert.ToLongTimeString();
            txtDataFechamento.Text = DateTime.Now.ToShortDateString();
            txtValorInicio.Text = c.ValorInicio.ToString("F2")+" R$";
            txtTotalEntrada.Text = c.TotalEntrada.ToString("F2") + " R$";
            txtTotalSaida.Text = c.TotalSaida.ToString("F2") + " R$";
            txtValorFechamento.Text = c.ValorFechamento.ToString("F2") + " R$";
            txtValorQuebra.Text = "0,00 R$";
            txtStatus.Text = c.statusCaixa.ToString();
        }


        private void FechaCaixa_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {


            }catch(DomainException EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btnFechaCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValorFechamento.Text == string.Empty) throw new DomainException("Valor Fechamento não pode ser nulo");
                DBConexao.ModifyOperation(CaixaDAO.UpdateStatusCaixa, _caixa, statusCaixa.CAIXA_FECHADO);
                MessageBox.Show("Caixa Fechado com sucesso!"); 
            }
            catch (DomainException EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void txtValorFechamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void txtValorFechamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {


                }catch(DomainException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
