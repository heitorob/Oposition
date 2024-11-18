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

            if (TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) btnReanimar.Visible = true;
            else btnReanimar.Visible = false;

            ImprimirAuditar();
        }

        private void HoraOpositor()
        {
            switch (rng.Next(0, 14))
            {
                case 0:
                    Investir(1);
                    break;
                case 1:
                    Medicar(1);
                    break;
                case 2:
                    Flagelar(1);
                    break;
                case 3:
                    Engajar(1);
                    break;
                case 4:
                    Proteger(1);
                    break;
                case 5:
                    Perfurar(1);
                    break;
                case 6:
                    Infectar(1);
                    break;
                case 7:
                    Ultrajar(1);
                    break;
                case 8:
                    Roubar(1);
                    break;
                case 9:
                    Confundir(1);
                    break;
                case 10:
                    Atordoar(1);
                    break;
                case 11:
                    Colidir(1);
                    break;
                case 12:
                    Bloquear(1);
                    break;
                case 13:
                    Prender(1);
                    break;
            }
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

            if (AtordoamentoRecursivo[0] > 0)
            {
                if (rng.Next(0, 5) > AtordoamentoRecursivo[0]) AtordoamentoRecursivo[0] = 0;
                else AtordoamentoRecursivo[0]--;
                return;
            }

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

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.\nReduziu a precosão em 20.", "Confundir", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Atordoar(int User)
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

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.\nAplicou Atordoamento.", "Atordoar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Colidir(int User)
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

            if (Saude[1 - User] > 0) Saude[User] = Math.Max(0, Saude[User] - 16);

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.\nSacrificou 16 de saúde.", "Sacrificar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Dilacerar(int User)
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

            if (User == 0) Poder = Math.Max(0, Poder - 3);

            if (rng.Next(0, 20) < CoeficientePrecisao[User] + 4)
            {
                MessageBox.Show("Foi por um triz, mas o ataque falhou!", "Errou", MessageBoxButtons.OK);
                Atualizar();
                return;
            }

            CoeficienteDano = Saude[1 - User] / 2;
            if (VerificadorEscudo[User]) CoeficienteDano /= 2;
            Saude[1 - User] = Math.Max(0, Saude[1 - User] - CoeficienteDano);

            MessageBox.Show("Tirou " + CoeficienteDano + " de saúde.", "Dilacerar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Bloquear(int User)
        {
            Analisar();

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

            if (User == 0) Poder = Math.Min(3, Poder + 1);

            TempoAtordoamento[1 - User] = 1;

            EsperaBloquear[User] = 2;

            MessageBox.Show("Gerou 1 poder. Aplicou Atordoamento.", "Bloquear", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Sacrificar()
        {
            Analisar();

            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            if (AtordoamentoRecursivo[0] > 0)
            {
                if (rng.Next(0, 5) > AtordoamentoRecursivo[0]) AtordoamentoRecursivo[0] = 0;
                else AtordoamentoRecursivo[0]--;
                return;
            }

            if (TempoAtordoamento[0] > 0)
            {
                TempoAtordoamento[0]--;
                return;
            }

            Poder = Math.Min(3, Poder + 3);

            Saude[0] = Math.Max(0, Saude[0] - 16);

            EsperaSacrificar = 4;

            MessageBox.Show("Gerou 3 poderes. Sacrificou 16 de saúde.", "Sacrificar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Prender(int User)
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

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            AtordoamentoRecursivo[1 - User] = 4;

            MessageBox.Show("Aplicou Atordoamento Recursivo.", "Prender", MessageBoxButtons.OK);

            Atualizar();
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            if (TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Investir(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);

            Atualizar();
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder == 3 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Canalizar();

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Medicar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            if (Poder < 3 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Flagelar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Engajar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0] || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Proteger(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0] || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Perfurar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || VerificadorDecaimento[1] || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Infectar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Ultrajar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Roubar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            if (Poder < 3 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Confundir(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Atordoar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Colidir(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            if (Poder < 3 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Dilacerar(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EsperaBloquear[0] > 0 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Bloquear(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            if (EsperaSacrificar > 0 || Poder > 0 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Sacrificar();

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Prender(0);

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnReanimar_Click(object sender, EventArgs e)
        {
            if (TempoAtordoamento[0] > 0)
            { 
                TempoAtordoamento[0]--;
                MessageBox.Show("Reanimou do Atordoamento.", "Atordoamento", MessageBoxButtons.OK);
            }

            if (rng.Next(0, 5) > AtordoamentoRecursivo[0])
            {
                AtordoamentoRecursivo[0] = 0;
                MessageBox.Show("Se livrou das amarras.", "Atordoamento Recursivo", MessageBoxButtons.OK);
            }
            else
            {
                AtordoamentoRecursivo[0]--;
                MessageBox.Show("Tentou se livrar das amarras, mas falhou.", "Atordoamento Recursivo", MessageBoxButtons.OK);
            }

            HoraOpositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }
    }
}