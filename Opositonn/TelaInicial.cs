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
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            cmbAtaque.SelectedItem = "Investir";
            cmbEspecialL.SelectedItem = "Canalizar";
            cmbEspecialF.SelectedItem = "Engajar";
            cmbEspecialM.SelectedItem = "Medicar";
            cmbEspecialS.SelectedItem = "Flagelar";
            cmbEquipavel.SelectedItem = "---";
        }

        private void btnConfrontar_Click(object sender, EventArgs e)
        {
            if (TelaLuta.Ataque == null || TelaLuta.ELivre == null || TelaLuta.EFraco == null || TelaLuta.EMedio == null || TelaLuta.EForte == null)
            {
                MessageBox.Show("Você não escolheu alguns ataques.\nComo vai encarar o Opositor assim?", "Build Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            TelaLuta luta = new TelaLuta();
            luta.ShowDialog();
        }

        private void cmbAtaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            TelaLuta.Ataque = (string)cmbAtaque.SelectedItem;
        }

        private void cmbEspecialL_SelectedIndexChanged(object sender, EventArgs e)
        {
            TelaLuta.ELivre = (string)cmbEspecialL.SelectedItem;
        }

        private void cmbEspecialF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TelaLuta.EFraco != null && TelaLuta.EFraco == TelaLuta.EMedio)
            {
                MessageBox.Show("Este ataque já está selecionado. Escolha outro.", "Ataque Já Escolhido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cmbEspecialF.SelectedIndex = -1;
                TelaLuta.EFraco = null;
                return;
            }

            TelaLuta.EFraco = (string)cmbEspecialF.SelectedItem;
        }

        private void cmbEspecialM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TelaLuta.EMedio != null && (TelaLuta.EMedio == TelaLuta.EFraco || TelaLuta.EMedio == TelaLuta.EForte))
            {
                MessageBox.Show("Este ataque já está selecionado. Escolha outro.", "Ataque Já Escolhido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cmbEspecialM.SelectedIndex = -1;
                TelaLuta.EMedio = null;
                return;
            }

            TelaLuta.EMedio = (string)cmbEspecialM.SelectedItem;
        }

        private void cmbEspecialS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TelaLuta.EForte != null && TelaLuta.EForte == TelaLuta.EMedio)
            {
                MessageBox.Show("Este ataque já está selecionado. Escolha outro.", "Ataque Já Escolhido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cmbEspecialF.SelectedIndex = -1;
                TelaLuta.EForte = null;
                return;
            }

            TelaLuta.EForte = (string)cmbEspecialS.SelectedItem;
        }

        private void cmbEquipavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TelaLuta.IEquip = (string)cmbEquipavel.SelectedItem;
        }
    }
}
