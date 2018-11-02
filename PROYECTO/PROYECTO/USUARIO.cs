using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PROYECTO
{
    public partial class USUARIO : Form
    {
        public USUARIO()
        {
            InitializeComponent();
        }

        private void USUARIO_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
                txtContraseña.Focus();
            else
            {
                if (e.KeyChar == 8 || e.KeyChar == 32 || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122))
                    e.Handled = false; 
                else
                    e.Handled = true;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnIngresar.Focus(); 
            else
                if (e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57))
                    e.Handled = false;
                else
                    e.Handled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            btnIngresar.BackColor = ;   
            StreamReader leer = new StreamReader(@"C:\Users\Morelia Hidalgo C\Documents\4to SEMESTRE EMI\ESTRUCTURA DE DATOS\Programs E.DATOS\PROYECTO\usuarios.txt");
            string linea;
            try
            {
                linea = leer.ReadLine();
                while (linea != null && linea!= txtUsuario.Text + txtContraseña.Text)
                {
                    linea = leer.ReadLine();
                }
                if (linea == (txtUsuario.Text + txtContraseña.Text))
                {
                    MessageBox.Show("Acceso Correcto");
                    Form1 inicio = new Form1();
                    inicio.Show();
                    this.Hide();
                }

                if (linea == null)
                {
                    MessageBox.Show("Acceso Denegado");
                    txtContraseña.Clear();
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
                leer.Close();
            }
            catch
            {
                MessageBox.Show("Error al leer");
            }           
        }
    }
}
