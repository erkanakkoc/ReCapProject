using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNameExists(carImage.ImagePath),
                CheckIfCarImageCountOfCarIdCorrect(carImage));

            if (result != null)
            {
                return result;
            }
                carImage.ImageDate = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
                _carImageDal.Delete(carImage);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci=>ci.ImageId==imageId));
        }

        

        private IResult CheckIfCarImageCountOfCarIdCorrect(CarImage carImage)
        {
            List<CarImage> getAll = _carImageDal.GetAll(ci => ci.CarId == carImage.CarId);
            var result = (getAll.Count() >= 5);


            if (result)
            {
                return new ErrorResult(Messages.CarImageCountOfCarIdError);
            }
            return new SuccessResult();
        }
        

        public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId), Messages.CarImagesListed);
        }

        private IResult CheckIfCarImageNameExists(string imagePath)
        {
            var result = _carImageDal.GetAll(ci => ci.ImagePath == imagePath).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarImagePathAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
