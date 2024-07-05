namespace VeggieLink.Data.Collections;

public class UserCollection
{
    public string Id { get; set; }
    public int Status { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Photo { get; set; }
    public string? Description { get; set; }
    public string? Segment { get; set; }
    public DateTime CreateDate { get; set; }
}