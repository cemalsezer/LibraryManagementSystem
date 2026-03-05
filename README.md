
# 📚 .NET MVC Kütüphane Yönetim Sistemi

Bu proje, kütüphanelerin kitap, kullanıcı ve kategori yönetimi gibi temel operasyonlarını dijitalleştirerek kolaylaştırmayı amaçlayan bir **MVC tabanlı web uygulamasıdır**.

## 🌟 Demo ve GitHub Bağlantıları

- **Live**: [http://librarymanagement.somee.com/ShowCase/Index/](http://librarymanagement.somee.com/ShowCase/Index/)  
- **GitHub**: [https://github.com/cemalsezer/LibraryManagementSystem](https://github.com/cemalsezer/LibraryManagementSystem)

---

## 🎯 Proje Özellikleri

- **Kategori Yönetimi**: Kütüphane kategorilerini ekleme, düzenleme ve silme.
- **Kitap Yönetimi**: Kitapların ödünç alma ve iade süreçlerini yönetme.
- **Kullanıcı Yönetimi**: Kullanıcı bilgilerini ekleme, düzenleme ve listeleme.
- **Soft Delete Desteği**: Verilerin güvenli şekilde arka planda saklanması.
- **Vitrin Paneli**: Kullanıcılar için kitap ve kategori listelerini görüntüleme.
- **Admin Paneli**: Kütüphane yöneticileri için kategori ve kitap yönetimi.
- **Responsive Tasarım**: Mobil ve masaüstü cihazlarla uyumlu bir kullanıcı arayüzü.

---

## 🛠️ Kullanılan Teknolojiler

- **ASP.NET MVC Framework**: Projenin temel yapısı.
- **Entity Framework**: Veritabanı yönetimi ve sorgulamaları.
- **LINQ**: Veri manipülasyonu ve sorgulama.
- **MS SQL Server**: Veritabanı altyapısı.
- **Bootstrap**: Arayüz tasarımı ve duyarlı yapı.
- **CSS & HTML5**: Görsel düzenlemeler ve yapısal kodlama.

---

## 🚀 Nasıl Çalıştırılır?

### Gerekli Ön Koşullar
1. **Visual Studio**: Projenin çalıştırılması için gerekli IDE.
2. **MS SQL Server**: Veritabanı sunucusu.
3. **.NET Framework 4.8 veya üzeri**: Projenin ihtiyaç duyduğu framework.

### Çalıştırma Adımları
1. **Proje Dosyalarını Klonlayın**:
   ```bash
   git clone https://github.com/cemalsezer/LibraryManagementSystem.git
   ```
2. **Visual Studio ile Açın**:
   - `LibraryManagementSystem.sln` dosyasını açın.
3. **Veritabanı Bağlantısını Yapılandırın**:
   - `Web.config` dosyasındaki `connectionString` değerini kendi SQL Server bağlantınıza uygun şekilde güncelleyin.
4. **Veritabanını Güncelleyin**:
   - `Package Manager Console`da aşağıdaki komutu çalıştırarak veritabanını oluşturun:
     ```bash
     Update-Database
     ```
5. **Proje Çalıştırın**:
   - Visual Studio'da `IIS Express` veya kendi sunucunuzda çalıştırın.

---

## 📂 Proje Dosya Yapısı

- **Controllers**: İş mantığını kontrol eden sınıflar.
- **Models**: Veritabanı modelleri ve iş sınıfları.
- **Views**: Kullanıcı arayüzüne dair Razor sayfaları.
- **Scripts**: Bootstrap ve diğer JS kütüphaneleri.

---

