using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            


            //carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = "2010", DailyPrice = 125, Description="Correct Example 1"});
            //carManager.Add(new Car { BrandId = 4, ColorId = 3, ModelYear = "2005", DailyPrice = 0, Description = "Failure Exapmle"});

            //brandManager.Add(new Brand { BrandName = "BMW" });
            //brandManager.Add(new Brand { BrandName = "AA" });
            Console.WriteLine("What do you want to do?");
            Console.WriteLine(" 1- Add New Car\n 2- Add New Brand \n 3- Add New Color\n 4- GetByColorId\n 5- GetByBrandId \n 6- GetByDailyPrice \n 7- GetByModelYears \n 8- GetAllCars");
            var choice = Convert.ToInt32(Console.ReadLine());
            string choiceString = "";
            int choiceInt = 0;
            switch (choice)
            {
                case 1:     //AddNewCar-------------------ITS WORKING
                    Car car1 = new Car();
                    Console.WriteLine("Brand Name: ");
                    car1.BrandId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Color Name: ");
                    car1.ColorId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Daily Price: ");
                    car1.DailyPrice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Model Year: ");
                    car1.ModelYear = Console.ReadLine();
                    Console.WriteLine("Description: ");
                    car1.Description = Console.ReadLine();
                    carManager.Add(car1);
                    break;

                case 2:     //AddNewBrand-------------------ITS WORKING
                    Brand brand1 = new Brand();
                    Console.WriteLine("Brand Name: ");
                    brand1.BrandName = Console.ReadLine();
                    brandManager.Add(brand1);
                    break;
                case 3:     //AddNewColor-------------------ITS WORKING
                    Color color1 = new Color();
                    Console.WriteLine("Color Name: ");
                    color1.ColorName = Console.ReadLine();
                    colorManager.Add(color1);
                    break;
                case 4:     //GetByColorId-------------------ITS WORKING
                    Console.WriteLine("Which Color Id Do You Want?");
                    choiceInt = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetCarsByColorId(choiceInt))
                    {
                        Console.WriteLine(car.CarId + "---" + car.BrandId + "---" + car.ColorId + "---" + car.ModelYear + "---" + car.DailyPrice + "---" + car.Description);
                    }
                    break;
                case 5:     //GetByBrandId-------------------ITS WORKING
                    Console.WriteLine("Which Brand Id Do You Want?");
                    choiceInt = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetCarsByBrandId(choiceInt))
                    {
                        Console.WriteLine(car.CarId + "---" + car.BrandId + "---" + car.ColorId + "---" + car.ModelYear + "---" + car.DailyPrice + "---" + car.Description);
                    }
                    break;
                case 6:     //GetByDailyPrice-------------------ITS WORKING
                    Console.WriteLine("Which Daily Price Range Do You Want?");
                    var choiceMin = Convert.ToInt32(Console.ReadLine());
                    var choiceMax = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetByDailyPrice(choiceMin, choiceMax))
                    {
                        Console.WriteLine(car.CarId + "---" + car.BrandId + "---" + car.ColorId + "---" + car.ModelYear + "---" + car.DailyPrice + "---" + car.Description);
                    }
                    break;
                case 7:     //GetByModelYears-------------------ITS WORKING
                    Console.WriteLine("Which Model Year Do You Want?");
                    choiceString = Console.ReadLine();
                    foreach (var car in carManager.GetByModelYear(choiceString))
                    {
                        Console.WriteLine(car.CarId + "---" + car.BrandId + "---" + car.ColorId + "---" + car.ModelYear + "---" + car.DailyPrice + "---" + car.Description);
                    }
                    break;
                case 8:     //GetAllCars-------------------ITS WORKING
                    foreach (var car in carManager.GetAll())
                    {
                        Console.WriteLine(car.CarId + "---" + car.BrandId + "---" + car.ColorId + "---" + car.ModelYear + "---" + car.DailyPrice + "---" + car.Description);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
