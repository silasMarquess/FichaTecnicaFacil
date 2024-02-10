using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Properties;
using MySql.Data.MySqlClient;


namespace FichaTecnicaFacil.DAO
{
    class DBConexao
    {
        public static MySqlConnection _conexao;
        string query = "server=db-fichatec.mysql.uhserver.com;userid=silasadmin;password=S1i2l3a4s5@; database=db_fichatec";
        string url2 = "server=localhost; userid=silas; password=182520; database=db_fichatec";


        public static void ModifyOperation<T>(Action<T> act, T obj)
        {
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    act(obj);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void ModifyOperation<T, J>(Action<T, J> act, T obj, J chave)
        {
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    act(obj, chave);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void ModifyOperation<T, J, S>(Action<T, J, S> act, T obj, J chave, S chave2)
        {
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    act(obj, chave, chave2);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static List<J> getLisObjectOperation<J>(Func<List<J>> get)
        {
            List<J> lista = null;
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {

                    OpenConexao();
                    lista = get();
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public static List<J> getLisObjectOperation<T, J>(Func<T, List<J>> get, T chave)
        {
            List<J> lista = null;
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    lista = get(chave);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public static List<J> getLisObjectOperation<T, H, J>(Func<T, H, List<J>> get, T chave, H chave2)
        {
            List<J> lista = null;
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    lista = get(chave, chave2);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public static J getObjetc<T,J>(Func<T,J> acao,T chave1)
        {
            J obj = (default);
            try
            {
                using (_conexao =new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    obj = acao(chave1);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return obj;
        }

        public static List<J> getLisObjectOperation<T, H, L, J>(Func<T, H, L, List<J>> get, T chave, H chave2, L chave3)
        {
            List<J> lista = null;
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    lista = get(chave, chave2, chave3);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public static List<J> getLisObjectOperation<T, H, M, L, J>(Func<T, H, L, M, List<J>> get, T chave, H chave2, L chave3, M chave4)
        {
            List<J> lista = null;
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    lista = get(chave, chave2, chave3, chave4);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return lista;
        }


        public static bool ValidateOperation<T>(Predicate<T> op, T obj)
        {
            bool test = false;
            try
            {

                using (_conexao = new MySqlConnection(Resources.URL))
                {
                    OpenConexao();
                    test = op(obj);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return test;
        }

        public static void OpenConexao()
        {
            if (_conexao.State == System.Data.ConnectionState.Closed)
            {
                _conexao.Open();
            }
        }
    }
}

