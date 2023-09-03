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
        /// <summary>
        /// Class <c>Form1</c> Janela para login.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Este método serve para login do usuário no SQL Server.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            var connection = new Connection($"Data Source=DESKTOP-8MOJPID;Initial Catalog=concilig;User ID={usuario};Password={senha}");
            
            try
            {
                connection.TestLogin();
                MessageBox.Show("Conexão Sucedida");
                Form2 f2 = new Form2(connection);
                f2.Closed += (s, args) => this.Close(); // Se o Form2 fechar, fechar também o Form1.
                f2.Show();
                this.Hide();
            }
            catch(Exception)
            {
                MessageBox.Show("Login ou Senha inválido");
            }
        }
    }
}
