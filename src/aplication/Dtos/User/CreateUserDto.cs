namespace VeggieLink.Aplication.Dtos.User;

public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Photo { get; set; }
    public string? Description { get; set; }
    public string? Segment { get; set; }
}