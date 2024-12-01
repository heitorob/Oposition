using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opositonn
{
    public partial class TelaLuta : Form
    {
        int[] Saude, Poder, Precisao, TempoAtordoamento, TempoEscudo, TempoDecaimento, TempoRecursivo, AtaquesOpositor, Equipavel;
        int[,] TempoEspera;

        public static string Ataque { get; set; }
        public static string ELivre { get; set; }
        public static string EFraco { get; set; }
        public static string EMedio { get; set; }
        public static string EForte { get; set; }
        public static string IEquip { get; set; }

        public Random rng = new Random();

        Dictionary<int, (string Nome, int Custo, int Precisao, Button[] Botoes)> Bglhs;

        public TelaLuta()
        {
            InitializeComponent();

            Saude = new int[2];
            Poder = new int[2];
            Precisao = new int[2];
            TempoEscudo = new int[2];
            TempoDecaimento = new int[2];
            TempoAtordoamento = new int[2];
            TempoEspera = new int[2, 5];
            TempoRecursivo = new int[2];
            AtaquesOpositor = new int[4];
            Equipavel = new int[2];

            Bglhs = new Dictionary<int, (string, int, int, Button[])>
            {
                { 0,  ("Investir",   0, 80,  new Button[] { btnInvestir,   null } ) },
                { 1,  ("Assaltar",   0, 80,  new Button[] { btnAssaltar,   null } ) },
                { 2,  ("Canalizar",  0, 0,   new Button[] { btnCanalizar,  null } ) },
                { 3,  ("Sacrificar", 0, 0,   new Button[] { btnSacrificar, null } ) },
                { 4,  ("Bloquear",   0, 0,   new Button[] { btnBloquear,   null } ) },
                { 5,  ("Engajar",    1, 0,   new Button[] { btnEngajar,    btnEngajarAlt } ) },
                { 6,  ("Proteger",   1, 0,   new Button[] { btnProteger,   btnProtegerAlt } ) },
                { 7,  ("Colidir",    1, 80,  new Button[] { btnColidir,    btnColidirAlt } ) },
                { 8,  ("Perfurar",   1, 80,  new Button[] { btnPerfurar,   btnPerfurarAlt } ) },
                { 9,  ("Ultrajar",   1, 60,  new Button[] { btnUltrajar,   btnUltrajarAlt } ) },
                { 10, ("Medicar",    2, 0,   new Button[] { btnMedicar,    btnMedicarAlt } ) },
                { 11, ("Atordoar",   2, 60,  new Button[] { btnAtordoar,   btnAtordoarAlt } ) },
                { 12, ("Roubar",     2, 80,  new Button[] { btnRoubar,     btnRoubarAlt } ) },
                { 13, ("Infectar",   2, 0,   new Button[] { btnInfectar,   btnInfectarAlt } ) },
                { 14, ("Prender",    2, 0,   new Button[] { btnPrender,    btnPrenderAlt } ) },
                { 15, ("Flagelar",   3, 80,  new Button[] { btnFlagelar,   null } ) },
                { 16, ("Confundir",  3, 100, new Button[] { btnConfundir,  null } ) },
                { 17, ("Dilacerar",  3, 60,  new Button[] { btnDilacerar,  null } ) }
            };
        }

        private void TelaLuta_Load(object sender, EventArgs e)
        {
            for (int User = 0; User <= 1; User++) Saude[User] = 200;
            for (int User = 0; User <= 1; User++) Poder[User] = 0;
            for (int User = 0; User <= 1; User++) Precisao[User] = 80;
            for (int User = 0; User <= 1; User++) TempoEscudo[User] = 0;
            for (int User = 0; User <= 1; User++) TempoDecaimento[User] = 0;
            for (int User = 0; User <= 1; User++) TempoAtordoamento[User] = 0;
            for (int User = 0; User <= 1; User++) TempoRecursivo[User] = 0;

            AtaquesOpositor[0] = 0;
            AtaquesOpositor[1] = rng.Next(4, 10);
            AtaquesOpositor[2] = rng.Next(10, 15);
            AtaquesOpositor[3] = rng.Next(15, 18);
            Equipavel[1] = rng.Next(0, 4);

            numAtaqueOpositor.Text = AtaquesOpositor[0].ToString();
            numAtaqueOpositorI.Text = AtaquesOpositor[1].ToString();
            numAtaqueOpositorII.Text = AtaquesOpositor[2].ToString();
            numAtaqueOpositorIII.Text = AtaquesOpositor[3].ToString();
            numEquipavelOpositor.Text = Equipavel[1].ToString();

            for (int Botao = 0; Botao <= 1; Botao++)
                Bglhs[Botao].Botoes[0].Visible = Ataque == Bglhs[Botao].Nome;
            for (int Botao = 2; Botao <= 4; Botao++)
                Bglhs[Botao].Botoes[0].Visible = ELivre == Bglhs[Botao].Nome;
            for (int Botao = 5; Botao <= 9; Botao++)
                Bglhs[Botao].Botoes[0].Visible = EFraco == Bglhs[Botao].Nome;
            for (int Botao = 5; Botao <= 14; Botao++)
                Bglhs[Botao].Botoes[Botao < 10 ? 1 : 0].Visible = EMedio == Bglhs[Botao].Nome;
            for (int Botao = 10; Botao <= 17; Botao++)
                Bglhs[Botao].Botoes[Botao < 15 ? 1 : 0].Visible = EForte == Bglhs[Botao].Nome;
            switch (IEquip)
            {
                default:
                    Equipavel[0] = 0; break;
                case "Item de Dano":
                    Equipavel[0] = 1; break;
                case "Item de Precisão":
                    Equipavel[0] = 2; break;
                case "Item de Imunidade":
                    Equipavel[0] = 3; break;
                case "Item de Poder":
                    Equipavel[0] = 4; break;
            }
            for (int Botao = 0; Botao <= 17; Botao++)
                for (int Alt = 0; Alt <= 1; Alt++)
                    if (Bglhs[Botao].Botoes[Alt] != null)
                        Bglhs[Botao].Botoes[Alt].Enabled = Poder[0] >= Bglhs[Botao].Custo;
        }

        private bool Atualizar()
        {
            lblSaudeUsuario.Text = Saude[0].ToString();
            lblSaudeOpositor.Text = Saude[1].ToString();

            prgUsuario.Value = Saude[0] / 2;
            prgOpositor.Value = Saude[1] / 2;

            lblPoder.Text = Poder[0].ToString();

            imgEscudoUsuario.Visible = TempoEscudo[0] > 0;

            imgEscudoOpositor.Visible = TempoEscudo[1] > 0;

            imgDecaimentoUsuario.Visible = TempoDecaimento[0] > 0;

            imgDecaimentoOpositor.Visible = TempoDecaimento[1] > 0;

            imgAtordoamentoUsuario.Visible = TempoAtordoamento[0] > 0 || TempoRecursivo[0] > 0;

            imgAtordoamentoOpositor.Visible = TempoAtordoamento[1] > 0 || TempoRecursivo[1] > 0;

            lblSaudeUsuario.ForeColor = Saude[0] <= 60 ? Color.Red : Color.Black;

            lblSaudeOpositor.ForeColor = Saude[1] <= 60 ? Color.Red : Color.Black;

            lblPoder.ForeColor = Poder[0] == (Equipavel[0] == 4 ? 4 : 3) ? Color.DarkTurquoise : Color.Black;

            btnReanimar.Visible = TempoAtordoamento[0] > 0 || TempoRecursivo[0] > 0;

            lblPoderOpositor.Text = Poder[1].ToString();
            numPrecisaoUsuario.Text = Precisao[0].ToString();
            numPrecisaoOpositor.Text = Precisao[1].ToString();

            for (int Botao = 0; Botao <= 17; Botao++)
                for (int Alt = 0; Alt <= 1; Alt++)
                    if (Bglhs[Botao].Botoes[Alt] != null) 
                        Bglhs[Botao].Botoes[Alt].Enabled = !btnReanimar.Visible && Poder[0] >= Bglhs[Botao].Custo;

            if (TestarFim()) return true;

            return false;
        }

        private bool Condicional(int User, int Ataque)
        {
            if (TempoRecursivo[User] > 0)
            {
                if (rng.Next(0, 5) > TempoRecursivo[User] || TempoRecursivo[User] == 1)
                { 
                    TempoRecursivo[User] = 0;
                    MessageBox.Show("Tentou usar " + Bglhs[Ataque].Nome + ", mas está atordoado.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                    MessageBox.Show("Atordoamento Recursivo acabou.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                }
                else
                {
                    TempoRecursivo[User]--;
                    MessageBox.Show("Tentou usar " + Bglhs[Ataque].Nome + ", mas está atordoado.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                }
                return false;
            }

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                MessageBox.Show("Tentou usar " + Bglhs[Ataque].Nome + ", mas está atordoado.", "Atordoamento", MessageBoxButtons.OK);
                return false;
            }

            if (Poder[User] < Bglhs[Ataque].Custo)
            {
                MessageBox.Show("Não acumulou Poderes suficientes.\nPrecisa de " + Bglhs[Ataque].Custo + ".", "Sem Poderes Suficientes.", MessageBoxButtons.OK);
                return false;
            }
            else if (User == 0) Poder[User] = Math.Max(0, Poder[User] - Bglhs[Ataque].Custo);
            else if (Bglhs[Ataque].Custo > 0) Poder[User] = 0;

            return true;
        }

        private bool TestarFim()
        {
            if (Saude[1] == 0)
            {
                MessageBox.Show("Triunfo", "Triunfo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return true;
            }
            if (Saude[0] == 0)
            {
                MessageBox.Show("Derrota", "Derrota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return true;
            }
            return false;
        }

        private void Rodada()
        {
            for (int User = 0; User <= 1; User++)
            {
                if (Precisao[User] < (Equipavel[User] == 2 ? 100 : 80)) Precisao[User] = Math.Min(Equipavel[User] == 2 ? 100 : 80, Precisao[User] + 5);
                else if (Precisao[User] > (Equipavel[User] == 2 ? 100 : 80)) Precisao[User] = Math.Max(Equipavel[User] == 2 ? 100 : 80, Precisao[User] - 5);
            }

            for (int User = 0; User <= 1; User++)
                for (int Ataque = 0; Ataque <= 4; Ataque++) 
                    TempoEspera[User, Ataque] = Math.Max(0, TempoEspera[User, Ataque] - 1);

            for (int User = 0; User <= 1; User++)
                TempoEscudo[User] = Math.Max(0, TempoEscudo[User] - 1);

            for (int User = 0; User <= 1; User++)
                if (TempoDecaimento[User] > 0) 
                { 
                    Saude[User] = Math.Max(0, Saude[User] - 8);
                    TempoDecaimento[User]--;
                    Atualizar();
                }
        }

        private void Usuario(int Ataque)
        {
            if (!Condicional(0, Ataque)) return;

            switch (Ataque)
            {
                default:
                    Investir(0); break;
                case 1:
                    Assaltar(1); break;
                case 2:
                    Canalizar(0); break;
                case 3:
                    Sacrificar(0); break;
                case 4:
                    Bloquear(0); break;
                case 5:
                    Engajar(0); break;
                case 6:
                    Proteger(0); break;
                case 7:
                    Colidir(0); break;
                case 8:
                    Perfurar(0); break;
                case 9:
                    Ultrajar(0); break;
                case 10:
                    Medicar(0); break;
                case 11:
                    Atordoar(0); break;
                case 12:
                    Roubar(0); break;
                case 13:
                    Infectar(0); break;
                case 14:
                    Prender(0); break;
                case 15:
                    Flagelar(0); break;
                case 16:
                    Confundir(0); break;
                case 17:
                    Dilacerar(0); break;
            }

            if (Atualizar()) return;

            Opositor();
        }

        private void Opositor()
        {
            if (Saude[1] < 180) Poder[1] = Math.Min(Poder[1] + 1, 4);

            int _escolha = rng.Next(0, Poder[1]);
            int Escolha = AtaquesOpositor[_escolha];

            if (!Condicional(1, Escolha)) return;

            switch (Escolha)
            {
                default:
                    Investir(1); break;
                case 4:
                    Bloquear(1); break;
                case 5:
                    Engajar(1); break;
                case 6:
                    Proteger(1); break;
                case 7:
                    Colidir(1); break;
                case 8:
                    Perfurar(1); break;
                case 9:
                    Ultrajar(1); break;
                case 10:
                    Medicar(1); break;
                case 11:
                    Atordoar(1); break;
                case 12:
                    Roubar(1); break;
                case 13:
                    Infectar(1); break;
                case 14:
                    Prender(1); break;
                case 15:
                    Flagelar(1); break;
                case 16:
                    Confundir(1); break;
                case 17:
                    Dilacerar(1); break;
            }

            Atualizar();
        }

        private int CalcularDano(int User, double Dano)
        {
            if (TempoEscudo[1 - User] > 0) Dano *= 0.8;
            if (Equipavel[User] == 1) Dano *= 1.2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - (int)Dano);

            return (int)Dano;
        }

        private bool CalcularAcerto(int User, int Ataque)
        {
            if (rng.Next(0, 100) > Precisao[User] + Bglhs[Ataque].Precisao - 80)
            {
                MessageBox.Show("Tentou usar " + Bglhs[Ataque].Nome + ", mas errou.", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return false;
            }

            return true;
        }

        private void Investir(int User)
        {
            if (!CalcularAcerto(User, 0)) return;

            CalcularDano(User, 16);

            MessageBox.Show("Usou Investir", "Investir", MessageBoxButtons.OK);
        }

        private void Canalizar(int User)
        {
            Poder[User] = Math.Min(Equipavel[User] == 4 ? 4 : 3, Poder[User] + 1);

            MessageBox.Show("Usou Canalizar.", "Canalizar", MessageBoxButtons.OK);
        }

        private void Medicar(int User)
        {

            Saude[User] = Math.Min(Equipavel[User] == 4 ? 300 : 200, Saude[User] + 40);

            TempoDecaimento[User] = 0;

            MessageBox.Show("Usou Medicar.", "Medicar", MessageBoxButtons.OK);
        }

        private void Flagelar(int User)
        {
            if (!CalcularAcerto(User, 15)) return;

            CalcularDano(User, 60);

            MessageBox.Show("Usou Flagelar.", "Flagelar", MessageBoxButtons.OK);
        }

        private void Engajar(int User)
        {
            Precisao[User] = Math.Min(Precisao[User] + 25, 125);

            TempoDecaimento[User] = 0;

            MessageBox.Show("Usou Engajar.", "Engajar", MessageBoxButtons.OK);
        }

        private void Proteger(int User)
        {
            TempoEscudo[User] = 10;

            MessageBox.Show("Usou Proteger.", "Proteger", MessageBoxButtons.OK);
        }

        private void Perfurar(int User)
        {
            if (!CalcularAcerto(User, 8)) return;

            CalcularDano(User, (TempoEscudo[1 - User] > 0 ? 50 : 28));

            TempoEscudo[1 - User] = 0;

            MessageBox.Show("Usou Perfurar.", "Perfurar", MessageBoxButtons.OK);
        }

        private void Infectar(int User)
        {
            TempoDecaimento[1 - User] = (Equipavel[1 - User] == 3) ? 0 : 10;

            MessageBox.Show("Usou Infectar.", "Infectar", MessageBoxButtons.OK);
        }

        private void Ultrajar(int User)
        {
            if (!CalcularAcerto(User, 9)) return;

            CalcularDano(User, 28);

            TempoDecaimento[1 - User] = (Equipavel[1 - User] == 3) ? 0 : 10;

            MessageBox.Show("Usou Ultrajar.", "Ultrajar", MessageBoxButtons.OK);
        }

        private void Roubar(int User)
        {
            if (!CalcularAcerto(User, 12)) return;

            Saude[User] = Math.Min(200, Saude[User] + CalcularDano(User, 28));

            MessageBox.Show("Usou Roubar.", "Roubar", MessageBoxButtons.OK);
        }

        private void Confundir(int User)
        {
            if (!CalcularAcerto(User, 16)) return;

            CalcularDano(User, 40);

            Precisao[1 - User] = Math.Max(35, Precisao[1 - User] - 25);

            MessageBox.Show("Usou Confundir.", "Confundir", MessageBoxButtons.OK);
        }

        private void Atordoar(int User)
        {
            if (!CalcularAcerto(User, 11)) return;

            CalcularDano(User, 40);

            TempoAtordoamento[1 - User] = Equipavel[1 - User] == 3 ? 0 : 1;

            MessageBox.Show("Usou Atordoar.", "Atordoar", MessageBoxButtons.OK);
        }

        private void Colidir(int User)
        {
            if (!CalcularAcerto(User, 7)) return;

            CalcularDano(User, 40);

            if (Saude[1 - User] > 0) Saude[User] = Math.Max(0, Saude[User] - 16);

            MessageBox.Show("Usou Colidir.", "Colidir", MessageBoxButtons.OK);
        }

        private void Dilacerar(int User)
        {
            if (!CalcularAcerto(User, 17)) return;

            CalcularDano(User, Saude[1 - User] / 2);

            MessageBox.Show("Usou Dilacerar.", "Dilacerar", MessageBoxButtons.OK);
        }

        private void Bloquear(int User)
        {
            if (User == 0) Poder[User] = Math.Min(Equipavel[User] == 4 ? 4 : 3, Poder[User] + 1);

            TempoAtordoamento[1 - User] = Equipavel[1 - User] == 3 ? 0 : 1;

            TempoEspera[User, 1] = 3;

            MessageBox.Show("Usou Bloquear.", "Bloquear", MessageBoxButtons.OK);
        }

        private void Sacrificar(int User)
        {
            Poder[User] = Math.Min(Equipavel[User] == 4 ? 4 : 3, Poder[User] + Equipavel[User] == 4 ? 4 : 3);

            Saude[0] = Math.Max(0, Saude[0] - 16);

            TempoEspera[User, 0] = 5;

            MessageBox.Show("Usou Sacrificar.", "Sacrificar", MessageBoxButtons.OK);
        }

        private void Prender(int User)
        {
            if (Equipavel[1 - User] != 3) TempoRecursivo[1 - User] = 4;

            TempoEspera[User, 2] = 7;

            MessageBox.Show("Usou Prender.", "Prender", MessageBoxButtons.OK);
        }

        private void Assaltar(int User)
        {
            if (!CalcularAcerto(User, 1)) return;

            CalcularDano(User, 8);

            Precisao[1 - User] = Math.Max(35, Precisao[1 - User] - 15);

            MessageBox.Show("Usou Assaltar.", "Assaltar", MessageBoxButtons.OK);
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            Usuario(0);

            Rodada();
        }

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            Usuario(1);

            Rodada();
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder[0] == (Equipavel[0] == 4 ? 4 : 3)) return;

            Usuario(2);

            Rodada();
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            if (TempoEspera[0, 0] > 0 || Poder[0] > 0) return;

            Usuario(3);

            Rodada();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (TempoEspera[0, 1] > 0) return;

            Usuario(4);

            Rodada();
        }

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            Usuario(5);

            Rodada();
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            Usuario(6);

            Rodada();
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            Usuario(7);

            Rodada();
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            Usuario(8);

            Rodada();
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            Usuario(9);

            Rodada();
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            Usuario(10);

            Rodada();
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            Usuario(11);

            Rodada();
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            Usuario(12);

            Rodada();
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            Usuario(13);

            Rodada();
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            Usuario(14);

            Rodada();
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            Usuario(15);

            Rodada();
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            Usuario(16);

            Rodada();
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            Usuario(17);

            Rodada();
        }

        private void btnReanimar_Click(object sender, EventArgs e)
        {
            Condicional(0, 0);

            Opositor();

            Rodada();
        }

        private void btnFugir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente desistir?", "Fugir?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            grpDebug.Visible = chkDebug.Checked;
        }

        private void numAtaqueOpositor_ValueChanged(object sender, EventArgs e)
        {
            AtaquesOpositor[0] = (int)numAtaqueOpositor.Value;
        }

        private void numAtaqueOpositorI_ValueChanged(object sender, EventArgs e)
        {
            AtaquesOpositor[1] = (int)numAtaqueOpositorI.Value;
        }

        private void numAtaqueOpositorII_ValueChanged(object sender, EventArgs e)
        {
            AtaquesOpositor[2] = (int)numAtaqueOpositorII.Value;
        }

        private void numAtaqueOpositorIII_ValueChanged(object sender, EventArgs e)
        {
            AtaquesOpositor[3] = (int)numAtaqueOpositorIII.Value;
        }

        private void numPrecisaoUsuario_ValueChanged(object sender, EventArgs e)
        {
            Precisao[0] = (int)numPrecisaoUsuario.Value;
        }

        private void numPrecisaoOpositor_ValueChanged(object sender, EventArgs e)
        {
            Precisao[1] = (int)numPrecisaoOpositor.Value;
        }

        private void numEquipavelOpositor_ValueChanged(object sender, EventArgs e)
        {
            Equipavel[1] = (int)numEquipavelOpositor.Value;
        }
    }
}