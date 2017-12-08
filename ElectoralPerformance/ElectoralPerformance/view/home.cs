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
                Title = "ZONA 11",
                LabelPoint = point => point.Y.ToString(),
            };
            ColumnSeries col1 = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                Title = "ZONA 299",
                LabelPoint = point => point.Y.ToString(),
            };
            axis.Labels = new List<string>();
            List<ColumnSeries> LineSeries = new List<ColumnSeries>();

            if (mySqlDataReader.HasRows)
            {
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader["zona"].Equals(11))
                    {
                        col.Values.Add(mySqlDataReader["qtdVotos"]);
                        axis.Labels.Add(mySqlDataReader["nome"].ToString());
                    }
                    else
                    {
                        col1.Values.Add(mySqlDataReader["qtdVotos"]);
                        axis.Labels.Add(mySqlDataReader["nome"].ToString());
                    }
                }
            }
            LineSeries.Add(col);
            LineSeries.Add(col1);
            foreach (ColumnSeries c in LineSeries) ccVotosZona.Series.Add(c);
            ccVotosZona.AxisX.Add(axis);
            ccVotosZona.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString(),
                Separator = new Separator()

            });
        }

        public void populaDataGrid()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            dtGridVotoSecao.DataSource = candidatoDAO.selectVotoSecao();
        }
    
    }
}
