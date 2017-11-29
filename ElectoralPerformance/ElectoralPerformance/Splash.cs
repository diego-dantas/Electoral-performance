using ElectoralPerformance.model.DAO;
using ElectoralPerformance.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectoralPerformance
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if(progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }
    }
}
