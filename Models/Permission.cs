using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace prueba_api.Models
{
    [Table("Permission")]
    public partial class Permission
    {
        [Key]
        public int Id { get; set; }
        [Column("emp_name")]
        public string EmpName { get; set; }
        [Column("emp_last_name")]
        public string EmpLastName { get; set; }
        [Column("p_type")]
        public int PType { get; set; }
        [Column("p_date")]
        public DateTime PDate { get; set; }

        [ForeignKey(nameof(PType))]
        [InverseProperty(nameof(PermissionType.Permissions))]
        public virtual PermissionType PTypeNavigation { get; set; }
    }
}
