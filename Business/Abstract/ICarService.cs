using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetByModelYear(string modelYear);
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);

        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarsBySelect(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetail(int carId);

        IDataResult<Car> GetCarFindex(int carId);
    }
}
