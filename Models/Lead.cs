namespace LeadTech.Models
{
    public class Lead
    {
        public int IdLead { get; set; }
        public string NomeLead { get; set; }
        public string EmailLead { get; set; }
        public string StatusLead { get; set; }
        public string DataCriacao { get; set; }
        public int TbClienteIdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int TbCampanhasIdCampanha { get; set; }
        public Campanha Campanha { get; set; }
    }
}
