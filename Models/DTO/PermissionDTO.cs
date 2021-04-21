using System;
using System.ComponentModel.DataAnnotations;

namespace prueba_api.Models.DTO
{
    public class PermissionDTO
    {
        public int? Id { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public int PType { get; set; }
        public DateTime PDate { get; set; } 
        public string PDateFormated
        {
            get { return PDate.ToString( "yyyy-MM-dd" ); }
        }
    }
}