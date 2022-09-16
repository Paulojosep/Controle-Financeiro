using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.BLL.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public double Limite { get; set; }
        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Despesa> Despesas { get; set; }
    }
}
