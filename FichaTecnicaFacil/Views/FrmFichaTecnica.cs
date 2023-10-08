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
            if(_receitaAtual is null)
            {
                MessageBox.Show("Nemhuma Instâncida de receita Iniciada");
                //validar

            }
            else
            {
                Ingrediente i = new Ingrediente();

                
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
                listaIngredienteFiltrados = _control.GetListaIngrdientePeloNome(nomeIngrediente);

                if (listaIngredienteFiltrados.Count == 0)
                {
                    txtRecIngredPrecoEmbalagem.Enabled = true;
                    txtRecContEmb.Enabled = true;
                    CbRecIngUN.Enabled = true;
                    txtRecIngredPrecoEmbalagem.Text = string.Empty;
                    txtRecContEmb.Text = string.Empty;
                    CbRecIngUN.Text = string.Empty;
                }
                else
                {
                    txtRecIngredPrecoEmbalagem.Enabled = false;
                    txtRecContEmb.Enabled = false;
                    CbRecIngUN.Enabled = false;
                }

            }catch(DomainException ex)
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
            }
        }

        private void FrmFichaTecnica_Load(object sender, EventArgs e)
        {
            if (tabControl_Receita.SelectedIndex == 0)
            {
                txt_IdReceita.Text = _control.GenerateCodigoReceita();
                _receitaAtual = new Receita();
                _receitaAtual.Id = txt_IdReceita.Text;
                txt_DescricaoReceita.Select();
            }
        }

        private void dgv_RecListaIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Produto p = listaIngredienteFiltrados.Find(getIngredientePeloNome);
            txt_ReceitaNomeIngrediente.Text = p.Descricao;
            txtReceitaIngQtde.Select();
            txtRecIngredPrecoEmbalagem.Text = p.PrecoEmbalagem.ToString("F2");
            txtRecContEmb.Text = p.ConteudoEmbalagem.ToString("F2");
            CbRecIngUN.Text = p.Un.ToString();

        }

        public bool getIngredientePeloNome(Produto p)
        {
            string nome = dgv_RecListaIngredientes.CurrentRow.Cells[0].Value.ToString();
            return (nome == p.Descricao) ? true : false;
        }
    }
}
