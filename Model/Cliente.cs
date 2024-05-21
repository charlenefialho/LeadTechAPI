using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTechAPI.Model
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public decimal TaxaChurn { get; set; }

        public string DataCriacao { get; set; }
        public Cliente()
        {
            Nome = string.Empty;
            Setor = string.Empty;
            TaxaChurn = 0;
            DataCriacao = "";
        }
    }
}
