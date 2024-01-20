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
using FichaTecnicaFacil.Entidades;
using FichaTecnicaFacil.DAO;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Views
{
    public partial class FrmPedidos : Form
    {

        private FrmPedidoControl _control;


        private Pedido _pedidoAtual;
        private Form1Controler _formControler;
        private List<Receita> listaReceitaFiltrada;
        private List<Pedido> _ListaPedido;
        public FrmPedidos()
        {
            InitializeComponent();
            _control = new FrmPedidoControl(this);
        }

        public FrmPedidos(Form1Controler formControl)
        {
            InitializeComponent();
            _formControler = formControl;
            formControl._form.Visible = false;
            _control = new FrmPedidoControl(this);
        }


        private void txt_PesquisaReceitaPeloNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCadPedNomeReceita_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nome = txtCadPedNomeReceita.Text;
                if (nome == string.Empty) throw new DomainException("Nada filtrado");
                listaReceitaFiltrada = DBConexao.getLisObjectOperation(FichaTenicaDAO.getListaReceita, nome);
                _control.MostraListaReceita(listaReceitaFiltrada);

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_ListaReceitasCadastradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_ListaReceitasCadastradas.Columns[e.ColumnIndex].Index == 5)
                {
                    Receita r = listaReceitaFiltrada.Find(getReceitaPorNome);
                    _pedidoAtual.AddReceita(r);
                    double desconto = double.Parse(txtDesconto.Text);
                    _control.MostraListaReceitaCarrinho(_pedidoAtual.ListaReceita);
                    txtTotalBruto.Text = "R$ " + _pedidoAtual.CalculaTotalPedido().ToString("F2");
                    txtTotalLiquido.Text =  _pedidoAtual.CalculaTotalLiquidoPedido(desconto).ToString("F2");
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool getReceitaPorNome(Receita r)
        {
            string codigo = dgv_ListaReceitasCadastradas.CurrentRow.Cells[0].Value.ToString();
            return (r.Id == codigo) ? true : false;
        }

        private void FrmPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmPedidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formControler._form.Visible = true;
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            _pedidoAtual = new Pedido();
            _pedidoAtual.CodigoPedido = _control.GenerateCodigoReceita();
            Dta_PrazoEntrega.Value = DateTime.Now;
            Gbox_CabecalhoPedido.Text = "PEDIDO NUMERO -" + _pedidoAtual.CodigoPedido;
        }

        private void TabControlPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlPedidos.SelectedIndex == 0)
            {
                _pedidoAtual = new Pedido();
                _pedidoAtual.CodigoPedido = _control.GenerateCodigoReceita();
                Gbox_CabecalhoPedido.Text = "PEDIDO NUMERO -" + _pedidoAtual.CodigoPedido;
            }
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDesconto.Text == string.Empty) txtDesconto.Text = "0,00";
                txtTotalLiquido.Text = _pedidoAtual.CalculaTotalLiquidoPedido(double.Parse(txtDesconto.Text)).ToString("F2");
                _pedidoAtual.Desconto = double.Parse(txtDesconto.Text);
            }
        }

        private void txtCadPedNomeReceita_MouseDown(object sender, MouseEventArgs e)
        {
            txtCadPedNomeReceita.SelectAll();
        }

        private void txtNomeCliente_MouseDown(object sender, MouseEventArgs e)
        {
            txtNomeCliente.SelectAll();
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void txtContatoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void btnSalvarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                //validação de dados
                if (txtNomeCliente.Text == string.Empty) throw new DomainException("Erro: Nome de cliente não pode ser vazio");
                if (txtContatoCliente.Text == string.Empty) throw new DomainException("Erro: Telefone de cliente não pode ser vazio");
                DateTime dataEntrega = Dta_PrazoEntrega.Value;
                if (dataEntrega < DateTime.Now) throw new DomainException("Erro: data de entrega não pode ser no passado");
                _pedidoAtual.NomeCLiente = txtNomeCliente.Text;
                _pedidoAtual.TelefoneCliente = txtContatoCliente.Text;
                _pedidoAtual.Status = statusPedido.PERDIDO_ABERTO;
                _pedidoAtual.Desconto = double.Parse(txtDesconto.Text);
                _pedidoAtual.Pagamento = TipoPag.NÃO_PAGO;
                _pedidoAtual.PrazoEntregada = new DateTime(Dta_PrazoEntrega.Value.Year, Dta_PrazoEntrega.Value.Month, Dta_PrazoEntrega.Value.Day);
                _pedidoAtual.DataPedido = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                _pedidoAtual.Total = double.Parse(txtTotalLiquido.Text);
                _control.ControlInsertPedido(_pedidoAtual);
                MessageBox.Show("Dados de Pedidos Salvos com sucesso !");

                //operações de controle de cadastro
                _pedidoAtual = null;
                _pedidoAtual = new Pedido();
                _pedidoAtual.CodigoPedido = _control.GenerateCodigoReceita();
                Gbox_CabecalhoPedido.Text = "PEDIDO NUMERO -" + _pedidoAtual.CodigoPedido;
                dgv_ListaReceitasCadastradas.Rows.Clear();
                txtCadPedNomeReceita.Text = string.Empty;
                _control.MostraListaReceitaCarrinho(_pedidoAtual.ListaReceita);

                _control.LimparCampos();
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                _ListaPedido = null;

                if (rb_FiltraPorCliente.Checked)
                {
                    string nome = txtNomereceitaPesquisa.Text;
                    _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos, nome);
                }
                else if (RbFiltroData.Checked)
                {
                    DateTime dataIn = new DateTime(dtaFiltroDataIn.Value.Year, dtaFiltroDataIn.Value.Month, dtaFiltroDataIn.Value.Day);
                    DateTime dataOut = new DateTime(dtaFiltroDatraFinal.Value.Year, dtaFiltroDatraFinal.Value.Month, dtaFiltroDatraFinal.Value.Day);

                    if (dataOut < dataIn) throw new DomainException("Erro: data final deve ser maior do que data inicial");
                    _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos, dataIn, dataOut);
                }
                else if (RbFiltraDataEntrega.Checked)
                {
                    DateTime dataIn = new DateTime(dtaFiltroDataIn.Value.Year, dtaFiltroDataIn.Value.Month, dtaFiltroDataIn.Value.Day);
                    DateTime dataOut = new DateTime(dtaFiltroDatraFinal.Value.Year, dtaFiltroDatraFinal.Value.Month, dtaFiltroDatraFinal.Value.Day);

                    if (dataOut < dataIn) throw new DomainException("Erro: data final deve ser maior do que data inicial");
                    _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidosPorPrazo, dataIn, dataOut);
                }
                else
                {
                    _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos, (statusPedido)CbFiltroStatus.SelectedIndex);
                }
                _control.MostrarListaPedidosFiltrada(_ListaPedido);
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvConsultaListaPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Pedido p = _ListaPedido.Find(getPedidoPorCodigo);
                if (dgvConsultaListaPedidos.Columns[e.ColumnIndex].Index == 5)
                {
                    DialogResult res = MessageBox.Show("Deseja realmente deletar o pedido selecionado", "Confirme", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No) throw new DomainException("Operação cancelada");
                    _control.DeletePedidoControl(p);
                    _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos);
                    _control.MostrarListaPedidosFiltrada(DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos));
                    dgvItensPedidos.Rows.Clear();
                    throw new DomainException("Pedido deletado");
                }

                List<Receita> lista = DBConexao.getLisObjectOperation(PedidosDAO.GetListaReceitasPorPedido, p);

                //buscarInformações de Ingredientes
                foreach (Receita r in lista)
                {
                    List<Ingrediente> listaIngrediente = DBConexao.getLisObjectOperation(FichaTenicaDAO.getListaIngredientePorReceita, r);
                    r.ListaIngrediente.Clear();
                    r.ListaIngrediente.AddRange(listaIngrediente);
                }
                p.ListaReceita.Clear();
                p.ListaReceita.AddRange(lista);

            
                CbFormaPag2.SelectedIndex = (int)p.Pagamento;
               
                _control.MostraListaReceitasConsultada(lista);
                txtConsultaNomeCliente.Text = p.NomeCLiente;
                txtConsultaTotalPedido.Text = "R$ " + p.CalculaTotalPedido().ToString("F2");
                txtConsultaDescontoPedido.Text = "R$ " + p.Desconto.ToString("F2");
                txtConsultaTelefone.Text = p.TelefoneCliente.ToString();
                txtConsultaTotalLiquido.Text = "R$ " + p.CalculaTotalLiquidoPedido(p.Desconto).ToString("F2");
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Erro: Nada selecionado. Voçê selecionou um espaço em branco d");
            }
        }

        public void DesmarcaRbs()
        {


        }

        public bool getPedidoPorCodigo(Pedido p)
        {
            string codigo = dgvConsultaListaPedidos.CurrentRow.Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(codigo)) throw new DomainException("Erro: Nada selecionado");
            return (codigo == p.CodigoPedido) ? true : false;
        }

        private void txtNomereceitaPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _ListaPedido = null;

                if (rb_FiltraPorCliente.Checked)
                {
                    string nome = txtNomereceitaPesquisa.Text;
                    if (nome == string.Empty) throw new DomainException("Nemhum nome digitado");
                    _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos, nome);
                    _control.MostrarListaPedidosFiltrada(_ListaPedido);
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ListaPedido is null) throw new DomainException("Nemhuma lista foi filtrada");
                _control.CalculaTotalVendido(_ListaPedido);

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCadListaReceitasPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCadListaReceitasPedido.Columns[e.ColumnIndex].Index == 3)
                {
                    string codigoReceita = dgvCadListaReceitasPedido.CurrentRow.Cells[0].Value.ToString();
                    foreach (Receita r in _pedidoAtual.ListaReceita)
                    {
                        if (r.Id == codigoReceita)
                        {
                            _pedidoAtual.ListaReceita.Remove(r);
                            MessageBox.Show("item: " + r.Descricao + " Romovido da Lista !");
                            break;
                        }
                    }
                    _control.MostraListaReceitaCarrinho(_pedidoAtual.ListaReceita);
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnRemoverFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                _ListaPedido = null;
                _ListaPedido = DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos);
                _control.MostrarListaPedidosFiltrada(_ListaPedido);
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void rb_FiltraPorCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RbFiltroData_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RbFiltraDataEntrega_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RbFiltroStatus_CheckedChanged(object sender, EventArgs e)
        {
            CbFiltroStatus.SelectedIndex = 0;
        }

        private void CbFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFecharPedido_Click(object sender, EventArgs e)
        {
            lbFormaPag.Visible = true;
            CbFormaPag1.Visible = true;
            btnConfirma.Visible = true;
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {

            try
            {
                //validação de dados
                DialogResult res = MessageBox.Show("Confirma o Faturamento(esta operação não pode ser desfeita)", "CONFIRME", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) throw new DomainException("Operação cancelada");
                if (CbFormaPag1.Text == string.Empty) throw new DomainException("Erro: Nemhuma forma de pagamento selecionada");
                if (txtNomeCliente.Text == string.Empty) throw new DomainException("Erro: Nome de cliente nãp pode ser vazio");
                if (txtContatoCliente.Text == string.Empty) throw new DomainException("Erro: Telefone de cliente não pode ser vazio");
                DateTime dataEntrega = Dta_PrazoEntrega.Value;
                if (dataEntrega < (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))) throw new DomainException("Erro: data de entrega não pode ser no passado");
                if (CbFormaPag1.SelectedIndex == 4) throw new DomainException("Forma de pagamento selecionada é invalida");
                
                _pedidoAtual.NomeCLiente = txtNomeCliente.Text;
                _pedidoAtual.Pagamento = (TipoPag)CbFormaPag1.SelectedIndex;
                _pedidoAtual.TelefoneCliente = txtContatoCliente.Text;
                _pedidoAtual.Status = statusPedido.PERDIDO_FECHADO;
                _pedidoAtual.Desconto = double.Parse(txtDesconto.Text);
                _pedidoAtual.DataFechamento = DateTime.Now;
                _pedidoAtual.PrazoEntregada = new DateTime(Dta_PrazoEntrega.Value.Year, Dta_PrazoEntrega.Value.Month, Dta_PrazoEntrega.Value.Day);
                _pedidoAtual.DataPedido = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                _pedidoAtual.Total = double.Parse(txtTotalLiquido.Text);
                _control.ControlInsertPedido(_pedidoAtual);
                MessageBox.Show("Dados de Pedidos Salvos com sucesso !");


                //operações de controle de cadastro
                _pedidoAtual = null;
                _pedidoAtual = new Pedido();
                _pedidoAtual.CodigoPedido = _control.GenerateCodigoReceita();
                Gbox_CabecalhoPedido.Text = "PEDIDO NUMERO -" + _pedidoAtual.CodigoPedido;
                dgv_ListaReceitasCadastradas.Rows.Clear();
                txtCadPedNomeReceita.Text = string.Empty;
                _control.MostraListaReceitaCarrinho(_pedidoAtual.ListaReceita);

                _control.LimparCampos();
                lbFormaPag.Visible = false;
                CbFormaPag1.Visible = false;
                btnConfirma.Visible = false;

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFaturar_Click(object sender, EventArgs e)
        {

            try
            {
                Pedido p = _ListaPedido.Find(getPedidoPorCodigo);
                if (p.Status == statusPedido.PERDIDO_FECHADO) throw new DomainException("Erro: O pedido ja foi faturado na data: " + p.DataFechamento.ToString());
                DialogResult res = MessageBox.Show("Deseja de fato faturar o pedido(esta operação não pode ser desfeita ta )", "confirme:", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) throw new DomainException("Operação cancelada");
                if (CbFormaPag2.Text == string.Empty) throw new DomainException("Erro:  nemhuma forma de pagamento selecionada");
                if (CbFormaPag2.SelectedIndex == 4) throw new DomainException("Forma de Pagamento selecionada é invalida");
                p.Pagamento = (TipoPag)CbFormaPag2.SelectedIndex;

                _control.UpdateStatusPedido(p);
                dgvItensPedidos.Rows.Clear();
                _control.MostrarListaPedidosFiltrada(DBConexao.getLisObjectOperation(PedidosDAO.getListaPedidos));

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Erro: Nada selecionado no Grid");
            }
        }

        private void txtDesconto_KeyDown(object sender, EventArgs e)
        {
            
                if (txtDesconto.Text == string.Empty) txtDesconto.Text = "0,00";
                txtTotalLiquido.Text = _pedidoAtual.CalculaTotalLiquidoPedido(double.Parse(txtDesconto.Text)).ToString("F2");
               _pedidoAtual.Desconto = double.Parse(txtDesconto.Text);
          
        }
    }
}
