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
    public partial class TelaInventario : Form
    {
        Dictionary<int, (string Nome, Button Botoes)> Ataques;

        public TelaInventario()
        {
            InitializeComponent();

            Ataques = new Dictionary<int, (string, Button)>
            {
                { 1,  ("Investir", btnInvestir) },
                { 2,  ("Assaltar", btnAssaltar) },
                { 3,  ("---Enganar---", btnEnganar) },
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
                { 19, ("---Refletir---", btnRefletir) },
                { 20, ("Dilacerar", btnDilacerar) },
                { 21, (string.Empty, btnEquipavel) },
                { 22, (string.Empty, btnEquipavelDano) },
                { 23, (string.Empty, btnEquipavelPrecisao) },
                { 24, (string.Empty, btnEquipavelImunidade) },
                { 25, (string.Empty, btnEquipavelProtecao) },
                { 26, (string.Empty, btnEquipavelPoder) },
            };
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            int n = 0;

            for (int i = 1; i <= 26; i++)
            {
                if (!Ataques[i].Botoes.Enabled)
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
                Ataques[i].Botoes.Enabled = i != s;
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(1, 3, 1);
        }

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(1, 3, 2);
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

        private void btnEquipavelDano_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(22, 26, 22);
        }

        private void btnEquipavelPrecisao_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(22, 26, 23);
        }

        private void btnEquipavelImunidade_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(22, 26, 24);
        }
        private void btnEquipavelProtecao_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(22, 26, 25);
        }

        private void btnEquipavelPoder_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(22, 26, 26);
        }

        private void AindaNaoFunciona(object sender, EventArgs e)
        {
            MessageBox.Show("Este controle ainda não está pronto. Aproveite os outros.", 
                "Controle Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TelaInventario_Load(object sender, EventArgs e)
        {
            foreach (int i in TelaInicial.d)
                if (i > 0) Ataques[i].Botoes.Enabled = false;
        }
    }
}
