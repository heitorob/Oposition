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

        Dictionary<int, Button> Equipaveis;

        TelaLuta telaLuta = new TelaLuta();

        public TelaInventario()
        {
            InitializeComponent();

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
                { 17, ("Dilacerar", btnDilacerar) }
            };

            Equipaveis = new Dictionary<int, Button>
            {
                { 1, btnEquipavelDano },
                { 2, btnEquipavelPrecisao },
                { 3, btnEquipavelImunidade },
                { 4, btnEquipavelPoder }
            };
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            for (int Ataque = 0; Ataque <= 1; Ataque++)
                if (!Ataques[Ataque].Botoes.Enabled) TelaLuta.Ataque = TelaLuta.Bglhs[Ataque].Nome;

            for (int Ataque = 2; Ataque <= 4; Ataque++)
                if (!Ataques[Ataque].Botoes.Enabled) TelaLuta.ELivre = TelaLuta.Bglhs[Ataque].Nome;

            for (int Ataque = 5; Ataque <= 9; Ataque++)
                if (!Ataques[Ataque].Botoes.Enabled) TelaLuta.EFraco = TelaLuta.Bglhs[Ataque].Nome;

            for (int Ataque = 10; Ataque <= 14; Ataque++)
                if (!Ataques[Ataque].Botoes.Enabled) TelaLuta.EMedio = TelaLuta.Bglhs[Ataque].Nome;

            for (int Ataque = 15; Ataque <= 17; Ataque++)
                if (!Ataques[Ataque].Botoes.Enabled) TelaLuta.EForte = TelaLuta.Bglhs[Ataque].Nome;

            for (int Equipavel = 1; Equipavel <= 4; Equipavel++)
            {
                if (!Equipaveis[Equipavel].Enabled) TelaLuta.IEquip = Equipavel;
                else TelaLuta.IEquip = 0;
            }

            this.Close();
        }

        private void SelecionarAtaque(int e, int E, int Selecionado)
        {
            for (int Escopo = e; Escopo <= E; Escopo++)
                Ataques[Escopo].Botoes.Enabled = Escopo != Selecionado;
        }

        private void SelecionarEquipavel(int Selecionado)
        {
            for (int Equipavel = 1; Equipavel <= 4; Equipavel++)
                Equipaveis[Equipavel].Enabled = Equipavel != Selecionado;
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

        private void btnAssaltar_Click(object sender, EventArgs e)
        {
            SelecionarAtaque(0, 1, 1);
        }

        private void btnEquipavelDano_Click(object sender, EventArgs e)
        {
            SelecionarEquipavel(1);
        }

        private void btnEquipavelPrecisao_Click(object sender, EventArgs e)
        {
            SelecionarEquipavel(2);
        }

        private void btnEquipavelPoder_Click(object sender, EventArgs e)
        {
            SelecionarEquipavel(4);
        }

        private void btnEquipavelImunidade_Click(object sender, EventArgs e)
        {
            SelecionarEquipavel(3);
        }

        private void TelaInventario_Load(object sender, EventArgs e)
        {
            
        }
    }
}
