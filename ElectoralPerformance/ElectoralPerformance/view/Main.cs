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
        home home = new home();
        Candidato candidato = new Candidato();
        public Main()
        {
            InitializeComponent();
           
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
            this.pnlMain.Controls.Remove(candidato);
            this.pnlMain.Controls.Remove(home);
        }

        private void candidatoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //callView(home);
            lblTitle.Visible = false;
            this.pnlMain.Controls.Remove(candidato);
            home.TopLevel = false;
            this.pnlMain.Controls.Add(home);
            home.Show();
        }

        private void votosPorZonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //callView(candidato);
            lblTitle.Visible = false;
            this.pnlMain.Controls.Remove(home);
            candidato.TopLevel = false;
            this.pnlMain.Controls.Add(candidato);
            candidato.Show();
        }


        public void callView(Form form)
        {
            //form = new Form();
            form.TopLevel = false;
            this.pnlMain.Controls.Add(form);
            form.Show();
            MessageBox.Show(form.Name.ToString());
        }
    }
}
