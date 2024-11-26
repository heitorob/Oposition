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

            AtaquesOpositor[0] = 0;
            AtaquesOpositor[1] = rng.Next(1, 7);
            AtaquesOpositor[2] = rng.Next(7, 12);
            AtaquesOpositor[3] = rng.Next(12, 15);

            numAtaqueOpositorI.Text = AtaquesOpositor[1].ToString();
            numAtaqueOpositorII.Text = AtaquesOpositor[2].ToString();
            numAtaqueOpositorIII.Text = AtaquesOpositor[3].ToString();
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

            ImprimirAuditar();
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

        private void ImprimirAuditar()
        {
            if (Saude[1] == 0)
            {
                MessageBox.Show("Triunfo", "Triunfo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else if (Saude[0] == 0)
            {
                MessageBox.Show("Derrota", "Derrota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
        }

        private void Usuario(int Ataque)
        {
            if (!Condicional(0)) return;

            switch (Ataque)
            {
                default:
                    Investir(0);
                    break;
                case 1:
                    Canalizar();
                    break;
                case 2:
                    Sacrificar();
                    break;
                case 3:
                    Bloquear(0);
                    break;
                case 4:
                    Engajar(0);
                    break;
                case 5:
                    Proteger(0);
                    break;
                case 6:
                    Perfurar(0);
                    break;
                case 7:
                    Ultrajar(0);
                    break;
                case 8:
                    Colidir(0);
                    break;
                case 9:
                    Medicar(0);
                    break;
                case 10:
                    Atordoar(0);
                    break;
                case 11:
                    Roubar(0);
                    break;
                case 12:
                    Infectar(0);
                    break;
                case 13:
                    Prender(0);
                    break;
                case 14:
                    Flagelar(0);
                    break;
                case 15:
                    Confundir(0);
                    break;
                case 17:
                    Dilacerar(0);
                    break;
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
                    Bloquear(1);
                    PoderOpositor = 0;
                    break;
                case 2:
                    Engajar(1);
                    PoderOpositor = 0;
                    break;
                case 3:
                    Proteger(1);
                    PoderOpositor = 0;
                    break;
                case 4:
                    Perfurar(1);
                    PoderOpositor = 0;
                    break;
                case 5:
                    Ultrajar(1);
                    PoderOpositor = 0;
                    break;
                case 6:
                    Colidir(1);
                    PoderOpositor = 0;
                    break;
                case 7:
                    Medicar(1);
                    PoderOpositor = 0;
                    break;
                case 8:
                    Atordoar(1);
                    PoderOpositor = 0;
                    break;
                case 9:
                    Roubar(1);
                    PoderOpositor = 0;
                    break;
                case 10:
                    Infectar(1);
                    PoderOpositor = 0;
                    break;
                case 11:
                    Prender(1);
                    PoderOpositor = 0;
                    break;
                case 12:
                    Flagelar(1);
                    PoderOpositor = 0;
                    break;
                case 13:
                    Confundir(1);
                    PoderOpositor = 0;
                    break;
                case 14:
                    Dilacerar(1);
                    PoderOpositor = 0;
                    break;
            }
        }

        private void Investir(int User)
        {
            Analisar();

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
            Analisar();

            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            Poder = Math.Min(3, Poder + 1);

            MessageBox.Show("Usou Canalizar.", "Canalizar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Medicar(int User)
        {
            Analisar();

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
            Analisar();

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

            MessageBox.Show("Usou Canalizar.", "Flagelar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Engajar(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            CoeficientePrecisao[User] = Math.Min(CoeficientePrecisao[User] + 20, 120);

            VerificadorDecaimento[User] = false;

            MessageBox.Show("Usou Engajar.", "Engajar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Proteger(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 1);

            VerificadorEscudo[User] = true;

            MessageBox.Show("Usou Proteger.", "Proteger", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Perfurar(int User)
        {
            Analisar();

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
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            VerificadorDecaimento[1 - User] = true;

            MessageBox.Show("Usou Infectar.", "Infectar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Ultrajar(int User)
        {
            Analisar();

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
            Analisar();

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
            Analisar();

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

            CoeficientePrecisao[1 - User] = Math.Max(60, CoeficientePrecisao[1 - User] - 20);

            MessageBox.Show("Usou Confundir.", "Confundir", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Atordoar(int User)
        {
            Analisar();

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
            Analisar();

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
            Analisar();

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
            Analisar();

            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Min(3, Poder + 1);

            TempoAtordoamento[1 - User] = 1;

            EsperaBloquear[User] = 2;

            MessageBox.Show("Usou Bloquear.", "Bloquear", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Sacrificar()
        {
            Analisar();

            EsperaBloquear[0] = Math.Max(0, EsperaBloquear[0] - 1);

            Poder = Math.Min(3, Poder + 3);

            Saude[0] = Math.Max(0, Saude[0] - 16);

            EsperaSacrificar = 4;

            MessageBox.Show("Usou Sacrificar.", "Sacrificar", MessageBoxButtons.OK);

            Atualizar();
        }

        private void Prender(int User)
        {
            Analisar();

            EsperaBloquear[User] = Math.Max(0, EsperaBloquear[User] - 1);
            if (User == 0) EsperaSacrificar = Math.Max(0, EsperaSacrificar - 1);

            if (User == 0) Poder = Math.Max(0, Poder - 2);

            AtordoamentoRecursivo[1 - User] = 4;

            MessageBox.Show("Usou Prender.", "Prender", MessageBoxButtons.OK);

            Atualizar();
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            Usuario(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);

            Atualizar();
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            if (Poder == 3) return;

            Usuario(1);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            if (Poder < 2) return;

            Medicar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            if (Poder < 3 || !Condicional(0)) return;

            Flagelar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || !Condicional(0)) return;

            Engajar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || VerificadorEscudo[0] || !Condicional(0)) return;

            Proteger(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || !Condicional(0)) return;

            Perfurar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || VerificadorDecaimento[1] || !Condicional(0)) return;

            Infectar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || !Condicional(0)) return;

            Ultrajar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || !Condicional(0)) return;

            Roubar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            if (Poder < 3 || !Condicional(0)) return;

            Confundir(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || !Condicional(0)) return;

            Atordoar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            if (Poder < 1 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Colidir(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            if (Poder < 3 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Dilacerar(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EsperaBloquear[0] > 0 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Bloquear(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            if (EsperaSacrificar > 0 || Poder > 0 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Sacrificar();

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            if (Poder < 2 || TempoAtordoamento[0] > 0 || AtordoamentoRecursivo[0] > 0) return;

            Prender(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void btnReanimar_Click(object sender, EventArgs e)
        {
            Condicional(0);

            Opositor();

            if (VerificadorDecaimento[1]) Saude[1] = Math.Max(0, Saude[1] - 8);
            if (VerificadorDecaimento[0]) Saude[0] = Math.Max(0, Saude[0] - 8);
            Atualizar();
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            grpDebug.Visible = chkDebug.Checked;
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