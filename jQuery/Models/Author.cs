using System.ComponentModel.DataAnnotations;

namespace jQuery.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public double Salary { get; set; }
    }
}
