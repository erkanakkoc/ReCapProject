using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalByRentDate(DateTime rentDate);
        IDataResult<List<RentalDetailDto>> GetRentalByReturnDate(DateTime returnDate);
        IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
