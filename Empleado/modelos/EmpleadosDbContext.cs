using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleado.modelos
{
    public class EmpleadosDbContext:DbContext
    {
        public EmpleadosDbContext():base("MiConexion")
        {
            
        }
        public DbSet <Empleado> Empleados { get; set; }
    }
}
