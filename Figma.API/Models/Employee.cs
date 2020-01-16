using System.ComponentModel.DataAnnotations;

namespace Figma.API.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required,StringLength(15)]
        public string EmpName { get; set; }

        [Required]
        public string EmpDesignation { get; set; }

        [Required]
        public string EmpDepartment { get; set; }
        
        [Required]
        public string EmpManager { get; set; }
        
        [Required]
        public string EmpType { get; set; }
    }
}