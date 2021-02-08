using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            //TryAgain:
            //if (car.DailyPrice>0 && car.CarName.Length>2)  //Both turns true
            //{
            //    _carDal.Add(car);
            //    Console.WriteLine("Car Id: " +car.CarId + " Added with "+car.DailyPrice+" Daily Price Successfully");
            //}
            //else if(car.DailyPrice <= 0 && car.CarName.Length > 2)  //carname turns true - dailyprice turn false
            //{
            //    Console.WriteLine("Error!!! Daily Price must be higher than 0");
            //    Console.WriteLine("Please write a correct value for daily price");
            //    car.DailyPrice= Convert.ToInt32(Console.ReadLine());
            //    goto TryAgain;
            //}
            //else if(car.DailyPrice > 0 && car.CarName.Length <= 2) //carname turns false - dailyprice turn true
            //{
            //    Console.WriteLine("Error!!! Car name must be longer than 2 letters");
            //    Console.WriteLine("Please write a correct car name");
            //    car.CarName = Console.ReadLine();
            //    goto TryAgain;
            //}
            //else
            //{
            //    Console.WriteLine("Error!!! Car name and Daily Price wrong");
            //}

            while (car.DailyPrice <= 0 && car.CarName.Length <= 2)
            {
                Console.WriteLine("Error!!! Daily Price must be higher than 0 and Car name must be longer than 2 letters");
                Console.WriteLine("Please write a correct value for daily price");
                car.DailyPrice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please write a correct value for car name");
                car.CarName = Console.ReadLine();
            }
            _carDal.Add(car);
            Console.WriteLine("Car Name: " + car.CarName + " Added with " + car.DailyPrice + " Daily Price Successfully");


        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Updated Successfully");
        }


        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Deleted Successfully");
        }


        public List<Car> GetAll()
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return _carDal.GetAll();
            
        }

        public Car GetById(int carId)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return _carDal.GetAll(b => b.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return _carDal.GetAll(co => co.ColorId == colorId);
        }
        public List<Car> GetByModelYear(string modelYear)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return _carDal.GetAll(c => c.ModelYear == modelYear);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
