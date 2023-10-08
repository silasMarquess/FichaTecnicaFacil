using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades;
using MySql.Data.MySqlClient;
using Npgsql;
using FichaTecnicaFacil.Entidades.enums;
namespace FichaTecnicaFacil.DAO

{
    class FichaTenicaDAO
    {
        public static void InsertFicha(Receita r)
        {
            string sql = "insert into Receita(idReceita,data, MargemLucro, ValorMaoObra, validade, descricaoReceita, rendimento) " +
                 "values(@idReceita,@data, @MargemLucro, @ValorMaoObra, @validade, @descricaoReceita, @rendimento)";

            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@idReceita", r.Id);
            cmd.Parameters.AddWithValue("@data", r.Data);

            cmd.Parameters.AddWithValue("@MargemLucro", r.MargemLucro);
            cmd.Parameters.AddWithValue("@ValorMaoObra", r.ValorMaoObra);

            cmd.Parameters.AddWithValue("@validade", r.Validade);
            cmd.Parameters.AddWithValue("@descricaoReceita", r.Descricao);
            cmd.Parameters.AddWithValue("@rendimento", r.Rendimento);
            cmd.ExecuteNonQuery();
        }

        public void InsertItemReceita(Receita r)
        {
            string sql = "insert into ingrediente(qtde, fk_Reeita_idReceita, fk_Produto_idProduto) " +
                "values (@qtde,@fk_Receita_idReceita, @fk_Produto_idProduto)";

            foreach (Ingrediente i in r.ListaIngrediente)
            {
                MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
                cmd.Parameters.AddWithValue("@qtde", i.Qtde);
                cmd.Parameters.AddWithValue("@fk_Receita_idReceita", r.Id);
                cmd.Parameters.AddWithValue("@fk_Produto_idProduto", i.Produto.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Receita> getListaReceita()
        {
            List<Receita> lista = new List<Receita>();
            string sql = "select * from receita";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string id = rd.GetString("idReceita");
                DateTime data = rd.GetDateTime("data");
                double margemLucro = rd.GetDouble("MargemLucro");
                double valorMaoObra = rd.GetDouble("ValorMaoObra");
                DateTime validade = rd.GetDateTime("validade");
                string descricao = rd.GetString("descricaoReceita");
                string redimento = rd.GetString("rendimento");
                double gastosGerais = rd.GetDouble("gastosGerais");

                Receita receita = new Receita(id, redimento, margemLucro, valorMaoObra, validade, descricao, data, gastosGerais);
                lista.Add(receita);
            }
            return lista;

        }


        public static void UpdateReceita(Receita r)
        {
            string sql = "update Receita set MargemLucro =@margemLucro, valorMaoObra=@valorMaoObra, validade =@validade, descricaoReceita = @descricao," +
                "rendimento =@rendimento  where idReceita = @idReceita";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@idReceita", r.Id);

            cmd.Parameters.AddWithValue("@MargemLucro", r.MargemLucro);
            cmd.Parameters.AddWithValue("@ValorMaoObra", r.ValorMaoObra);

            cmd.Parameters.AddWithValue("@validade", r.Validade);
            cmd.Parameters.AddWithValue("@descricaoReceita", r.Descricao);
            cmd.Parameters.AddWithValue("@rendimento", r.Rendimento);
            cmd.ExecuteNonQuery();

        }

        public static void getListaIngredientePorReceita(Receita r)
        {
            string sql = "select i.qtde, i.idIngrediente, p.idProduto, p.PrecoEmbalagem, p.ConteudoEmbalagem, p.UN, p.descricao from Ingrediente " +
                "from Ingrediente as i  " +
                "inner join Produto as p " +
                "on fk_produto_idProduto = p.idProduto " +
                "where fk_Receita_idReceita = @idReceita";

            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@idReceita", r.Id);

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                //Fazendo Produto
                int idProduto = rd.GetInt32("idProduto");
                double precoProduto = rd.GetDouble("precoProduto");
                double conteudoEmbalagem = rd.GetDouble("conteudoEmbalagem");
                UN un = (UN)rd.GetInt32("UN");
                string descricao = rd.GetString("descricao");

                Produto p = new Produto(idProduto, precoProduto, conteudoEmbalagem, un, descricao);

                double qtde = rd.GetDouble("qtde");
                int idIngrediente = rd.GetInt32("idIngrediente");
                Ingrediente I = new Ingrediente(idIngrediente, qtde, p);
                r.AddIngrediente(I);

            }

        }


        public static void DeleteReceita(Receita r)
        {
            string sql = "delete from Receita where idReceita = @idReceita";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@idReceita", r.Id);
            cmd.ExecuteNonQuery();
        }


        public static bool VerificaSeReceitaExiste(Receita r)
        {
            string sql = "select * from receita where descricaoReceiat = @descricaoReceita";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
        }

        public static bool VerificaSeIdReceitaExiste(string IdReceita)
        {
            string sql = "select * from receita where idReceita =@IdReceita";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@IdReceita", IdReceita);
            MySqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
        }
    }
}
