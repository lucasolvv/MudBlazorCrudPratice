using System.ComponentModel.DataAnnotations;
namespace MUDCRUD.Components.Domain
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
