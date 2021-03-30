using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
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

        public CarImageManager(ICarImageDal carImageDAL)
        {
            _carImageDal = carImageDAL;
        }

        [SecuredOperation("carimage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId), CheckIfImageExtensionValid(file));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            string path = Get(carImage.CarImageId).Data.ImagePath;
            IResult result = BusinessRules.Run(CheckIfImageExists(carImage.CarImageId), CheckIfImageCanDelete(path));
            if (result != null)
            {
                return result;
            }
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [SecuredOperation("carimage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        //public IResult Update(IFormFile file, CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId), CheckIfImageExtensionValid(file), CheckIfImageExists(carImage.Id));
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    carImage.ImageDate = DateTime.Now;
        //    string oldPath = Get(carImage.CarImageId).Data.ImagePath;
        //    carImage.ImagePath = FileHelper.Update(file, oldPath);          
        //    _carImageDal.Update(carImage);
        //    return new SuccessResult(Messages.CarImageUpdated);
        //}


        public IResult Update(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId), CheckIfImageExtensionValid(file), CheckIfImageExists(carImage.Id));
            if (result != null)
            {
                return result;
            }
            carImage.ImageDate = DateTime.Now;
            string oldPath = Get(carImage.CarImageId).Data.ImagePath;
            carImage.ImagePath = FileHelper.Update(file, oldPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id),Messages.CarImagesListed);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageCountOfCarIdError);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\defaultimage.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, ImageDate = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExists(id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageMustBeExists);
        }

        private IResult CheckIfImageCanDelete(string path)
        {
            if (File.Exists(path) && Path.GetFileName(path) != @"\WebAPI\wwwroot\Images\default1.jpg")
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FileCannotDelete);
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool IsValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!IsValidFileExtension)
            {
                return new ErrorResult(Messages.InvalidImageExtension);
            }
            return new SuccessResult();
        }

    }
}
