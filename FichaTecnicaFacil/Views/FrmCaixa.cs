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
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.Entidades;

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
            try
            {
                _control.AbriNovoCaixa();
            }catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                txtDescricao.Select();
                CbTipoMovFilter.SelectedIndex = 2;
                CbNaturezaMovFilter.SelectedIndex = 5;

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
                DateTime dataiN = new DateTime(dta_In.Value.Year, dta_In.Value.Month, dta_In.Value.Day);
                DateTime dataOut = new DateTime(dta_Out.Value.Year, dta_Out.Value.Month, dta_Out.Value.Day);
                if (dataOut < dataiN) throw new DomainException("Data final deve ser maior ou igual a data inicial !");
                _control.MostraListaCaixas(dataiN,dataOut);
            }
            catch(DomainException ex)
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

        private void dgv_ListaCaixasFiltrados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CbTipoMovFilter.SelectedIndex = 2;
                CbNaturezaMovFilter.SelectedIndex = 5;
                _control.getListaMovimentacoes();

            }catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLancarMovimentacao_Click(object sender, EventArgs e)
        {

            try
            {
                _control.ValidaCadFluxo();
                Fluxo f = new Fluxo();
                f.Horario = DateTime.Now;
                f.data = DateTime.Now;
                f.Descricao = txtDescricao.Text;
                f.Valor = double.Parse(txtValor.Text);
                f.Natureza = (TipoPag)CbNatureza.SelectedIndex;
                f.Tipo = (tipoFluxo)CbTipoMovimentacao.SelectedIndex;

                DialogResult res = MessageBox.Show("Confirma a inclusao de dados ?", "Confirme",MessageBoxButtons.YesNo);
                if (res == DialogResult.No) throw new DomainException("Operação Cancelada !");
                _control.InsertMovimentacaoCaixa(f);
                txtDescricao.Select();
               

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtValor.Select();
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
                CbNatureza.DroppedDown = true;
                CbNatureza.SelectedIndex = 0;
                CbNatureza.Select();
            }
        }

        private void CbNatureza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CbTipoMovimentacao.DroppedDown = true;
                CbTipoMovimentacao.SelectedIndex = 0;
                CbTipoMovimentacao.Select();
            }
        }

        private void CbTipoMovimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLancarMovimentacao_Click(sender, e);
            }
        }

        private void LbcartoesGlobal_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void lbMovimentacoes_Click(object sender, EventArgs e)
        {

        }

        private void dgvFluxoDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_ListaCaixasFiltrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Confirma o cancelamento da movimentação ?","Confirme:", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) throw new DomainException("Operação cancelada !");
               
                DateTime dataiN = new DateTime(dta_In.Value.Year, dta_In.Value.Month, dta_In.Value.Day);
                DateTime dataOut = new DateTime(dta_Out.Value.Year, dta_Out.Value.Month, dta_Out.Value.Day);
                
                _control.DeleteMovimentacao();
                _control.MostraListaCaixas(dataiN, dataOut);


            }
            catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dELETECAIXAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Confirma o cancelamento do caixa ?", "confirme:", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) throw new DomainException("Operação cancelada !");
                _control.deleteCaixaSelecionado();
                DateTime dataiN = new DateTime(dta_In.Value.Year, dta_In.Value.Month, dta_In.Value.Day);
                DateTime dataOut = new DateTime(dta_Out.Value.Year, dta_Out.Value.Month, dta_Out.Value.Day);
                _control.MostraListaCaixas(dataiN, dataOut);
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbCodCaixa_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _control.FiltrarMovCaixaTipo();
                _control.FiltrarMovNat();
            }catch(DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
