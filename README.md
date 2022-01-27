
## 3. Hafta Ödev + Week 2 WebApi Improvement(CQRS,Generic Repository) + CleanArch
**Her bölümde yapılan işlemler hakkındaki açıklamaları aşağıda aşama aşama bulabilirsiniz.**

1. Patikadev yapısını düşünerek bir db oluşturun
  - eğitimler, öğrenciler,katılımcılar,eğitmenler,asistanlar, eğitimde öğrencilerin yoklamalarının ve başarı durumlarının tutulduğu tablolar olacaktır.
  - veritipleri ve ilişkiler belirtilmelidir.
2. trigger yazın
  - öğrenci yoklaması girildiğinde. yoklama durumuna göre başarı durumunu hafta bazlı olarak güncelleyin.(Örn: eğitim 7 hafta olsun. ilk iki hafta derslere katıldı ise başarı oranı 2/7 nin % olarak karşılı olmalı.)
3. stored procedure yazın
  - öğrencileri eğitimlere ekleyen bir procedure olacak. öğrenci belirtilen eğitim tarihinde herhangi başka bir eğitime kayıtlı olmamalıdır.
4. view yazın
  - eğitim bazlı öğrencileri listeleyin(gruplu olarak)

# Bonus
- Aynı yapıyı ef code first olarak sadece model bazında oluşturun

<hr>

## 3. Hafta Ödev
1.  Veri tabanının tabloları oluşturuldu ve tablolar arası ilişkiler oluşturuldu. Aşağıdaki diagramdan inceleyebilirisiniz.
![Diagram](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/BarisTutakli.Week3/blob/main/Diagram0.png?raw=true)
2. UpdateStudentSuccessStatusWeekly isimli Trigger oluşturuldu.
3. SP_RegisterNewStudent adlı store proc oluşturuldu.
4. OrderByCourseId ve ListStudentDetails adlı iki view oluşturuldu.
5. Backup dosyası yüklendi.
<hr>

## WebApi Improvement(CQRS,Generic Repository)

### Generic Repository Pattern
To apply gerenric repository, i created 5 interfaces and 5  implementation of these interfaces. Each class has only one responsibility. I created separated files because of single responsibility principle. 

#### Common/Base
These are generic interfaces:
* IRead
* ICreate
* IReadAll
* IUpdate
* IDelete
##### Common/Base/Concrete
These are implementations of the interfaces above:
* BaseReadRepository
* BaseCreateRepository
* BaseReadAllRepository
* BaseUpdateRepository
* BaseDeleteRepository

For instance, you can see one of the interfaces below
```c#
    public interface ICreate<TEntity> where TEntity : BaseEntity
    {
        int Create(TEntity entity);
    }
```

### CQRS(Command and Query Responsibility Segragation)
In the directory of ProductOperations, i created following folders and classes:
* Commands
   1. Request
   2. Response
* Queries
   1. Request
   2. Response
* Handlers
   1. CommandHandlers
   2. QueryHandlers

```c#
   public class CreateProductCommandHandler
    {
        public CreateProductCommandRequest Model { get; set; }
        private readonly BaseCreateRepository<Product, ECommerceDbContext> _createRepository;
        // Used dependency injection in constructor
        public CreateProductCommandHandler(BaseCreateRepository<Product, ECommerceDbContext> baseCreateRepository)
        {
            _createRepository = baseCreateRepository;
        }

        // If a product does not already exist, this function save it.
        public CreateProductCommandResponse Handle(CreateProductCommandRequest request)
        {
            Model = request;
            var createdProductId = _createRepository.Create(new Product()
            {
                CategoryId = Model.CategoryId,
                ProductName = Model.ProductName,
                PublishDate = Model.PublishDate,
                CreatedDate = DateTime.Now
            });
            // Return product ıd and success message
            return createdProductId > 0 ? new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = createdProductId
            } : new CreateProductCommandResponse
            {
                IsSuccess = false,
            };
        }
    }
```
### Extendent IServicesCollection
I extended IServiceCollection by creating a static class and static in **Services** folder. I added all the other required processes using the dependency injection method in ProductController.
```c#
public static void AddServices(this IServiceCollection services)
    {

        services.AddScoped<BaseReadAllRepository<Product, ECommerceDbContext>>();
        services.AddScoped<GetProductsQueryHandler>();

        services.AddScoped<BaseReadRepository<Product, ECommerceDbContext>>();
        services.AddScoped<GetProductDetailQueryHandler>();

        services.AddScoped<BaseCreateRepository<Product, ECommerceDbContext>>();
        services.AddScoped<CreateProductCommandHandler>();

        services.AddScoped<BaseDeleteRepository<Product, ECommerceDbContext>>();
        services.AddScoped<DeleteProductCommandHandler>();

        services.AddScoped<BaseUpdateRepository<Product, ECommerceDbContext>>();
        services.AddScoped<UpdateProductCommandHandler>();

        
}
```


## CleanArch Project 
I started **CleanArch** project and created Application and API layer. 
