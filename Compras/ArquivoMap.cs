using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compras
{
    /// <summary>
    /// Class <c>ArquivoMap</c> Mapeamento das colunas do csv que será importado.
    /// </summary>
    public sealed class ArquivoMap : ClassMap<Arquivo>
    {
        /// <summary>
        /// Este método serve para mapear as variáveis que serão ingeridas pelas propriedades
        /// da classe Arquivo.
        /// </summary>
        public ArquivoMap()
        {
            Map(m => m.Nome).Name("Nome");
            Map(m => m.Cpf).Name("CPF"); ;
            Map(m => m.Produto).Name("Produto"); ;
            Map(m => m.Contrato).Name("Contrato"); ;
            Map(m => m.Vencimento).Name("Vencimento"); ;
            Map(m => m.Valor).Name("Valor");
        }
    }
}
