namespace LeadTech.Models
{
    public class Campanha
    {
        public int IdCampanha { get; set; }
        public string NomeCampanha { get; set; }
        public string DataInicio { get; set; }
        public string DataTermino { get; set; }
        public decimal Custo { get; set; }
        public decimal Roi { get; set; }
        public int TbClienteIdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}
