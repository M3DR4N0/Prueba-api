using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace prueba_api.Models
{
    [Table("PermissionType")]
    public partial class PermissionType
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permission>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(Permission.PTypeNavigation))]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
