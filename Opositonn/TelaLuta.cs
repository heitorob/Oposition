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
        int[] Saude, CoeficientePrecisao, TempoAtordoamento, EsperaBloquear, AtordoamentoRecursivo, AtaquesOpositor;
        int CoeficienteDano, Poder, PoderOpositor, EsperaSacrificar;
        bool[] VerificadorEscudo, VerificadorDecaimento;

        Random rng = new Random();

        public TelaLuta()
        {
            InitializeComponent();

            Saude = new int[2];
            CoeficientePrecisao = new int[2];
            VerificadorEscudo = new bool[2];
            VerificadorDecaimento = new bool[2];
            TempoAtordoamento = new int[2];
            EsperaBloquear = new int[2];
            AtordoamentoRecursivo = new int[2];
            AtaquesOpositor = new int[4];
        }

        private void TelaLuta_Load(object sender, EventArgs e)
        {
            Saude[0] = 200;
            Saude[1] = 200;
            Poder = 0;
            PoderOpositor = 0;
            CoeficientePrecisao[0] = 80;
            CoeficientePrecisao[1] = 80;
            VerificadorEscudo[0] = false;
            VerificadorEscudo[1] = false;
            VerificadorDecaimento[0] = false;
            VerificadorDecaimento[1] = false;
            TempoAtordoamento[0] = 0;
            TempoAtordoamento[1] = 0;
            EsperaBloquear[0] = 0;
            EsperaBloquear[1] = 0;
            AtordoamentoRecursivo[0] = 0;
            AtordoamentoRecursivo[1] = 0;

            AtaquesOpositor[0] = rng.Next(0, 2);
            AtaquesOpositor[1] = rng.Next(2, 8);
            AtaquesOpositor[2] = rng.Next(8, 13);
            AtaquesOpositor[3] = rng.Next(13, 16);

            cmbAtaque.SelectedItem = "Investir";
            cmbEspecialL.SelectedItem = "Canalizar";
            cmbEspecialF.SelectedItem = "Engajar";
            cmbEspecialM.SelectedItem = "Medicar";
            cmbEspecialS.SelectedItem = "Flagelar";

            numAtaqueOpositor.Text = AtaquesOpositor[0].ToString();
            numAtaqueOpositorI.Text = AtaquesOpositor[1].ToString();
            numAtaqueOpositorII.Text = AtaquesOpositor[2].ToString();
            numAtaqueOpositorIII.Text = AtaquesOpositor[3].ToString();
        }

        private void Atualizar()
        {
            lblSaudeUsuario.Text = Saude[0].ToString();
            lblSaudeOpositor.Text = Saude[1].ToString();
            lblPoder.Text = Poder.ToString();

            imgEscudoUsuario.Visible = VerificadorEscudo[0];

            imgEscudoOpositor.Visible = VerificadorEscudo[1];

            imgDecaimentoUsuario.Visible = VerificadorDecaimento[0];

            imgDecaimentoOpositor.Visible = VerificadorDecaimento[1];

            imgAtordoamentoUsuario.Visible = TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0;

            imgAtordoamentoOpositor.Visible = TempoAtordoamento[1] > 0 || AtordoamentoRecursivo[1] > 0;

            lblSaudeUsuario.ForeColor = Saude[0] <= 60 ? Color.Red : Color.Black;

            lblSaudeOpositor.ForeColor = Saude[1] <= 60 ? Color.Red : Color.Black;

            lblPoder.ForeColor = Poder == 3 ? Color.DarkTurquoise : Color.Black;

            btnReanimar.Visible = TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0;

            lblPoderOpositor.Text = PoderOpositor.ToString();
            numPrecisaoUsuario.Text = CoeficientePrecisao[0].ToString();
            numPrecisaoOpositor.Text = CoeficientePrecisao[1].ToString();

            TestarFim();
        }

        private bool Condicional(int User)
        {
            if (AtordoamentoRecursivo[User] > 0)
            {
                if (rng.Next(0, 5) > AtordoamentoRecursivo[User]) 
                { 
                    AtordoamentoRecursivo[User] = 0;
                    MessageBox.Show("Atordoamento Recursivo acabou.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                }
                else
                {
                    AtordoamentoRecursivo[User]--;
                    MessageBox.Show("Está com Atordoamento Recursivo.", "Atordoamento Recursivo", MessageBoxButtons.OK);
                }
                return false;
            }

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                MessageBox.Show("Está com Atordoamento.", "Atordoamento", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void TestarFim()
        {
            if (Saude[1] == 0)
            {
                MessageBox.Show("Triunfo", "Triunfo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return;
            }
            if (Saude[0] == 0)
            {
                MessageBox.Show("Derrota", "Derrota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return;
            }
        }

        private void Rodada()
        {
            for (int User = 0; User <= 1; User++)
            {
                if (CoeficientePrecisao[User] < 80) CoeficientePrecisao[User] = Math.Min(80, CoeficientePrecisao[User] + 5);
                else if (CoeficientePrecisao[User] > 80) CoeficientePrecisao[User] = Math.Max(80, CoeficientePrecisao[User] - 5);
            }

            for (int User = 0; User <= 1; User++) if (VerificadorDecaimento[User]) Saude[User] = Math.Max(0, Saude[User] - 8);
        }

        private void Usuario(int Ataque)
        {
            if (!Condicional(0)) return;

            switch (Ataque)
            {
                default:
                    Investir(0); break;
                case 1:
                    Assaltar(0); break;
                case 2:
                    Canalizar(); break;
                case 3:
                    Sacrificar(); break;
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
        }

        private void Opositor()
        {
            if (!Condicional(1)) return;

            PoderOpositor = Math.Min(PoderOpositor + 1, 4);

            switch (AtaquesOpositor[rng.Next(0, PoderOpositor)])
            {
                default:
                    Investir(1);
                    break;
                case 1:
                    Assaltar(1);
                    PoderOpositor = 0;
                    break;
                case 2:
                    Bloquear(1);
                    PoderOpositor = 0;
                    break;
                case 3:
                    Engajar(1);
                    PoderOpositor = 0;
                    break;
                case 4:
                    Proteger(1);
                    PoderOpositor = 0;
                    break;
                case 5:
                    Perfurar(1);
                    PoderOpositor = 0;
                    break;
                case 6:
                    Ultrajar(1);
                    PoderOpositor = 0;
                    break;
                case 7:
                    Colidir(1);
                    PoderOpositor = 0;
                    break;
                case 8:
                    Medicar(1);
                    PoderOpositor = 0;
                    break;
                case 9:
                    Atordoar(1);
                    PoderOpositor = 0;
                    break;
                case 10:
                    Roubar(1);
                    PoderOpositor = 0;
                    break;
                case 11:
                    Infectar(1);
                    PoderOpositor = 0;
                    break;
                case 12:
                    Prender(1);
                    PoderOpositor = 0;
                    break;
                case 13:
                    Flagelar(1);
                    PoderOpositor = 0;
                    break;
                case 14:
                    Confundir(1);
                    PoderOpositor = 0;
                    break;
                case 15:
                    Dilacerar(1);
                    PoderOpositor = 0;
                    break;
            }
        }

        private void Investir(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (rng.Next(0, 100) > CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 16;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Usou Investir", "Investir", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Canalizar()
        {
            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            Poder = Math.Min(3, Poder + 1);

            MessageBox.Show("Usou Canalizar.", "Canalizar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Medicar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            Saude[User] = Math.Min(200, Saude[User] + 40);

            VerificadorDecaimento[User] = false;

            MessageBox.Show("Usou Medicar.", "Medicar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Flagelar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 100) > CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 60;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Usou Flagelar.", "Flagelar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Engajar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            CoeficientePrecisao[User] = Math.Min(CoeficientePrecisao[User] + 25, 125);

            VerificadorDecaimento[User] = false;

            MessageBox.Show("Usou Engajar.", "Engajar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Proteger(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            VerificadorEscudo[User] = true;

            MessageBox.Show("Usou Proteger.", "Proteger", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Perfurar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            if (rng.Next(0, 100) > CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 28;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = 40;

            VerificadorEscudo[1 - User] = false;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Usou Perfurar.", "Perfurar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Infectar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            VerificadorDecaimento[1 - User] = true;

            MessageBox.Show("Usou Infectar.", "Infectar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Ultrajar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            if (rng.Next(0, 100) > CoeficientePrecisao[User] - 20)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 28;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            VerificadorDecaimento[1 - User] = true;

            MessageBox.Show("Usou Ultrajar.", "Ultrajar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Roubar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            if (rng.Next(0, 100) > CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 28;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            Saude[User] = Math.Min(200, Saude[User] + CoeficienteDano);

            MessageBox.Show("Usou Roubar.", "Roubar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Confundir(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 100) > CoeficientePrecisao[User] + 20)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 40;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            CoeficientePrecisao[1 - User] = Math.Max(35, CoeficientePrecisao[1 - User] - 25);

            MessageBox.Show("Usou Confundir.", "Confundir", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Atordoar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            if (rng.Next(0, 100) > CoeficientePrecisao[User] - 20)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 40;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            TempoAtordoamento[1 - User] = 1;

            MessageBox.Show("Usou Atordoar.", "Atordoar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Colidir(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            if (rng.Next(0, 100) > CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 40;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            if (Saude[1 - User] > 0) Saude[User] = Math.Max(0, Saude[User] - 16);

            MessageBox.Show("Usou Colidir.", "Colidir", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Dilacerar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 100) > CoeficientePrecisao[User] - 20)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = Saude[1 - User] / 2;
            if (VerificadorEscudo[User]) CoeficienteDano /= 2;
            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Usou Dilacerar.", "Dilacerar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Bloquear(int User)
        {
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Min(3, Poder + 1);

            TempoAtordoamento[1 - User] = 1;

            EsperaBloquear[User] = 2;

            MessageBox.Show("Usou Bloquear.", "Bloquear", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Sacrificar()
        {
            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            Poder = Math.Min(3, Poder + 3);

            Saude[0] = Math.Max(0, Saude[0] - 16);

            EsperaSacrificar = 4;

            MessageBox.Show("Usou Sacrificar.", "Sacrificar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Prender(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            AtordoamentoRecursivo[1 - User] = 4;

            MessageBox.Show("Usou Prender.", "Prender", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Assaltar(int User)
        {
            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (rng.Next(0, 100) > CoeficientePrecisao[User] - 20)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 12;

            if (VerificadorEscudo[1 - User]) CoeficienteDano /= 2;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            CoeficientePrecisao[1 - User] = Math.Max(35, CoeficientePrecisao[1 - User] - 15);

            MessageBox.Show("Usou Assaltar.", "Assaltar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            Usuario(0);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            Usuario(1);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder == 3) return;

            Usuario(2);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            if (EsperaSacrificar > 0 || Poder > 0) return;

            Usuario(3);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EsperaBloquear[0] > 0) return;

            Usuario(4);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Usuario(5);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0]) return;

            Usuario(6);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Usuario(7);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Usuario(8);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Usuario(9);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Usuario(10);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Usuario(11);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Usuario(12);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Usuario(13);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Usuario(14);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;

            Usuario(15);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;

            Usuario(16);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;

            Usuario(17);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void btnReanimar_Click(object sender, EventArgs e)
        {
            Condicional(0);

            Opositor();

            Rodada();

            Atualizar();
        }

        private void cmbAtaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAtaque.SelectedItem)
            {
                case "Investir":
                    btnInvestir.Visible = true;
                    btnAssaltar.Visible = false;
                    break;
                case "Assaltar":
                    btnInvestir.Visible = false;
                    btnAssaltar.Visible = true;
                    break;
            }
        }

        private void cmbEspecialL_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEspecialL.SelectedItem)
            {
                case "Canalizar":
                    btnCanalizar.Visible = true;
                    btnSacrificar.Visible = false;
                    btnBloquear.Visible = false;
                    break;
                case "Sacrificar":
                    btnCanalizar.Visible = false;
                    btnSacrificar.Visible = true;
                    btnBloquear.Visible = false;
                    break;
                case "Bloquear":
                    btnCanalizar.Visible = false;
                    btnSacrificar.Visible = false;
                    btnBloquear.Visible = true;
                    break;
            }
        }

        private void cmbEspecialF_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEspecialF.SelectedItem)
            {
                case "Engajar":
                    btnEngajar.Visible = true;
                    btnProteger.Visible = false;
                    btnColidir.Visible = false;
                    btnPerfurar.Visible = false;
                    btnUltrajar.Visible = false;
                    break;
                case "Proteger":
                    btnEngajar.Visible = false;
                    btnProteger.Visible = true;
                    btnColidir.Visible = false;
                    btnPerfurar.Visible = false;
                    btnUltrajar.Visible = false;
                    break;
                case "Colidir":
                    btnEngajar.Visible = false;
                    btnProteger.Visible = false;
                    btnColidir.Visible = true;
                    btnPerfurar.Visible = false;
                    btnUltrajar.Visible = false;
                    break;
                case "Perfurar":
                    btnEngajar.Visible = false;
                    btnProteger.Visible = false;
                    btnColidir.Visible = false;
                    btnPerfurar.Visible = true;
                    btnUltrajar.Visible = false;
                    break;
                case "Ultrajar":
                    btnEngajar.Visible = false;
                    btnProteger.Visible = false;
                    btnColidir.Visible = false;
                    btnPerfurar.Visible = false;
                    btnUltrajar.Visible = true;
                    break;
            }
        }

        private void cmbEspecialM_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEspecialM.SelectedItem)
            {
                case "Medicar":
                    btnMedicar.Visible = true;
                    btnAtordoar.Visible = false;
                    btnRoubar.Visible = false;
                    btnInfectar.Visible = false;
                    btnPrender.Visible = false;
                    break;
                case "Atordoar":
                    btnMedicar.Visible = false;
                    btnAtordoar.Visible = true;
                    btnRoubar.Visible = false;
                    btnInfectar.Visible = false;
                    btnPrender.Visible = false;
                    break;
                case "Roubar":
                    btnMedicar.Visible = false;
                    btnAtordoar.Visible = false;
                    btnRoubar.Visible = true;
                    btnInfectar.Visible = false;
                    btnPrender.Visible = false;
                    break;
                case "Infectar":
                    btnMedicar.Visible = false;
                    btnAtordoar.Visible = false;
                    btnRoubar.Visible = false;
                    btnInfectar.Visible = true;
                    btnPrender.Visible = false;
                    break;
                case "Prender":
                    btnMedicar.Visible = false;
                    btnAtordoar.Visible = false;
                    btnRoubar.Visible = false;
                    btnInfectar.Visible = false;
                    btnPrender.Visible = true;
                    break;
            }
        }

        private void cmbEspecialS_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEspecialS.SelectedItem)
            {
                case "Flagelar":
                    btnFlagelar.Visible = true;
                    btnConfundir.Visible = false;
                    btnDilacerar.Visible = false;
                    break;
                case "Confundir":
                    btnFlagelar.Visible = false;
                    btnConfundir.Visible = true;
                    btnDilacerar.Visible = false;
                    break;
                case "Dilacerar":
                    btnFlagelar.Visible = false;
                    btnConfundir.Visible = false;
                    btnDilacerar.Visible = true;
                    break;
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
            CoeficientePrecisao[0] = (int)numPrecisaoUsuario.Value;
        }

        private void numPrecisaoOpositor_ValueChanged(object sender, EventArgs e)
        {
            CoeficientePrecisao[1] = (int)numPrecisaoOpositor.Value;
        }
    }
}