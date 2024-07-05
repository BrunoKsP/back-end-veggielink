using data.domain.Collections;
using VeggieLink.Data.Collections;

namespace VeggieLink.Infra.domain.Dtos;

public class ProductWithCategory : ProductCollection
{
    
    public int Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Thumb { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime HarvestDate { get; set; }
    public string CategoryId { get; set; }
     public string CategoryName {get;set;}
     public CategoryCollection CategoryDetails { get; set; }
}