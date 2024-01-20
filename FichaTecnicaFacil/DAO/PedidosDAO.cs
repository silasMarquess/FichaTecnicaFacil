using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades;
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.Views;
using MySql.Data.MySqlClient;

namespace FichaTecnicaFacil.DAO
{
    class PedidosDAO
    {


        public static void InsertVenda(Venda v)
        {
            string query = "insert into Venda(fk_receita_idReceita, fk_pedido_codigoPedido) values(@receita,@pedido)";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@receita", v.Receita.Id);
            cmd.Parameters.AddWithValue("@pedido", v.Pedido.CodigoPedido);
            cmd.ExecuteNonQuery();

        }
        public static void InsertPedido(Pedido p)
        {
            string sql = "insert into Pedido(codigoPedido, dataPedido, statusPedido, Prazoentrega, desconto, dataFechamento, nomeCliente, whatsApp, f_pagamento) " +
                "values(@codigoPedido, @dataPedido, @statusPedido, @Prazoentrega, @desconto, @dataFechamento, @nomeCliente, @whatsApp, @pagamento)";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigoPedido", p.CodigoPedido);
            cmd.Parameters.AddWithValue("@Prazoentrega", p.PrazoEntregada);
            cmd.Parameters.AddWithValue("@desconto", p.Desconto);
            cmd.Parameters.AddWithValue("@nomeCliente", p.NomeCLiente);
            cmd.Parameters.AddWithValue("@whatsApp", p.TelefoneCliente);
            cmd.Parameters.AddWithValue("@statusPedido", (int)p.Status);
            cmd.Parameters.AddWithValue("@dataFechamento", p.DataFechamento);
            cmd.Parameters.AddWithValue("@dataPedido", p.DataPedido);
            cmd.Parameters.AddWithValue("@pagamento",(int)p.Pagamento);
            cmd.ExecuteNonQuery();
        }

        public static void deletePedido(Pedido p)
        {
            string query = "delete from Pedido where codigoPedido = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigo", p.CodigoPedido);
            cmd.ExecuteNonQuery();
        }

        public static bool VerificaCodigo(string codigo)
        {
            string query = "select codigoPedido from Pedido where codigopedido = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
        }

