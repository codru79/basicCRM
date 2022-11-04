using basicCRM.Models.DBObjects;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basicCRM.Models
{
    public class EmployeeModel
    {
        public Guid Idemployee { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string? Role { get; set; }
       
    }

}
