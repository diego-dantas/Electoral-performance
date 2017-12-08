using ElectoralPerformance.model.DAO;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
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
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
            populaEleicao();
            populaEstado();
            populaCargo();
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

        //metodo para popular combox de cargo
        public void populaCargo()
        {
            CargosDAO cargosDAO = new CargosDAO();
            try
            {
                cbCargo.DataSource = cargosDAO.select();
                cbCargo.ValueMember = "id";
                cbCargo.DisplayMember = "descricao";
                cbCargo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao popular o combox de cargo" + ex);
            }

        }

        private void cbEstado_DropDownClosed(object sender, EventArgs e)
        {
            populaCidade(cbEstado.SelectedValue.ToString());
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            PartidoDAO partidoDAO = new PartidoDAO();
            MySqlDataReader dataReader = partidoDAO.selectRankCargo(cbEleicao.SelectedValue.ToString(), cbCidade.SelectedValue.ToString(), cbCargo.SelectedValue.ToString());

            ccRank.Series.Clear();
            ccRank.AxisY.Clear();
            ccRank.AxisX.Clear();

            ColumnSeries column = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };

            Axis axis = new Axis()
            {
                Separator = new Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }
            };

            axis.Labels = new List<string>();
            List<ColumnSeries> LineSeries = new List<ColumnSeries>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    column.Values.Add(Convert.ToInt32(dataReader["votos"]));
                    axis.Labels.Add(dataReader["sigla"].ToString());

                }
            }

            LineSeries.Add(column);

            foreach (ColumnSeries c in LineSeries) ccRank.Series.Add(c);

            ccRank.Zoom = ZoomingOptions.X;
            ccRank.AxisX.Add(axis);
            ccRank.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString()


            });
        }
    }
}
