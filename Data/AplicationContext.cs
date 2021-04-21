using Microsoft.EntityFrameworkCore;
using prueba_api.Models;

namespace prueba_api.Data
{
    public class AplicationContext : DbContext
    {
        public AplicationContext()
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }

    }
}