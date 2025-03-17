# E-ticaret Projesi

Bu proje, bir e-ticaret uygulamasının temel işlevlerini sağlamayı amaçlayan bir .NET 7.0 web API'sidir.

## İçindekiler

- [Proje Açıklaması](#proje-açıklaması)
- [Kurulum](#kurulum)
- [Çalıştırma](#çalıştırma)
- [Bağımlılıklar](#bağımlılıklar)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)
- [package.json ve requirements.txt Açıklaması](#packagejson-ve-requirementstxt-açıklaması)
- [Yapılandırma Dosyası Açıklaması](#yapılandırma-dosyası-açıklaması)
- [API Referansı](#api-referansı)

## Proje Açıklaması

Bu depo, bir e-ticaret platformunun back-end'ini uygulamak için tasarlanmış bir .NET 7.0 Web API projesi içermektedir. Ürün yönetimi, kategori yönetimi, müşteri yönetimi, sipariş yönetimi ve kimlik doğrulama gibi temel özellikleri içerir. Amaç, ölçeklenebilir, bakımı kolay ve güvenli bir e-ticaret API'si sağlamaktır.

## Kurulum

1.  Depoyu klonlayın:

    ```bash
    git clone https://github.com/muhammetalifidan/E-commerceProject.git
    ```

2.  .NET 7.0 SDK'sını yükleyin:
    [.NET 7.0 SDK'sını indirin](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

3. Veritabanı bağlantı dizesini yapılandırın:
    *   `DataAccess/Concrete/EntityFramework/NorthwindContext.cs` dosyasını açın.
    *   `OnConfiguring` metodunda, `optionsBuilder.UseSqlServer()` içinde veritabanı bağlantı dizesini uygun şekilde düzenleyin.

    ```csharp
    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
    ```

4.  `appsettings.json` dosyasında JWT token ayarlarını yapılandırın.

    ```json
    "TokenOptions": {
      "Audience": "your_audience",
      "Issuer": "your_issuer",
      "AccessTokenExpiration": 10,
      "SecurityKey": "your_security_key"
    }
    ```

## Çalıştırma

1.  WebAPI projesinin bulunduğu dizine gidin:

    ```bash
    cd WebAPI
    ```

2.  Projeyi çalıştırın:

    ```bash
    dotnet run
    ```

    Bu komut, uygulamayı yerel olarak başlatacak ve swagger arayüzüne `https://localhost:7255/swagger` veya `http://localhost:5028/swagger` adresinden erişebilirsiniz.

## Bağımlılıklar

*   **Microsoft.NET.SDK** (.NET 7.0)
*   **Autofac** (7.0.1, 8.0.0, 6.0.1): Bağımlılık enjeksiyonu.
*   **FluentValidation** (11.5.2): Veri doğrulama.
*   **Microsoft.AspNetCore.Http.Abstractions** (2.2.0): HTTP soyutlamaları.
*   **Microsoft.EntityFrameworkCore** (7.0.5): ORM aracı.
*   **Microsoft.EntityFrameworkCore.SqlServer** (7.0.5): SQL Server sağlayıcısı.
*   **Microsoft.Extensions.Configuration** (7.0.0): Yapılandırma sistemi.
*   **Microsoft.Extensions.Configuration.Binder** (7.0.4): Yapılandırma bağlayıcısı.
*   **Microsoft.Extensions.Identity.Core** (7.0.5): Kimlik yönetimi.
*   **Microsoft.IdentityModel.Tokens** (6.30.1): JWT token işlemleri.
*   **Newtonsoft.Json** (13.0.3): JSON serileştirme ve deserializasyon.
*   **System.IdentityModel.Tokens.Jwt** (6.30.1): JWT token işlemleri.

## Katkıda Bulunma

Katkılar memnuniyetle karşılanır! Lütfen katkıda bulunmadan önce aşağıdaki adımları izleyin:

1.  Projeyi fork edin.
2.  Yeni bir branch oluşturun (`git checkout -b feature/yenilik`).
3.  Değişikliklerinizi commit edin (`git commit -am 'feat: Yeni özellik eklendi'`).
4.  Branch'inizi remote'a push edin (`git push origin feature/yenilik`).
5.  Pull Request gönderin.

## Yapılandırma Dosyası Açıklaması

### appsettings.json

Bu dosya, uygulama ayarlarını içerir. En önemli bölümü `TokenOptions` bölümüdür.

*   `Audience`: JWT token'ın hedef kitlesi.
*   `Issuer`: JWT token'ı yayınlayan kişi.
*   `AccessTokenExpiration`: Access token'ın dakika cinsinden geçerlilik süresi.
*   `SecurityKey`: JWT token'ı imzalamak için kullanılan güvenlik anahtarı.

```json
{
  "TokenOptions": {
    "Audience": "engin@engin.com",
    "Issuer": "engin@engin.com",
    "AccessTokenExpiration": 10,
    "SecurityKey": "mysupersecretkeymysupersecretkeymysupersecretkeymysupersecretkey"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## API Referansı

Aşağıda, projedeki bazı API uç noktalarının referansı bulunmaktadır:

| Uç Nokta           | Metod | Parametreler                 | Açıklama                                                       | Tip      |
| ------------------ | ----- | ---------------------------- | ------------------------------------------------------------- | -------- |
| `api/auth/login`    | POST  | `UserForLoginDto` (`Email`, `Password`) | Kullanıcının giriş yapmasını sağlar.                                 | JSON     |
| `api/auth/register` | POST  | `UserForRegisterDto` (`Email`, `Password`, `FirstName`, `LastName`) | Yeni bir kullanıcı kaydeder.                                       | JSON     |
| `api/products/add`  | POST  | `Product` (`CategoryId`, `ProductName`, `UnitsInStock`, `UnitPrice`) | Yeni bir ürün ekler.                                               | JSON     |
| `api/products/getbyid` | GET  | `id` (int)                                   | Belirli bir ID'ye sahip bir ürünü getirir.                                    | Query Parameter |
| `api/products/getall`  | GET  |                                   | Tüm ürünleri getirir.                                    |  |
| `api/products/getbycategory`  | GET  | `categoryId` (int)                                   | Tüm ürünleri belirtilen kategoriye göre getirir.                                    | Query Parameter |
| `api/categories/add`  | POST  | `Category` (`CategoryName`)                                   | Yeni bir kategori ekler.                                    | JSON |
| `api/categories/getbyid`  | GET  | `id` (int)                                   | Belirli bir ID'ye sahip bir kategoriyi getirir.                                    | Query Parameter |
| `api/categories/getall`  | GET  |                                   | Tüm kategorileri getirir.                                    |  |
| `api/customers/add`  | POST  | `Customer` (`CustomerId`, `ContactName`, `CompanyName`, `City`)                                   | Yeni bir müşteri ekler.                                    | JSON |
| `api/customers/getbyid`  | GET  | `id` (string)                                   | Belirli bir ID'ye sahip bir müşteriyi getirir.                                    | Query Parameter |
| `api/customers/getall`  | GET  |                                   | Tüm müşterileri getirir.                                    |  |
| `api/orders/add`  | POST  | `Order` (`CustomerId`, `EmployeeId`, `OrderDate`, `ShipCity`)                                   | Yeni bir sipariş ekler.                                    | JSON |
| `api/orders/getbyid`  | GET  | `id` (int)                                   | Belirli bir ID'ye sahip bir siparişi getirir.                                    | Query Parameter |
| `api/orders/getall`  | GET  |                                   | Tüm siparişleri getirir.                                    |  |
