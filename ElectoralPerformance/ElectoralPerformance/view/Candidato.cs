using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using ElectoralPerformance.model.DAO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections;
using ElectoralPerformance.model.DTO;

namespace ElectoralPerformance.view
{
    public partial class Candidato : Form
    {
    
        public Candidato()
        {
            InitializeComponent();
      
            //gerarGraficoColuna();
            grafico();


        }
        

        //Evento para popular os combox 
        private void Teste_Load(object sender, EventArgs e)
        {
            populaEleicao();
            populaEstado();
            populaCargo();
        }


        private void btnGerar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbEleicao.SelectedValue.ToString());
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

        /*
        * Evento para do combox de cargo, 
        * assim que o mesmo e fechado ele chamado o metodo populaCandidato 
        * para carregar os candidatos apenas do mesmo cargo
       */
        private void cbCargo_DropDownClosed(object sender, EventArgs e)
        {
            populaCandidato(cbEleicao.SelectedValue.ToString(), cbCidade.SelectedValue.ToString(), cbCargo.SelectedValue.ToString());
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




        public void populaCandidato(string eleicao, string codMunicipio, string idCargo)
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();

            try
            {
                cbCandidato.DataSource = candidatoDAO.selectCandidato(eleicao, codMunicipio, idCargo);               
                cbCandidato.ValueMember = "cpf";
                cbCandidato.DisplayMember = "nome";
                cbCandidato.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao popular o combox de candidato " + ex);
            }
        }


        public void grafico()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            MySqlDataReader mySqlDataReader = candidatoDAO.selectVotoZona();

            int[] total = new int[] { 10, 12, 39, 40 };
            string[] ano = new string[] { "Diego", "Bia", "Bete", "Gabi" };
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
            //foreach (var x in total) column.Values.Add(x);
            //foreach (var x in ano) axis.Labels.Add(x.ToString());

            if (mySqlDataReader.HasRows)
            {
                while (mySqlDataReader.Read())
                {
                    column.Values.Add(mySqlDataReader["qtdVotos"]);
                    axis.Labels.Add(mySqlDataReader["nome"].ToString());
                }
            }

            cartesianChart1.Series.Add(column);
            cartesianChart1.AxisX.Add(axis);
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            
            });
            
               
            

        }

        public void gerarGraficoColuna()
        {
           // CandidatoDAO candidatoDAO = new CandidatoDAO();
           // MySqlDataReader mySqlDataReader = candidatoDAO.selectVotoZona();

                        
/*            ArrayList year = new ArrayList();
            year.Add("Diego");
            year.Add("Bia");
            year.Add("Bete");
            year.Add("Gabi");

            
            int[] total = new int[] { 10, 12, 39, 40 };
            int[] total2 = new int[] { 10, 12, 39, 40 };
            string[] ano = new string[] { "Diego", "Bia", "Bete", "Gabi" };

            ColumnSeries col = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };

            Axis axis = new Axis(){
                Separator = new Separator()
                {
                    Step = 1, 
                    IsEnabled = false
                }
            };

            axis.Labels = new List<string>();
            foreach (var x in ano)
            {
                col.Values.Add(x);
            }
            cartesianChart1.Series.Add(col);
            //cartesianChart1.Series.Add(col1);
            //cartesianChart1.AxisX.Add(axis);
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            });

            /*
                        if (mySqlDataReader.HasRows)
                        {
                            string nome = "";
                            //while (mySqlDataReader.Read())
                            //{
                            mySqlDataReader.Read();
                                nome = mySqlDataReader["nome"].ToString();
                                MessageBox.Show(nome);
                                //col.Values.Add(nome);
                                //axis.Labels.Add(mySqlDataReader["qtdVotos"].ToString());
                           // }
                        }*/



        }





        public void gerarGraficaLinha()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {5, 2, 8, 3},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
    

            //modifying any series values will also animate and update the chart
            cartesianChart1.Series[2].Values.Add(5d);


        }


        /*public void grafico()
        {
            int[] total = new int[] { 10, 12, 39, 40 };
            string[] ano = new string[] { "Diego", "Bia", "Bete", "Gabi" };
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
            foreach (var x in total) column.Values.Add(x);
            foreach (var x in ano) axis.Labels.Add(x.ToString());

            cartesianChart1.Series.Add(column);
            cartesianChart1.AxisX.Add(axis);
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            
            });
            
               
            

        }*/


    }
}
