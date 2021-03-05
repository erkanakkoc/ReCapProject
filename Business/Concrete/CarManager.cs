using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
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

            //VERSION 2.0

            //while (car.DailyPrice <= 0 && car.CarName.Length <= 2)
            //{
            //    Console.WriteLine("Error!!! Daily Price must be higher than 0 and Car name must be longer than 2 letters");
            //    Console.WriteLine("Please write a correct value for daily price");
            //    car.DailyPrice = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Please write a correct value for car name");
            //    car.CarName = Console.ReadLine();
            //}
            //if (car.CarName.Length<2)
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
             
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            //Console.WriteLine("Car Name: " + car.CarName + " Added with " + car.DailyPrice + " Daily Price Successfully");


        }
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
            //Console.WriteLine("Updated Successfully");
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            //Console.WriteLine("Deleted Successfully");
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
            
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            //Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(b => b.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            //Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(co => co.ColorId == colorId));
        }
        public IDataResult<List<CarDetailDto>> GetByModelYear(string modelYear)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ModelYear == modelYear));
        }

        public IDataResult<List<CarDetailDto>> GetByDailyPrice(decimal min, decimal max)
        {
            Console.WriteLine("Car Id   Brand Name   Color Name   Model Year   Daily Price   Description");
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {

            Add(car);
            if (car.CarName.Length<2)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
    }
}
