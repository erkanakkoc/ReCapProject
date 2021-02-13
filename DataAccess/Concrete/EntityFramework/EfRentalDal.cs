using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentalDetailDto 
                             { 
                                 RentalId = r.RentalId, 
                                 CarName = c.CarName, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 CompanyName = cu.CompanyName, 
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate 
                             };
                return result.ToList();
            }
        }
    }
}
