
# 3. Hafta Ödev 
Veritabanı 
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

## WebApi Improvement(CQRS,Generic Repository, MediatR)

### Generic Repository Pattern
To apply gerenric repository, i created 5 interfaces and 5  implementation of these interfaces. Each class has only one responsibility. Separating classes acording to their responsibilities lets us to use them separetly.

#### Common/Base
##### Common/Base/Abstract
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
### Mediatr Pattern(manually)
I extended IServiceCollection by creating a static class and static method named **CustomMediatR** in **Services** folder. I added all the other required processes using the dependency injection method in ProductController.
