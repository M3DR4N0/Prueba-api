using System;

namespace prueba_api.Models.DTO
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public int PType { get; set; }
        public DateTime PDate { get; set; }
    }
}