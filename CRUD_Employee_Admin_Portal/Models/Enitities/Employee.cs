namespace CRUD_Employee_Admin_Portal.Models.Enitities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    
        public required  string Email { get; set; }

        public string ? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
