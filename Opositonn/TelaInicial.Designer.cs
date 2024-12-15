namespace Opositonn
{
    partial class TelaInicial
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfrontar = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaisLonga = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bodoni MT", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use Os Verbos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bodoni MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "O embate celestial entre Usuário e Opositor";
            // 
            // btnConfrontar
            // 
            this.btnConfrontar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfrontar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfrontar.Font = new System.Drawing.Font("Bodoni MT Condensed", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfrontar.Location = new System.Drawing.Point(300, 253);
            this.btnConfrontar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConfrontar.Name = "btnConfrontar";
            this.btnConfrontar.Size = new System.Drawing.Size(200, 66);
            this.btnConfrontar.TabIndex = 2;
            this.btnConfrontar.Text = "Confrontar";
            this.btnConfrontar.UseVisualStyleBackColor = true;
            this.btnConfrontar.Click += new System.EventHandler(this.btnConfrontar_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventario.Font = new System.Drawing.Font("Bodoni MT Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Location = new System.Drawing.Point(510, 260);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(160, 56);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "Inventário";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMaisLonga);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(129, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Placares de Líderes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bodoni MT", 8F);
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Partida Mais Longa";
            // 
            // lblMaisLonga
            // 
            this.lblMaisLonga.AutoSize = true;
            this.lblMaisLonga.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaisLonga.Font = new System.Drawing.Font("Bodoni MT", 10F);
            this.lblMaisLonga.Location = new System.Drawing.Point(126, 24);
            this.lblMaisLonga.Name = "lblMaisLonga";
            this.lblMaisLonga.Size = new System.Drawing.Size(15, 20);
            this.lblMaisLonga.TabIndex = 4;
            this.lblMaisLonga.Text = "-";
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnConfrontar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaInicial";
            this.Load += new System.EventHandler(this.TelaInicial_Load);
            this.Shown += new System.EventHandler(this.TelaInicial_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfrontar;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaisLonga;
    }
}