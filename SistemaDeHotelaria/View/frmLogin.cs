using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria
{
    public partial class frmLoginUsuario : Form
    {
        public frmLoginUsuario()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmPrincipal telaInicial = new frmPrincipal();
            telaInicial.Show(); 
        }

        private void frmLoginUsuario_Load(object sender, EventArgs e)
        {
                this.BackColor = System.Drawing.Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ckbLembrar_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
