namespace VeggieLink.Aplication.Dtos.Products;

public class ChangeProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime PreparingDate { get; set; }
    public DateTime HarverstDate { get; set; }
    public string Fertilizer { get; set; }
    public string Observation { get; set; }
    public string Thumb { get; set; }
    public string CategoryId { get; set; }
    public int Status { get; set; }
}