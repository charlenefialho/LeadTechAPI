using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTechAPI.Model
{
    [Table("tb_lead")]
    public class Lead
    {
        [Key]
        public int IdLead { get; set; }

        [Required]
        [Column("NomeLead")]
        public string Nome { get; set; }

        [Required]
        [Column("EmailLead")]
        public string Email { get; set; }

        [Required]
        [Column("StatusLead")]
        public string Status { get; set; }

        [Required]
        [Column("DataCriacao")]
        public String DataCriacao { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int TbClienteIdCliente { get; set; }

        [Required]
        [ForeignKey("Campanha")]
        public int TbCampanhasIdCampanha { get; set; }

        public Cliente Cliente { get; set; }

        public Campanha Campanha { get; set; }
    }
}
