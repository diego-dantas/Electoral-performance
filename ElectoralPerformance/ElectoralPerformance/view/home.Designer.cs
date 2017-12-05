namespace ElectoralPerformance.view
{
    partial class home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcVotosTotal = new LiveCharts.WinForms.PieChart();
            this.ccVotosZona = new LiveCharts.WinForms.CartesianChart();
            this.dtGridVotoSecao = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVotoSecao)).BeginInit();
            this.SuspendLayout();
            // 
            // pcVotosTotal
            // 
            this.pcVotosTotal.Location = new System.Drawing.Point(12, 65);
            this.pcVotosTotal.Name = "pcVotosTotal";
            this.pcVotosTotal.Size = new System.Drawing.Size(750, 274);
            this.pcVotosTotal.TabIndex = 0;
            this.pcVotosTotal.Text = "pieChart1";
            // 
            // ccVotosZona
            // 
            this.ccVotosZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ccVotosZona.Location = new System.Drawing.Point(12, 427);
            this.ccVotosZona.Name = "ccVotosZona";
            this.ccVotosZona.Size = new System.Drawing.Size(1228, 322);
            this.ccVotosZona.TabIndex = 2;
            this.ccVotosZona.Text = "cartesianChart2";
            // 
            // dtGridVotoSecao
            // 
            this.dtGridVotoSecao.AllowUserToAddRows = false;
            this.dtGridVotoSecao.AllowUserToDeleteRows = false;
            this.dtGridVotoSecao.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dtGridVotoSecao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGridVotoSecao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridVotoSecao.Location = new System.Drawing.Point(801, 36);
            this.dtGridVotoSecao.Name = "dtGridVotoSecao";
            this.dtGridVotoSecao.ReadOnly = true;
            this.dtGridVotoSecao.Size = new System.Drawing.Size(361, 376);
            this.dtGridVotoSecao.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(864, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Votos por Zona e Seção - DILADOR";
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1252, 780);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGridVotoSecao);
            this.Controls.Add(this.ccVotosZona);
            this.Controls.Add(this.pcVotosTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "home";
            this.ShowIcon = false;
            this.Text = "home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVotoSecao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.PieChart pcVotosTotal;
        private LiveCharts.WinForms.CartesianChart ccVotosZona;
        private System.Windows.Forms.DataGridView dtGridVotoSecao;
        private System.Windows.Forms.Label label1;
    }
}