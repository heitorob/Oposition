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
        int[] Saude, Poder, Precisao, TempoAtordoamento, TempoEscudo, TempoDecaimento, TempoRecursivo;
        int[,] TempoEspera;

        public static int[,] Build { get; set; }

        public Random rng = new Random();

        public static Dictionary<int, (string Nome, int Custo, int Precisao, Button[] Botoes)> Bglhs;

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

            Bglhs = new Dictionary<int, (string, int, int, Button[])>
            {                
                { 1,  ("Investir",   0, 80,  new Button[] { btnInvestir,   null } ) },
                { 2,  ("Assaltar",   0, 80,  new Button[] { btnAssaltar,   null } ) },
                { 3,  ("---Enganar---",   0, 80,  new Button[] { provisorio,   null } ) },
                { 4,  ("Canalizar",  0, 0,   new Button[] { btnCanalizar,  null } ) },
                { 5,  ("Sacrificar", 0, 0,   new Button[] { btnSacrificar, null } ) },
                { 6,  ("Bloquear",   0, 0,   new Button[] { btnBloquear,   null } ) },
                { 7,  ("Engajar",    1, 0,   new Button[] { btnEngajar,    null } ) },
                { 8,  ("Proteger",   1, 0,   new Button[] { btnProteger,   null } ) },
                { 9,  ("Colidir",    1, 80,  new Button[] { btnColidir,    null } ) },
                { 10, ("Perfurar",   1, 80,  new Button[] { btnPerfurar,   null } ) },
                { 11, ("Ultrajar",   1, 60,  new Button[] { btnUltrajar,   null } ) },
                { 12, ("Medicar",    2, 0,   new Button[] { btnMedicar,    null } ) },
                { 13, ("Atordoar",   2, 60,  new Button[] { btnAtordoar,   null } ) },
                { 14, ("Roubar",     2, 80,  new Button[] { btnRoubar,     null } ) },
                { 15, ("Infectar",   2, 0,   new Button[] { btnInfectar,   null } ) },
                { 16, ("Prender",    2, 0,   new Button[] { btnPrender,    null } ) },
                { 17, ("Flagelar",   3, 80,  new Button[] { btnFlagelar,   null } ) },
                { 18, ("Confundir",  3, 100, new Button[] { btnConfundir,  null } ) },
                { 19, ("---Refletir---",  3, 100, new Button[] { provisorio,  null } ) },
                { 20, ("Dilacerar",  3, 60,  new Button[] { btnDilacerar,  null } ) }
            };
        }

        private void TelaLuta_Load(object sender, EventArgs e)
        {
            Build[1, 0] = 1;
            Build[1, 1] = rng.Next(6, 12);
            Build[1, 2] = rng.Next(12, 17);
            Build[1, 3] = rng.Next(17, 21);
            Build[1, 4] = rng.Next(22, 26);

            for (int User = 0; User <= 1; User++)
            {
                Saude[User] = 200;
                Poder[User] = 0;
                Precisao[User] = (Build[User, 5 - User] == 23) ? 100 : 80;
                TempoEscudo[User] = 0;
                TempoDecaimento[User] = 0;
                TempoAtordoamento[User] = 0;
                TempoRecursivo[User] = 0;
                for (int i = 0; i < 5; i++)
                    TempoEspera[User, i] = 0;
            }

            for (int Botao = 1; Botao <= 20; Botao++)
                Bglhs[Botao].Botoes[0].Visible = false;

            foreach (int i in TelaInicial.d)
                if (i > 0 && i < 21) Bglhs[i].Botoes[0].Visible = true;

            for (int Botao = 1; Botao <= 20; Botao++)
                for (int Alt = 0; Alt <= 1; Alt++)
                    if (Bglhs[Botao].Botoes[Alt] != null)
                        Bglhs[Botao].Botoes[Alt].Enabled = Poder[0] >= Bglhs[Botao].Custo;

            Atualizar();
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

            lblPoder.ForeColor = Poder[0] == ((Build[0, 5] == 26) ? 4 : 3) ? Color.DarkTurquoise : Color.Black;

            btnReanimar.Visible = TempoAtordoamento[0] > 0 || TempoRecursivo[0] > 0;

            for (int Botao = 1; Botao <= 20; Botao++)
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
            else if (Ataque > 5) Poder[User] = 0;

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
                if (Precisao[User] < (Build[User, 5] == 23 ? 100 : 80)) Precisao[User] = Math.Min(Build[User, 5] == 23 ? 100 : 80, Precisao[User] + 5);
                else if (Precisao[User] > (Build[User, 5] == 23 ? 100 : 80)) Precisao[User] = Math.Max(Build[User, 5] == 23 ? 100 : 80, Precisao[User] - 5);
            
                for (int Ataque = 0; Ataque <= 4; Ataque++)
                    TempoEspera[User, Ataque] = Math.Max(0, TempoEspera[User, Ataque] - 1);
                
                TempoEscudo[User] = Math.Max(0, TempoEscudo[User] - 1);

                if (TempoDecaimento[User] > 0)
                {
                    Saude[User] = Math.Max(0, Saude[User] - 8);
                    TempoDecaimento[User]--;
                }

                if (Build[User, 5 - User] == 25)
                    Saude[User] = Math.Min(200, Saude[User] + 8);

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
                case 2:
                    Assaltar(0); break;
                case 3:
                    break;
                case 4:
                    Canalizar(0); break;
                case 5:
                    Sacrificar(0); break;
                case 6:
                    Bloquear(0); break;
                case 7:
                    Engajar(0); break;
                case 8:
                    Proteger(0); break;
                case 9:
                    Colidir(0); break;
                case 10:
                    Perfurar(0); break;
                case 11:
                    Ultrajar(0); break;
                case 12:
                    Medicar(0); break;
                case 13:
                    Atordoar(0); break;
                case 14:
                    Roubar(0); break;
                case 15:
                    Infectar(0); break;
                case 16:
                    Prender(0); break;
                case 17:
                    Flagelar(0); break;
                case 18:
                    Confundir(0); break;
                case 19:
                    break;
                case 20:
                    Dilacerar(0); break;
            }

            if (Atualizar()) return;

            Opositor();
        }

        private void Opositor()
        {
            if (Saude[1] < 180) Poder[1] = Math.Min(Poder[1] + 1, 4);

            int _escolha = rng.Next(0, Poder[1]);
            int Escolha = Build[1, _escolha];

            if (!Condicional(1, Escolha)) return;

            switch (Escolha)
            {
                default:
                    Investir(1); break;
                case 6 when TempoAtordoamento[0] == 0 && TempoRecursivo[0] == 0 && TempoEspera[1, 1] == 0:
                    Bloquear(1);
                    break;
                case 7:
                    Engajar(1); break;
                case 8:
                    Proteger(1); break;
                case 9:
                    Colidir(1); break;
                case 10:
                    Perfurar(1); break;
                case 11:
                    Ultrajar(1); break;
                case 12:
                    Medicar(1); break;
                case 13:
                    Atordoar(1); break;
                case 14:
                    Roubar(1); break;
                case 15:
                    Infectar(1); break;
                case 16 when TempoAtordoamento[0] == 0 && TempoRecursivo[0] == 0 && TempoEspera[1, 2] == 0:
                    Prender(1); break;
                case 17:
                    Flagelar(1); break;
                case 18:
                    Confundir(1); break;
                case 19:
                    break;
                case 20:
                    Dilacerar(1); break;
            }

            Atualizar();
        }

        private int CalcularDano(int User, double Dano)
        {
            if (TempoEscudo[1 - User] > 0) Dano *= 0.5;
            if (Build[User, 5 - User] == 22) Dano *= 1.25;

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
            if (!CalcularAcerto(User, 1)) return;

            CalcularDano(User, 16);

            MessageBox.Show("Usou Investir", "Investir", MessageBoxButtons.OK);
        }

        private void Canalizar(int User)
        {
            Poder[User] = Math.Min((Build[User, 5] == 26) ? 4 : 3, Poder[User] + 1);

            MessageBox.Show("Usou Canalizar.", "Canalizar", MessageBoxButtons.OK);
        }

        private void Medicar(int User)
        {

            Saude[User] = Math.Min(200, Saude[User] + 40);

            TempoDecaimento[User] = 0;

            MessageBox.Show("Usou Medicar.", "Medicar", MessageBoxButtons.OK);
        }

        private void Flagelar(int User)
        {
            if (!CalcularAcerto(User, 17)) return;

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
            TempoEscudo[User] += 4;

            MessageBox.Show("Usou Proteger.", "Proteger", MessageBoxButtons.OK);
        }

        private void Perfurar(int User)
        {
            if (!CalcularAcerto(User, 10)) return;

            CalcularDano(User, (TempoEscudo[1 - User] > 0 ? 80 : 28));

            TempoEscudo[1 - User] = 0;

            MessageBox.Show("Usou Perfurar.", "Perfurar", MessageBoxButtons.OK);
        }

        private void Infectar(int User)
        {
            TempoDecaimento[1 - User] += (Build[1 - User, 5] == 24) ? 0 : 4;

            MessageBox.Show("Usou Infectar.", "Infectar", MessageBoxButtons.OK);
        }

        private void Ultrajar(int User)
        {
            if (!CalcularAcerto(User, 11)) return;

            CalcularDano(User, 28);

            TempoDecaimento[1 - User] += (Build[1 - User, 5] == 24) ? 0 : 4;

            MessageBox.Show("Usou Ultrajar.", "Ultrajar", MessageBoxButtons.OK);
        }

        private void Roubar(int User)
        {
            if (!CalcularAcerto(User, 14)) return;

            Saude[User] = Math.Min(200, Saude[User] + CalcularDano(User, 28));

            MessageBox.Show("Usou Roubar.", "Roubar", MessageBoxButtons.OK);
        }

        private void Confundir(int User)
        {
            if (!CalcularAcerto(User, 18)) return;

            CalcularDano(User, 40);

            Precisao[1 - User] = Math.Max(35, Precisao[1 - User] - 25);

            MessageBox.Show("Usou Confundir.", "Confundir", MessageBoxButtons.OK);
        }

        private void Atordoar(int User)
        {
            if (!CalcularAcerto(User, 13)) return;

            CalcularDano(User, 40);

            TempoAtordoamento[1 - User] = Build[1 - User, 5] == 24 ? 0 : 1;

            MessageBox.Show("Usou Atordoar.", "Atordoar", MessageBoxButtons.OK);
        }

        private void Colidir(int User)
        {
            if (!CalcularAcerto(User, 9)) return;

            CalcularDano(User, 40);

            if (Saude[1 - User] > 0) Saude[User] = Math.Max(0, Saude[User] - 16);

            MessageBox.Show("Usou Colidir.", "Colidir", MessageBoxButtons.OK);
        }

        private void Dilacerar(int User)
        {
            if (!CalcularAcerto(User, 20)) return;

            CalcularDano(User, Saude[1 - User] / 2);

            MessageBox.Show("Usou Dilacerar.", "Dilacerar", MessageBoxButtons.OK);
        }

        private void Bloquear(int User)
        {
            if (User == 0) Poder[User] = Math.Min((Build[User, 5] == 26) ? 4 : 3, Poder[User] + 1);

            TempoAtordoamento[1 - User] = Build[1 - User, 5] == 24 ? 0 : 1;

            TempoEspera[User, 1] = 3;

            MessageBox.Show("Usou Bloquear.", "Bloquear", MessageBoxButtons.OK);
        }

        private void Sacrificar(int User)
        {
            Poder[User] = Math.Min((Build[User, 5] == 26) ? 4 : 3, Poder[User] + Build[User, 5] == 26 ? 4 : 3);

            Saude[0] = Math.Max(0, Saude[0] - 16);

            TempoEspera[User, 0] = 5;

            MessageBox.Show("Usou Sacrificar.", "Sacrificar", MessageBoxButtons.OK);
        }

        private void Prender(int User)
        {
            if (Build[1 - User, 5] != 24) TempoRecursivo[1 - User] = 4;

            TempoEspera[User, 2] = 7;

            MessageBox.Show("Usou Prender.", "Prender", MessageBoxButtons.OK);
        }

        private void Assaltar(int User)
        {
            if (!CalcularAcerto(User, 2)) return;

            CalcularDano(User, 12);

            Precisao[1 - User] = Math.Max(35, Precisao[1 - User] - 15);

            MessageBox.Show("Usou Assaltar.", "Assaltar", MessageBoxButtons.OK);
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            Usuario(1);

            Rodada();
        }

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            Usuario(2);

            Rodada();
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder[0] == (Build[0, 5] == 26 ? 4 : 3)) return;

            Usuario(4);

            Rodada();
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            if (TempoEspera[0, 0] > 0 || Poder[0] > 0) return;

            Usuario(5);

            Rodada();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (TempoEspera[0, 1] > 0) return;

            Usuario(6);

            Rodada();
        }

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            Usuario(7);

            Rodada();
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            Usuario(8);

            Rodada();
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            Usuario(9);

            Rodada();
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            Usuario(10);

            Rodada();
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            Usuario(11);

            Rodada();
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            Usuario(12);

            Rodada();
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            Usuario(13);

            Rodada();
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            Usuario(14);

            Rodada();
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            Usuario(15);

            Rodada();
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            Usuario(16);

            Rodada();
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            Usuario(17);

            Rodada();
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            Usuario(18);

            Rodada();
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            Usuario(20);

            Rodada();
        }

        private void btnReanimar_Click(object sender, EventArgs e)
        {
            if (TempoRecursivo[0] > 0)
            {
                if (rng.Next(0, 5) > TempoRecursivo[0] || TempoRecursivo[0] == 1)
                {
                    TempoRecursivo[0] = 0;
                    MessageBox.Show("Está atordoado.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                    MessageBox.Show("Atordoamento Recursivo acabou.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                }
                else
                {
                    TempoRecursivo[0]--;
                    MessageBox.Show("Está atordoado.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                }
            }

            if (TempoAtordoamento[0] > 0)
            {
                TempoAtordoamento[0]--;
                MessageBox.Show("Está atordoado.", "Atordoamento", MessageBoxButtons.OK);
            }

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
    }
}