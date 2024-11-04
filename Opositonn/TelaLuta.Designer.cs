namespace Opositonn
{
    partial class TelaLuta
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSaudeUsuario = new System.Windows.Forms.Label();
            this.lblSaudeOpositor = new System.Windows.Forms.Label();
            this.btnInvestir = new System.Windows.Forms.Button();
            this.btnCanalizar = new System.Windows.Forms.Button();
            this.lblPoder = new System.Windows.Forms.Label();
            this.btnMedicar = new System.Windows.Forms.Button();
            this.btnFlagelar = new System.Windows.Forms.Button();
            this.btnEngajar = new System.Windows.Forms.Button();
            this.btnProteger = new System.Windows.Forms.Button();
            this.btnPerfurar = new System.Windows.Forms.Button();
            this.btnInfectar = new System.Windows.Forms.Button();
            this.btnUltrajar = new System.Windows.Forms.Button();
            this.imgEscudoUsuario = new System.Windows.Forms.PictureBox();
            this.imgDecaimentoUsuario = new System.Windows.Forms.PictureBox();
            this.imgEscudoOpositor = new System.Windows.Forms.PictureBox();
            this.imgDecaimentoOpositor = new System.Windows.Forms.PictureBox();
            this.btnRoubar = new System.Windows.Forms.Button();
            this.btnConfundir = new System.Windows.Forms.Button();
            this.btnAtordoar = new System.Windows.Forms.Button();
            this.imgAtordoamentoUsuario = new System.Windows.Forms.PictureBox();
            this.imgAtordoamentoOpositor = new System.Windows.Forms.PictureBox();
            this.btnColidir = new System.Windows.Forms.Button();
            this.btnDilacerar = new System.Windows.Forms.Button();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.tipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgEscudoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDecaimentoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEscudoOpositor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDecaimentoOpositor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAtordoamentoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAtordoamentoOpositor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSaudeUsuario
            // 
            this.lblSaudeUsuario.AutoSize = true;
            this.lblSaudeUsuario.Location = new System.Drawing.Point(358, 228);
            this.lblSaudeUsuario.Name = "lblSaudeUsuario";
            this.lblSaudeUsuario.Size = new System.Drawing.Size(33, 19);
            this.lblSaudeUsuario.TabIndex = 0;
            this.lblSaudeUsuario.Text = "200";
            // 
            // lblSaudeOpositor
            // 
            this.lblSaudeOpositor.AutoSize = true;
            this.lblSaudeOpositor.Location = new System.Drawing.Point(358, 106);
            this.lblSaudeOpositor.Name = "lblSaudeOpositor";
            this.lblSaudeOpositor.Size = new System.Drawing.Size(33, 19);
            this.lblSaudeOpositor.TabIndex = 0;
            this.lblSaudeOpositor.Text = "200";
            // 
            // btnInvestir
            // 
            this.btnInvestir.Location = new System.Drawing.Point(21, 352);
            this.btnInvestir.Name = "btnInvestir";
            this.btnInvestir.Size = new System.Drawing.Size(182, 61);
            this.btnInvestir.TabIndex = 1;
            this.btnInvestir.Text = "Investir";
            this.tipInfo.SetToolTip(this.btnInvestir, "Tira 16 de saúde do Opositor.\r\nPrecisão - 80.");
            this.btnInvestir.UseVisualStyleBackColor = true;
            this.btnInvestir.Click += new System.EventHandler(this.btnInvestir_Click);
            // 
            // btnCanalizar
            // 
            this.btnCanalizar.Location = new System.Drawing.Point(209, 352);
            this.btnCanalizar.Name = "btnCanalizar";
            this.btnCanalizar.Size = new System.Drawing.Size(182, 61);
            this.btnCanalizar.TabIndex = 1;
            this.btnCanalizar.Text = "Canalizar";
            this.tipInfo.SetToolTip(this.btnCanalizar, "Invoca 1 poder.");
            this.btnCanalizar.UseVisualStyleBackColor = true;
            this.btnCanalizar.Click += new System.EventHandler(this.btnCanalizar_Click);
            // 
            // lblPoder
            // 
            this.lblPoder.AutoSize = true;
            this.lblPoder.Location = new System.Drawing.Point(415, 228);
            this.lblPoder.Name = "lblPoder";
            this.lblPoder.Size = new System.Drawing.Size(17, 19);
            this.lblPoder.TabIndex = 2;
            this.lblPoder.Text = "0";
            // 
            // btnMedicar
            // 
            this.btnMedicar.Location = new System.Drawing.Point(21, 655);
            this.btnMedicar.Name = "btnMedicar";
            this.btnMedicar.Size = new System.Drawing.Size(182, 61);
            this.btnMedicar.TabIndex = 1;
            this.btnMedicar.Text = "Medicar";
            this.tipInfo.SetToolTip(this.btnMedicar, "Recupera 40 de saúde do Usuário.\r\nRemove efeito de Decaimento do Usuário.");
            this.btnMedicar.UseVisualStyleBackColor = true;
            this.btnMedicar.Click += new System.EventHandler(this.btnMedicar_Click);
            // 
            // btnFlagelar
            // 
            this.btnFlagelar.Location = new System.Drawing.Point(21, 778);
            this.btnFlagelar.Name = "btnFlagelar";
            this.btnFlagelar.Size = new System.Drawing.Size(182, 61);
            this.btnFlagelar.TabIndex = 1;
            this.btnFlagelar.Text = "Flagelar";
            this.tipInfo.SetToolTip(this.btnFlagelar, "Tira 60 de saúde do Opositor.\r\nPrecisão - 80.");
            this.btnFlagelar.UseVisualStyleBackColor = true;
            this.btnFlagelar.Click += new System.EventHandler(this.btnFlagelar_Click);
            // 
            // btnEngajar
            // 
            this.btnEngajar.Location = new System.Drawing.Point(21, 468);
            this.btnEngajar.Name = "btnEngajar";
            this.btnEngajar.Size = new System.Drawing.Size(182, 61);
            this.btnEngajar.TabIndex = 3;
            this.btnEngajar.Text = "Engajar";
            this.tipInfo.SetToolTip(this.btnEngajar, "Aumenta a precisão em 20.\r\nRemove efeito de Decaimento do Usuário.");
            this.btnEngajar.UseVisualStyleBackColor = true;
            this.btnEngajar.Click += new System.EventHandler(this.btnEngajar_Click);
            // 
            // btnProteger
            // 
            this.btnProteger.Location = new System.Drawing.Point(21, 535);
            this.btnProteger.Name = "btnProteger";
            this.btnProteger.Size = new System.Drawing.Size(182, 61);
            this.btnProteger.TabIndex = 1;
            this.btnProteger.Text = "Proteger";
            this.tipInfo.SetToolTip(this.btnProteger, "Invoca um Escudo.");
            this.btnProteger.UseVisualStyleBackColor = true;
            this.btnProteger.Click += new System.EventHandler(this.btnProteger_Click);
            // 
            // btnPerfurar
            // 
            this.btnPerfurar.Location = new System.Drawing.Point(209, 468);
            this.btnPerfurar.Name = "btnPerfurar";
            this.btnPerfurar.Size = new System.Drawing.Size(182, 61);
            this.btnPerfurar.TabIndex = 1;
            this.btnPerfurar.Text = "Perfurar";
            this.tipInfo.SetToolTip(this.btnPerfurar, "Tira 28 de saúde do Opositor.\r\nDestrói Escudos do Opositor.\r\nTira 12 de saúde a m" +
        "ais se destrói um Escudo.\r\nPrecisão - 80.");
            this.btnPerfurar.UseVisualStyleBackColor = true;
            this.btnPerfurar.Click += new System.EventHandler(this.btnPerfurar_Click);
            // 
            // btnInfectar
            // 
            this.btnInfectar.Location = new System.Drawing.Point(397, 655);
            this.btnInfectar.Name = "btnInfectar";
            this.btnInfectar.Size = new System.Drawing.Size(182, 61);
            this.btnInfectar.TabIndex = 1;
            this.btnInfectar.Text = "Infectar";
            this.tipInfo.SetToolTip(this.btnInfectar, "Aplica efeito de Decaimento no Opositor.");
            this.btnInfectar.UseVisualStyleBackColor = true;
            this.btnInfectar.Click += new System.EventHandler(this.btnInfectar_Click);
            // 
            // btnUltrajar
            // 
            this.btnUltrajar.Location = new System.Drawing.Point(209, 535);
            this.btnUltrajar.Name = "btnUltrajar";
            this.btnUltrajar.Size = new System.Drawing.Size(182, 61);
            this.btnUltrajar.TabIndex = 1;
            this.btnUltrajar.Text = "Ultrajar";
            this.tipInfo.SetToolTip(this.btnUltrajar, "Tira 28 de saúde do Opositor.\r\nAplica efeito de Decaimento no Opositor.\r\nPrecisão" +
        " - 60.");
            this.btnUltrajar.UseVisualStyleBackColor = true;
            this.btnUltrajar.Click += new System.EventHandler(this.btnUltrajar_Click);
            // 
            // imgEscudoUsuario
            // 
            this.imgEscudoUsuario.Image = global::Opositonn.Properties.Resources.placeholder_icones;
            this.imgEscudoUsuario.Location = new System.Drawing.Point(438, 207);
            this.imgEscudoUsuario.Name = "imgEscudoUsuario";
            this.imgEscudoUsuario.Size = new System.Drawing.Size(40, 40);
            this.imgEscudoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgEscudoUsuario.TabIndex = 4;
            this.imgEscudoUsuario.TabStop = false;
            this.tipInfo.SetToolTip(this.imgEscudoUsuario, "Reduz a saúde perdida em 60%.\r\nDura até ser removido.");
            this.imgEscudoUsuario.Visible = false;
            // 
            // imgDecaimentoUsuario
            // 
            this.imgDecaimentoUsuario.Image = global::Opositonn.Properties.Resources.placeholder_icones;
            this.imgDecaimentoUsuario.Location = new System.Drawing.Point(484, 207);
            this.imgDecaimentoUsuario.Name = "imgDecaimentoUsuario";
            this.imgDecaimentoUsuario.Size = new System.Drawing.Size(40, 40);
            this.imgDecaimentoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDecaimentoUsuario.TabIndex = 4;
            this.imgDecaimentoUsuario.TabStop = false;
            this.tipInfo.SetToolTip(this.imgDecaimentoUsuario, "Tira 8 de saúde no final de cada turno.\r\nDura até ser removido.");
            this.imgDecaimentoUsuario.Visible = false;
            // 
            // imgEscudoOpositor
            // 
            this.imgEscudoOpositor.Image = global::Opositonn.Properties.Resources.placeholder_icones;
            this.imgEscudoOpositor.Location = new System.Drawing.Point(438, 85);
            this.imgEscudoOpositor.Name = "imgEscudoOpositor";
            this.imgEscudoOpositor.Size = new System.Drawing.Size(40, 40);
            this.imgEscudoOpositor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgEscudoOpositor.TabIndex = 4;
            this.imgEscudoOpositor.TabStop = false;
            this.tipInfo.SetToolTip(this.imgEscudoOpositor, "Reduz a saúde perdida em 60%.\r\nDura até ser removido.");
            this.imgEscudoOpositor.Visible = false;
            // 
            // imgDecaimentoOpositor
            // 
            this.imgDecaimentoOpositor.Image = global::Opositonn.Properties.Resources.placeholder_icones;
            this.imgDecaimentoOpositor.Location = new System.Drawing.Point(484, 85);
            this.imgDecaimentoOpositor.Name = "imgDecaimentoOpositor";
            this.imgDecaimentoOpositor.Size = new System.Drawing.Size(40, 40);
            this.imgDecaimentoOpositor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDecaimentoOpositor.TabIndex = 4;
            this.imgDecaimentoOpositor.TabStop = false;
            this.tipInfo.SetToolTip(this.imgDecaimentoOpositor, "Tira 8 de saúde no final de cada turno.\r\nDura até ser removido.");
            this.imgDecaimentoOpositor.Visible = false;
            // 
            // btnRoubar
            // 
            this.btnRoubar.Location = new System.Drawing.Point(209, 655);
            this.btnRoubar.Name = "btnRoubar";
            this.btnRoubar.Size = new System.Drawing.Size(182, 61);
            this.btnRoubar.TabIndex = 1;
            this.btnRoubar.Text = "Roubar";
            this.tipInfo.SetToolTip(this.btnRoubar, "Tira 28 de saúde do Opositor.\r\nRecupera 28 de saúde do Usuário.\r\nPrecisão - 80.");
            this.btnRoubar.UseVisualStyleBackColor = true;
            this.btnRoubar.Click += new System.EventHandler(this.btnRoubar_Click);
            // 
            // btnConfundir
            // 
            this.btnConfundir.Location = new System.Drawing.Point(209, 778);
            this.btnConfundir.Name = "btnConfundir";
            this.btnConfundir.Size = new System.Drawing.Size(182, 61);
            this.btnConfundir.TabIndex = 1;
            this.btnConfundir.Text = "Confundir";
            this.tipInfo.SetToolTip(this.btnConfundir, "Tira 40 pontos de saúde do Opositor.\r\nReduz a precisão do Opositor em 10.\r\nPrecis" +
        "ão - 100.");
            this.btnConfundir.UseVisualStyleBackColor = true;
            this.btnConfundir.Click += new System.EventHandler(this.btnConfundir_Click);
            // 
            // btnAtordoar
            // 
            this.btnAtordoar.Location = new System.Drawing.Point(585, 655);
            this.btnAtordoar.Name = "btnAtordoar";
            this.btnAtordoar.Size = new System.Drawing.Size(182, 61);
            this.btnAtordoar.TabIndex = 1;
            this.btnAtordoar.Text = "Atordoar";
            this.tipInfo.SetToolTip(this.btnAtordoar, "Tira 40 de saúde do Opositor.\r\nAplica efeito de Atordoamento no Opositor.\r\nPrecis" +
        "ão - 60.");
            this.btnAtordoar.UseVisualStyleBackColor = true;
            this.btnAtordoar.Click += new System.EventHandler(this.btnAtordoar_Click);
            // 
            // imgAtordoamentoUsuario
            // 
            this.imgAtordoamentoUsuario.Image = global::Opositonn.Properties.Resources.placeholder_icones;
            this.imgAtordoamentoUsuario.Location = new System.Drawing.Point(530, 207);
            this.imgAtordoamentoUsuario.Name = "imgAtordoamentoUsuario";
            this.imgAtordoamentoUsuario.Size = new System.Drawing.Size(40, 40);
            this.imgAtordoamentoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAtordoamentoUsuario.TabIndex = 4;
            this.imgAtordoamentoUsuario.TabStop = false;
            this.tipInfo.SetToolTip(this.imgAtordoamentoUsuario, "Impede o turno de ser realizado.\r\nDura 1 turno.");
            this.imgAtordoamentoUsuario.Visible = false;
            // 
            // imgAtordoamentoOpositor
            // 
            this.imgAtordoamentoOpositor.Image = global::Opositonn.Properties.Resources.placeholder_icones;
            this.imgAtordoamentoOpositor.Location = new System.Drawing.Point(530, 85);
            this.imgAtordoamentoOpositor.Name = "imgAtordoamentoOpositor";
            this.imgAtordoamentoOpositor.Size = new System.Drawing.Size(40, 40);
            this.imgAtordoamentoOpositor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAtordoamentoOpositor.TabIndex = 4;
            this.imgAtordoamentoOpositor.TabStop = false;
            this.tipInfo.SetToolTip(this.imgAtordoamentoOpositor, "Impede o turno de ser realizado.\r\nDura 1 turno.");
            this.imgAtordoamentoOpositor.Visible = false;
            // 
            // btnColidir
            // 
            this.btnColidir.Location = new System.Drawing.Point(397, 468);
            this.btnColidir.Name = "btnColidir";
            this.btnColidir.Size = new System.Drawing.Size(182, 61);
            this.btnColidir.TabIndex = 3;
            this.btnColidir.Text = "Colidir";
            this.tipInfo.SetToolTip(this.btnColidir, "Tira 40 de saúde do Opositor.\r\nTira 16 de saúde do Usuário.\r\nPrecisão - 80.");
            this.btnColidir.UseVisualStyleBackColor = true;
            this.btnColidir.Click += new System.EventHandler(this.btnColidir_Click);
            // 
            // btnDilacerar
            // 
            this.btnDilacerar.Location = new System.Drawing.Point(397, 778);
            this.btnDilacerar.Name = "btnDilacerar";
            this.btnDilacerar.Size = new System.Drawing.Size(182, 61);
            this.btnDilacerar.TabIndex = 1;
            this.btnDilacerar.Text = "Dilacerar";
            this.tipInfo.SetToolTip(this.btnDilacerar, "Tira metade da saúde do Opositor.\r\nPrecisão - 60.\r\nTempo de espera - 4 turnos.");
            this.btnDilacerar.UseVisualStyleBackColor = true;
            this.btnDilacerar.Click += new System.EventHandler(this.btnDilacerar_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.Location = new System.Drawing.Point(397, 352);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(182, 61);
            this.btnBloquear.TabIndex = 1;
            this.btnBloquear.Text = "Bloquear";
            this.tipInfo.SetToolTip(this.btnBloquear, "Invoca 1 poder.\r\nAtordoa o Opositor.\r\nTempo de espera - 2 turnos.");
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // tipInfo
            // 
            this.tipInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipInfo.ToolTipTitle = "Informações";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ataques Livres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ataques Fracos (Poder 1)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 633);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ataques Médios (Poder 2)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 756);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ataques Fortes (Poder 3)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Usuário";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Opositor";
            // 
            // TelaLuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 881);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgAtordoamentoOpositor);
            this.Controls.Add(this.imgDecaimentoOpositor);
            this.Controls.Add(this.imgAtordoamentoUsuario);
            this.Controls.Add(this.imgEscudoOpositor);
            this.Controls.Add(this.imgDecaimentoUsuario);
            this.Controls.Add(this.imgEscudoUsuario);
            this.Controls.Add(this.btnColidir);
            this.Controls.Add(this.btnEngajar);
            this.Controls.Add(this.lblPoder);
            this.Controls.Add(this.btnFlagelar);
            this.Controls.Add(this.btnMedicar);
            this.Controls.Add(this.btnBloquear);
            this.Controls.Add(this.btnCanalizar);
            this.Controls.Add(this.btnDilacerar);
            this.Controls.Add(this.btnConfundir);
            this.Controls.Add(this.btnRoubar);
            this.Controls.Add(this.btnUltrajar);
            this.Controls.Add(this.btnAtordoar);
            this.Controls.Add(this.btnInfectar);
            this.Controls.Add(this.btnPerfurar);
            this.Controls.Add(this.btnProteger);
            this.Controls.Add(this.btnInvestir);
            this.Controls.Add(this.lblSaudeOpositor);
            this.Controls.Add(this.lblSaudeUsuario);
            this.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TelaLuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TelaLuta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgEscudoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDecaimentoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEscudoOpositor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDecaimentoOpositor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAtordoamentoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAtordoamentoOpositor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaudeUsuario;
        private System.Windows.Forms.Label lblSaudeOpositor;
        private System.Windows.Forms.Button btnInvestir;
        private System.Windows.Forms.Button btnCanalizar;
        private System.Windows.Forms.Label lblPoder;
        private System.Windows.Forms.Button btnMedicar;
        private System.Windows.Forms.Button btnFlagelar;
        private System.Windows.Forms.Button btnEngajar;
        private System.Windows.Forms.Button btnProteger;
        private System.Windows.Forms.Button btnPerfurar;
        private System.Windows.Forms.Button btnInfectar;
        private System.Windows.Forms.Button btnUltrajar;
        private System.Windows.Forms.PictureBox imgEscudoUsuario;
        private System.Windows.Forms.PictureBox imgDecaimentoUsuario;
        private System.Windows.Forms.PictureBox imgEscudoOpositor;
        private System.Windows.Forms.PictureBox imgDecaimentoOpositor;
        private System.Windows.Forms.Button btnRoubar;
        private System.Windows.Forms.Button btnConfundir;
        private System.Windows.Forms.Button btnAtordoar;
        private System.Windows.Forms.PictureBox imgAtordoamentoUsuario;
        private System.Windows.Forms.PictureBox imgAtordoamentoOpositor;
        private System.Windows.Forms.Button btnColidir;
        private System.Windows.Forms.Button btnDilacerar;
        private System.Windows.Forms.Button btnBloquear;
        private System.Windows.Forms.ToolTip tipInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

