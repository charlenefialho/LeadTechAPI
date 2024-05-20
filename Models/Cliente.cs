namespace LeadTech.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public decimal TaxaChurn { get; set; }
        public string DataCriacao { get; set; }
        public ICollection<Campanha> Campanhas { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}
