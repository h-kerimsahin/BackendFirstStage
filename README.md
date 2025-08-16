# BackendFirstStage

Bu proje, .NET 9.0 kullanılarak geliştirilmiş bir backend API projesidir. Clean Architecture pattern'i kullanılarak tasarlanmıştır.

## 🏗️ Proje Yapısı

```
BackendFirstStage/
├── src/
│   ├── BackendFirstStage.Api/          # Web API katmanı
│   ├── BackendFirstStage.Applications/ # Uygulama servisleri ve DTO'lar
│   ├── BackendFirstStage.Domain/       # Domain entities ve exceptions
│   └── BackendFirstStage.Infrastructures/ # Veritabanı ve repository implementasyonları
└── BackendFirstStage.sln
```

## 📋 Gereksinimler

- **.NET 9.0 SDK** - [İndirme Linki](https://dotnet.microsoft.com/download/dotnet/9.0)
- **SQL Server** - LocalDB, Express veya Full Edition
- **Visual Studio 2022** veya **Visual Studio Code** (önerilen)
- **Entity Framework Core Tools**

## 🚀 Kurulum Adımları

### 1. Projeyi Klonlama
```bash
git clone <repository-url>
cd BackendFirstStage
```

### 2. .NET SDK Kontrolü
```bash
dotnet --version
# .NET 9.0.x olmalı
```

### 3. Entity Framework Tools Kurulumu
```bash
dotnet tool install --global dotnet-ef
```

### 4. NuGet Paketlerini Restore Etme
```bash
dotnet restore
```

### 5. Veritabanı Bağlantı Ayarları

#### Environment Variable ile (Önerilen)
```bash
# Windows PowerShell
$env:MsSqlServer = "Server=localhost;Database=BackendFirstStageDb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"

# Windows Command Prompt
set MsSqlServer=Server=localhost;Database=BackendFirstStageDb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true

# Linux/macOS
export MsSqlServer="Server=localhost;Database=BackendFirstStageDb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
```

#### Alternatif: appsettings.json ile
`src/BackendFirstStage.Api/appsettings.json` dosyasında connection string'i güncelleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BackendFirstStageDb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
  }
}
```

### 6. Veritabanı Migration'ları

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

### 7. Projeyi Çalıştırma
```bash
cd src/BackendFirstStage.Api
dotnet run
```

API varsayılan olarak şu adreslerde çalışacaktır:
- **HTTP**: `http://localhost:5114`
- **HTTPS**: `https://localhost:7153`

## �� API Endpoints

### Health Controller
- **GET** `/health` - API sağlık durumu

### Product Controller
- **POST** `/api/product` - Yeni ürün ekleme
- **GET** `/api/product` - Tüm ürünleri listeleme
- **GET** `/api/product/{id}` - ID ile ürün detay bilgisi
- **DELETE** `/api/product/{id}` - Ürün silme

### Error Test Controller
- **GET** `/api/errortest/not-found` - NotFoundException test
- **GET** `/api/errortest/validation-error` - ValidationException test
- **GET** `/api/errortest/general-error` - Genel Exception test
- **GET** `/api/errortest/divide-by-zero` - DivideByZeroException test
- **GET** `/api/errortest/argument-null` - ArgumentNullException test

## 🧪 Test Etme

### Ana Sayfa Testi
Proje çalıştıktan sonra tarayıcınızda şu adresi ziyaret edin:
```
http://localhost:5114/
```

### Swagger UI
Proje çalıştıktan sonra tarayıcınızda şu adresleri ziyaret edin:
```
http://localhost:5114/swagger
https://localhost:7153/swagger
```

### HTTP Test Dosyası
`BackendFirstStage.Api.http` dosyası ile API endpoint'lerini test edebilirsiniz. Dosyada host adresini doğru porta göre güncellemeyi unutmayın.

## 🔧 Geliştirme

### Proje Yapısı
- **Domain Layer**: Entities, exceptions ve domain logic
- **Application Layer**: Services, DTOs ve business logic
- **Infrastructure Layer**: Database context, repositories ve external services
- **API Layer**: Controllers ve middleware

### Yeni Migration Ekleme
```bash
cd src/BackendFirstStage.Api
dotnet ef migrations add <MigrationName> --project ../BackendFirstStage.Infrastructures --startup-project .
```

### Veritabanını Güncelleme
```bash
cd src/BackendFirstStage.Api
dotnet ef database update --project ../BackendFirstStage.Infrastructures --startup-project .
```

## 🐛 Troubleshooting

### Yaygın Hatalar

**"Unable to resolve service for type 'DbContextOptions'"**
- Environment variable'ın doğru set edildiğinden emin olun
- `appsettings.Development.json` dosyasında fallback connection string olduğunu kontrol edin

**"Connection string is not configured"**
- `MsSqlServer` environment variable'ını set edin
- Veya `appsettings.json` dosyasında `DefaultConnection` değerini güncelleyin

**"Database does not exist"**
- Migration'ları uygulayın: `dotnet ef database update`
- SQL Server'ın çalıştığından emin olun

**"Port already in use"**
- Farklı bir port kullanın veya mevcut portu kullanan uygulamayı durdurun
- Varsayılan portlar: HTTP 5114, HTTPS 7153

**"404 Not Found" hatası**
- Proje çalışıyor mu kontrol edin: `dotnet run`
- Swagger UI'ı test edin: `http://localhost:5114/swagger`
- Ana sayfayı test edin: `http://localhost:5114/`

## 📝 Notlar

- Global exception handling middleware aktif
- Entity Framework Core 9.0 ile Code-First yaklaşımı
- Clean Architecture pattern kullanılmış
- Async/await pattern tüm servislerde uygulanmış
- .NET 9.0 Preview sürümü kullanılmış
- Swagger UI entegrasyonu mevcut
- Root path (/) için HomeController eklendi

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit yapın (`git commit -m 'Add some AmazingFeature'`)
4. Push yapın (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje [MIT License](LICENSE) altında lisanslanmıştır.