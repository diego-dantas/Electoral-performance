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
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
           
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Connection conne = new Connection();
            conne.openConnection();
            
        }

        private void lnkInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void lnkCandidato_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Candidato candidato = new Candidato();
            candidato.TopLevel = false;
            this.pnlMain.Controls.Add(candidato);
            candidato.Show();
        }

        private void lnkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
