using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //public IResult CheckReturnDate(int carId)
        //{
        //    var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
        //    if (result.Count > 0)
        //    {
        //        return new ErrorResult(Messages.RentalInvalid);
        //    }
        //    return new SuccessResult(Messages.RentalAdded);
        //}

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //var result = CheckReturnDate(rental.CarId);
            //if (!result.Success)
            //{
            //    return new ErrorResult(result.Message);
            //}
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
        public IResult Update(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult();
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));

        }

        public IDataResult<List<RentalDetailDto>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.CarId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(cu => cu.CustomerId == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByRentDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.RentDate == rentDate));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByReturnDate(DateTime returnDate)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == returnDate));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.RentalReturned);
        }

        
    }
}
