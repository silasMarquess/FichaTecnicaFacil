using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FichaTecnicaFacil.Entidades.enums;
using FichaTecnicaFacil.Entidades;
using FichaTecnicaFacil.DAO;
using FichaTecnicaFacil.Views;
using System.Windows.Forms;

namespace FichaTecnicaFacil.Controler
{
    class caixaControler
    {
        public FrmCaixa _form;
        public Form1Controler pai;
        public List<Caixa> listaCaixasAbertos;

        public caixaControler(FrmCaixa form)
        {
            _form = form;
        }
        public caixaControler(FrmCaixa form, Form1Controler formPai)
        {
            _form = form;
            this.pai = formPai;
        }

        public void FechaFormulario()
        {
            _form.Close();
            pai._form.Visible = true;
        }

        public void getNumCaixasAbertos()
        {
            listaCaixasAbertos = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixaAberto);
            _form.txtNumCaixas.Text = listaCaixasAbertos.Count.ToString();
            System.Windows.Forms.MessageBox.Show("Existe caixas Abertos no sistema");
        }

        public void AbriNovoCaixa()
        {
            AbriCaixa form = new AbriCaixa();
            if (listaCaixasAbertos.Count > 0) throw new DomainException("Opção Bloqueada, enquanto vc estiver com um caixa aberto");
            form.ShowDialog();
        }

        public void FechamentoCaixa()
        {
            listaCaixasAbertos = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixaAberto);
            if (!(listaCaixasAbertos != null && listaCaixasAbertos.Count > 0)) throw new DomainException("Não existe caixa Operante Aberto !");
            FechaCaixa f = new FechaCaixa(listaCaixasAbertos[0]);
            f.ShowDialog();
        }

       public void MostraListaCaixas(DateTime dataIn, DateTime dataOut)
        {
            listaCaixasAbertos = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixa,dataIn, dataOut);
            if (listaCaixasAbertos.Count == 0) throw new DomainException("Nemhum Caixa encontrado");
            this.MostrarListaCaixasDataGrid(listaCaixasAbertos);
        }

        private void MostrarListaCaixasDataGrid(List<Caixa> listaFonte)
        {
            _form.dgv_ListaCaixasFiltrados.Rows.Clear();

            for (int i = 0; i < listaFonte.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgv_ListaCaixasFiltrados.Rows[i].Clone();

                linha.Cells[0].Value = listaFonte[i].codigoCaixa.ToString();
                linha.Cells[1].Value = listaFonte[i].HoraAbert.ToShortDateString();

                statusCaixa status = listaFonte[i].statusCaixa;
                if (status == statusCaixa.CAIXA_ABERTO)
                {
                    linha.Cells[2].Value = "Aberto";
                    linha.Cells[2].Style.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    linha.Cells[2].Value = "Fechado";
                    linha.Cells[2].Style.ForeColor = System.Drawing.Color.Red;
                }

                _form.dgv_ListaCaixasFiltrados.Rows.Add(linha);

            }
        }

    }
}
