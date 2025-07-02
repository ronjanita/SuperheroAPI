namespace SuperheroAPI.Models
{
    public class Villain
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
