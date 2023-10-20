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

namespace FichaTecnicaFacil.Views
{
    public partial class FrmPedidos : Form
    {

        private FrmPedidoControl _control;
        private Pedido _pedidoAtual;
        private Form1Controler _formControler;
        private List<Receita> listaReceitaFiltrada;
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
                if (nome == string.Empty) throw new DomainException("Erro nada filtrado");
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
                    _control.MostraListaReceitaCarrinho(_pedidoAtual.ListaReceita);
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
            return (r.Id==codigo) ? true : false;
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
            Gbox_CabecalhoPedido.Text = "PEDIDO NUMERO -" + _pedidoAtual.CodigoPedido;
        }

        private void TabControlPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
