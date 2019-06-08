using System;
using System.Collections.Generic;

namespace TesteDDD.NetCORE.Infra.Core.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? SalarioBase { get; set; }

        public ICollection<Pessoa> Pessoa { get; set; }
    }
}
