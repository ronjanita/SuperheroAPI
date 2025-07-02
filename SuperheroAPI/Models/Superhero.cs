using System.ComponentModel.DataAnnotations;

namespace SuperheroAPI.Models
{
    public class Superhero
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
