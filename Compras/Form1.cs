using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var connection = new Connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            Connection.ConnectionString = $"Data Source=DESKTOP-8MOJPID;Initial Catalog=concilig;User ID={usuario};Password={senha}";

            var cnn = new Connection();
            try
            {
                SqlConnection cursor = cnn.connect_to_database();
                cursor.Open();
                MessageBox.Show("Conexão Aberta!");
                cursor.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Usuario ou senha incorreta");
            }
        }
    }
}
