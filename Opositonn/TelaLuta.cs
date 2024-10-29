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
        double[] Saude, CoeficientePrecisao, TempoAtordoamento, EsperaBloquear;
        double CoeficienteDano, Poder;
        bool[] VerificadorEscudo, VerificadorDecaimento;

        Random rng = new Random();

        public TelaLuta()
        {
            InitializeComponent();

            Saude = new double[2];
            CoeficientePrecisao = new double[2];
            VerificadorEscudo = new bool[2];
            VerificadorDecaimento = new bool[2];
            TempoAtordoamento = new double[2];
            EsperaBloquear = new double[2];
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
        }

        private void Analisar()
        {
            Saude[0] = Convert.ToDouble(lblSaudeUsuario.Text);
            Saude[1] = Convert.ToDouble(lblSaudeOpositor.Text);
            Poder = Convert.ToDouble(lblPoder.Text);
        }

        private void Atualizar()
        {
            lblSaudeUsuario.Text = Saude[0].ToString("0");
            lblSaudeOpositor.Text = Saude[1].ToString("0");
            lblPoder.Text = Poder.ToString();

            if (VerificadorEscudo[0]) imgEscudoUsuario.Visible = true;
            else imgEscudoUsuario.Visible = false;

            if (VerificadorEscudo[1]) imgEscudoOpositor.Visible = true;
            else imgEscudoOpositor.Visible = false;

            if (VerificadorDecaimento[0]) imgDecaimentoUsuario.Visible = true;
            else imgDecaimentoUsuario.Visible = false;

            if (VerificadorDecaimento[1]) imgDecaimentoOpositor.Visible = true;
            else imgDecaimentoOpositor.Visible = false;

            if (TempoAtordoamento[0] > 0) imgAtordoamentoUsuario.Visible = true;
            else imgAtordoamentoUsuario.Visible = false;

            if (TempoAtordoamento[1] > 0) imgAtordoamentoOpositor.Visible = true;
            else imgAtordoamentoOpositor.Visible = false;
        }

        private void Investir(int User)
        {
            Analisar();

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

            Atualizar();
        }

        private void Canalizar()
        {
            Analisar();

            if (TempoAtordoamento[0] > 0)
            {
                TempoAtordoamento[0]--;
                return;
            }

            Poder = Math.Min(3, Poder + 1);

            Atualizar();
        }

        private void Medicar(int User)
        {
            Analisar();

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            Saude[User] = Math.Min(200, Saude[User] + 40);

            VerificadorDecaimento[User] = false;

            Atualizar();
        }

        private void Flagelar(int User)
        {
            Analisar();

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

            Atualizar();
        }

        private void Engajar(int User)
        {
            Analisar();

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            CoeficientePrecisao[User] = Math.Max(0, CoeficientePrecisao[User] - 4);

            VerificadorDecaimento[User] = false;

            Atualizar();
        }

        private void Proteger(int User)
        {
            Analisar();

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            VerificadorEscudo[User] = true;

            Atualizar();
        }

        private void Perfurar(int User)
        {
            Analisar();

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

            if (VerificadorEscudo[1 - User])
            {
                CoeficienteDano += 12;
                VerificadorEscudo[1 - User] = false;
            }

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            Atualizar();
        }

        private void Infectar(int User)
        {
            Analisar();

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            VerificadorDecaimento[1 - User] = true;

            Atualizar();
        }

        private void Ultrajar(int User)
        {
            Analisar();

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

            Atualizar();
        }

        private void Roubar(int User)
        {
            Analisar();

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

            Atualizar();
        }

        private void Assaltar(int User)
        {
            Analisar();

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

            CoeficienteDano = 12;

            if (VerificadorEscudo[1 - User]) CoeficienteDano = Math.Max(0, CoeficienteDano - 8);

            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            Atualizar();
        }

        private void Confundir(int User)
        {
            Analisar();

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

            if (TempoAtordoamento[User] > 0)
            {
                TempoAtordoamento[User]--;
                return;
            }

            if (User == 0) Poder = Math.Min(3, Poder + 1);

            TempoAtordoamento[1 - User] = 1;

            EsperaBloquear[User] = 3;

            Atualizar();
        }

        private async void btnInvestir_Click(object sender, EventArgs e)
        {
            if (rng.Next(0, 2) == 0)
            {
                Investir(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Investir(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder == 3) return;
            if (rng.Next(0, 2) == 0)
            {
                Canalizar();

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Canalizar();
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnMedicar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;
            if (rng.Next(0, 2) == 0)
            {
                Medicar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);
                Medicar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnFlagelar_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;
            if (rng.Next(0, 2) == 0)
            {
                Flagelar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);
                Flagelar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnEngajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || CoeficientePrecisao[0] == 0) return;
            if (rng.Next(0, 2) == 0)
            {
                Engajar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);
                Engajar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnProteger_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0]) return;
            if (rng.Next(0, 2) == 0)
            {
                Proteger(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Proteger(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnPerfurar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0]) return;
            if (rng.Next(0, 2) == 0)
            {
                Perfurar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Perfurar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnInfectar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || VerificadorDecaimento[1]) return;
            if (rng.Next(0, 2) == 0)
            {
                Infectar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Infectar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnUltrajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;
            if (rng.Next(0, 2) == 0)
            {
                Ultrajar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Ultrajar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnRoubar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;
            if (rng.Next(0, 2) == 0)
            {
                Roubar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Roubar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnAssaltar_Click(object sender, EventArgs e)
        {
            Assaltar(0);

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
            if (rng.Next(0, 2) == 0)
            {
                Confundir(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Confundir(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnAtordoar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;
            if (rng.Next(0, 2) == 0)
            {

                Atordoar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Atordoar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnColidir_Click(object sender, EventArgs e)
        {
            if (Poder < 1) return;
            if (rng.Next(0, 2) == 0)
            {

                Colidir(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Colidir(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnDilacerar_Click(object sender, EventArgs e)
        {
            if (Poder < 3) return;
            if (rng.Next(0, 2) == 0)
            {

                Dilacerar(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Dilacerar(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private async void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EsperaBloquear[0] > 0) return;

            if (rng.Next(0, 2) == 0)
            {
                Bloquear(0);

                await Task.Delay(500);

                Investir(1);
            }
            else
            {
                Investir(1);

                await Task.Delay(500);

                Bloquear(0);
            }
            await Task.Delay(500);
            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }
    }
}
