namespace Figma.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpDesignation { get; set; }

        public string EmpDepartment { get; set; }

        public string EmpManager { get; set; }

        public string EmpType { get; set; }
    }
}