        public static List<Pedido> getListaPedidos(string nomeCliente)
        {
            List<Pedido> lista = new List<Pedido>();
            string query = "select * from Pedido where nomeCliente LIKE '" + nomeCliente + "%'";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string codigo = rd.GetString("codigoPedido");
                DateTime dataPedido = rd.GetDateTime("dataPedido");
                statusPedido status = (statusPedido)rd.GetInt16("statusPedido");
                double desconto = rd.GetDouble("desconto");
                DateTime? dataFechamento = ValidadaDadosNull.ConverteData(rd["dataFechamento"], false);
                string nomeCliente2 = rd.GetString("nomeCliente");
                DateTime prazo = rd.GetDateTime("PrazoEntrega");
                string telefone = rd.GetString("whatsApp");
                double total = rd.GetDouble("total");
                TipoPag pag;

                if (rd["f_pagamento"] == null || status==statusPedido.PERDIDO_ABERTO)
                {
                    pag = TipoPag.NÃO_PAGO;
                }
                else
                {
                    pag = (TipoPag)rd.GetInt16("f_pagamento");
                }

                Pedido p = new Pedido(codigo, dataPedido, desconto, prazo, dataFechamento, status, nomeCliente2, telefone, pag, total);
                lista.Add(p);
            }
            return lista;
        }

        public static List<Pedido> getListaPedidos()
        {
            List<Pedido> lista = new List<Pedido>();
            string query = "select * from Pedido";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string codigo = rd.GetString("codigoPedido");
                DateTime dataPedido = rd.GetDateTime("dataPedido");
                statusPedido status = (statusPedido)rd.GetInt16("statusPedido");
                double desconto = rd.GetDouble("desconto");
                DateTime? dataFechamento = ValidadaDadosNull.ConverteData(rd["dataFechamento"], false);
                string nomeCliente2 = rd.GetString("nomeCliente");
                DateTime prazo = rd.GetDateTime("PrazoEntrega");
                string telefone = rd.GetString("whatsApp");
                double total = rd.GetDouble("total");
                TipoPag pag;

                if (rd["f_pagamento"] == null || status == statusPedido.PERDIDO_ABERTO)
                {
                    pag = TipoPag.NÃO_PAGO;
                }
                else
                {
                    pag = (TipoPag)rd.GetInt16("f_pagamento");
                }

                Pedido p = new Pedido(codigo, dataPedido, desconto, prazo, dataFechamento, status, nomeCliente2, telefone, pag, total);
                lista.Add(p);
            }
            return lista;
        }

        public static List<Pedido> getListaPedidos(DateTime dataIn, DateTime dataOut)
        {
            List<Pedido> lista = new List<Pedido>();
            string query = "select * from Pedido where dataPedido>=@dataIn and datapedido <= @dataOut";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@dataIn", dataIn);
            cmd.Parameters.AddWithValue("@dataOut", dataOut);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string codigo = rd.GetString("codigoPedido");
                DateTime dataPedido = rd.GetDateTime("dataPedido");
                statusPedido status = (statusPedido)rd.GetInt16("statusPedido");
                double desconto = rd.GetDouble("desconto");
                DateTime? dataFechamento = ValidadaDadosNull.ConverteData(rd["dataFechamento"], false);
                string nomeCliente2 = rd.GetString("nomeCliente");
                DateTime prazo = rd.GetDateTime("PrazoEntrega");
                string telefone = rd.GetString("whatsApp");
                double total = rd.GetDouble("total");
                TipoPag pag;

                if (rd["f_pagamento"] == null || status == statusPedido.PERDIDO_ABERTO)
                {
                    pag = TipoPag.NÃO_PAGO;
                }
                else
                {
                    pag = (TipoPag)rd.GetInt16("f_pagamento");
                }

                Pedido p = new Pedido(codigo, dataPedido, desconto, prazo, dataFechamento, status, nomeCliente2, telefone, pag, total);
                lista.Add(p);
            }
            return lista;
        }


        public static List<Pedido> getListaPedidosPorPrazo(DateTime dataIn, DateTime dataOut)
        {
            List<Pedido> lista = new List<Pedido>();
            string query = "select * from Pedido where PrazoEntrega>=@dataIn and PrazoEntrega <= @dataOut and statusPedido = @status";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@dataIn", dataIn);
            cmd.Parameters.AddWithValue("@dataOut", dataOut);
            cmd.Parameters.AddWithValue("@status", (int)statusPedido.PERDIDO_ABERTO);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string codigo = rd.GetString("codigoPedido");
                DateTime dataPedido = rd.GetDateTime("dataPedido");
                statusPedido status = (statusPedido)rd.GetInt16("statusPedido");
                double desconto = rd.GetDouble("desconto");
                DateTime? dataFechamento = ValidadaDadosNull.ConverteData(rd["dataFechamento"], false);
                string nomeCliente2 = rd.GetString("nomeCliente");
                DateTime prazo = rd.GetDateTime("PrazoEntrega");
                string telefone = rd.GetString("whatsApp");
                double total = rd.GetDouble("total");
                TipoPag pag;

                if (rd["f_pagamento"] == null || status == statusPedido.PERDIDO_ABERTO)
                {
                    pag = TipoPag.NÃO_PAGO;
                }
                else
                {
                    pag = (TipoPag)rd.GetInt16("f_pagamento");
                }

                Pedido p = new Pedido(codigo, dataPedido, desconto, prazo, dataFechamento, status, nomeCliente2, telefone, pag, total);
                lista.Add(p);
            }
            return lista;
        }

        public static void UpdateStatusPedido(Pedido p)
        {
            string query = "update Pedido set statusPedido = @status, f_pagamento = @pag where codigoPedido = @codigoPedido";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@status", (int)statusPedido.PERDIDO_FECHADO);
            cmd.Parameters.AddWithValue("@codigoPedido", p.CodigoPedido);
            cmd.Parameters.AddWithValue("@pag",(int) p.Pagamento);
            cmd.ExecuteNonQuery();
        }


        public static List<Pedido> getListaPedidos(statusPedido status)
        {
            List<Pedido> lista = new List<Pedido>();
            string query = "select * from Pedido where statusPedido = @status";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@status", (int)status);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string codigo = rd.GetString("codigoPedido");
                DateTime dataPedido = rd.GetDateTime("dataPedido");
                statusPedido status2 = (statusPedido)rd.GetInt16("statusPedido");
                double desconto = rd.GetDouble("desconto");
                DateTime? dataFechamento = ValidadaDadosNull.ConverteData(rd["dataFechamento"], false);
                string nomeCliente2 = rd.GetString("nomeCliente");
                DateTime prazo = rd.GetDateTime("PrazoEntrega");
                string telefone = rd.GetString("whatsApp");
                double total = rd.GetDouble("total");
                TipoPag pag;

                if (rd["f_pagamento"] == null || status == statusPedido.PERDIDO_ABERTO)
                {
                    pag = TipoPag.NÃO_PAGO;
                }
                else
                {
                    pag = (TipoPag)rd.GetInt16("f_pagamento");
                }

                Pedido p = new Pedido(codigo, dataPedido, desconto, prazo, dataFechamento, status2, nomeCliente2, telefone,pag, total);
                lista.Add(p);
            }
            return lista;
        }

        public static List<Receita> GetListaReceitasPorPedido(Pedido p)
        {
            List<Receita> lista = new List<Receita>();

            string query = "select r.*, v.* from Venda as v " +
                "inner join Receita as r " +
                "on fk_Receita_idReceita = r.idReceita " +
                "where fk_Pedido_codigoPedido = @pedido";

            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@pedido", p.CodigoPedido);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                //construindo instancia de receita
                string codigoReceita = rd.GetString("idReceita");
                DateTime dataCad = rd.GetDateTime("data");
                double MargemLucro = rd.GetDouble("MargemLucro");
                double ValorMaoObra = rd.GetDouble("ValorMaoObra");
                string validade = rd.GetString("Validade");
                string descricaoReceita = rd.GetString("descricaoReceita");
                string rendimento = rd.GetString("Rendimento");
                double gastosGearis = rd.GetDouble("gastosGerais");
                Receita r = new Receita(codigoReceita, rendimento, MargemLucro, ValorMaoObra, validade, descricaoReceita, dataCad, gastosGearis);
                lista.Add(r);
            }
            return lista;

        }
    }
}
