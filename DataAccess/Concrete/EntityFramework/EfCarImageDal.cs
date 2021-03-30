using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarDbContext>, ICarImageDal
    {
        public bool IsExists(int carImageId)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return context.CarImages.Any(c => c.CarImageId == carImageId);
            }
        }
    }
}
