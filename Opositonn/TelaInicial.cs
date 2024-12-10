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

        private void btnConfrontar_Click(object sender, EventArgs e)
        {
            TelaLuta luta = new TelaLuta();
            luta.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            TelaInventario inventario = new TelaInventario();
            inventario.ShowDialog();
        }
    }
}
