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
            this.cmbEspecialF = new System.Windows.Forms.ComboBox();
            this.cmbAtaque = new System.Windows.Forms.ComboBox();
            this.cmbEspecialL = new System.Windows.Forms.ComboBox();
            this.cmbEspecialM = new System.Windows.Forms.ComboBox();
            this.cmbEquipavel = new System.Windows.Forms.ComboBox();
            this.cmbEspecialS = new System.Windows.Forms.ComboBox();
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
            // cmbEspecialF
            // 
            this.cmbEspecialF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialF.Font = new System.Drawing.Font("Bodoni MT", 12F);
            this.cmbEspecialF.FormattingEnabled = true;
            this.cmbEspecialF.Items.AddRange(new object[] {
            "Engajar",
            "Proteger",
            "Colidir",
            "Perfurar",
            "Ultrajar"});
            this.cmbEspecialF.Location = new System.Drawing.Point(625, 251);
            this.cmbEspecialF.Name = "cmbEspecialF";
            this.cmbEspecialF.Size = new System.Drawing.Size(121, 27);
            this.cmbEspecialF.TabIndex = 9;
            this.cmbEspecialF.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialF_SelectedIndexChanged);
            // 
            // cmbAtaque
            // 
            this.cmbAtaque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtaque.Font = new System.Drawing.Font("Bodoni MT", 12F);
            this.cmbAtaque.FormattingEnabled = true;
            this.cmbAtaque.Items.AddRange(new object[] {
            "Investir",
            "Assaltar"});
            this.cmbAtaque.Location = new System.Drawing.Point(625, 185);
            this.cmbAtaque.Name = "cmbAtaque";
            this.cmbAtaque.Size = new System.Drawing.Size(121, 27);
            this.cmbAtaque.TabIndex = 10;
            this.cmbAtaque.SelectedIndexChanged += new System.EventHandler(this.cmbAtaque_SelectedIndexChanged);
            // 
            // cmbEspecialL
            // 
            this.cmbEspecialL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialL.Font = new System.Drawing.Font("Bodoni MT", 12F);
            this.cmbEspecialL.FormattingEnabled = true;
            this.cmbEspecialL.Items.AddRange(new object[] {
            "Canalizar",
            "Sacrificar",
            "Bloquear"});
            this.cmbEspecialL.Location = new System.Drawing.Point(625, 218);
            this.cmbEspecialL.Name = "cmbEspecialL";
            this.cmbEspecialL.Size = new System.Drawing.Size(121, 27);
            this.cmbEspecialL.TabIndex = 11;
            this.cmbEspecialL.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialL_SelectedIndexChanged);
            // 
            // cmbEspecialM
            // 
            this.cmbEspecialM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialM.Font = new System.Drawing.Font("Bodoni MT", 12F);
            this.cmbEspecialM.FormattingEnabled = true;
            this.cmbEspecialM.Items.AddRange(new object[] {
            "Engajar",
            "Proteger",
            "Colidir",
            "Perfurar",
            "Ultrajar",
            "Medicar",
            "Atordoar",
            "Roubar",
            "Infectar",
            "Prender"});
            this.cmbEspecialM.Location = new System.Drawing.Point(625, 284);
            this.cmbEspecialM.Name = "cmbEspecialM";
            this.cmbEspecialM.Size = new System.Drawing.Size(121, 27);
            this.cmbEspecialM.TabIndex = 12;
            this.cmbEspecialM.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialM_SelectedIndexChanged);
            // 
            // cmbEquipavel
            // 
            this.cmbEquipavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipavel.Font = new System.Drawing.Font("Bodoni MT", 12F);
            this.cmbEquipavel.FormattingEnabled = true;
            this.cmbEquipavel.Items.AddRange(new object[] {
            "---",
            "Item de Dano",
            "Item de Precisão",
            "Item de Imunidade",
            "Item de Poder"});
            this.cmbEquipavel.Location = new System.Drawing.Point(625, 350);
            this.cmbEquipavel.Name = "cmbEquipavel";
            this.cmbEquipavel.Size = new System.Drawing.Size(121, 27);
            this.cmbEquipavel.TabIndex = 13;
            this.cmbEquipavel.SelectedIndexChanged += new System.EventHandler(this.cmbEquipavel_SelectedIndexChanged);
            // 
            // cmbEspecialS
            // 
            this.cmbEspecialS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialS.Font = new System.Drawing.Font("Bodoni MT", 12F);
            this.cmbEspecialS.FormattingEnabled = true;
            this.cmbEspecialS.Items.AddRange(new object[] {
            "Medicar",
            "Atordoar",
            "Roubar",
            "Infectar",
            "Prender",
            "Flagelar",
            "Confundir",
            "Dilacerar"});
            this.cmbEspecialS.Location = new System.Drawing.Point(625, 317);
            this.cmbEspecialS.Name = "cmbEspecialS";
            this.cmbEspecialS.Size = new System.Drawing.Size(121, 27);
            this.cmbEspecialS.TabIndex = 14;
            this.cmbEspecialS.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialS_SelectedIndexChanged);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbAtaque);
            this.Controls.Add(this.cmbEspecialL);
            this.Controls.Add(this.cmbEspecialM);
            this.Controls.Add(this.cmbEquipavel);
            this.Controls.Add(this.cmbEspecialS);
            this.Controls.Add(this.cmbEspecialF);
            this.Controls.Add(this.btnConfrontar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaInicial";
            this.Shown += new System.EventHandler(this.TelaInicial_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfrontar;
        private System.Windows.Forms.ComboBox cmbEspecialF;
        private System.Windows.Forms.ComboBox cmbAtaque;
        private System.Windows.Forms.ComboBox cmbEspecialL;
        private System.Windows.Forms.ComboBox cmbEspecialM;
        private System.Windows.Forms.ComboBox cmbEquipavel;
        private System.Windows.Forms.ComboBox cmbEspecialS;
    }
}