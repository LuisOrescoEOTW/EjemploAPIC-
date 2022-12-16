using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planos.Models
{
    public class DobSemi
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public virtual ICollection<DobPlano> Plano { get; set; }
    }
}
