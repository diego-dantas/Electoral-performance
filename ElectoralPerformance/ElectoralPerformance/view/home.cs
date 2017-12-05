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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();

            gerarGraficoPizza();
            gerarGraficosColuna1();
            populaDataGrid();
        }


        public void gerarGraficoPizza()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            MySqlDataReader reader = candidatoDAO.selectVotoEleicao();

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
            if (reader.HasRows)
            {

                for (int i = 0; i < 3; i++)
                {
                    reader.Read();
                    votos[i] = Convert.ToInt32(reader["votos"]);
                    nome[i] = reader["nome"].ToString();
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
            foreach (var x in pieSeries) pcVotosTotal.Series.Add(x);

            pcVotosTotal.LegendLocation = LegendLocation.Right;
        }

        public void gerarGraficosColuna1()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            MySqlDataReader mySqlDataReader = candidatoDAO.selectVotoZona();

           
            
            

            ccVotosZona.Series = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            ccVotosZona.Series.Add(new RowSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            ccVotosZona.Series[1].Values.Add(48d);

            ccVotosZona.AxisY.Add(new Axis
            {
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            ccVotosZona.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString("N")
            });

            var tooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.SharedYValues
            };

            ccVotosZona.DataTooltip = tooltip;
            
        }



        public void populaDataGrid()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            dtGridVotoSecao.DataSource = candidatoDAO.selectVotoSecao();
        }
    
    }
}
