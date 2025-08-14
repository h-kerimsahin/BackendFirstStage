using BackendFirstStage.Domain.Entities.Seedwork;

namespace BackendFirstStage.Domain.Entities;
public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; }

    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
        ImageUrl = string.Empty;
    }
}
