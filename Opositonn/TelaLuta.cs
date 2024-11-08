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
        int[] Saude, CoeficientePrecisao, TempoAtordoamento, EsperaBloquear, AtordoamentoRecursivo;
        int CoeficienteDano, Poder, EsperaSacrificar;
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
        }

        private void TelaLuta_Load(object sender, EventArgs e)
        {
            Saude[0] = 200;
            Saude[1] = 200;
            CoeficientePrecisao[0] = 4;
            CoeficientePrecisao[1] = 4;
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
        }

        private void Analisar()
        {
            Saude[0] = Convert.ToInt16(lblSaudeUsuario.Text);
            Saude[1] = Convert.ToInt16(lblSaudeOpositor.Text);
            Poder = Convert.ToInt16(lblPoder.Text);
        }

        private void Atualizar()
        {
            lblSaudeUsuario.Text = Saude[0].ToString();
            lblSaudeOpositor.Text = Saude[1].ToString();
            lblPoder.Text = Poder.ToString();

            if (VerificadorEscudo[0]) imgEscudoUsuario.Visible = true;
            else imgEscudoUsuario.Visible = false;

            if (VerificadorEscudo[1]) imgEscudoOpositor.Visible = true;
            else imgEscudoOpositor.Visible = false;

            if (VerificadorDecaimento[0]) imgDecaimentoUsuario.Visible = true;
            else imgDecaimentoUsuario.Visible = false;

            if (VerificadorDecaimento[1]) imgDecaimentoOpositor.Visible = true;
            else imgDecaimentoOpositor.Visible = false;

            if (TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) imgAtordoamentoUsuario.Visible = true;
            else imgAtordoamentoUsuario.Visible = false;

            if (TempoAtordoamento[1] > 0 || AtordoamentoRecursivo[1] > 0) imgAtordoamentoOpositor.Visible = true;
            else imgAtordoamentoOpositor.Visible = false;

            if (Saude[0] <= 60) lblSaudeUsuario.ForeColor = Color.Red;
            else lblSaudeUsuario.ForeColor = Color.Black;

            if (Saude[1] <= 60) lblSaudeOpositor.ForeColor = Color.Red;
            else lblSaudeOpositor.ForeColor = Color.Black;

            if (Poder == 3) lblPoder.ForeColor = Color.DarkTurquoise;
            else lblPoder.ForeColor = Color.Black;

            ImprimirAuditar();
        }

        private void ImprimirAuditar()
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

        private void Investir(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (AtordoamentoRecursivo[User] > 0)
            {
                if (rng.Next(0, 5) > AtordoamentoRecursivo[User]) AtordoamentoRecursivo[User] = 0;
                else AtordoamentoRecursivo[User]--;
                return;
            }

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (rng.Next(0, 20) < CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 16;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 10);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.", "Investir", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Canalizar()
        {
            Analisar();

            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            if (TempoAtordoamento[0] > 0)
            {
                TempoAtordoamento[0]--;
                return;
            }

            Poder = Math.Min(3, Poder + 1);

            MessageBox.Show("Invocou 1 poder.", "Canalizar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Medicar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            Saude[User] = Math.Min(200, Saude[User] + 40);

            string r = "Recuperou 40 de saúde.";
            if (VerificadorDecaimento[User]) r += "\nRemoveu efeito de Decaimento."; 

            VerificadorDecaimento[User] = false;

            MessageBox.Show(r, "Medicar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Flagelar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 10) < CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 60;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 40);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.", "Flagelar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Engajar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            CoeficientePrecisao[User] = Math.Max(0, CoeficientePrecisao[User] - 4);

            string r = "Aumentou a precisão em 20.";
            if (VerificadorDecaimento[User]) r += "\nRemoveu efeito de Decaimento.";

            VerificadorDecaimento[User] = false;

            MessageBox.Show(r, "Engajar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Proteger(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            VerificadorEscudo[User] = true;

            MessageBox.Show("Invocou um Escudo.", "Proteger", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Perfurar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            if (rng.Next(0, 20) < CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 28;

            if (VerificadorEscudo[1 - User]) CoeficienteDano += 12;

            string r = "Tirou " + CoeficienteDano + " de saúde.";
            if (VerificadorEscudo[1 - User]) r += "\nDestruiu o Escudo da oposição.";

            VerificadorEscudo[1 - User] = false;

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show(r, "Perfurar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Infectar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            VerificadorDecaimento[1 - User] = true;

            MessageBox.Show("Aplicou Decaimento.", "Infectar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Ultrajar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            if (rng.Next(0, 20) < CoeficientePrecisao[User] + 4)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 28;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 16);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            VerificadorDecaimento[1 - User] = true;

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.\nAplicou Decaimento.", "Ultrajar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Roubar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            if (rng.Next(0, 20) < CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 28;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 16);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            Saude[User] = Math.Min(200, Saude[User] + CoeficienteDano);

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.\nRecuperou " + CoeficienteDano + " de saúde.", "Roubar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Confundir(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 20) < CoeficientePrecisao[User] - 4)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 40;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 24);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            CoeficientePrecisao[1 - User] = Math.Min(8, CoeficientePrecisao[1 - User] + 2);

            Atualizar();
        }

        private void Atordoar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            if (rng.Next(0, 20) < CoeficientePrecisao[User] + 4)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 40;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 24);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            TempoAtordoamento[1 - User] = 1;

            Atualizar();
        }

        private async void Colidir(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            if (rng.Next(0, 20) < CoeficientePrecisao[User])
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = 40;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 24);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            Atualizar();

            await Task.Delay(500);

            if (Saude[1 - User] > 0) Saude[User] = Math.Max(0, Saude[User] - 16);

            Atualizar();
        }

        private void Dilacerar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 20) < CoeficientePrecisao[User] + 4)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            if (VerificadorEscudo[1 - User]) Saude[1 - User] = Math.Max(0, Saude[1 - User] * 3 / 4);
            else Saude[1 - User] = Math.Max(0, Saude[1 - User] * 1 / 2);

            Atualizar();
        }

        private void Bloquear(int User)
        {
            Analisar();

            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Min(3, Poder + 1);

            TempoAtordoamento[1 - User] = 1;

            EsperaBloquear[User] = 2;

            Atualizar();
        }

        private void Sacrificar()
        {
            Analisar();

            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            if (TempoAtordoamento[0] > 0)
            {
                TempoAtordoamento[0]--;
                return;
            }

            Poder = Math.Min(3, Poder + 3);

            Saude[0] = Math.Max(0, Saude[0] - 16);

            EsperaSacrificar = 4;

            Atualizar();
        }

        private void Prender(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            AtordoamentoRecursivo[1 - User] = 4;

            Atualizar();
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            Investir(0);

            Investir(1);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);

            Atualizar();
        }

        private async void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder == 3) return;

            Canalizar();

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnMedicar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Medicar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnFlagelar_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;

            Flagelar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnEngajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Engajar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnProteger_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0]) return;

            Proteger(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnPerfurar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0]) return;

            Perfurar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnInfectar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || VerificadorDecaimento[1]) return;

            Infectar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnUltrajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Ultrajar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnRoubar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Roubar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnConfundir_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;

            Confundir(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnAtordoar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Atordoar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnColidir_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;

            Colidir(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnDilacerar_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;

            Dilacerar(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EsperaBloquear[0] > 0) return;

            Bloquear(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnSacrificar_Click(object sender, EventArgs e)
        {
            if (EsperaSacrificar > 0 || Poder > 0) return;

            Sacrificar();

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnPrender_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Prender(0);

            await Task.Delay(500);

            Investir(1);

            await Task.Delay(500);

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }
    }
}
