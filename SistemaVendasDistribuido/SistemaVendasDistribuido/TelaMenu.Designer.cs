namespace SistemaVendasDistribuido
{
    partial class TelaMenu
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
            this.btnMenuProdutos = new System.Windows.Forms.Button();
            this.btnMenuVendas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.FECHAR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenuProdutos
            // 
            this.btnMenuProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnMenuProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuProdutos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuProdutos.ForeColor = System.Drawing.Color.White;
            this.btnMenuProdutos.Location = new System.Drawing.Point(302, 37);
            this.btnMenuProdutos.Name = "btnMenuProdutos";
            this.btnMenuProdutos.Size = new System.Drawing.Size(130, 27);
            this.btnMenuProdutos.TabIndex = 1;
            this.btnMenuProdutos.Text = "Gerir Produtos";
            this.btnMenuProdutos.UseVisualStyleBackColor = false;
            this.btnMenuProdutos.Click += new System.EventHandler(this.btnMenuProdutos_Click_1);
            // 
            // btnMenuVendas
            // 
            this.btnMenuVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnMenuVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuVendas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuVendas.ForeColor = System.Drawing.Color.White;
            this.btnMenuVendas.Location = new System.Drawing.Point(246, 226);
            this.btnMenuVendas.Name = "btnMenuVendas";
            this.btnMenuVendas.Size = new System.Drawing.Size(134, 30);
            this.btnMenuVendas.TabIndex = 2;
            this.btnMenuVendas.Text = "Caixa de Vendas";
            this.btnMenuVendas.UseVisualStyleBackColor = false;
            this.btnMenuVendas.Click += new System.EventHandler(this.btnMenuVendas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PeachPuff;
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "PAINEL DE CONTROLO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaVendasDistribuido.Properties.Resources.Gemini_Generated_Image_hwsswdhwsswdhwss;
            this.pictureBox1.Location = new System.Drawing.Point(-14, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(693, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(81, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gerir Clientes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnMenuClientes_Click);
            // 
            // FECHAR
            // 
            this.FECHAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.FECHAR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FECHAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FECHAR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FECHAR.ForeColor = System.Drawing.Color.White;
            this.FECHAR.Location = new System.Drawing.Point(507, 217);
            this.FECHAR.Name = "FECHAR";
            this.FECHAR.Size = new System.Drawing.Size(65, 30);
            this.FECHAR.TabIndex = 5;
            this.FECHAR.Text = "Fechar";
            this.FECHAR.UseVisualStyleBackColor = false;
            this.FECHAR.Click += new System.EventHandler(this.FECHAR_Click);
            // 
            // TelaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(607, 291);
            this.Controls.Add(this.FECHAR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMenuVendas);
            this.Controls.Add(this.btnMenuProdutos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Vendas Centralizado - Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMenuProdutos;
        private System.Windows.Forms.Button btnMenuVendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button FECHAR;
    }
}