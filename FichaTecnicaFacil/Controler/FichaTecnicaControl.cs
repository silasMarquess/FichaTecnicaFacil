using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Views;
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.Entidades;
using FichaTecnicaFacil.DAO;
using System.Windows.Forms;

namespace FichaTecnicaFacil.Controler
{
    public class FichaTecnicaControl
    {
        private FrmFichaTecnica _form;
        private Form1Controler _formPai;
        private List<Produto> lista;

        public FichaTecnicaControl(FrmFichaTecnica form, Form1Controler formPai)
        {
            _form = form;
            _formPai = formPai;
        }

        internal void ClosedOperation()
        {
            _form.Close();
            _formPai._form.Visible = true;
        }

        public void CadastrarIngrediente(Produto p)
        {
            //validação
            ValidaInsercao();
            bool teste = DBConexao.ValidateOperation(ProdutoDAO.VerificaSeJaExiste, p);
            if (teste) throw new DomainException("Erro:  ingrediente ja esta cadastrado no sistema ");
            //inseririr produto
            DBConexao.ModifyOperation(ProdutoDAO.InsertProduto, p);
            MessageBox.Show("Ingrediente cadastrado com sucesso");
        }

        public void ConsultaListaGeralProduto()
        {
            lista = DBConexao.getLisObjectOperation(ProdutoDAO.getListaProdutos);
            _form.dgv_ListaProdutos.Rows.Clear();

            for(int i =0; i<lista.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgv_ListaProdutos.Rows[i].Clone();
                linha.Cells[0].Value = lista[i].Id.ToString();
                linha.Cells[1].Value = lista[i].Descricao.ToString();
                linha.Cells[1].Style.ForeColor = System.Drawing.Color.Blue;
                linha.Cells[2].Value = "R$ "+lista[i].PrecoEmbalagem.ToString("F2");
                linha.Cells[3].Value = lista[i].ConteudoEmbalagem.ToString();
                linha.Cells[4].Value = lista[i].Un.ToString();
                _form.dgv_ListaProdutos.Rows.Add(linha);
            }
            _form.txt_NumProdutosCadastrados.Text = lista.Count + " Cadastrados !";
        }

        public void DeleteProduto()
        {

            DialogResult res = MessageBox.Show("Confirme a Exclusão do Produto?:", "CONFIRMAÇÃO", MessageBoxButtons.YesNo);
            if(res == DialogResult.No)
            {
                throw new DomainException("Operação cancelada com sucesso !");
            }
            Produto p = lista.Find(getProdutoForID);
            DBConexao.ModifyOperation(ProdutoDAO.DeleteProduto, p);
            MessageBox.Show("Produto Selecioando deletado com sucesso ! ");
        }

        public void UpdateProduto(Produto p)
        {
            ValidaInsercao();
            if (p is null) throw new DomainException("Erro: Nada selecionado");
            DialogResult res = MessageBox.Show("Deseja Atualizar os dados do produto. as Receitas serão atualizadas:", "CONFIRMAÇÃO", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                throw new DomainException("Operação cancelada com sucesso !");
            }
            DBConexao.ModifyOperation(ProdutoDAO.UpdateProduto, p);
            MessageBox.Show("Produto selecionado atualizado com sucesso" );

        }

        public void GetInformacoesDaTabela()
        {
            Produto p = lista.Find(getProdutoForID);
            if (p is null) throw new DomainException("Nada selecionado !");
            _form.txt_idIngrediente.Text = p.Id.ToString();
            _form.txt_descricaoIngrediente.Text = p.Descricao;
            _form.txt_PrecoEmbalagem.Text = p.PrecoEmbalagem.ToString();
            _form.Cb_UNIngrediente.SelectedIndex = (int)p.Un;
            _form.txt_ConteudoEmbalagem.Text = p.ConteudoEmbalagem.ToString();
        }

        public void LimparCampos()
        {
            _form.txt_idIngrediente.Text = string.Empty;
            _form.txt_descricaoIngrediente.Text = string.Empty;
            _form.txt_PrecoEmbalagem.Text = string.Empty;
            _form.txt_ConteudoEmbalagem.Text = string.Empty;
            _form.Cb_UNIngrediente.SelectedIndex = -1;

        }
        

        public void ValidaInsercao()
        {
            if (string.IsNullOrEmpty(_form.txt_descricaoIngrediente.Text))   throw new DomainException("Campo de descrição não pode ser vazio");
            if (string.IsNullOrEmpty(_form.txt_PrecoEmbalagem.Text)) throw new DomainException("Campo de Preco da embalagem nao pode ser vazio");
            if (string.IsNullOrEmpty(_form.Cb_UNIngrediente.Text)) throw new DomainException("UN é orbrigatorio");
            if (string.IsNullOrEmpty(_form.txt_ConteudoEmbalagem.Text)) throw new DomainException("Conteudo total da embalagem é orbrigatorio");
        }


        public bool getProdutoForID(Produto p)
        {
            int id = int.Parse(_form.dgv_ListaProdutos.CurrentRow.Cells[0].Value.ToString());
            return (id == p.Id) ? true : false;
        }



        //CONTROLE DE RECEITAS
        public void InsertReceitaControl(Receita receita)
        {
            ValidaInsercao();
            bool teste = DBConexao.ValidateOperation(FichaTenicaDAO.VerificaSeReceitaExiste, receita);
            if (teste) throw new DomainException("Erro: Receita ja existe");
            DBConexao.ModifyOperation(FichaTenicaDAO.InsertFicha, receita);
            MessageBox.Show("Receita Cadastrada com sucesso !");
        }

        public List<Produto> GetListaIngrdientePeloNome(string nome)
        {
            List<Produto> lista = DBConexao.getLisObjectOperation(ProdutoDAO.getListaProdutos, nome);
            _form.dgv_RecListaIngredientes.Rows.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgv_RecListaIngredientes.Rows[i].Clone();
                linha.Cells[0].Value = lista[i].Descricao.ToString();
                linha.Cells[0].Style.ForeColor = System.Drawing.Color.Blue;
                linha.Cells[1].Value = "0,00";
                linha.Cells[2].Value = "R$ " + lista[i].PrecoEmbalagem.ToString("F2");
                linha.Cells[3].Value = lista[i].ConteudoEmbalagem.ToString();
                linha.Cells[4].Value = lista[i].Un.ToString();
                linha.Cells[5].Value = "0,00"; 
                _form.dgv_RecListaIngredientes.Rows.Add(linha);
            }
            return lista;
        }




        public string GenerateCodigoReceita()
        {
            Random rd = new Random();
            int numeros = rd.Next();
            string codigo = "RE" + numeros.ToString().Substring(0, 4);
            bool teste = DBConexao.ValidateOperation(FichaTenicaDAO.VerificaSeIdReceitaExiste, codigo);

            while (teste)
            {
                numeros = rd.Next();
                codigo = numeros.ToString().Substring(0, 4);
            }
            return codigo;
        }


        public void ValidaInsercaoReceita()
        {
            if (string.IsNullOrEmpty(_form.txt_DescricaoReceita.Text)) throw new DomainException("Nome da Receita nao pode ser vazio");
            if (string.IsNullOrEmpty(_form.txt_RendimentoReceita.Text)) throw new DomainException("Rendimento nao pode ser vazio ");
            if (string.IsNullOrEmpty(_form.txt_ValidadeReceita.Text)) throw new DomainException("Validade da receita nao pode ser vazio ");
        }
    }
}
