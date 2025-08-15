# BackendFirstStage

## Database Migration

Bu proje Entity Framework Core kullanarak database migration'ları yönetir.

### Gereksinimler

- .NET 8.0 SDK
- SQL Server (LocalDB, Express veya Full Edition)
- Entity Framework Core Tools

### Kurulum

1. **Entity Framework Tools kurulumu:**
   ```bash
   dotnet tool install --global dotnet-ef
   ```

2. **Environment Variable ayarlama:**
   ```bash
   # Windows PowerShell
   $env:MsSqlServer = "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;TrustServerCertificate=true;"
   
   # Windows Command Prompt
   set MsSqlServer=Server=your_server;Database=your_db;User Id=your_user;Password=your_password;TrustServerCertificate=true;
   
   # Linux/macOS
   export MsSqlServer="Server=your_server;Database=your_db;User Id=your_user;Password=your_password;TrustServerCertificate=true;"
   ```

### Migration Komutları

#### Migration Oluşturma
```bash
cd src/BackendFirstStage.Api
dotnet ef migrations add InitialCreate --project ../BackendFirstStage.Infrastructures --startup-project .
```

#### Migration Uygulama
```bash
cd src/BackendFirstStage.Api
dotnet ef database update --project ../BackendFirstStage.Infrastructures --startup-project .
```

#### PowerShell Script Kullanımı
```bash
# Environment variable'ı set ettikten sonra
.\run-migrations.ps1
```

### Troubleshooting

**Hata: "Unable to resolve service for type 'DbContextOptions'"**
- Environment variable'ın doğru set edildiğinden emin olun
- `appsettings.Development.json` dosyasında fallback connection string olduğunu kontrol edin
- `AppDbContextFactory` sınıfının doğru yapılandırıldığından emin olun

**Hata: "Connection string is not configured"**
- `MsSqlServer` environment variable'ını set edin
- Veya `appsettings.json` dosyasında `DefaultConnection` değerini güncelleyin