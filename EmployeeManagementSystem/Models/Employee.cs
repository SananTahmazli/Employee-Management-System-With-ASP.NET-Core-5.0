using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("employee's name and surname")]
        public string NameAndSurname { get; set; }
        [Required]
        [DisplayName("employee's salary")]
        [Range(500, 3000, ErrorMessage = "The employee's salary can be between 500 and 3000 AZN!")]
        public double Salary { get; set; }
        [Required]
        [DisplayName("employee's city")]
        public string City { get; set; }
        [Required]
        [DisplayName("employee's experience level")]
        public string ExperienceLevel { get; set; }
        [Required]
        [DisplayName("employee's birth date")]
        public DateTime BirthDate { get; set; }
    }
}
