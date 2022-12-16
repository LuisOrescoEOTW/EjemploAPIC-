using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planos.Models
{
    public class DobEstadoPlano
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<DobPlano> Plano { get; set; }
    }
}
