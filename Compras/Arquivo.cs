using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compras
{
    /// <summary>
    /// Class <c>Arquivo</c> propriedades dos valores de cada coluna do arquivo a ser importado.
    /// </summary>
    /// 
    public class Arquivo
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Contrato { get; set; }
        public string Produto { get; set; }
        public string Vencimento { get; set; }
        public string Valor { get; set; }

    }
}
