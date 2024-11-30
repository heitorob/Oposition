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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use Os Verbos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "O embate celestial entre Usuário e Opositor";
            // 
            // btnConfrontar
            // 
            this.btnConfrontar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfrontar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfrontar.Font = new System.Drawing.Font("Papyrus", 22.25F);
            this.btnConfrontar.Location = new System.Drawing.Point(291, 289);
            this.btnConfrontar.Name = "btnConfrontar";
            this.btnConfrontar.Size = new System.Drawing.Size(219, 63);
            this.btnConfrontar.TabIndex = 2;
            this.btnConfrontar.Text = "Confrontar";
            this.btnConfrontar.UseVisualStyleBackColor = true;
            this.btnConfrontar.Click += new System.EventHandler(this.btnConfrontar_Click);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfrontar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelaInicial";
            this.Text = "TelaInicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfrontar;
    }
}