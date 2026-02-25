using System;
using System.Windows.Forms;

namespace Opositonn
{
    public partial class TelaInicial : Form
    {
        public static int[] d { get; set; }
        public static int c { get; set; }

        TelaInventario I = new TelaInventario();
        TelaLuta L = new TelaLuta();

        public TelaInicial()
        {
            d = new int[6];
            TelaLuta.Build = new int[2, 6];
            InitializeComponent();
        }

        private void TelaInicial_Shown(object sender, EventArgs e)
        {
            d[0] = 1;
            d[1] = 4;
            d[2] = 7;
            d[3] = 12;
            d[4] = 17;
            d[5] = 21;
        }

        private void btnConfrontar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
                TelaLuta.Build[0, i] = d[i];

            L.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            I.ShowDialog();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            
        }
    }
}
