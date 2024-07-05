namespace aplication.Dtos.Products;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime PreparingDate { get; set; }
    public string Fertilizer { get; set; }
    public string Observation { get; set; }
    public string Thumb { get; set; }
    public string CategoryId { get; set; }
}