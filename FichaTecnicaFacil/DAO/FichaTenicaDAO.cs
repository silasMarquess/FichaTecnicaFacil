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
            string sql = "insert into Receita(idReceita,data, MargemLucro, ValorMaoObra, validade, descricaoReceita, rendimento,gastosGerais) " +
                 "values(@idReceita,@data, @MargemLucro, @ValorMaoObra, @validade, @descricaoReceita, @rendimento, @gastosGerais)";

            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@idReceita", r.Id);
            cmd.Parameters.AddWithValue("@data", r.Data);

            cmd.Parameters.AddWithValue("@MargemLucro", r.MargemLucro);
            cmd.Parameters.AddWithValue("@ValorMaoObra", r.ValorMaoObra);

            cmd.Parameters.AddWithValue("@validade", r.Validade);
            cmd.Parameters.AddWithValue("@descricaoReceita", r.Descricao);
            cmd.Parameters.AddWithValue("@rendimento", r.Rendimento);
            cmd.Parameters.AddWithValue("@gastosGerais", r.GastosGerais);
            cmd.ExecuteNonQuery();
        }

        public static void InsertItemReceita(Receita r)
        {
            string sql = "insert into ingrediente(qtde, fk_Receita_idReceita, fk_Produto_idProduto) " +
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


        public static void UpdateItemReceita(Receita r)
        {
            string sql = "update Ingrediente qtde = @qtde where fk_Receita_idreceita = @idreceita";

            foreach (Ingrediente i in r.ListaIngrediente)
            {
                MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
                cmd.Parameters.AddWithValue("@qtde", i.Qtde);
                cmd.Parameters.AddWithValue("@fk_Receita_idReceita", r.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void deleteIngredientePorReceita(Receita r)
        {
            string query = "delete from Ingrediente where fk_Receita_Idreceita = @receita";
            MySqlCommand cmd = new MySqlCommand(query, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@receita", r.Id);
            cmd.ExecuteNonQuery();
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
                string validade = rd.GetString("validade");
                string descricao = rd.GetString("descricaoReceita");
                string redimento = rd.GetString("rendimento");
                double gastosGerais = rd.GetDouble("gastosGerais");

                Receita receita = new Receita(id, redimento, margemLucro, valorMaoObra, validade, descricao, data, gastosGerais);
                lista.Add(receita);
            }
            return lista;

        }

        public static List<Receita> getListaReceita(string nomeReceita)
        {
            List<Receita> lista = new List<Receita>();
            string sql = "select * from receita where descricaoReceita LIKE '%" + nomeReceita + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string id = rd.GetString("idReceita");
                DateTime data = rd.GetDateTime("data");
                double margemLucro = rd.GetDouble("MargemLucro");
                double valorMaoObra = rd.GetDouble("ValorMaoObra");
                string validade = rd.GetString("validade");
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
            string sql = "update Receita set MargemLucro =@margemLucro, valorMaoObra=@valorMaoObra, validade =@validade, descricaoReceita = @descricao, " +
                "rendimento = @rendimento, gastosGerais = @gastosGerais  where idReceita = @idReceita";

            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@idReceita", r.Id);

            cmd.Parameters.AddWithValue("@margemLucro", r.MargemLucro);
            cmd.Parameters.AddWithValue("@ValorMaoObra", r.ValorMaoObra);

            cmd.Parameters.AddWithValue("@validade", r.Validade);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@rendimento", r.Rendimento);
            cmd.Parameters.AddWithValue("@gastosGerais", r.GastosGerais);
            cmd.ExecuteNonQuery();

        }

        public static int getIdProdutoPorDescrica(string descricao)
        {
            int id = 0;
            string sql = "select * from Produto where descricao = @descricao";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            MySqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                id = rd.GetInt32("idProduto");
            }
            return id;

        }

        public static List<Ingrediente> getListaIngredientePorReceita(Receita r)
        {
            List<Ingrediente> lista = new List<Ingrediente>();

            string sql = "select i.qtde, i.idIngrediente, p.idProduto, p.PrecoEmbalagem, p.ConteudoEmbalagem, p.UN, p.descricao " +
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
                double precoProduto = rd.GetDouble("precoEmbalagem");
                double conteudoEmbalagem = rd.GetDouble("conteudoEmbalagem");
                UN un = (UN)rd.GetInt32("UN");
                string descricao = rd.GetString("descricao");

                Produto p = new Produto(idProduto, precoProduto, conteudoEmbalagem, un, descricao);

                double qtde = rd.GetDouble("qtde");
                int idIngrediente = rd.GetInt32("idIngrediente");
                Ingrediente I = new Ingrediente(idIngrediente, qtde, p);
                lista.Add(I);

            }
            return lista;

        }


        public static bool VerificaSeIngredienteInDataBAse(Produto p)
        {
            string sql = "select * from Produto where descricao = @descricao ";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@descricao", p.Descricao);
            MySqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
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
            string sql = "select * from receita where descricaoReceita = @descricaoReceita";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@descricaoReceita", r.Descricao);
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
