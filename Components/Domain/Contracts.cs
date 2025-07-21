using System.ComponentModel.DataAnnotations;

namespace MUDCRUD.Components.Domain
{
    public static class Contracts
    {
        public class CreateEmployeeContract
        {
            [Required]
            public string EmployeeName { get; set; }
            [Required]
            public string Gender { get; set; }
            [Required]
            public string City { get; set; }
        }

        public class UpdateEmployeeContract
        {
            [Required]
            public Guid Id { get; set; }
            [Required]
            public string EmployeeName { get; set; }
            [Required]
            public string Gender { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public DateTime UpdatedAt { get; set; }
        }

        public class EmployeeContract
        {
            public Guid Id { get; set; }

            public string EmployeeName { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
