using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        //public int BrandId { get; set; }
        public string BrandName { get; set; }
        //public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime ImageDate { get; set; }

    }
}
