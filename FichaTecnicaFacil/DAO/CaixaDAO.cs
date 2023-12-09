using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FichaTecnicaFacil.Entidades;
using MySql.Data.MySqlClient;
using FichaTecnicaFacil.Entidades.enums;
using System.Threading.Tasks;

namespace FichaTecnicaFacil.DAO
{
    class CaixaDAO : DBConexao
    {
        public static void InsertCaixa(Caixa c)
        {
            string sql = "insert into Caixa(codigoCaixa, horaAbert, horaFechamento, valorInicio, totalEntrada,totalSaida," +
                "valorFechamento,valorQuebra,status) values(@codigoCaixa, @horaAbert, @horaFechamento, @valorInicio, @totalEntrada,@totalSaida," +
                "@valorFechamento,@valorQuebra,@status)";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigoCaixa", c.codigoCaixa);
            cmd.Parameters.AddWithValue("@horaAbert", c.HoraAbert);
            cmd.Parameters.AddWithValue("@horaFechamento", c.HoraFechamento);
            cmd.Parameters.AddWithValue("@valorInicio", c.ValorInicio);
            cmd.Parameters.AddWithValue("@totalEntrada", c.TotalEntrada);
            cmd.Parameters.AddWithValue("@totalSaida", c.TotalSaida);
            cmd.Parameters.AddWithValue("@valorFechamento", c.ValorFechamento);
            cmd.Parameters.AddWithValue("@valorQuebra", c.ValorQuebra);
            cmd.Parameters.AddWithValue("@status", (int)c.statusCaixa);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteCaixa(Caixa c)
        {
            string sql = "delete from Caixa where codigoCaixa = @caixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@caixa", c.codigoCaixa);
            cmd.ExecuteNonQuery();

        }

        public static void UpdateStatusCaixa(Caixa c, statusCaixa status)
        {
            string sql = "update Caixa set status = @status where codigoCaixa = @caixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@status", (int)status);
            cmd.Parameters.AddWithValue("@caixa", c.codigoCaixa);
            cmd.ExecuteNonQuery();
        }

        public static List<Caixa> getListaCaixa(DateTime dataInicio, DateTime dataFim)
        {
            List<Caixa> lista = new List<Caixa>();
            string sql = "select * from Caixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Caixa c = new Caixa();
                c.codigoCaixa = rd.GetString("codigoCaixa");
                c.HoraAbert = rd.GetDateTime("horaAbert");
                c.HoraFechamento = rd.GetDateTime("horaFechamento");
                if (rd["valorInicio"] != null) c.ValorInicio = rd.GetDouble("valorInicio");
                c.TotalEntrada = rd.GetDouble("totalEntrada");
                c.TotalSaida = rd.GetDouble("totalSaida");
                c.ValorFechamento = rd.GetDouble("ValorFechamento");
                c.ValorQuebra = rd.GetDouble("ValorQuebra");
                c.statusCaixa = (statusCaixa)rd.GetInt16("status");

                DateTime dataIN = new DateTime(c.HoraAbert.Year, c.HoraAbert.Month, c.HoraAbert.Day);

                if (dataInicio <= dataIN && dataIN <= dataFim)
                {
                    lista.Add(c);
                }
            }
            return lista;
        }


        public static List<Caixa> getListaCaixa()
        {
            List<Caixa> lista = new List<Caixa>();
            string sql = "select * from Caixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Caixa c = new Caixa();
                c.codigoCaixa = rd.GetString("codigoCaixa");
                c.HoraAbert = rd.GetDateTime("horaAbert");
                c.HoraFechamento = rd.GetDateTime("horaFechamento");
                if (rd["valorInicio"] != null) c.ValorInicio = rd.GetDouble("valorInicio");
                c.TotalEntrada = rd.GetDouble("totalEntrada");
                c.TotalSaida = rd.GetDouble("totalSaida");
                c.ValorFechamento = rd.GetDouble("ValorFechamento");
                c.ValorQuebra = rd.GetDouble("ValorQuebra");
                c.statusCaixa = (statusCaixa)rd.GetInt16("status");
                DateTime dataIN = new DateTime(c.HoraAbert.Year, c.HoraAbert.Month, c.HoraAbert.Day);
                lista.Add(c);

            }
            return lista;
        }

        public static bool VerificaCodigoCaixa(string codigo)
        {
            string sql = "select * from Caixa where codigoCaixa = @codigoCaixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigoCaixa",codigo);
            MySqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read()) ? true : false;
        }

        public static List<Caixa> getListaCaixaAberto()
        {
            List<Caixa> lista = new List<Caixa>();
            string sql = "select * from Caixa where status = @statusCaixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@statusCaixa", (int)statusCaixa.CAIXA_ABERTO);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Caixa c = new Caixa();
                c.codigoCaixa = rd.GetString("codigoCaixa");
                c.HoraAbert = rd.GetDateTime("horaAbert");
                c.HoraFechamento = rd.GetDateTime("horaFechamento");
                if (rd["valorInicio"] != null) c.ValorInicio = rd.GetDouble("valorInicio");
                c.TotalEntrada = rd.GetDouble("totalEntrada");
                c.TotalSaida = rd.GetDouble("totalSaida");
                c.ValorFechamento = rd.GetDouble("ValorFechamento");
                c.ValorQuebra = rd.GetDouble("ValorQuebra");
                c.statusCaixa = (statusCaixa)rd.GetInt16("status");
                DateTime dataIN = new DateTime(c.HoraAbert.Year, c.HoraAbert.Month, c.HoraAbert.Day);
                lista.Add(c);

            }
            return lista;
        }


        public static void Insertfluxo(Fluxo f)
        {
            string sql = "insert into Fluxo(descricao, valor, tipo, horario, data)" +
                "values(@descricao,@valor, @tipo, @horario, @data)";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("descricao", f.Descricao);
            cmd.Parameters.AddWithValue("@valor", f.Valor);
            cmd.Parameters.AddWithValue("@tipo", (int)f.Tipo);
            cmd.Parameters.AddWithValue("@horario", f.Horario);
            cmd.Parameters.AddWithValue("@data", f.data);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteFluxo(Fluxo f)
        {
            string sql = "delete from Fluxo where id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("idFluxo", f.Id);
            cmd.ExecuteNonQuery();
        }

        public static void getListaFluxoPorCaixa(Caixa c)
        {
            string sql = "select * from Fluxo where fk_Caixa_codigoCaixa = @codigoCaixa";
            MySqlCommand cmd = new MySqlCommand(sql, DBConexao._conexao);
            cmd.Parameters.AddWithValue("@codigoCaixa", c.codigoCaixa);

            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Fluxo f = new Fluxo();
                f.Id = rd.GetInt32("idFluxo");
                f.Descricao = rd.GetString("descricao");
                f.Valor = rd.GetDouble("valor");
                f.Tipo = (tipoFluxo)rd.GetInt32("tipo");
                f.Horario = rd.GetDateTime("horario");
                f.data = rd.GetDateTime("data");
                c.AddFluxo(f);
            }
        }




    }
}
