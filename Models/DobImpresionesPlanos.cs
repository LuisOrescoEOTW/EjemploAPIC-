using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planos.Models
{
    public class DobImpresionesPlanos
    {
        public int Id { get; set; }
        public int PlanoId { get; set; }
        public virtual DobPlano Plano { get; set; }
        public int UsuarioId { get; set; }
        public virtual DobUsuario Usuario { get; set; }
        public DateTime FechaImpresion { get; set; }
        public DateTime FechaBaja { get; set; }
        public int UsuarioBajaId { get; set; }
        public virtual DobUsuario UsuarioBaja { get; set; }
    }
}
