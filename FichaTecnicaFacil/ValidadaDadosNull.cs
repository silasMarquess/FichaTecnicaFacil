using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaTecnicaFacil
{
    class ValidadaDadosNull
    {


        /// <summary>
        /// Tenta converter um objeto como data, 
        ///  --- se apresentar erro e DataNull=False retorna menor data possivel em C#
        ///  ---                      DataNull=true  retorna null 
        /// </summary>
        /// <param name="data">Objeto DateTime</param>
        /// <param name="DataNull">(true/false) se deseja receber um valor nulo</param>
        /// <returns>DateTime/null</returns>
        public static DateTime? ConverteData(object data, Boolean DataNull = false)
        {
            DateTime newData;
            try
            {
                newData = Convert.ToDateTime(data);
            }
            catch (Exception)
            {
                if (DataNull)
                {
                    return null;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }

            return newData;
        }

        /// <summary>
        /// Tenta converter um objeto como string 
        /// --- Se apresentar erro retorna ""
        /// </summary>
        /// <param name="Valor">Objeto string</param>
        /// <returns>retorna string</returns>
        public static string ConverteString(object Valor)
        {
            string newValor;
            try
            {
                newValor = (string)Valor;
            }
            catch (Exception)
            {
                return "";
            }

            return newValor;
        }

        /// <summary>
        /// Tenta converter um objeto como Int32 
        /// --- Se apresentar erro retorna 0
        /// </summary>
        /// <param name="Valor">Objeto int</param>
        /// <returns>retorna Int32</returns>
        public static Int32 ConverteInt32(object Valor)
        {
            Int32 newValor;
            try
            {
                newValor = ConverteInt32(Valor);
            }
            catch (Exception)
            {
                return 0;
            }

            return newValor;
        }

        /// <summary>
        /// Tenta converter um objeto como Boolean 
        /// --- Se apresentar erro retorna false
        /// </summary>
        /// <param name="Valor">Objeto Boolean</param>
        /// <returns>retorna Boolean</returns>
        public static Boolean ConverteBoolean(object Valor)
        {
            Boolean newValor;
            try
            {
                newValor = ConverteBoolean(Valor);
            }
            catch (Exception)
            {
                return false;
            }

            return newValor;
        }
    }

}
