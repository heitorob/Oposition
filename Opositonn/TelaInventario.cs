using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Opositonn
{
    public partial class TelaInventario : Form
    {
        Dictionary<int, (string Nome, Button Botoes)> Gizmos;
        int InfoEgg = 0;

        public TelaInventario()
        {
            InitializeComponent();

            Gizmos = new Dictionary<int, (string, Button)>
            {
                { 1,  ("Investir", btnInvestir) },
                { 2,  ("Assaltar", btnAssaltar) },
                { 3,  ("Sufocar", btnSufocar) },
                { 4,  ("Canalizar", btnCanalizar) },
                { 5,  ("Sacrificar", btnSacrificar) },
                { 6,  ("Bloquear", btnBloquear) },
                { 7,  ("Engajar", btnEngajar) },
                { 8,  ("Proteger", btnProteger) },
                { 9,  ("Colidir", btnColidir) },
                { 10, ("Perfurar", btnPerfurar) },
                { 11, ("Ultrajar", btnUltrajar) },
                { 12, ("Medicar", btnMedicar) },
                { 13, ("Atordoar", btnAtordoar) },
                { 14, ("Roubar", btnRoubar) },
                { 15, ("Infectar", btnInfectar) },
                { 16, ("Prender", btnPrender) },
                { 17, ("Flagelar", btnFlagelar) },
                { 18, ("Confundir", btnConfundir) },
                { 19, ("Refletir", btnRefletir) },
                { 20, ("Dilacerar", btnDilacerar) },
                { 21, (string.Empty, btnEquipavelDinheiro) },
                { 22, (string.Empty, btnEquipavelDano) },
                { 23, (string.Empty, btnEquipavelPrecisao) },
                { 24, (string.Empty, btnEquipavelImunidade) },
                { 25, (string.Empty, btnEquipavelProtecao) },
                { 26, (string.Empty, btnEquipavelPoder) },
            };
        }

        private void InfoPadrao(object sender, EventArgs e)
        {
            InfoEgg = 0;
            lblInformar.Text = "Obtenha informações sobre cada ataque ou item pairando sobre algum botão com seu ponteiro.";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            int n = 0;

            for (int i = 1; i <= 26; i++)
            {
                if (Gizmos[i].Botoes.ForeColor == Color.LightGray)
                {
                    TelaInicial.d[n] = i;
                    n++;
                }
            }

            this.Close();
        }

        private void SelecionarAtaque(int m, int n, int s)
        {
            for (int i = m; i <= n; i++)
                Gizmos[i].Botoes.ForeColor = Color.Black;
            Gizmos[s].Botoes.ForeColor = Color.LightGray;
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(1, 3, 1);
        }

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(1, 3, 2);
        }

        private void btnSufocar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(1, 3, 3);
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(4, 6, 4);
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(4, 6, 5);
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(4, 6, 6);
        }

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(7, 11, 7);
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(7, 11, 8);
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(7, 11, 9);
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(7, 11, 10);
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(7, 11, 11);
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(12, 16, 12);
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(12, 16, 13);
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(12, 16, 14);
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(12, 16, 15);
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(12, 16, 16);
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(17, 20, 17);
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(17, 20, 18);
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(17, 20, 20);
        }

        private void btnEquipavelDinheiro_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(21, 26, 21);
        }

        private void btnEquipavelDano_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(21, 26, 22);
        }

        private void btnEquipavelPrecisao_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(21, 26, 23);
        }

        private void btnEquipavelImunidade_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(21, 26, 24);
        }
        private void btnEquipavelProtecao_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(21, 26, 25);
        }

        private void btnEquipavelPoder_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(21, 26, 26);
        }

        private void AindaNaoFunciona(object sender, EventArgs e)
        {
            MessageBox.Show("Este controle ainda não está pronto. Aproveite os outros.",
                "Controle Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void TelaInventario_Load(object sender, EventArgs e)
        {
            foreach (int i in TelaInicial.d)
                if (i > 0) Gizmos[i].Botoes.ForeColor = Color.LightGray;

            lblDinheiro.Text = "$" + TelaInicial.c.ToString();
        }

        private void lblInformar_Click(object sender, EventArgs e)
        {
            InfoEgg++;
            string egg = "";
            Random rng = new Random();
            switch (InfoEgg)
            {
                default:
                    egg = "🎶 VOCÊ É GAY!! 🎶";
                    SelecionarAtaque(1, 3, rng.Next(1, 3));
                    SelecionarAtaque(4, 6, rng.Next(4, 6));
                    SelecionarAtaque(7, 11, rng.Next(7, 11));
                    SelecionarAtaque(12, 16, rng.Next(12, 16));
                    SelecionarAtaque(17, 20, rng.Next(17, 20));
                    SelecionarAtaque(21, 26, rng.Next(21, 26));
                    break;
                case 1: egg = "🎶 Atenção: 🎶"; break;
                case 2: egg = "🎶 Mãozinha p'ra cima! 🎶"; break;
                case 3: egg = "🎶 Mãozinha p'ra baixo! 🎶"; break;
                case 4: egg = "🎶 Olha pr'um lado! 🎶"; break;
                case 5: egg = "🎶 Olha pr'o outro! 🎶"; break;
                case 6: egg = "🎶 Eu vou dizer... 🎶"; break;
                case 7: egg = "🎶 Barra! 🎶"; break;
                case 8: egg = "🎶 Flexão! 🎶"; break;
                case 9: egg = "🎶 Esteira! 🎶"; break;
                case 10: egg = "🎶 Bicicleta! 🎶"; break;
                case 11: egg = "🎶 Pulando Corda! 🎶"; break;
                case 12: egg = "🎶 Não para! 🎶"; break;
                case 13: egg = "🎶 Eu vou dizer... 🎶"; break;
                case 14: egg = "🎶 Inspira pelo nariz! 🎶"; break;
                case 15: egg = "🎶 Expira pela boca! 🎶"; break;
                case 16: egg = "🎶 Abre as pernas! 🎶"; break;
                case 17: egg = "🎶 Encosta a mão no chão! 🎶"; break;
                case 18: egg = "🎶 Eu vou dizer... 🎶"; break;
                case 19: egg = "🎶 Abaixa! 🎶"; break;
                case 20: egg = "🎶 Sobe! 🎶"; break;
                case 21: egg = "🎶 Mão nas cadeiras! 🎶"; break;
                case 22: egg = "🎶 Olha p'ra mim! 🎶"; break;
                case 23: egg = "🎶 Tá acabando! 🎶"; break;
                case 24: egg = "🎶 Mais um pouco! 🎶"; break;
                case 25: egg = "🎶 Eu vou dizer... 🎶"; break;
                case 26: egg = "🎶 Você é gay! 🎶"; break;
            }
            lblInformar.Text = egg;
        }

        private void btnInvestir_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "INVESTIR - Subtrai 16 pontos de saúde do Opositor.";
        }

        private void btnAssaltar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "ASSALTAR - Subtrai 12 pontos de saúde e 10 pontos de precisão do Opositor.";
        }

        private void btnSufocar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "SUFOCAR - Subtrai 20 pontos de saúde do Opositor. Usá-lo repetidamente vai fazê-lo perder dano progressivamente.";
        }

        private void btnCanalizar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "CANALIZAR - Aumenta o poder em um ponto.";
        }

        private void btnSacrificar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "SACRIFICAR - Maximiza o poder, mas subtrai 16 pontos de saúde do Usuário. Possui tempo de espera de 4 turnos para poder ser usado novamente.";
        }

        private void btnBloquear_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "BLOQUEAR - Aumenta o poder em um ponto e atordoa o Opositor por um turno. Possui tempo de espera de 2 turnos para poder ser usado novamente.";
        }

        private void btnEngajar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "ENGAJAR - Aumenta a precisão do Usuário em 20 pontos e remove efeitos negativos do Usuário.";
        }

        private void btnProteger_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "PROTEGER - Invoca 4 turnos de escudo para o Usuário.";
        }

        private void btnUltrajar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "ULTRAJAR - Subtrai 28 pontos de saúde e aplica efeito de decaimento por 4 turnos no Opositor. Pode errar com maior frequência.";
        }

        private void btnColidir_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "COLIDIR - Subtrai 40 pontos de saúde do Opositor, mas também subtrai 16 pontos de saúde do Usuário.";
        }

        private void btnPerfurar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "PERFURAR - Subtrai 28 pontos de saúde do Opositor. Pode destruir escudos e reflexões do Opositor, aumentando o dano causado significativamente.";
        }

        private void btnMedicar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "MEDICAR - Restaura 40 pontos de saúde e remove efeitos negativos do Usuário.";
        }

        private void btnAtordoar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "ATORDOAR - Subtrai 40 pontos de saúde e atordoa o Opositor por um turno. Pode errar com maior frequência.";
        }

        private void btnRoubar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "ROUBAR - Subtrai 28 pontos de saúde do Opositor e os adiciona à saúde do Usuário.";
        }

        private void btnInfectar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "INFECTAR - Aplica o efeito de decaimento por 4 turnos no Opositor.";
        }

        private void btnPrender_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "PRENDER - Aplica o efeito de atordoamento recursivo no Opositor. Possui tempo de espera de 6 turnos para poder ser usado novamente.";
        }

        private void btnFlagelar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "FLAGELAR - Subtrai 60 pontos de saúde do Opositor.";
        }

        private void btnConfundir_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "CONFUNDIR - Subtrai 40 pontos de saúde e 20 pontos de precisão do Opositor. Nunca vai errar enquanto o Usuário estiver com suas faculdades em dia.";
        }

        private void btnDilacerar_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "DILACERAR - Subtrai metade da saúde do Opositor. Pode errar com maior frequência.";
        }

        private void btnRefletir_MouseEnter(object sender, EventArgs e)
        {
            lblInformar.Text = "REFLETIR - Reflete o próximo ataque do Opositor de volta para ele.";
        }
    }
}