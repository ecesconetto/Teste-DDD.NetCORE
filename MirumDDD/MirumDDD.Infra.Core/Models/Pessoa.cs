using System;
using System.Collections.Generic;

namespace MirumDDD.Infra.Core.Models
{
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public int? CargoId { get; set; }

        public Cargo Cargo { get; set; }
    }
}
