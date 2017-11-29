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

namespace ElectoralPerformance.view
{
    public partial class Candidato : Form
    {
        public Candidato()
        {
            InitializeComponent();

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            cartesianChart1.Series[1].Values.Add(48d);

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
        }

        private void Teste_Load(object sender, EventArgs e)
        {
            EleicoesDAO eleicoesDAO = new EleicoesDAO();
            DataTable dataTable = eleicoesDAO.select();


            try
            {
                cbEleicao.DataSource = dataTable;
                cbEleicao.ValueMember = "id";
                cbEleicao.DisplayMember = "descricao";
                cbEleicao.SelectedItem = "";
                cbEleicao.Refresh();
            }catch(Exception ex)
            {
                MessageBox.Show("Erro Combox do ano de eleição " + ex);

            }
        }
    }
}
