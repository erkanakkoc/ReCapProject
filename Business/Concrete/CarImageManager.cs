using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNameExists(carImage.ImagePath),
                CheckIfCarImageCountOfCarIdCorrect(carImage.CarId));

            if (result != null)
            {
                return result;
            }

                carImage.ImagePath = "test";
                carImage.ImageDate = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.ImageId == imageId));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageCountOfCarIdCorrect(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountOfCarIdError);
            }
            return new SuccessResult();
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
