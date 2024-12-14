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

        readonly TelaLuta telaLuta = new TelaLuta();

        public TelaInventario()
        {
            InitializeComponent();

            TelaLuta.Ataque = new int[2, 6];

            Ataques = new Dictionary<int, (string, Button)>
            {
                { 0,  ("Investir", btnInvestir) },
                { 1,  ("Assaltar", btnAssaltar) },
                { 2,  ("Canalizar", btnCanalizar) },
                { 3,  ("Sacrificar", btnSacrificar) },
                { 4,  ("Bloquear", btnBloquear) },
                { 5,  ("Engajar", btnEngajar) },
                { 6,  ("Proteger", btnProteger) },
                { 7,  ("Colidir", btnColidir) },
                { 8,  ("Perfurar", btnPerfurar) },
                { 9,  ("Ultrajar", btnUltrajar) },
                { 10, ("Medicar", btnMedicar) },
                { 11, ("Atordoar", btnAtordoar) },
                { 12, ("Roubar", btnRoubar) },
                { 13, ("Infectar", btnInfectar) },
                { 14, ("Prender", btnPrender) },
                { 15, ("Flagelar", btnFlagelar) },
                { 16, ("Confundir", btnConfundir) },
                { 17, ("Dilacerar", btnDilacerar) },
                { 18, (string.Empty, btnVoltar) },
                { 19, (string.Empty, btnVoltar) },
                { 20, (string.Empty, btnEquipavelDano) },
                { 21, (string.Empty, btnEquipavelPrecisao) },
                { 22, (string.Empty, btnEquipavelImunidade) },
                { 23, (string.Empty, btnEquipavelPoder) },
            };
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            int n = 0;

            for (int i = 0; i <= 23; i++)
            {
                if (!Ataques[i].Botoes.Enabled)
                {
                    TelaLuta.Ataque[0, n] = i >= 20 ? i - 19 : i;
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

        private void btnEngajar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(5, 9, 5);
        }

        private void btnProteger_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(5, 9, 6);
        }

        private void btnColidir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(5, 9, 7);
        }

        private void btnPerfurar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(5, 9, 8);
        }

        private void btnUltrajar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(5, 9, 9);
        }

        private void btnInvestir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(0, 1, 0);
        }

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(0, 1, 1);
        }

        private void btnCanalizar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(2, 4, 2);
        }

        private void btnSacrificar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(2, 4, 3);
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(2, 4, 4);
        }

        private void btnMedicar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(10, 14, 10);
        }

        private void btnAtordoar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(10, 14, 11);
        }

        private void btnRoubar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(10, 14, 12);
        }

        private void btnInfectar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(10, 14, 13);
        }

        private void btnPrender_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(10, 14, 14);
        }

        private void btnFlagelar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(15, 17, 15);
        }

        private void btnConfundir_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(15, 17, 16);
        }

        private void btnDilacerar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(15, 17, 17);
        }

        private void btnEquipavelDano_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(20, 23, 20);
        }

        private void btnEquipavelPrecisao_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(20, 23, 21);
        }

        private void btnEquipavelPoder_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(20, 23, 23);
        }

        private void btnEquipavelImunidade_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(20, 23, 22);
        }

        private void TelaInventario_Load(object sender, EventArgs e)
        {

        }
    }
}
