namespace MirumDDD.Domain.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public int CargoId { get; set; }
        public CargoModel Cargo { get; set; }
    }
}
