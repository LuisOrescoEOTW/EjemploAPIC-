using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planos.Models
{
    public class DobPlano
    {
        public int Id { get; set; }
        public int SemielaboradoId { get; set; }
        public virtual DobSemi Semielaborado { get; set; }
        public string Imagen { get; set; }
        public int EstadoId { get; set; }
        public virtual DobEstadoPlano Estado { get; set; }
        public DateTime FechaCambioEstado { get; set; }
        public int UsuarioId { get; set; }
        public virtual DobUsuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaBaja { get; set; }
        public int UsuarioBajaId { get; set; }
        public virtual DobUsuario UsuarioBaja { get; set; }
        public virtual ICollection<DobImpresionesPlanos> ImpresionesPlanos { get; set; }
    }
}
