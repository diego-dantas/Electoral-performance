namespace ElectoralPerformance.view
{
    partial class Eleitorado
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbEleicao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbZona = new System.Windows.Forms.ComboBox();
            this.dtGridPerfil = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ano da Eleição ";
            // 
            // cbEleicao
            // 
            this.cbEleicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEleicao.FormattingEnabled = true;
            this.cbEleicao.Items.AddRange(new object[] {
            "ELEIÇÃO"});
            this.cbEleicao.Location = new System.Drawing.Point(12, 50);
            this.cbEleicao.Name = "cbEleicao";
            this.cbEleicao.Size = new System.Drawing.Size(165, 21);
            this.cbEleicao.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Estado";
            // 
            // cbCidade
            // 
            this.cbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbCidade.FormattingEnabled = true;
            this.cbCidade.Location = new System.Drawing.Point(270, 50);
            this.cbCidade.Name = "cbCidade";
            this.cbCidade.Size = new System.Drawing.Size(225, 21);
            this.cbCidade.TabIndex = 12;
            this.cbCidade.DropDownClosed += new System.EventHandler(this.cbCidade_DropDownClosed);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(183, 50);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(81, 21);
            this.cbEstado.TabIndex = 11;
            this.cbEstado.DropDownClosed += new System.EventHandler(this.cbEstado_DropDownClosed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(528, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Perfil eleitoral por zona";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(588, 48);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 16;
            this.btnGerar.Text = "Gerar Visão";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(520, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Zona";
            // 
            // cbZona
            // 
            this.cbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZona.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbZona.FormattingEnabled = true;
            this.cbZona.Location = new System.Drawing.Point(501, 50);
            this.cbZona.Name = "cbZona";
            this.cbZona.Size = new System.Drawing.Size(81, 21);
            this.cbZona.TabIndex = 17;
            // 
            // dtGridPerfil
            // 
            this.dtGridPerfil.AllowUserToAddRows = false;
            this.dtGridPerfil.AllowUserToDeleteRows = false;
            this.dtGridPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtGridPerfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtGridPerfil.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtGridPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridPerfil.Location = new System.Drawing.Point(12, 137);
            this.dtGridPerfil.Name = "dtGridPerfil";
            this.dtGridPerfil.ReadOnly = true;
            this.dtGridPerfil.Size = new System.Drawing.Size(809, 346);
            this.dtGridPerfil.TabIndex = 19;
            // 
            // Eleitorado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 522);
            this.Controls.Add(this.dtGridPerfil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbZona);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCidade);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEleicao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Eleitorado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Eleitorado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEleicao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbZona;
        private System.Windows.Forms.DataGridView dtGridPerfil;
    }
}