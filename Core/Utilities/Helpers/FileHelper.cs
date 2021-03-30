using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            //var sourcepath = Path.GetTempFileName();
            //if (file.Length > 0)
            //{
            //    using (var stream = new FileStream(sourcepath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //}
            //var result = newPath(file);
            //File.Move(sourcepath, result.newPath);
            //return result.Path2.Replace("\\","/");

            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images";
            var newGuidPath = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string newPath = path + @"\" + newGuidPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            using (var stream = File.Create(newPath))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
            return newGuidPath;
        }
        public static void Delete(string path)
        {
            //path = path.Replace("/", "\\");
            //try
            //{
            //    File.Delete(path);
            //}
            //catch (Exception exception)
            //{
            //    return new ErrorResult(exception.Message);
            //}

            //return new SuccessResult();

            File.Delete(path);
        }
        public static string Update(string oldPath, IFormFile file)
        {
            //var result = newPath(file);
            //if (sourcePath.Length > 0)
            //{
            //    using (var stream = new FileStream(result.newPath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //}
            //File.Delete(sourcePath);
            //return result.Path2.Replace("\\", "/");

            Delete(oldPath);
            return Add(file);


        }
        //public static (string newPath, string Path2) newPath(IFormFile file)
        //{
        //    FileInfo ff = new FileInfo(file.FileName);
        //    string fileExtension = ff.Extension;

        //    string path = Environment.CurrentDirectory + @"\wwwroot\Images";
        //    var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
        //    //string webPath = string.Format("/Images/{0}",newPath);

        //    string result = $@"{path}\{newPath}";
        //    return (result, $"{newPath}");
        //}


    }
}
