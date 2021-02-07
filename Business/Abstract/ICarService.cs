using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        Car GetById(int carId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetByModelYear(string modelYear);
        List<CarDetailDto> GetCarDetails();
    }
}
