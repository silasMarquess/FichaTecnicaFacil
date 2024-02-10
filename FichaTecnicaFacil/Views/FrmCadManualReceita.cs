using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.Entidades;
using System.Windows.Forms;
using FichaTecnicaFacil.Controler;
using FichaTecnicaFacil.Views;


namespace FichaTecnicaFacil.Views
{
    public partial class FrmCadManualReceita : Form
    {
        private FrmPedidos _fPedidos;
        private FichaTecnicaControl f;
        public FrmCadManualReceita()
        {
            InitializeComponent();
        }

        public FrmCadManualReceita(FrmPedidos form)
        {
            InitializeComponent();
            _fPedidos = form;
            f = new FichaTecnicaControl();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmCadManualReceita_Load(object sender, EventArgs e)
        {

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Voçê confirma a operação ?", "CONFIRMAÇÃO", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) throw new DomainException("Operação cancelada");
                //validação
                if (txtDescricao.Text == string.Empty) throw new DomainException("Descrição nao pode ser vazia");
                if (txtValorTotal.Text == string.Empty) throw new DomainException("Valor total não pode ser vazio");
                if (txtQuantidade.Text == string.Empty) throw new DomainException("Quantidade não pode ser vazio");

                Receita r = new Receita();
                r.Id = f.GenerateCodigoReceita();
                r.Descricao = txtDescricao.Text;
                r.Data = DateTime.Now;
                r.MargemLucro = 0;
                r.ValorMaoObra = 0;
                r.Total = double.Parse(txtValorTotal.Text);

                //SALVAR RECEITA ADICIONAL
                f.InsertReceitaControl(r);

                double qtde = double.Parse(txtQuantidade.Text);

                for (int i = 0; i < qtde; i++)
                {
                    _fPedidos._pedidoAtual.AddReceita(r);
                }

                MessageBox.Show("Novo Item Adicionado com sucesso !");


            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtQuantidade.Text == string.Empty) throw new DomainException("Quantidade não pode ser vazio");
                    double quantidade = double.Parse(txtQuantidade.Text);
                    double valor = double.Parse
                        (txtValorTotal.Text);
                    double subTotal = quantidade * valor;
                    txtSubTotal.Text = "R$ "+subTotal.ToString("F2");
                }

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValorTotal.SelectAll();
                txtValorTotal.Select();
            }
        }

        private void txtValorTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantidade.SelectAll();
                txtQuantidade.Select();
            }
        }
    }
}
