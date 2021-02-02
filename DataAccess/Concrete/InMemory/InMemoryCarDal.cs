using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //Global değişken olduğu için _ koyuyoruz
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=59.90M, ModelYear=2000, Description="Minimum 3 günlük kiralanabilir"}
            new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=64.90M, ModelYear=2005, Description="Minimum 3 günlük kiralanabilir"}
            new Car{Id=3, BrandId=2, ColorId=3, DailyPrice=69.90M, ModelYear=2005, Description="Minimum 3 günlük kiralanabilir"}
            new Car{Id=4, BrandId=3, ColorId=2, DailyPrice=89.90M, ModelYear=2020, Description="Minimum 3 günlük kiralanabilir"}
            new Car{Id=5, BrandId=4, ColorId=4, DailyPrice=79.90M, ModelYear=2015, Description="Minimum 3 günlük kiralanabilir"}

            };

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
    }
}
