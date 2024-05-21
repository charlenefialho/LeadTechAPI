using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTechAPI.Model
{
    [Table("tb_campanhas")]
    public class Campanha
    {
        [Key]
        public int IdCampanha { get; set; }

        [Required]
        public string NomeCampanha { get; set; } // Deve ser inicializado no construtor

        [Required]
        public string DataInicio { get; set; } // Deve ser inicializado no construtor

        [Required]
        public string DataTermino { get; set; } // Deve ser inicializado no construtor

        public decimal Custo { get; set; }

        public decimal Roi { get; set; }

        [ForeignKey("Cliente")]
        public int TbClienteIdCliente { get; set; }

        public Cliente Cliente { get; set; } 

        public Campanha()
        {
            NomeCampanha = string.Empty; // Inicialize a propriedade com um valor padrão
            DataInicio = ""; // Inicialize a propriedade com um valor padrão
            DataTermino = ""; // Inicialize a propriedade com um valor padrão
            Cliente = new Cliente(); // Inicialize a propriedade com um novo objeto Cliente
        }
    }
}
