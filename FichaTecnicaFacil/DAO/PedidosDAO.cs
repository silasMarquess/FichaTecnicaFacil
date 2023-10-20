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
            string query = "insert into venda(fk_receita_idReceita, fk_pedido_codigoPedido) values (@receita,@pedido)";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@receita", v.Receita.Id);
            cmd.Parameters.AddWithValue("@pedido", v.Pedido.CodigoPedido);
            cmd.ExecuteNonQuery();

        }
        public static void InsertPedido(Pedido p)
        {
            string sql = "insert into pedido(codigoPedido, dataPedido, statusPedido, Prazoentrega, desconto, dataFechamento, nomeCliente, whatsApp)" +
                "values(@codigoPedido, @@codigoPedido, @statusPedido, @Prazoentrega, @desconto, @dataFechamento, @nomeCliente, @whatsApp)";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigoPedido", p.CodigoPedido); cmd.Parameters.AddWithValue("@Prazoentrega", p.PrazoEntregada);
            cmd.Parameters.AddWithValue("@desconto", p.Desconto); cmd.Parameters.AddWithValue("@nomeCliente", p.NomeCLiente); cmd.Parameters.AddWithValue("@whatsApp",p.TelefoneCliente);
            cmd.Parameters.AddWithValue("@statusPedido", (int)p.Status); cmd.Parameters.AddWithValue("@dataFechamento", p.DataFechamento);
            cmd.Parameters.AddWithValue("@dataPedido", p.DataPedido);
            cmd.ExecuteNonQuery();
        }

        public static void deletePedido(Pedido p)
        {
            string query = "delete from pedido where codigoPedido = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigo", p.CodigoPedido);
            cmd.ExecuteNonQuery();
        }

        public static bool VerificaCodigo(string codigo)
        {
            string query = "select codigoPedido from pedido where codigopedido = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
        }

        public static List<Pedido> getListaPedidos()
        {
            List<Pedido> lista = new List<Pedido>();
            string query = "select * from pedido";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string codigo = rd.GetString("codigostring");
                DateTime dataPedido = rd.GetDateTime("dataPedido");
                statusPedido status = (statusPedido)rd.GetInt16("statusPedido");
                double desconto = rd.GetDouble("desconto");
                DateTime dataFechamento = rd.GetDateTime("dataFechamento");
                string nomeCliente = rd.GetString("nomeCliente");
                DateTime prazo = rd.GetDateTime("PrazoEntrega");
                string telefone = rd.GetString("whatsApp");
                Pedido p = new Pedido(codigo, dataPedido, desconto, prazo, dataFechamento, status, nomeCliente, telefone);
                lista.Add(p);
            }
            return lista;
        }

        public static List<Receita> GetListaReceitasPorPedido(Pedido p)
        {
            List<Receita> lista = new List<Receita>();

            string query = "select r.*, v.* from Venda as v " +
                "inner join receita as r " +
                "on fk_Receita_idReceita = r.idReceita" +
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
