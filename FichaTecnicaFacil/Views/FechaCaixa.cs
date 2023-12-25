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
using FichaTecnicaFacil.Controler;
using FichaTecnicaFacil.DAO;
using FichaTecnicaFacil.Entidades;

namespace FichaTecnicaFacil.Views
{
    public partial class FechaCaixa : Form
    {
        private Caixa _caixa;
        private caixaControler _paiControl;
        public FechaCaixa()
        {
            InitializeComponent();
        }

        public FechaCaixa(Caixa c, caixaControler paiControl)
        {
            InitializeComponent();
            _paiControl = paiControl;
            _caixa = c;
            txtCodigoCaixa.Text = c.codigoCaixa;
            txtDataAbertura.Text = c.HoraAbert.ToShortDateString() + " - "+c.HoraAbert.ToLongTimeString();
            txtDataFechamento.Text = DateTime.Now.ToShortDateString();
            txtValorInicio.Text = c.ValorInicio.ToString("F2")+" R$";
            txtTotalEntrada.Text = c.getEntradaGeral().ToString("F2") + " R$";
            txtSaldoLiquido.Text = (c.getEntradaGeral() - c.getTotalSaida()).ToString("F2");

            //calculo duração
            DateTime dataHoje = DateTime.Now;
            TimeSpan duracao = dataHoje.Subtract(c.HoraAbert);
            txtDuracao.Text = duracao.TotalDays.ToString("F2") + " dias";

            txtTotalSaida.Text = c.getTotalSaida().ToString("F2") + " R$";
            txtValorFechamento.Text = c.ValorFechamento.ToString("F2") + " R$";
            txtValorQuebra.Text = "0,00 R$";
            txtStatus.Text = c.statusCaixa.ToString();

            if (c.statusCaixa == statusCaixa.CAIXA_ABERTO)
            {
                txtStatus.ForeColor = Color.Green;
            }
        }

        public FechaCaixa(Caixa c)
        {
            InitializeComponent();
            _caixa = c;
            txtCodigoCaixa.Text = c.codigoCaixa;
            txtDataAbertura.Text = c.HoraAbert.ToShortDateString() + " - " + c.HoraAbert.ToLongTimeString();
            txtDataFechamento.Text = DateTime.Now.ToShortDateString();
            txtValorInicio.Text = c.ValorInicio.ToString("F2") + " R$";
            txtTotalEntrada.Text = c.TotalEntrada.ToString("F2") + " R$";
            txtTotalSaida.Text = c.TotalSaida.ToString("F2") + " R$";
            txtValorFechamento.Text = c.ValorFechamento.ToString("F2") + " R$";
            txtValorQuebra.Text = "0,00 R$";
            txtStatus.Text = c.statusCaixa.ToString();
            if (c.statusCaixa == statusCaixa.CAIXA_ABERTO)
            {
                txtStatus.ForeColor = Color.Green;
            }
        }


        private void FechaCaixa_Load(object sender, EventArgs e)
        {
            txtValorFechamento.SelectAll();
            MessageBox.Show("informe o valor de fechamento");
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
                 double valorVirtual = (_caixa.getEntradaGeral() - _caixa.getTotalSaida());

                double valorFechamento = double.Parse(txtValorFechamento.Text);
                double valorQuebra = valorVirtual - valorFechamento;

                if (txtValorFechamento.Text == string.Empty) throw new DomainException("Valor Fechamento não pode ser nulo");
                _caixa.HoraFechamento = DateTime.Now;
                _caixa.ValorFechamento = valorFechamento;
                _caixa.ValorQuebra = valorQuebra;
                _caixa.TotalEntrada = _caixa.getEntradaGeral();
                _caixa.TotalSaida = _caixa.getTotalSaida();

                DBConexao.ModifyOperation(CaixaDAO.UpdateStatusCaixa, _caixa, statusCaixa.CAIXA_FECHADO);
                MessageBox.Show("Caixa Fechado com sucesso!");
                _paiControl.getNumCaixasAbertos();
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
                    double valorVirtual = (_caixa.getEntradaGeral() - _caixa.getTotalSaida());
                    double valorFechamento = double.Parse(txtValorFechamento.Text);
                    double valorQuebra = valorVirtual - valorFechamento;
                    if (valorQuebra < 0)
                    {
                    txtValorQuebra.Text = valorQuebra.ToString("F2") +" R$ PARA MAIS";
                    }
                    else
                    {
                        txtValorQuebra.Text = valorQuebra.ToString("F2") + " R$ PARA MENOS";
                    }
                }
                catch(DomainException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtCancelarCaixa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValorFechamento_MouseDown(object sender, MouseEventArgs e)
        {
            txtValorFechamento.SelectAll();
        }
    }
}
