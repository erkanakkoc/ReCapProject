﻿using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
            TryAgain:
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car Id: " +car.CarId + " Added with "+car.DailyPrice+" Daily Price Successfully");
            }
            else
            {
                Console.WriteLine("Error!!! Daily Price must be higher than 0");
                Console.WriteLine("Please write a correct value for daily price");
                car.DailyPrice= Convert.ToInt32(Console.ReadLine());
                goto TryAgain;

            }
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
            return _carDal.GetAll();
            
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(b => b.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(co => co.ColorId == colorId);
        }
        public List<Car> GetByModelYear(string modelYear)
        {
            return _carDal.GetAll(c => c.ModelYear == modelYear);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }       
    }
}
