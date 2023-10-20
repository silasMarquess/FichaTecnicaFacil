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
using FichaTecnicaFacil.Views;


namespace FichaTecnicaFacil.Controler
{
    class FrmPedidoControl
    {
        private FrmPedidos _form;

        public FrmPedidoControl(FrmPedidos form)
        {
            _form = form;
        }

        private void ControlInsertPedido(Pedido p)
        {
            Action<Pedido> acao = PedidosDAO.InsertPedido;
            DBConexao.ModifyOperation(acao, p);

            foreach (Receita r in p.ListaReceita)
            {
                Venda v = new Venda(p, r);
                DBConexao.ModifyOperation(PedidosDAO.InsertVenda, v);
            }
            MessageBox.Show("Pedido Registrado com sucesso !");
        }

        public string GenerateCodigoReceita()
        {
            Random rd = new Random();
            int numeros = rd.Next();
            string codigo = "PE" + numeros.ToString().Substring(0, 4);
            bool teste = DBConexao.ValidateOperation(PedidosDAO.VerificaCodigo, codigo);

            while (teste)
            {
                numeros = rd.Next();
                codigo = numeros.ToString().Substring(0, 4);
            }
            return codigo;
        }

        public void MostraListaReceitaCarrinho(List<Receita> lista)
        {
            _form.dgvCadListaReceitasPedido.Rows.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                List<Ingrediente> listaI = DBConexao.getLisObjectOperation(FichaTenicaDAO.getListaIngredientePorReceita, lista[i]);
                lista[i].ListaIngrediente.Clear();
                lista[i].ListaIngrediente.AddRange(listaI);

                DataGridViewRow linha = (DataGridViewRow)_form.dgvCadListaReceitasPedido.Rows[i].Clone();

                linha.Cells[0].Value = lista[i].Id.ToString();
                linha.Cells[1].Value = lista[i].Descricao.ToString();

                linha.Cells[2].Value = lista[i].CalcularTotalReceita(lista[i].GastosGerais, lista[i].ValorMaoObra, lista[i].MargemLucro);
                linha.Cells[3].Value = lista[i].Validade;
                _form.dgvCadListaReceitasPedido.Rows.Add(linha);
            }
        }

        public void MostraListaReceita(List<Receita> listaFonte)
        {
            _form.dgv_ListaReceitasCadastradas.Rows.Clear();

            for (int i = 0; i < listaFonte.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgv_ListaReceitasCadastradas.Rows[i].Clone();

                linha.Cells[0].Value = listaFonte[i].Id.ToString();
                linha.Cells[1].Value = listaFonte[i].Descricao.ToString();

                linha.Cells[2].Value = listaFonte[i].Rendimento;
                linha.Cells[3].Value = listaFonte[i].Validade;

                linha.Cells[4].Value = listaFonte[i].Data.ToShortDateString();

                _form.dgv_ListaReceitasCadastradas.Rows.Add(linha);
            }
        }
    }
}
