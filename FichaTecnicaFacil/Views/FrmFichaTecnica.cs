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
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.Views
{
    public partial class FrmFichaTecnica : Form
    {
        private FichaTecnicaControl _control;
        private Receita _receitaAtual;
        private int Ident = 0;
        private List<Produto> listaIngredienteFiltrados;
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
            this.WindowState = FormWindowState.Minimized;
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

        private void btn_SalvarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ident == 0)
                {
                    //get informações e contrucao de produto
                    string nome = txt_descricaoIngrediente.Text;
                    double preco = double.Parse(txt_PrecoEmbalagem.Text);
                    UN un = (UN)Cb_UNIngrediente.SelectedIndex;
                    double conteudo = double.Parse(txt_ConteudoEmbalagem.Text);

                    Produto p = new Produto(0, preco, conteudo, un, nome);
                    _control.CadastrarIngrediente(p);
                    _control.LimparCampos();
                    _control.ConsultaListaGeralProduto();
                    Ident = 0;
                }
                else if (Ident == 1)
                {
                    int id = int.Parse(txt_idIngrediente.Text);
                    string nome = txt_descricaoIngrediente.Text;
                    double preco = double.Parse(txt_PrecoEmbalagem.Text);
                    UN un = (UN)Cb_UNIngrediente.SelectedIndex;
                    double conteudo = double.Parse(txt_ConteudoEmbalagem.Text);

                    Produto p = new Produto(id, preco, conteudo, un, nome);
                    _control.UpdateProduto(p);
                    _control.LimparCampos();
                    _control.ConsultaListaGeralProduto();
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_PrecoEmbalagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void dgv_ListaProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_ListaProdutos.Columns[e.ColumnIndex].Index == 5)
                {
                    _control.DeleteProduto();
                    _control.ConsultaListaGeralProduto();
                }
                else if (dgv_ListaProdutos.Columns[e.ColumnIndex].Index == 6)
                {
                    _control.GetInformacoesDaTabela();
                    Ident = 1;
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                _control.ConsultaListaGeralProduto();
                txt_descricaoIngrediente.Select();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _control.LimparCampos();
        }

        private void txt_descricaoIngrediente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_PrecoEmbalagem.Select();
            }
        }

        private void txt_PrecoEmbalagem_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_NovaRecita_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddIngrediente_Click(object sender, EventArgs e)
        {

            try
            {
                Produto p = listaIngredienteFiltrados.Find(getIngredientePeloNome);

                if (p is null)
                {
                    if (string.IsNullOrEmpty(txt_ReceitaNomeIngrediente.Text)) throw new DomainException("erro: Nome do Ingrediente não pode ser vazio");
                    if (string.IsNullOrEmpty(txtReceitaIngQtde.Text)) throw new DomainException("quantidade do Item de Receita nao pode ser vazio");
                    if (string.IsNullOrEmpty(txtRecIngredPrecoEmbalagem.Text)) throw new DomainException("Preço da embalagem não pode ser vazio !");
                    if (string.IsNullOrEmpty(txtRecContEmb.Text)) throw new DomainException("Conteudo da embalagem não pode ser vazio !");
                    if (string.IsNullOrEmpty(CbRecIngUN.Text)) throw new DomainException("Campo de UN não pode ser vazio");

                    string nome = txt_ReceitaNomeIngrediente.Text;
                    double precoEmbalagem = double.Parse(txtRecIngredPrecoEmbalagem.Text);
                    double conteudoEmbalagem = double.Parse(txtRecContEmb.Text);
                    UN un = (UN)CbRecIngUN.SelectedIndex;
                    p = new Produto(0, precoEmbalagem, conteudoEmbalagem, un, nome);
                }

                if (string.IsNullOrEmpty(txtReceitaIngQtde.Text)) throw new DomainException("quantidade do Item de Receita nao pode ser vazio");
                double qtde = double.Parse(txtReceitaIngQtde.Text);
                Ingrediente i = new Ingrediente(0, qtde, p);
                _receitaAtual.AddIngrediente(i);
                MessageBox.Show(p.Descricao + " Adicionado à receita ");
                this.MostraItensReceita();

                txtReceitaIngQtde.Text = string.Empty;
                btn_AddIngrediente.Enabled = false;
                txtReceitaIngQtde.Enabled = false;
                CbRecIngUN.Enabled = false;
                txtRecContEmb.Enabled = false;
                txtRecIngredPrecoEmbalagem.Enabled = false;
                txt_ReceitaNomeIngrediente.Text = string.Empty;
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                txtTotalSomaIngredientes.Text = "R$ " + _receitaAtual.getTotalIngrdiente().ToString("F2");
            }

        }

        public void MostraItensReceita()
        {
            List<Ingrediente> lista = _receitaAtual.ListaIngrediente;
            dgv_RecListaIngredientes.Rows.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)dgv_RecListaIngredientes.Rows[i].Clone();
                linha.Cells[0].Value = lista[i].Produto.Descricao.ToString();
                linha.Cells[0].Style.ForeColor = System.Drawing.Color.Blue;
                linha.Cells[1].Value = lista[i].Qtde + lista[i].Produto.Un.ToString();
                linha.Cells[2].Value = "R$ " + lista[i].Produto.PrecoEmbalagem.ToString("F2");
                linha.Cells[3].Value = lista[i].Produto.ConteudoEmbalagem.ToString();
                linha.Cells[4].Value = lista[i].Produto.Un.ToString();
                linha.Cells[5].Value = lista[i].CalculaCustoIngrediente().ToString("F2");
                dgv_RecListaIngredientes.Rows.Add(linha);
            }
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txt_ValidadeReceita_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ReceitaNomeIngrediente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nomeIngrediente = txt_ReceitaNomeIngrediente.Text;
                if (nomeIngrediente != string.Empty)
                {
                    listaIngredienteFiltrados = _control.GetListaIngrdientePeloNome(nomeIngrediente);
                }
                else
                {
                    this.MostraItensReceita();
                }

                if (listaIngredienteFiltrados.Count == 0)
                {
                    txtRecIngredPrecoEmbalagem.Enabled = true;
                    txtRecContEmb.Enabled = true;
                    CbRecIngUN.Enabled = true;
                    txtRecIngredPrecoEmbalagem.Text = string.Empty;
                    txtRecContEmb.Text = string.Empty;
                    CbRecIngUN.Text = string.Empty;
                    btn_AddIngrediente.Enabled = true;
                    txtReceitaIngQtde.Enabled = true;
                }
                else
                {
                    txtRecIngredPrecoEmbalagem.Enabled = false;
                    txtRecContEmb.Enabled = false;
                    CbRecIngUN.Enabled = false;
                    btn_AddIngrediente.Enabled = false;
                    txtReceitaIngQtde.Enabled = false;
                }

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl_Receita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_Receita.SelectedIndex == 0)
            {
                txt_IdReceita.Text = _control.GenerateCodigoReceita();
                _receitaAtual = new Receita();
                _receitaAtual.Id = txt_IdReceita.Text;
                txt_DescricaoReceita.Select();
                txt_dataCadastro.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void FrmFichaTecnica_Load(object sender, EventArgs e)
        {
            if (tabControl_Receita.SelectedIndex == 0)
            {
                txt_IdReceita.Text = _control.GenerateCodigoReceita();
                _receitaAtual = new Receita();
                _receitaAtual.Id = txt_IdReceita.Text;
                txt_dataCadastro.Text = DateTime.Now.ToShortDateString();
                txt_DescricaoReceita.Select();
            }
        }

        private void dgv_RecListaIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Produto p = listaIngredienteFiltrados.Find(getIngredientePeloNome);

            if (dgv_RecListaIngredientes.Columns[e.ColumnIndex].Index == 6)
            {
                Ingrediente i = _receitaAtual.ListaIngrediente.Find(getIngredientePeloNome);
                _receitaAtual.ListaIngrediente.Remove(i);
                MessageBox.Show("Item removido !");
                this.MostraItensReceita();
                txtTotalSomaIngredientes.Text = string.Empty;
                txtPrecoFinal.Text = string.Empty;

            }
            else
            {

                if (p != null)
                {
                    txt_ReceitaNomeIngrediente.Text = p.Descricao;
                    txtReceitaIngQtde.Select();
                    txtRecIngredPrecoEmbalagem.Text = p.PrecoEmbalagem.ToString("F2");
                    txtRecContEmb.Text = p.ConteudoEmbalagem.ToString("F2");
                    CbRecIngUN.Text = p.Un.ToString();
                    txtReceitaIngQtde.Text = string.Empty;
                    btn_AddIngrediente.Enabled = true;
                    txtReceitaIngQtde.Enabled = true;
                }

            }

        }

        public bool getIngredientePeloNome(Produto p)
        {
            string nome = dgv_RecListaIngredientes.CurrentRow.Cells[0].Value.ToString();
            return (nome == p.Descricao) ? true : false;
        }

        public bool getIngredientePeloNome(Ingrediente i)
        {
            string nome = dgv_RecListaIngredientes.CurrentRow.Cells[0].Value.ToString();
            return (nome == i.Produto.Descricao) ? true : false;
        }

        private void txtGastosAdicionais_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnCalcularCustoReceita_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGastosAdicionais.Text) || string.IsNullOrEmpty(txtCustoMaoObra.Text)) throw new DomainException("Verifique os campos de texto que não podem ser vazios !");
                double gastosGerais = double.Parse(txtGastosAdicionais.Text);
                double MaodeObra = double.Parse(txtCustoMaoObra.Text);
                txtCustoReceita.Text = "R$ " + _receitaAtual.CalculaCustoReceita(gastosGerais, MaodeObra).ToString("F2");
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMargemLucro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMargemLucroDinheiro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void CBox_MargemLucroPerc_CheckedChanged(object sender, EventArgs e)
        {
            if (CBoxMargemLucroPerc.Checked)
            {
                txtMargemLucroDinheiro.Enabled = false;
                CboxMargemReal.Checked = false;
                txtMargemLucroDinheiro.Text = string.Empty;
                txtMargemLucroPerc.Enabled = true;
            }
            else
            {
                txtMargemLucroPerc.Enabled = false;
                txtMargemLucroPerc.Text = string.Empty;
                txtPrecoFinal.Text = string.Empty;
            }
        }

        private void txtPrecoFinal_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboxMargemReal_CheckedChanged(object sender, EventArgs e)
        {

            if (CboxMargemReal.Checked)
            {
                txtMargemLucroDinheiro.Enabled = true;
                CBoxMargemLucroPerc.Checked = false;
            }
            else
            {
                txtMargemLucroDinheiro.Text = string.Empty;
                txtMargemLucroDinheiro.Enabled = false;
                txtPrecoFinal.Text = string.Empty;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCalcularPrecoFinal_Click(object sender, EventArgs e)
        {
            try
            {


                double gastosGerais = double.Parse(txtGastosAdicionais.Text);
                double MaodeObra = double.Parse(txtCustoMaoObra.Text);

                if (CboxMargemReal.Checked)
                {
                    if (txtMargemLucroDinheiro.Text == string.Empty) throw new DomainException("Campo de Margem de Lucro não pode ser vazio");
                    double real = double.Parse(txtMargemLucroDinheiro.Text);
                    txtPrecoFinal.Text = _receitaAtual.CalcularTotalReceitaValorReal(gastosGerais, MaodeObra, real).ToString("F2");
                }
                else
                {
                    if (txtMargemLucroPerc.Text == string.Empty) throw new DomainException("Campo de Margem de Lucro não pode ser vazio");
                    double perc = double.Parse(txtMargemLucroPerc.Text);
                    txtPrecoFinal.Text = _receitaAtual.CalcularTotalReceita(gastosGerais, MaodeObra, perc).ToString("F2");
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtReceitaIngQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.EnterSomenteDec(e);
        }

        private void dgv_RecListaIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotalSomaIngredientes_MouseDown(object sender, MouseEventArgs e)
        {
            txtTotalSomaIngredientes.SelectAll();
        }

        private void txtGastosAdicionais_MouseDown(object sender, MouseEventArgs e)
        {
            txtGastosAdicionais.SelectAll();
        }

        private void txtCustoMaoObra_MouseDown(object sender, MouseEventArgs e)
        {
            txtCustoMaoObra.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //VALIDAÇÃO
                if (_receitaAtual.ListaIngrediente.Count == 0) throw new DomainException("A lista de Ingrediente não pode ser vazia !");
                if (txt_DescricaoReceita.Text == string.Empty) throw new DomainException("Nome de receita não pode ser vazio !");
                if (txt_ValidadeReceita.Text == string.Empty) _receitaAtual.Validade = "não Informado !";
                if (txt_RendimentoReceita.Text == string.Empty) _receitaAtual.Rendimento = "não informado !";

                if (string.IsNullOrEmpty(txtGastosAdicionais.Text) || string.IsNullOrEmpty(txtCustoMaoObra.Text)) throw new DomainException("Verifique os campos de Margem de Lucro que não podem ser vazios !");

                _receitaAtual.GastosGerais = double.Parse(txtGastosAdicionais.Text);
                _receitaAtual.Data = DateTime.Now;
                _receitaAtual.ValorMaoObra = double.Parse(txtCustoMaoObra.Text);
                _receitaAtual.Validade = txt_ValidadeReceita.Text;
                _receitaAtual.Descricao = txt_DescricaoReceita.Text;
                _receitaAtual.Rendimento = txt_RendimentoReceita.Text;
                _receitaAtual.Id = txt_IdReceita.Text;

                double MargemLucroValorReal = double.Parse(txtMargemLucroDinheiro.Text);
                double totalCustoReceita = _receitaAtual.CalculaCustoReceita(_receitaAtual.GastosGerais, _receitaAtual.ValorMaoObra);

                if (CboxMargemReal.Checked)
                {
                    if (txtMargemLucroDinheiro.Text == string.Empty) throw new DomainException("Campo de Margem de Lucro não pode ser vazio");
                    _receitaAtual.MargemLucro = (MargemLucroValorReal / totalCustoReceita) * 100;
                }
                else
                {
                    if (txtMargemLucroPerc.Text == string.Empty) throw new DomainException("Campo de Margem de Lucro não pode ser vazio");
                    _receitaAtual.MargemLucro = double.Parse(txtMargemLucroPerc.Text);
                }

                _control.InsertReceitaControl(_receitaAtual);

            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
