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
            graficoPizza(cbCidade.SelectedValue.ToString(),
                         cbEleicao.SelectedValue.ToString(),
                         cbCandidato.SelectedValue.ToString(),
                         cbCargo.SelectedValue.ToString());

            grafico(cbCidade.SelectedValue.ToString(),
                         cbEleicao.SelectedValue.ToString(),
                         cbCandidato.SelectedValue.ToString(),
                         cbCargo.SelectedValue.ToString());
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


        public void grafico(string codMun, string idEleicao, string cpf, string idCargo)
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            int numCand = candidatoDAO.getNumberCandidato(codMun, idEleicao, cpf, idCargo);

            MySqlDataReader mySqlDataReader = candidatoDAO.selectVotoSecaoPorCandidato(codMun, idCargo, numCand.ToString());
            

         
             LineSeries column = new LineSeries()
             {
                 DataLabels = true,
                 Values = new ChartValues<int>(),
                 Title = "Zona",
                 LabelPoint = point => point.Y.ToString()
             };

            LineSeries column1 = new LineSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                Title = "Zona",
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
            List<LineSeries> LineSeries = new List<LineSeries>();
           


            if (mySqlDataReader.HasRows)
            {
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader["zona"].Equals(11))
                    {
                        column.Values.Add(Convert.ToInt32(mySqlDataReader["VOTOS"]));
                        axis.Labels.Add("Seção " + mySqlDataReader["secao"].ToString());
                    }
                    else
                    {
                        column1.Values.Add(Convert.ToInt32(mySqlDataReader["VOTOS"]));
                        axis.Labels.Add("Seção " + mySqlDataReader["secao"].ToString());
                    }
                }
            }
                                             
            LineSeries.Add(column);
            LineSeries.Add(column1);
            foreach (LineSeries c in LineSeries) cartesianChart1.Series.Add(c);

            cartesianChart1.Zoom = ZoomingOptions.X;
            cartesianChart1.Series.Add(column);
            cartesianChart1.AxisX.Add(axis);
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString()


            });
            cartesianChart1.LegendLocation = LegendLocation.Top;
        }
       

        public void graficoPizza(string codMun, string idEleicao, string cpf, string idCargo)
        {

            pieChart1.Series.Clear(); 

            CandidatoDAO candidatoDAO = new CandidatoDAO();
            MySqlDataReader mySqlDataReader = candidatoDAO.selectVotoZonaCandidato(codMun, idEleicao, cpf, idCargo);
            int linhas = candidatoDAO.countZonaCandidato(codMun, idEleicao, cpf, idCargo);
            List<PieSeries> pieSeries = new List<PieSeries>();
            
            int[] votos = new int[linhas];
            string[] nome = new string[linhas];
            string[] zona = new string[linhas];
 


            if (mySqlDataReader.HasRows)
            {
                
                int cont = 0;
                while(mySqlDataReader.Read())
                {
                    
                    votos[cont] = Convert.ToInt32(mySqlDataReader["qtdVotos"]);
                    nome[cont] = mySqlDataReader["nome"].ToString();
                    zona[cont] = mySqlDataReader["zona"].ToString();
                    cont++;
                }
            }

                       
            if (linhas == 1)
            {
                PieSeries pie0 = new PieSeries()
                {
                    Values = new ChartValues<int>(),
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString()
                };

                pie0.Values.Add(votos[0]);
                pie0.Title = zona[0];

                pieSeries.Add(pie0);
                
            }
            else if (linhas == 2)
            {
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

                pie0.Values.Add(votos[0]);
                pie0.Title = zona[0];
                pie1.Values.Add(votos[1]);
                pie1.Title = zona[1];

                pieSeries.Add(pie0);
                pieSeries.Add(pie1);
                
            }
            else if (linhas == 3)
            {
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
                pie0.Values.Add(votos[0]);
                pie0.Title = zona[0];
                pie1.Values.Add(votos[1]);
                pie1.Title = zona[1];
                pie2.Values.Add(votos[2]);
                pie2.Title = zona[2];

                pieSeries.Add(pie0);
                pieSeries.Add(pie1);
                pieSeries.Add(pie2);
            }
            
            foreach (var x in pieSeries) pieChart1.Series.Add(x); 

      

            pieChart1.LegendLocation = LegendLocation.Right;

        }

    }
}
