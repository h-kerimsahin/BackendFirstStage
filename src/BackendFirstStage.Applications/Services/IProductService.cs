using BackendFirstStage.Applications.DTOs;

namespace BackendFirstStage.Applications.Services;

public interface IProductService
{
    Task<ProductDetailDto?> GetProductByIdAsync(int id);
    Task<IEnumerable<ProductListDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductListDto>> GetActiveProductsAsync();
    Task<ProductDetailDto> CreateProductAsync(CreateProductDto createProductDto);
    Task<ProductDetailDto> UpdateProductAsync(UpdateProductDto updateProductDto);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> SoftDeleteProductAsync(int id);
    Task<IEnumerable<ProductListDto>> GetProductsByNameAsync(string name);
}
