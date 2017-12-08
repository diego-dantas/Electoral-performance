using ElectoralPerformance.model.DAO;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    public partial class Main : Form
    {
        home home = new home();
        Candidato candidato = new Candidato();
        Eleitorado eleitorado = new Eleitorado();
        Ranking ranking = new Ranking();
        Partido partido = new Partido();
        public Main()
        {
            InitializeComponent();
            graficoExeplo();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Connection conne = new Connection();
            conne.openConnection();

        }

        private void lnkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void cANDIDATOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Visible = true;
            lblBody.Visible = true;
            cartesianChart1.Visible = true;
            this.pnlMain.Controls.Remove(candidato);
            this.pnlMain.Controls.Remove(home);
            this.pnlMain.Controls.Remove(eleitorado);
            this.pnlMain.Controls.Remove(partido);
            this.pnlMain.Controls.Remove(ranking);
        }

        private void candidatoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lblTitle.Visible = false;
            lblBody.Visible = false;
            cartesianChart1.Visible = false;
            this.pnlMain.Controls.Remove(candidato);
            this.pnlMain.Controls.Remove(eleitorado);
            this.pnlMain.Controls.Remove(ranking);
            this.pnlMain.Controls.Remove(partido);
            home.TopLevel = false;
            this.pnlMain.Controls.Add(home);
            home.Show();
        }

        private void votosPorZonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Visible = false;
            lblBody.Visible = false;
            cartesianChart1.Visible = false;
            this.pnlMain.Controls.Remove(home);
            this.pnlMain.Controls.Remove(eleitorado);
            this.pnlMain.Controls.Remove(ranking);
            this.pnlMain.Controls.Remove(partido);
            candidato.TopLevel = false;
            this.pnlMain.Controls.Add(candidato);
            candidato.Show();
        }

        private void eleitoradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Visible = false;
            this.pnlMain.Controls.Remove(home);
            this.pnlMain.Controls.Remove(candidato);
            this.pnlMain.Controls.Remove(ranking);
            this.pnlMain.Controls.Remove(partido);
            eleitorado.TopLevel = false;
            this.pnlMain.Controls.Add(eleitorado);
            eleitorado.Show();
        }

        private void rankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Visible = false;
            lblBody.Visible = false;
            cartesianChart1.Visible = false;
            this.pnlMain.Controls.Remove(candidato);
            this.pnlMain.Controls.Remove(eleitorado);
            this.pnlMain.Controls.Remove(home);
            this.pnlMain.Controls.Remove(partido);
            ranking.TopLevel = false;
            this.pnlMain.Controls.Add(ranking);
            ranking.Show();
        }


        private void partidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Visible = false;
            lblBody.Visible = false;
            cartesianChart1.Visible = false;
            this.pnlMain.Controls.Remove(candidato);
            this.pnlMain.Controls.Remove(eleitorado);
            this.pnlMain.Controls.Remove(home);
            this.pnlMain.Controls.Remove(ranking);
            partido.TopLevel = false;
            this.pnlMain.Controls.Add(partido);
            partido.Show();
        }

        public void graficoExeplo()
        {
            SeriesCollection = new SeriesCollection
            {
                new ScatterSeries
                {
                    Title = "Series A",
                    Values = new ChartValues<ObservablePoint>()
                },
                new ScatterSeries
                {
                    Title = "Series B",
                    Values = new ChartValues<ObservablePoint>(),
                    PointGeometry = DefaultGeometries.Diamond
                },
                new ScatterSeries
                {
                    Title = "Series C",
                    Values = new ChartValues<ObservablePoint>(),
                    PointGeometry = DefaultGeometries.Triangle,
                    StrokeThickness = 2
                }
            };

            var r = new Random();

            foreach (var series in SeriesCollection)
            {
                for (var i = 0; i < 20; i++)
                {
                    series.Values.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
                }
            }

            cartesianChart1.Series = SeriesCollection;
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = new Random();

            foreach (var values in SeriesCollection.Select(x => x.Values))
            {
                for (var i = 0; i < 20; i++)
                {
                    ((ObservablePoint)values[i]).X = r.NextDouble() * 10;
                    ((ObservablePoint)values[i]).Y = r.NextDouble() * 10;
                }
            }
        }

       
    }
}
