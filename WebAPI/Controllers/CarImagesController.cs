using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        
        ICarImageService _carImageService;

        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int imagedId)
        {
            var result = _carImageService.GetById(imagedId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("add")]
        //public IActionResult Add(CarImage carImage)
        //{
        //    var result = _carImageService.Add(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        //[HttpPost("update")]
        //public IActionResult Update(CarImage carImage)
        //{
        //    var result = _carImageService.Update(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("upload")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        //public string Post([FromForm] FileUpload objectFile)
        {

            System.IO.FileInfo ffe = new System.IO.FileInfo(file.FileName);
            string formfileExtension = ffe.Extension;



            var createdUniqueFileName = Guid.NewGuid().ToString("N") +
                "_" + DateTime.Now.Year +
                "_" + DateTime.Now.Month +
                "_" + DateTime.Now.Day +
                formfileExtension;
            if (file.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                string webimagepath = "\\images\\" + createdUniqueFileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + createdUniqueFileName))
                //using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    
                }


                var result = _carImageService.Add(file, carImage);

                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);

            }
            







        }

        //[HttpPost("upload")]
        //public IActionResult Add([FromForm] List<IFormFile> formFile, [FromForm] CarImage carImage)
        //{
        //    List<IResult> results = new List<IResult>();
        //    foreach (var resim in formFile)
        //    {
        //        if (resim.Length > 0)
        //        {
        //            string resimUzantisi = Path.GetExtension(resim.FileName); //Resmin uzantısını alır
        //            string yeniResimAdi = string.Format("{0}{1}", Guid.NewGuid().ToString("D"), resimUzantisi);// yüklenen resmin ismini Guid ile değiştirir
        //            string imageKlasoru = Path.Combine(_webHostEnvironment.WebRootPath, "Images");// WebRootPath -> D:\Documents\VSProjects\ReCapProject-CarRentalCompany\WebAPI\wwwroot  yüklenen resmin yüklendiği konumu verir
        //            string tamResimYolu = Path.Combine(imageKlasoru, yeniResimAdi); // resmin ismine kadar olan dosya yolunu verir
        //            string webResimYolu = string.Format("/Images/{0}", yeniResimAdi); // İlgili klasörün dosya yolunu kendine uyarlar \ işaretini / çevirir

        //            // _webHostEnvironment.WebRootPath = D:\Documents\VSProjects\ReCapProject-CarRentalCompany\WebAPI\wwwroot
        //            // tamResimYolu = D:\Documents\VSProjects\ReCapProject-CarRentalCompany\WebAPI\wwwroot\Images\image.bmp
        //            // webResimYolu = /Images/image.bmp

        //            if (!Directory.Exists(imageKlasoru))
        //                Directory.CreateDirectory(imageKlasoru);
        //            using (FileStream fileStream = System.IO.File.Create(tamResimYolu))
        //            {
        //                resim.CopyTo(fileStream);
        //                fileStream.Flush();
        //            }
        //            results.Add(_carImageService.Add(new CarImage()
        //            {
        //                ImagePath = webResimYolu,
        //                CarId = carImage.CarId
        //            }));
        //        }
        //    }
        //    var kontrol = BusinessRules.Run(results.ToArray());
        //    if (kontrol == null)
        //        return Ok(new SuccessResult("Resim yüklendi"));
        //    else
        //        return BadRequest(kontrol);

        //}




        //[HttpPost("upload")]
        //public IActionResult Add([FromForm] List<IFormFile> formFile, [FromForm] CarImage carImage)
        //{
        //    try
        //    {
        //        List<IResult> results = new List<IResult>();
        //        foreach (var image in formFile)
        //        {
        //            if (image.Length > 0)
        //            {
        //                string formfileExtension = Path.GetExtension(image.FileName); //Resmin uzantısını alır
        //                var createdUniqueFileName = Guid.NewGuid().ToString("N") +
        //                    "_" + DateTime.Now.Year +
        //                    "_" + DateTime.Now.Month +
        //                    "_" + DateTime.Now.Day +
        //                    formfileExtension;

        //                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
        //                string webimagepath = "\\images\\" + createdUniqueFileName;


        //                if (!Directory.Exists(path))
        //                {
        //                    Directory.CreateDirectory(path);
        //                }
        //                using (FileStream fileStream = System.IO.File.Create(path + createdUniqueFileName))
        //                {
        //                    image.CopyTo(fileStream);
        //                    fileStream.Flush();
        //                }
        //                results.Add(_carImageService.Add(new CarImage()
        //                {
        //                    ImagePath = webimagepath,
        //                    CarId = carImage.CarId
        //                }));
        //            }
        //        }
        //        var kontrol = BusinessRules.Run(results.ToArray());
        //        if (kontrol == null)
        //            return Ok(new SuccessResult("Resim yüklendi"));
        //        else
        //            return BadRequest(kontrol);
        //    }
            
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }


    }
}
