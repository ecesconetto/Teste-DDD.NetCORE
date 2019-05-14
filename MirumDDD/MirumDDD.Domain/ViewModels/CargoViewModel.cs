using System.ComponentModel.DataAnnotations;

namespace MirumDDD.Domain.ViewModels
{
    public class CargoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? SalarioBase { get; set; }
    }
}
