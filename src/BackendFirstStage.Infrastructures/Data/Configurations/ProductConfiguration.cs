using BackendFirstStage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendFirstStage.Infrastructures.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Ürün adı");
            
        builder.Property(p => p.Description)
            .HasMaxLength(1000)
            .HasComment("Ürün açıklaması");
            
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired()
            .HasComment("Ürün fiyatı");
            
        builder.Property(p => p.StockQuantity)
            .IsRequired()
            .HasComment("Stok miktarı");
            
        builder.Property(p => p.ImageUrl)
            .HasMaxLength(500)
            .HasComment("Ürün resim URL'i");
            
        builder.Property(p => p.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("Aktif mi?");
            
        builder.Property(p => p.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("Silinmiş mi?");
            
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasComment("Oluşturulma tarihi");
            
        builder.Property(p => p.UpdatedAt)
            .HasComment("Güncellenme tarihi");
            
        builder.Property(p => p.DeletedAt)
            .HasComment("Silinme tarihi");
        
        // Indexes
        builder.HasIndex(p => p.Name)
            .HasDatabaseName("IX_Products_Name");
            
        builder.HasIndex(p => p.IsActive)
            .HasDatabaseName("IX_Products_IsActive");
            
        builder.HasIndex(p => p.IsDeleted)
            .HasDatabaseName("IX_Products_IsDeleted");
            
        builder.HasIndex(p => new { p.IsActive, p.IsDeleted })
            .HasDatabaseName("IX_Products_IsActive_IsDeleted");
    }
}
