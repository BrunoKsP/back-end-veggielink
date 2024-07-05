namespace aplication.Dtos.Products;

public class ListProductDto
{
    public string? Name { get; set; }
    public string? Thumb {get;set;}
    public string? Description { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime HarverstDate { get; set; }
    public int Status { get; set; }
    public string CategoryId { get; set; }
}