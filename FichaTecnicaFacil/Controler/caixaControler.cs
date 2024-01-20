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
    public class caixaControler
    {
        public FrmCaixa _form;
        public Form1Controler pai;
        public List<Caixa> listaCaixasAbertos;
        public List<Caixa> _listaCaixaGeral;
        public Caixa _caixaAtual;
        public List<Fluxo> _listaFluxoFilter;

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
            if (listaCaixasAbertos.Count > 0)
            {
                _caixaAtual = listaCaixasAbertos[0];
                _form.txtNumCaixas.Text = "Sim";
            }
            else
            {

                _form.txtNumCaixas.Text = "Não";
            }

            // System.Windows.Forms.MessageBox.Show("Existe caixas Abertos no sistema");
        }

        public void AbriNovoCaixa()
        {
            AbriCaixa form = new AbriCaixa(this);
            listaCaixasAbertos = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixaAberto);
            if (listaCaixasAbertos.Count > 0) throw new DomainException("Opção Bloqueada, enquanto vc estiver com um caixa aberto");
            form.ShowDialog();
        }

        public void FechamentoCaixa()
        {
            _caixaAtual.getListaMovimentacoes().Clear();
            listaCaixasAbertos = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixaAberto);
            if (!(listaCaixasAbertos != null && listaCaixasAbertos.Count > 0)) throw new DomainException("Não existe caixa Operante Aberto !");
            DBConexao.ModifyOperation(CaixaDAO.getListaFluxoPorCaixa, _caixaAtual);
            FechaCaixa f = new FechaCaixa(_caixaAtual, this);
            f.ShowDialog();
        }

        public void MostraListaCaixas(DateTime dataIn, DateTime dataOut)
        {
            _listaCaixaGeral = null;
            _listaCaixaGeral = DBConexao.getLisObjectOperation(CaixaDAO.getListaCaixa, dataIn, dataOut);
            this.MostrarListaCaixasDataGrid(_listaCaixaGeral);
            if (_listaCaixaGeral.Count == 0) throw new DomainException("Nemhum Caixa encontrado para Hoje");

            foreach (Caixa c in _listaCaixaGeral)
            {
                DBConexao.ModifyOperation(CaixaDAO.getListaFluxoPorCaixa, c);
            }

            this.MostraResumoMovimentacaoGeral(_listaCaixaGeral);
            _form.lbNumCaixas.Text = _listaCaixaGeral.Count.ToString();

        }

        private void MostrarListaCaixasDataGrid(List<Caixa> listaFonte)
        {
            _form.dgv_ListaCaixasFiltrados.Rows.Clear();

            for (int i = 0; i < listaFonte.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgv_ListaCaixasFiltrados.Rows[i].Clone();

                linha.Cells[0].Value = listaFonte[i].codigoCaixa.ToString();
                linha.Cells[1].Value = listaFonte[i].HoraAbert.ToShortDateString();
                linha.Cells[2].Value = listaFonte[i].HoraAbert.ToShortTimeString();

                statusCaixa status = listaFonte[i].statusCaixa;
                if (status == statusCaixa.CAIXA_ABERTO)
                {
                    linha.Cells[3].Value = "Aberto";
                    linha.Cells[3].Style.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    linha.Cells[3].Value = "Fechado";
                    linha.Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                }

                linha.Cells[4].Value = "R$_"+listaFonte[i].ValorInicio.ToString("F2");
                _form.dgv_ListaCaixasFiltrados.Rows.Add(linha);

            }
        }

        public void InsertMovimentacaoCaixa(Fluxo f)
        {
            f.Caixa = _caixaAtual;
            DBConexao.ModifyOperation(CaixaDAO.Insertfluxo, f);
            this.LimparCampos();
            MessageBox.Show("Fluxo cadastrado no Caixa Aberto Atual");

            DateTime dataiN = new DateTime(_form.dta_In.Value.Year, _form.dta_In.Value.Month, _form.dta_In.Value.Day);
            DateTime dataOut = new DateTime(_form.dta_Out.Value.Year, _form.dta_Out.Value.Month, _form.dta_Out.Value.Day);
            MostraListaCaixas(dataiN, dataOut);

            MostraResumoMovimentacaoGeral(_listaCaixaGeral);

            //Caixa c = _listaCaixaGeral.Find(getListaCaixa);

            Caixa c = null;
            foreach (Caixa obj in _listaCaixaGeral)
            {
                if (obj.codigoCaixa == _form.lbCodCaixa.Text)
                {
                    c = obj;
                }
            }
            this.MostraResumoCaixa(c);
            this.mostraListaMovimentacaoGrid(c.getListaMovimentacoes());

        }

        public void getListaMovimentacoes()
        {
            Caixa c = _listaCaixaGeral.Find(this.getListaCaixa);
            _form.lbCodCaixa.Text = c.codigoCaixa;
            if (c is null) throw new DomainException("Nemhum caixa selecionado");
            this.mostraListaMovimentacaoGrid(c.getListaMovimentacoes());
            this.MostraResumoCaixa(c);
            if (c.getListaMovimentacoes().Count == 0) throw new DomainException("Caixa sem movimentações!");
        }

        public void MostraResumoCaixa(Caixa c)
        {
            _form.lbEntPix.Text = "R$ " + c.getTotalEntradaPix().ToString("F2");
            _form.lbEntDinheiro.Text = "R$ " + c.getTotalEntradaEspecie().ToString("F2");
            _form.lbEntCartores.Text = c.getTotalEntradaCartaoCredito() + "C - " + c.getTotalEntradaCartaoDebito() + "D";
            _form.lbSaiPix.Text = "R$ " + c.getTotalSaidaPix().ToString("F2");
            _form.lbSaiEspe.Text = "R$ " + c.getTotalSaidaEspecie().ToString("F2");
            _form.lbSaiCartaoes.Text = c.getTotalSaidaCartaoCredito() + "C - " + c.getTotalSaidaCartaoDebito() + "D";
            _form.lbEntradaTotalCaixa.Text = "R$ " + c.getEntradaGeral().ToString("F2");
            _form.lbSaidaTotalCaixa.Text = "R$ " + c.getTotalSaida().ToString("F2");
            _form.lbDiferenca.Text = "R$ " + c.getDiferenca().ToString("F2");
            _form.lbHorarioAbertura.Text = c.HoraAbert.ToShortDateString() + "-" + c.HoraAbert.ToShortTimeString();
            _form.lbHoraFechamento.Text = c.HoraFechamento.ToShortDateString() + "-" + c.HoraFechamento.ToShortTimeString();
            _form.lbValFinal.Text = "R$ " + c.ValorFechamento.ToString("F2");
            _form.lbValQuebra.Text = "R$ " + c.ValorQuebra.ToString("F2");

        }

        private void mostraListaMovimentacaoGrid(List<Fluxo> lista)
        {
            _form.dgvFluxoDados.Rows.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow linha = (DataGridViewRow)_form.dgvFluxoDados.Rows[i].Clone();
                System.Drawing.Color corLinha = System.Drawing.Color.Blue;
                if (lista[i].Tipo == tipoFluxo.FLUXO_SAIDA) corLinha = System.Drawing.Color.Red;

                linha.Cells[0].Value = lista[i].Id.ToString();
                linha.Cells[0].Style.ForeColor = corLinha;

                linha.Cells[1].Value = lista[i].Descricao;
                linha.Cells[1].Style.ForeColor = corLinha;

                linha.Cells[2].Value = "+R$ " + lista[i].Valor.ToString("F2");
                if (corLinha == System.Drawing.Color.Red) linha.Cells[2].Value = "-R$ " + lista[i].Valor.ToString("F2");
                linha.Cells[2].Style.ForeColor = corLinha;

                linha.Cells[3].Value = lista[i].Tipo.ToString();
                linha.Cells[3].Style.ForeColor = corLinha;

                linha.Cells[4].Value = lista[i].Horario.ToShortTimeString();
                linha.Cells[4].Style.ForeColor = corLinha;

                linha.Cells[5].Value = lista[i].data.ToShortDateString();
                linha.Cells[5].Style.ForeColor = corLinha;

                linha.Cells[6].Value = lista[i].Natureza.ToString();
                linha.Cells[6].Style.ForeColor = corLinha;


                _form.dgvFluxoDados.Rows.Add(linha);

            }
        }

        public void MostraResumoMovimentacaoGeral(List<Caixa> lista)
        {
            double entradaGeral = 0;

            double despesaGeral = 0;
            double diferenca = 0;
            double numMovimentacoes = 0;
            double pixGlobal = 0;
            double cartaoCreditogeral = 0;
            double cartaoDebitoGeral = 0;
            double totalDinheiro = 0;
            double valorInicioGeral = 0;

            foreach (Caixa c in lista)
            {
                entradaGeral += c.getEntradaGeral();
                despesaGeral += c.getTotalSaida();
                pixGlobal += c.getTotalEntradaPix();
                cartaoCreditogeral += c.getTotalEntradaCartaoCredito();
                cartaoDebitoGeral += c.getTotalEntradaCartaoDebito();
                totalDinheiro += c.getTotalEntradaEspecie();
                valorInicioGeral += c.ValorInicio;
            }

            diferenca = (entradaGeral+valorInicioGeral) - despesaGeral;
            _form.LbEntradaGlobal.Text = "R$ " + entradaGeral.ToString("F2");
            _form.lbDespesaGlobal.Text = "R$ " + despesaGeral.ToString("F2");
            _form.lbDiferencaGlobal.Text = "R$ " + diferenca.ToString("F2");
            _form.LbEntradaDinheiroGlobal.Text = "R$ " + totalDinheiro.ToString("F2");
            _form.lbPixGlobal.Text = "R$ " + pixGlobal.ToString("F2");
            _form.lbCartCreditoGlobal.Text = "R$ " + cartaoCreditogeral.ToString("F2");
            _form.lbCartaoDebGlobal.Text = "R$ " + cartaoDebitoGeral.ToString("F2");
        }


        public void ValidaCadFluxo()
        {
            if (_caixaAtual is null) throw new DomainException("erro: Nemhum aberto no momento !");
            if (_form.txtDescricao.Text == string.Empty) throw new DomainException("erro: Descricao da movimentacao não pode ser vazio");
            if (_form.txtValor.Text == string.Empty) throw new DomainException("Campo de Valor Não pode ser vazio");
            if (_form.CbNatureza.Text == string.Empty) throw new DomainException("Natureza da Movimentacao é obrigatória");
            if (_form.CbTipoMovimentacao.Text == string.Empty) throw new DomainException("Tipo de Movimentacão é obrigatorio");

        }

        private void LimparCampos()
        {
            _form.txtDescricao.Text = string.Empty;
            _form.txtIdMov.Text = string.Empty;
            _form.txtValor.Text = string.Empty;
            _form.CbNatureza.SelectedIndex = -1;
            _form.CbTipoMovimentacao.SelectedIndex = -1;
        }

        public bool getListaCaixa(Caixa c)
        {
            string codigo = _form.dgv_ListaCaixasFiltrados.CurrentRow.Cells[0].Value.ToString();
            return (codigo == c.codigoCaixa) ? true : false;
        }


        public void deleteCaixaSelecionado()
        {
            Caixa c = _listaCaixaGeral.Find(getListaCaixa);
            DBConexao.ModifyOperation(CaixaDAO.DeleteCaixa, c);
            MessageBox.Show("caixa deletado com sucesso !");

        }

        public void DeleteMovimentacao()
        {
            Fluxo f = new Fluxo();
            f.Id = int.Parse(_form.dgvFluxoDados.CurrentRow.Cells[0].Value.ToString());
            DBConexao.ModifyOperation(CaixaDAO.DeleteFluxo, f);
            MessageBox.Show("Movimentação Deletada com sucesso !");

            DateTime dataiN = new DateTime(_form.dta_In.Value.Year, _form.dta_In.Value.Month, _form.dta_In.Value.Day);
            DateTime dataOut = new DateTime(_form.dta_Out.Value.Year, _form.dta_Out.Value.Month, _form.dta_Out.Value.Day);
            MostraListaCaixas(dataiN, dataOut);

            Caixa c = null;
            foreach (Caixa obj in _listaCaixaGeral)
            {
                if (obj.codigoCaixa == _form.lbCodCaixa.Text)
                {
                    c = obj;
                }
            }
            this.mostraListaMovimentacaoGrid(c.getListaMovimentacoes());
            this.MostraResumoCaixa(c);
        }

        public void FiltrarMovCaixaTipo()
        {
            Caixa c = _listaCaixaGeral.Find(getListaCaixa);
            _listaFluxoFilter = c.getListaMovimentacoes();
            if (c is null) throw new DomainException("Erro: Nemhum caixa selecionado");
            if (_form.CbTipoMovFilter.SelectedIndex != 2)
            {
                _listaFluxoFilter = c.getListaMovimentacoes().FindAll(FiltarPorTipoMov);
            }
            this.mostraListaMovimentacaoGrid(_listaFluxoFilter);
        }

        public void FiltrarMovNat()
        {
            Caixa c = _listaCaixaGeral.Find(getListaCaixa);
            if (c is null) throw new DomainException("Erro: Nemhum caixa selecionado");

            if (_form.CbNaturezaMovFilter.SelectedIndex != 5)
            {
                if (_listaFluxoFilter != null)
                {
                    _listaFluxoFilter = _listaFluxoFilter.FindAll(FiltarPorNarurezaFluxo);
                }
                else
                {
                    _listaFluxoFilter = c.getListaMovimentacoes().FindAll(FiltarPorNarurezaFluxo);
                }
            }
            this.mostraListaMovimentacaoGrid(_listaFluxoFilter);
        }

        public bool FiltarPorTipoMov(Fluxo f)
        {
            tipoFluxo tipo = (tipoFluxo)_form.CbTipoMovFilter.SelectedIndex;
            return (tipo == f.Tipo) ? true : false;
        }

        private bool FiltarPorNarurezaFluxo(Fluxo f)
        {
            TipoPag nat = (TipoPag)_form.CbNaturezaMovFilter.SelectedIndex;
            return (nat == f.Natureza) ? true : false;
        }

    }
}
