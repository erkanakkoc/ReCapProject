using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine(color.ColorName+ " added Successfully");
        }
        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine(color.ColorName + " updated Successfully");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine(color.ColorName + " deleted Successfully");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(co => co.ColorId == colorId);
        }

        
    }
}
