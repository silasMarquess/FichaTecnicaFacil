﻿using System;
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

        public void ControlInsertPedido(Pedido p)
        {
            Action<Pedido> acao = PedidosDAO.InsertPedido;
            DBConexao.ModifyOperation(acao, p);
            foreach (Receita r in p.ListaReceita)
            {
                Venda v = new Venda(p, r);
                DBConexao.ModifyOperation(PedidosDAO.InsertVenda, v);
            }
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

                linha.Cells[2].Value = "R$ "+lista[i].CalcularTotalReceita(lista[i].GastosGerais, lista[i].ValorMaoObra, lista[i].MargemLucro).ToString("F2");
                _form.dgvCadListaReceitasPedido.Rows.Add(linha);
            }
        }

        public void LimparCampos()
        {
            _form.txtTotalBruto.Text = "0,00";
            _form.txtDesconto.Text = "0,00";
            _form.txtTotalLiquido.Text = "0,00";
            _form.txtNomeCliente.Text = string.Empty;
            _form.Dta_PrazoEntrega.Value = DateTime.Now;
            _form.txtContatoCliente.Text = "";
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

        public void MostrarListaPedidosFiltrada(List<Pedido> listaFonte)
        {
            double soma = 0;
            double totaldesconto = 0;

            _form.dgvConsultaListaPedidos.Rows.Clear();
            for (int i = 0; i < listaFonte.Count; i++)
            {
                totaldesconto += listaFonte[i].Desconto;
                DataGridViewRow linha = (DataGridViewRow)_form.dgvConsultaListaPedidos.Rows[i].Clone();

                linha.Cells[0].Value = listaFonte[i].CodigoPedido;
                linha.Cells[1].Value = listaFonte[i].DataPedido.ToShortDateString();

                linha.Cells[2].Value = listaFonte[i].NomeCLiente.ToUpper();
                linha.Cells[3].Value = listaFonte[i].PrazoEntregada.ToShortDateString();

                linha.Cells[4].Value = listaFonte[i].Status.ToString();
                _form.dgvConsultaListaPedidos.Rows.Add(linha);
            }

            _form.txtQtdeFiltrados.Text = listaFonte.Count().ToString();
            _form.txtConsultaTotaldesconto.Text = "R$ " + totaldesconto.ToString("F2");
        }

        public void DeletePedidoControl(Pedido p)
        {
            DBConexao.ModifyOperation(PedidosDAO.deletePedido, p);
        }

        public void UpdateStatusPedido(Pedido p)
        {
            DBConexao.ModifyOperation(PedidosDAO.UpdateStatusPedido, p);
        }

        public void CalculaTotalVendido(List<Pedido> listaFonte)
        {
            double soma = 0;
            double totaldesconto = 0;

            foreach (Pedido p in listaFonte)
            {
                List<Receita> lista = DBConexao.getLisObjectOperation(PedidosDAO.GetListaReceitasPorPedido, p);
                p.ListaReceita.Clear();

                foreach (Receita r in lista)
                {
                    List<Ingrediente> listaI = DBConexao.getLisObjectOperation(FichaTenicaDAO.getListaIngredientePorReceita, r);
                    r.ListaIngrediente.Clear();
                    r.ListaIngrediente.AddRange(listaI);
                    p.AddReceita(r);
                }

                soma += p.CalculaTotalLiquidoPedido(p.Desconto);
            }

            _form.txtConsultaTotalVendido.Text = "R$ "+soma.ToString("F2");
        }

        public void MostraListaReceitasConsultada(List<Receita> listaFonte)
        {
            _form.dgvItensPedidos.Rows.Clear();
            for (int i = 0; i < listaFonte.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgvItensPedidos.Rows[i].Clone();
                linha.Cells[0].Value = listaFonte[i].Id;
                linha.Cells[1].Value = listaFonte[i].Descricao;
                linha.Cells[2].Value = "R$ " + listaFonte[i].CalcularTotalReceita(listaFonte[i].GastosGerais, listaFonte[i].ValorMaoObra, listaFonte[i].MargemLucro).ToString("F2");
                _form.dgvItensPedidos.Rows.Add(linha);
            }
        }
    }
}
