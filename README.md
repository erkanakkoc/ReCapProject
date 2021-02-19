![racp](https://user-images.githubusercontent.com/51466724/108199343-ea1a6f00-712d-11eb-8a5f-1e58784efd2a.jpg)

It's a simple rent a car project. But it will be professional with new updates.

Here is the list that you can make with this project right now;

  - CRUD for Cars, Colors, Brands, Users, Customers and Rentals
  - Working with a real DB
  - EntityFramework files added
  - IEntity, IDto, IEntityRepository, EfEntityRepositoryBase added
  - Core Layer added 
  - Real-time queries with your inputs
  - WebAPI added
  - Controllers added (CarsController, BrandsController, ColorsController, CustomersController, UsersController, RentalsController)
  - All functions of Business Layers added to Controllers

 
# New Features!

## Version 1.8.1
- Autofac ✔
- New Rules(Model Year Must Be Between 1900-2099, ReturnDate Can't Be Early Date Than RentalDate) ✔
- FluentValidation (UserValidator, CarValidator, RentalValidator) ✔
- ValidationAspect ✔
- AOP ✔
- Tested on Postman ✔


## LAYERS

### 1) Business Layer
#### - Concrete Classes
1. [CarManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/CarManager.cs)
2. [BrandManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/BrandManager.cs)
3. [ColorManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/ColorManager.cs)
4. [CustomerManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/CustomerManager.cs)
5. [UserManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/UserManager.cs)
6. [RentalManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/RentalManager.cs)
  
#### - Abstract Classes
1. [ICarService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/ICarService.cs)
2. [IBrandService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/IBrandService.cs)
3. [IColorService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/IColorService.cs)
4. [ICustomerService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/ICustomerService.cs)
5. [IUserService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/IUserService.cs)
6. [IRentalService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/IRentalService.cs)

#### - Constants Classes
1. [Messages.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Constants/Messages.cs)

#### - DependencyResolvers
1. [AutofacBusinessModule.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/DependencyResolvers/Autofac/AutofacBusinessModule.cs)

#### - FluentValidation
1. [CarValidator.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/ValidationRules/FluentValidation/CarValidator.cs)
2. [RentalValidator.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/ValidationRules/FluentValidation/RentalValidator.cs)
3. [UserValidator.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/ValidationRules/FluentValidation/UserValidator.cs)


### 2) DataAccess Layer
#### - EntityFramework
1. [EfCarDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfCarDal.cs)
2. [EfBrandDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfBrandDal.cs)
3. [EfColorDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfColorDal.cs)
4. [EfCustomerDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfCustomerDal.cs)
5. [EfUserDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfUserDal.cs)
6. [EfRentalDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfRentalDal.cs)
7. [RentACarDbContext.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/RentACarDbContext.cs)

#### - InMemory
1. [InMemoryCarDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryCarDal.cs)
2. [InMemoryBrandDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryBrandDal.cs)
3. [InMemoryColorDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryColorDal.cs)
4. [InMemoryCustomerDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryCustomerDal.cs)
5. [InMemoryUserDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryUserDal.cs)
6. [InMemoryRentalDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryRentalDal.cs)

#### - Abstract Classes
1. [ICarDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/ICarDal.cs)
2. [IBrandDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IBrandDal.cs)
3. [IColorDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IColorDal.cs)
4. [ICustomerDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/ICustomerDal.cs)
5. [IUserDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IUserDal.cs)
6. [IRentalDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IRentalDal.cs)
7. [IEntityRepository.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IEntityRepository.cs)

### 3) Entities Layer
#### - Concrete Classes
1. [Car.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Car.cs)
2. [Brand.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Brand.cs)
3. [Color.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Color.cs)
4. [Customer.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Customer.cs)
5. [User.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/User.cs)
6. [Rental.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Rental.cs)

#### - Abstract Classes
1. [IEntity.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Abstract/IEntity.cs)

#### - DTOs Classes
1. [CarDetailDto.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Abstract/CarDetailDto.cs)
2. [RentalDetailDto.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Abstract/RentalDetailDto.cs)

### 4) Core Layer
#### - DataAccess
1. [IEntityRepository.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/DataAccess/IEntityRepository.cs)
2. [EfEntityRepositoryBase.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/DataAccess/EntityFramework/EfEntityRepositoryBase.cs)

#### - Entities
1. [IDto.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/Entities/IDto.cs)
2. [IEntity.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/Entities/IEntity.cs)

#### - Utilities
##### - Interceptors
1. [AspectInterceptorSelector.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/Utilities/Interceptors/AspectInterceptorSelector.cs)
2. [MethodInterception.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/Utilities/Interceptors/MethodInterception.cs)
3. [MethodInterceptionBaseAttribute.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/Utilities/Interceptors/MethodInterceptionBaseAttribute.cs)

#### - CrossCuttingConcerns
1. [ValidationTool.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/CrossCuttingConcerns/Validation/ValidationTool.cs)


#### - Aspects
1. [ValidationAspect.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Core/Aspects/Autofac/Validation/ValidationAspect.cs)


### 5) ConsoleUI
1. [Program.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/ConsoleUI/Program.cs)


## SQL Tables
![rcp](https://user-images.githubusercontent.com/51466724/108183763-7b341a80-711b-11eb-9f84-110b0998e560.jpg)

## OUTPUT

![output1](https://user-images.githubusercontent.com/51466724/108192079-e0403e00-7124-11eb-8e0c-bbe5de49be71.jpeg)
