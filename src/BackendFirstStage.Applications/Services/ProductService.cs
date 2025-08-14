using BackendFirstStage.Applications.DTOs;
using BackendFirstStage.Domain.Entities;
using BackendFirstStage.Applications.Repositories;
using BackendFirstStage.Applications.Repositories.Seedwork;

namespace BackendFirstStage.Applications.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDetailDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product != null ? MapToProductDetailDto(product) : null;
    }

    public async Task<IEnumerable<ProductListDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(MapToProductListDto);
    }

    public async Task<IEnumerable<ProductListDto>> GetActiveProductsAsync()
    {
        var products = await _productRepository.GetActiveAsync();
        return products.Select(MapToProductListDto);
    }

    public async Task<ProductDetailDto> CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
            StockQuantity = createProductDto.StockQuantity,
            ImageUrl = createProductDto.ImageUrl
        };

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return MapToProductDetailDto(product);
    }

    public async Task<ProductDetailDto> UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var product = await _productRepository.GetByIdAsync(updateProductDto.Id);
        if (product == null)
            throw new ArgumentException($"Product with ID {updateProductDto.Id} not found");

        product.Name = updateProductDto.Name;
        product.Description = updateProductDto.Description;
        product.Price = updateProductDto.Price;
        product.StockQuantity = updateProductDto.StockQuantity;
        product.ImageUrl = updateProductDto.ImageUrl;

        await _productRepository.UpdateAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return MapToProductDetailDto(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        if (result)
            await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task<bool> SoftDeleteProductAsync(int id)
    {
        var result = await _productRepository.SoftDeleteAsync(id);
        if (result)
            await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task<IEnumerable<ProductListDto>> GetProductsByNameAsync(string name)
    {
        var products = await _productRepository.GetProductsByNameAsync(name);
        return products.Select(MapToProductListDto);
    }



    private static ProductListDto MapToProductListDto(Product product)
    {
        return new ProductListDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            CreatedAt = product.CreatedAt
        };
    }

    private static ProductDetailDto MapToProductDetailDto(Product product)
    {
        return new ProductDetailDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            IsActive = product.IsActive,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}
