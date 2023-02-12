# OrderManagementAPI
ASP.NET Core WebAPI

# Order Management API Docs

Bu uygulamada, Monolithic Software Design yapı kullanılıp N-Tier Architecture (Entities,DataAccess,Business,UI,Core) üzerine tasarlanmıştır. Uygulama geliştirmeye açık olmaması sebebi ile referans tipin etkinliğinden faydalanmıştır. 

Uygulamamız, SOLID Prensipleri ile geliştirilmiş,OOP teknikleri ayrıca Design Pattern'ler,Delegate'ler ve Reflection aktif olarak kullanılmıştır.






## Solid Principles & Application Level Usage

**Single Responsibility Principle:** Uygulamamızın Business Katmanın'da gerekli İş Kuralları ile Validation'lar ayrıştırılmıştır. Ve burada bir Entity doğrulaması yaparken bunu Entity Katmanın'da bulunan property Attribute ile değil de Aspect'lerle sağlanmıştır.

**Open-Closed Principle:** Bu prensibi en etkin olarak DataAccess katmanında görmekteyiz. Uygulama içerisinde herhangi ORM değişikliğinde alt yapımız hazır olduğu için herhangi bir katman'da değişiklik yapmadan direkt olarak farklı bir 

**Dependency Inversion Principle:** Bu prensibi çeşitli tekniklerle projemizde görmekteyiz. İlk olarak referans tiplerin yer tutucu özelliği ile Constructor içerisinde Injection yaparak uygulamasını görmeyiz. Ancak burada bizim ihtiyacımız olan somut nesneler olduğu için 3 çeşit bağımlılık yöntemi bulunmaktadır. Custom oluşturduğumuz yapı (Core.Utilities.IoC > ServiceTools methodu içerisinde IServiceCollection) ile, ya da Aspect yapımızı sağlayan Autofac ile, ya da .Net Core'un bize sağladığı built-in (Singleton,Transient,Scoped) yapılardan Dependency Chain oluşturmanın önüne geçerek burada çözümlememizi yapabilmekteyiz.

## OOP Techniques & Application Level Usage

**Polymorphism:** Bu tekniği en etkin olarak proje içersinde İş Kuralı oluştururken kullanımı gördük, Çünkü iş kuralları içerisinde bir true/false dönen bool bir Result ararız. Ancak bunu bir CleanCode Tekniği ile bir method alabildiği kadar parametler ile sonucumuzu alabiliyoruz. (Core.Utilities.Business > BusinessRules Class'ı içerisindeki Run Methodu bizlere bu yapıyı sağlamaktadır.)

**Encapsualtion:** Uygulama içerisinde Result Management yaptığımız Core Modülü içerisinde; normalde bir method bir değer döner; Ancak method'a birden çok değer döndürmesini istiyorsak Örneğin; hem Data bilgisi ve Result bilgisi bunun için kullandığımız yapı IDataResult dönüş değerli methodlardır ve burada Encapsualtion uygulanmıştır.







  
## Application Technologies

Uygulama Katmanları `.NET Standart v2.0 Class Library` ile geliştirmiş olup; .NET/.NET Core için gerekli uyumluluğu sağlıyor olması her platformda tüketilmesini sağlamaktadır.

ORM olarak, projemizde `Entity Framework Core` kullanılmıştır.

WebAPI'miz `.NET Core 3.1`'dir

  
## Başlarken 

Uygulama'yı başlatırken;

```bash 
  add-migration <new_migration_mymigration>
  update-database
```
Projeniz'de gerekli paketlerin yüklü olduğundan emin olduktan sonra; build alınız ve proje sizi Swagger'ın başlangıç ekranına yönlendirecektir. Aşağıdaki `Swagger` URL verilmiştir:
NOT: Burada `localhost`'unuzu kontrol ediniz.
```bash 
  https://localhost:44361/index.html
```

    
## API Kullanımı

#### Authorize (Register)

```http
  POST /api/auth/register
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| **firstName**,**lastName**,**email**,**password** | `JSON` | Parametreleri lütfen giriniz. |

#### Authentication (Login)

```http
  POST /api/auth/login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| **email**,**password**  | `JSON` | Parametreleri lütfen giriniz. |


#### Tüm öğeleri getir

```http
  GET /api/orders/getall
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
|  | `JSON` | Parametre Gerektirmez |

#### Öğeyi getir

```http
  GET /api/orders/getbyid?orderId=${id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `JSON` | Lütfen **ıd** parametre değerini atayınız |


#### Öğeyi ekle

```http
  POST /api/orders/add
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `entity`      | `JSON` | Lütfen ekleme **sipariş bilgilerini** parametre olarak atayınız |

#### Öğeyi güncelle
```http
  POST /api/orders/update
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `entity`      | `JSON` | Lütfen güncelleme yapmak için **sipariş bilgilerini** parametre olarak atayınız |

#### Öğeyi silme
```http
  POST /api/orders/delete
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `entity`      | `JSON` | Lütfen silme yapabilmek için **sipariş bilgilerini** parametre olarak atayınız |


  
