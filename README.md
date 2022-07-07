
#  TELEPERFORMANCE & Patika.Dev .NET Bootcamp Bitirme Projesi

Bu Proje 183. Teleperformance & Patika.Dev .Net Bootcamp sonunda verilen Shopping List  projesini içermektedir.


### Proje Tanımı

Kayıt olan kullanıcılar *User* rolü ile kategori bazlı liste oluşturabilir, silebilir, güncelleyebilir,listeye ürün ekleyebilir veya liste adı,kategori adı,oluşturulma tarihine göre liste aratabilir. Sadece *Admin* olarak giriş yapan kullanıcı ise bütün listeleri ve tamamlanmış listeleri görebilir.

***Postman*** yada ***Swagger*** ile kullanılan *Rest API* projesinde verileri saklamak için veri tabanı olarak ***MS SQL***, .Net ile bağlantı için *orm* olarak ***EntityFramework Core*** 
kullanılmıştır. *Admin* kullanıcısı *Kategoriler* ve *Roller* *seed data* *ef core* aracılığıyla eklenmiştir.

Tamamlanma durumları *ısComplete* endpoint'i üzerinden *true* olarak güncellenen listeler ***Rabbitmq*** kuyruk sistemine eklenmektedir.
***Worker service*** üzerinden sürekli dinlenen kuyruk yapımız tamamlanan listeleri ***MongoDb*** veri tabanına eklenmektedir. Ayrıca *global exception custom middleware* üzerinden ayrı bir *Logs* klasöründe *text* dosyaları halinde günlük olarak tutulmaktadır. 

Projede *distrubuted cache* için ***Redis***, *rol tabanlı yetkilendirme ve kısıtlama yetkilendirme için ***Identity ve JWT bearer***,  *validation* için ***FluentValidation***,
*log* için ***SeriLog*** kütüphanleri , *Redis* ve *Rabbitmq* ***Docker image*** üzeriden, *Ms Sql* ve *Mongodb* lokal olarak kullanılmıştır.

Kurumsal mimari ve Clean Architecture için Onion Architecture mimarisi , CQRS ve MediatR kütüphaneleri kullanılmıştır.

___
## Kullanılan Yöntem ve Teknolojiler
* ***.NET 6.0 Web API***
 * ***Microsoft SQL***
 * ***MongoDb***
 * ***Entity Framework***
 * ***Rabbitmq***
 * ***Redis***
 * ***Automapper***
 * ***Fluent Validation***
 * ***Identity & JWT Bearer Tokens***
 * ***SeriLogger***
 * ***CQRS***
 * ***MediatR***
 * ***Onion Architecture***
 * ***Repository Pattern***
 * ***SOLID Principles***
 * ******
 
___

## Projeyi Geliştirici Ortamında Çalıştırmak İçin

### Ön Gereksinimler
* Visual Studio 2020+
* Microsoft SQL Server 2019+
* .Net 6.0

### Çalıştırılması
Local klasöre projeyi klonlamak için :
```
 git clone https://github.com/186-Teleperformans-Net-Bootcamp/ShoppingListProject-sercan-iyili
```
Projeyi build ederek gerekli veritabanları aşağıdaki komut ile oluşturulabilir.
```
 update-database
```
