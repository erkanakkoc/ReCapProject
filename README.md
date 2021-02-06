# Rent A Car Project

It's a simple rent a car console project. But it will be professional with new updates.

Here is the list that you can make with this project right now;

  - CRUD for Car, Color, Brand
  - Working with a real DB
  - Real-time queries with your inputs (GetCarsByBrandID, GetCarsByColorId, GetByModelYear, GetByDailyPrice, GetById)
  - New adding rules (DailyPrice, BrandName)
 
# New Features!

## Version 1.4.1
- Connection to Db ✔
- EntityFramework files added ✔
- Added GetByBrandId, GetByColorId, GetByModelYear, GetByDailyPrice Queries in [Program.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/ConsoleUI/Program.cs) file ✔
- Visual Updated ✔
- New Car's DailyPrice must be higher than 0 ✔
- New Brand's Name must be longer than 2 letter ✔


## LAYERS

### 1) Business Layer
#### - Concrete Classes
1. [CarManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/CarManager.cs)
2. [BrandManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/BrandManager.cs)
3. [ColorManager.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Concrete/ColorManager.cs)
  
#### - Abstract Classes
1. [ICarService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/ICarService.cs)
2. [IBrandService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/IBrandService.cs)
3. [IColorService.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Business/Abstract/IColorService.cs)

### 2) DataAccess Layer
#### - EntityFramework
1. [EfCarDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfCarDal.cs)
2. [EfBrandDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfBrandDal.cs)
3. [EfColorDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfColorDal.cs)
4. [RentACarDbContext.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/RentACarDbContext.cs)

#### - InMemory
1. [InMemoryCarDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryCarDal.cs)
2. [InMemoryBrandDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryBrandDal.cs)
3. [InMemoryColorDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Concrete/InMemory/InMemoryColorDal.cs)

#### - Abstract Classes
1. [ICarDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/ICarDal.cs)
2. [IBrandDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IBrandDal.cs)
3. [IColorDal.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IColorDal.cs)
4. [IEntityRepository.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/DataAccess/Abstract/IEntityRepository.cs)

### 3) Entities Layer
#### - Concrete Classes
1. [Car.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Car.cs)
2. [Brand.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Brand.cs)
3. [Color.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Concrete/Color.cs)

#### - Abstract Classes
1. [IEntity.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/Entities/Abstract/IEntity.cs)



### 4) ConsoleUI
1. [Program.cs](https://github.com/erkanakkoc/ReCapProject/blob/master/ConsoleUI/Program.cs)


## SQL Tables

#### Brands
Variable Name | Data Type
------------ | -------------
BrandId | int
BrandName | nvarchar(15)

#### Cars
Variable Name | Data Type
------------ | -------------
CarId | int
BrandId | int
ColorId | int
ModelYear | nvarchar(5)
DailyPrice | decimal
Description | nvarchar(255)

#### Colors
Variable Name | Data Type
------------ | -------------
ColorId | int
ColorName | nvarchar(15)

