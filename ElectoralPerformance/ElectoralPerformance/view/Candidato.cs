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
            //graficoPizza();
            graficoPizza();


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

            /* ColumnSeries column = new ColumnSeries()
             {
                 DataLabels = true,
                 Values = new ChartValues<int>(),
                 LabelPoint = point => point.Y.ToString()
             };

             ColumnSeries column1 = new ColumnSeries()
             {
                 DataLabels = true,
                 Values = new ChartValues<int>(),
                 LabelPoint = point => point.Y.ToString()
             };*/

            Axis axis = new Axis()
            {
                Separator = new Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }
            };
            ColumnSeries col = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString(),
            };
            ColumnSeries col1 = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString(),
            };
            axis.Labels = new List<string>();
            List<ColumnSeries> LineSeries = new List<ColumnSeries>();
            string zona = "";
            for (int i = 0; i < 2; i++)
            {

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                       /* zona = mySqlDataReader["zona"].ToString();
                        if (zona.Equals("11"))
                        {
                            col.Values.Add(mySqlDataReader["qtdVotos"]);
                            axis.Labels.Add(mySqlDataReader["nome"].ToString());
                        }
                        if (zona.Equals("299"))
                        {
                            col1.Values.Add(mySqlDataReader["qtdVotos"]);
                            axis.Labels.Add(mySqlDataReader["nome"].ToString());
                        }*/

                        col.Values.Add(mySqlDataReader["qtdVotos"]);
                        //col1.Values.Add(mySqlDataReader["qtdVotos"]);
                        axis.Labels.Add(mySqlDataReader["nome"].ToString());

                    }
                }
                
                
                
            }
            LineSeries.Add(col);
            //LineSeries.Add(col1);
            foreach(ColumnSeries c in LineSeries) cartesianChart1.Series.Add(c);





            //foreach (var x in total) column.Values.Add(x);
            //foreach (var x in ano) axis.Labels.Add(x.ToString());

            /* if (mySqlDataReader.HasRows)
             {
                 while (mySqlDataReader.Read())
                 {
                     column.Values.Add(mySqlDataReader["qtdVotos"]);
                     column1.Values.Add(mySqlDataReader["qtdVotos"]);
                     axis.Labels.Add(mySqlDataReader["nome"].ToString());
                 }
             }*/

            //cartesianChart1.Series.Add(column);
            //cartesianChart1.Series.Add(column1);
            cartesianChart1.AxisX.Add(axis);
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()
            
            });
            
               
            

        }

        public void graficoPizza()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            MySqlDataReader mySqlDataReader = candidatoDAO.selectVotoEleicao();
            int[] votos = new int[3];
            string[] nome = new string[3];
            
            PieSeries pie0 = new PieSeries()
            {
                Values = new ChartValues<int>(),
                PushOut = 15,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };

            PieSeries pie1 = new PieSeries()
            {
                Values = new ChartValues<int>(),
                PushOut = 15,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };

            PieSeries pie2 = new PieSeries()
            {
                Values = new ChartValues<int>(),
                PushOut = 15,
                DataLabels = true,
                LabelPoint = point => point.Y.ToString()
            };

            List<PieSeries> pieSeries = new List<PieSeries>();
            if (mySqlDataReader.HasRows)
            {

                for(int i = 0; i < 3; i++)                
                {
                    mySqlDataReader.Read();
                    votos[i] = Convert.ToInt32(mySqlDataReader["votos"]);
                    nome[i] = mySqlDataReader["nome"].ToString();
                }
            }

            pie0.Values.Add(votos[0]);
            pie0.Title = nome[0];
            pie1.Values.Add(votos[1]);
            pie1.Title = nome[1];
            pie2.Values.Add(votos[2]);
            pie2.Title = nome[2];
           

            pieSeries.Add(pie0);
            pieSeries.Add(pie1);
            pieSeries.Add(pie2);
            foreach (var x in pieSeries) pieChart1.Series.Add(x);

            pieChart1.LegendLocation = LegendLocation.Right;
            
        }

        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("Click ");
        }


        public void graficoPizzaaa()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Maria",
                    Values = new ChartValues<double> {3},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Charles",
                    Values = new ChartValues<double> {4},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Frida",
                    Values = new ChartValues<double> {6},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Frederic",
                    Values = new ChartValues<double> {2},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
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
