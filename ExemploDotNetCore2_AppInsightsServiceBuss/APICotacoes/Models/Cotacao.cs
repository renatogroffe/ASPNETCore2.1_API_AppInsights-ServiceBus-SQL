using System;

namespace APICotacoes.Models
{
    public class Cotacao
    {
        public string NomeMoeda { get; set; }
        public DateTime DtUltimaCarga { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public string Variacao { get; set; }
    }
}