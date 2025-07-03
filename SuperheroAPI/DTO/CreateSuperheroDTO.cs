namespace SuperheroAPI.DTO
{
    public class CreateSuperheroDTO : SuperheroDTO
    {
        new public required string FirstName { get; set; } = string.Empty;
        new public required string LastName { get; set; } = string.Empty;
        new public required string Place { get; set; } = string.Empty;
    }
}
