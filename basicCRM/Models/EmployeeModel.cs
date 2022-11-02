namespace basicCRM.Models
{
    public class EmployeeModel
    {
        public Guid Idemployee { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Idrole { get; set; } = null!;
        public string IduserLogin { get; set; } = null!;
    }
}
