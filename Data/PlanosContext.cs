using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Planos.Models;

namespace Planos.Models
{
    public class PlanosContext : DbContext
    {
        public PlanosContext (DbContextOptions<PlanosContext> options)
            : base(options)
        {
        }

        public DbSet<Planos.Models.DobEstadoPlano> DobEstadoPlano { get; set; }

        public DbSet<Planos.Models.DobImpresionesPlanos> DobImpresionesPlanos { get; set; }

        public DbSet<Planos.Models.DobPlano> DobPlano { get; set; }

        public DbSet<Planos.Models.DobSemi> DobSemi { get; set; }

        public DbSet<Planos.Models.DobUsuario> DobUsuario { get; set; }
    }
}
