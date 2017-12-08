using ElectoralPerformance.model.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectoralPerformance.view
{
    public partial class Eleitorado : Form
    {
        public Eleitorado()
        {
            InitializeComponent();
            populaEleicao();
            populaEstado();
        }

        //bloco de metodos para popular os combox

        //metodo para popular o combox de anos de eleicoes
        public void populaEleicao()
        {
            try
            {
                EleicoesDAO eleicoesDAO = new EleicoesDAO();
                cbEleicao.DataSource = eleicoesDAO.select();
                cbEleicao.ValueMember = "id";
                cbEleicao.DisplayMember = "descricao";
                cbEleicao.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Combox do ano de eleição " + ex);

            }
        }

        //metodo para popular o combox de estados
        public void populaEstado()
        {
            EstadosDAO estadosDAO = new EstadosDAO();
            try
            {
                cbEstado.DataSource = estadosDAO.select();
                cbEstado.ValueMember = "id";
                cbEstado.DisplayMember = "uf";
                //cbEstado.Refresh();              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao popular o combox de estado" + ex);
            }

        }

        //metodo para popular o comboxcidade
        public void populaCidade(string codEstado)
        {
            CidadeDAO cidadeDAO = new CidadeDAO();
            try
            {
                cbCidade.DataSource = cidadeDAO.selectCidade(codEstado);
                cbCidade.ValueMember = "codMunicipio";
                cbCidade.DisplayMember = "municipio";
                cbCidade.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao popular o combox de cidades" + ex);
            }
        }

        public void populaZonaEleitoral(string codMun, string idEle)
        {
            ZonaDAO zonaDAO = new ZonaDAO();
            try
            {
                cbZona.DataSource = zonaDAO.selectZonaCidade(codMun, idEle);
                cbZona.ValueMember = "zona";
                cbZona.DisplayMember = "zona";
                cbZona.Refresh();
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao popular o combox de zona" + ex);
            }
        }
       
        /*
         * Evento para do combox de estado, 
         * assim que o mesmo e fechado ele chamado o metodo populaCidade 
         * para carregar as cidades apenas do estado selecionado
        */
        private void cbEstado_DropDownClosed(object sender, EventArgs e)
        {
            populaCidade(cbEstado.SelectedValue.ToString());
        }

        private void cbCidade_DropDownClosed(object sender, EventArgs e)
        {
            populaZonaEleitoral(cbCidade.SelectedValue.ToString(), cbEleicao.SelectedValue.ToString());
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            ZonaDAO zonaDAO = new ZonaDAO();
            dtGridPerfil.DataSource = zonaDAO.selectPerfilEleitoral(cbCidade.SelectedValue.ToString(), cbEleicao.SelectedValue.ToString(), cbZona.SelectedValue.ToString());
        }
    }
}
