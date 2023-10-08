using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades;
using Npgsql;
using MySql.Data.MySqlClient;
using FichaTecnicaFacil.Entidades.enums;

namespace FichaTecnicaFacil.DAO
{
    class ProdutoDAO
    {
        public static void InsertProduto(Produto p)
        {
            string sql = "insert into Produto(PrecoEmbalagem, ConteudoEmbalagem, UN, descricao) " +
                "values(@PrecoEmbalagem, @ConteudoEmbalagem, @UN, @descricao)";

            MySqlCommand cmd  =  new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@PrecoEmbalagem", p.PrecoEmbalagem);
            cmd.Parameters.AddWithValue("@ConteudoEmbalagem", p.ConteudoEmbalagem);
            cmd.Parameters.AddWithValue("@UN", (int)p.Un);
            cmd.Parameters.AddWithValue("@descricao", p.Descricao);
            cmd.ExecuteNonQuery();
        }


        public static void UpdateProduto(Produto p)
        {
            string sql = "update Produto set PrecoEmbalagem = @PrecoEmbalagem, ConteudoEmbalagem=@ConteudoEmbalagem,UN=@UN," +
                " descricao = @descricao where idProduto = @id";

            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@PrecoEmbalagem", p.PrecoEmbalagem);
            cmd.Parameters.AddWithValue("@ConteudoEmbalagem", p.ConteudoEmbalagem);
            cmd.Parameters.AddWithValue("@UN", (int)p.Un);
            cmd.Parameters.AddWithValue("@descricao", p.Descricao);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteProduto(Produto p)
        {
            string sql = "delete from produto where idProduto = @id";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.ExecuteNonQuery();
        }

        public  static List<Produto> getListaProdutos()
        {
            List<Produto> lista = new List<Produto>();
            string sql = "select * from  produto";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int idProduto = rd.GetInt32("idProduto");
                double precoEmbalagem = rd.GetDouble("precoEmbalagem");
                double conteudo = rd.GetDouble("conteudoEmbalagem");
                UN un = (UN)rd.GetInt16("UN");
                string descricao = rd.GetString("descricao");
                Produto p = new Produto(idProduto, precoEmbalagem, conteudo, un, descricao);
                lista.Add(p);
            }
            return lista;
        }

        public static List<Produto> getListaProdutos(string descricao)
        {
            List<Produto> lista = new List<Produto>();
            string sql = "select * from  produto  where descricao LIKE '"+descricao+"%'";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int idProduto = rd.GetInt32("idProduto");
                double precoEmbalagem = rd.GetDouble("precoEmbalagem");
                double conteudo = rd.GetDouble("conteudoEmbalagem");
                UN un = (UN)rd.GetInt16("UN");
                string descricao2 = rd.GetString("descricao");
                Produto p = new Produto(idProduto, precoEmbalagem, conteudo, un, descricao2);
                lista.Add(p);
            }
            return lista;
        }

        public static bool VerificaSeJaExiste(Produto p)
        {
            string sql = "Select * from Produto where descricao = @descricao and UN =@un and  PrecoEmbalagem = @preco";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@Un", (int)p.Un);
            cmd.Parameters.AddWithValue("@descricao", p.Descricao);
            cmd.Parameters.AddWithValue("@preco", p.PrecoEmbalagem);

            MySqlDataReader  rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
        }
    }
}
