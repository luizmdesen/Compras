using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Compras
{
    /// <summary>
    /// Class <c>Form2</c> Janela para consulta e importação de dados.
    /// </summary>
    public partial class Form2 : Form
    {
        /// <value>Property <c>ofd</c> serve para capturar o path do arquivo a ser importado.</value>
        private OpenFileDialog ofd;
        /// <value>Property <c>cnn</c> representa a conexão ao SQL Server utilizando a classe Connection.</value>
        private Connection cnn { get; set; }
        public Form2(Connection connection)
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
            cnn = connection;
            populateGrid();
        }
        /// <summary>
        /// Este método irá popular o dataGridView1 da classe Form2 utilizando a conexão do SQL Server.
        /// </summary>
        public void populateGrid()
        {
            dataGridView1.Rows.Clear();
            var reader = cnn.Read("select * from Compras;");
            while (reader.Read())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = reader.GetValue(0);
                dataGridView1.Rows[index].Cells[1].Value = reader.GetValue(1);
                dataGridView1.Rows[index].Cells[2].Value = reader.GetValue(2);
                dataGridView1.Rows[index].Cells[3].Value = reader.GetValue(3);
                dataGridView1.Rows[index].Cells[4].Value = reader.GetValue(4);
                dataGridView1.Rows[index].Cells[5].Value = reader.GetValue(5);
            }
            reader.Close();
        }
        /// <summary>
        /// Este método importa um arquivo csv para popular os dados da tabela Compras do banco de dados.
        /// </summary>
        private void import_Click(object sender, EventArgs e)
        {

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> listA = new List<string>();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = true
                };
                using (var reader = new StreamReader(ofd.FileName))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<ArquivoMap>();
                    var records = csv.GetRecords<Arquivo>();

                    foreach (var r in records)
                    {
                        string auxValor = r.Valor.Replace(",", "."); // Trocar "," por "." para inserir o dado como decimal no BD.
                        listA.Add($"('{r.Nome}','{r.Cpf}','{r.Contrato}','{r.Produto}','{r.Vencimento}',{auxValor}) ");
                    }
                }
                string query = "insert into Compras (nome, cpf, contrato, produto, vencimento, valor) values";
                query += string.Join(",\n", listA) + ";";

                cnn.ExecuteOnDatabase(query);
                populateGrid();
                MessageBox.Show("Arquivo importado com sucesso!");
            }

        }
    }
}
