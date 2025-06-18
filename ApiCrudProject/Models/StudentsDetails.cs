using System.ComponentModel.DataAnnotations;

namespace ApiCrudProject.Models
{
    public class StudentsDetails
    {

        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
    }
}
