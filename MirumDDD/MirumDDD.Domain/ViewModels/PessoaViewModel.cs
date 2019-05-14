using System.ComponentModel.DataAnnotations;

namespace MirumDDD.Domain.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string RG { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)")]
        public string Email { get; set; }

        [Range(1, 100)]
        [Required]
        public int CargoId { get; set; }
        public CargoViewModel Cargo { get; set; }
    }
}
