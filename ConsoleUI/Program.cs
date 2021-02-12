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


            int choiceInt = 0;
            Console.WriteLine("Which Color Id Do You Want?");
            choiceInt = Convert.ToInt32(Console.ReadLine());

            var resultColorId = carManager.GetCarsByColorId(choiceInt);
            if (resultColorId.Success == true)
            {
                foreach (var car in resultColorId.Data)
                {
                    Console.WriteLine("   " + car.CarId + "\t " + car.CarName+ "" + car.ModelYear + "\t   " + car.DailyPrice + "\t\t" + car.Description);
                }
            }





            Console.WriteLine("What do you want to do?");
            Console.WriteLine(" 1- Add New Car\n 2- Add New Brand \n 3- Add New Color\n 4- GetByColorId\n 5- GetByBrandId \n 6- GetByDailyPrice \n 7- GetByModelYears \n 8- GetAllCars");
            Console.WriteLine("-----------------------------------------------------------------");
            var choice = Convert.ToInt32(Console.ReadLine());
            string choiceString = "";


            switch (choice)
            {
                case 1:     //AddNewCar-------------------ITS WORKING
                    AddNewCar(carManager);
                    break;

                case 2:     //AddNewBrand-------------------ITS WORKING
                    AddNewBrand(brandManager);
                    break;
                case 3:     //AddNewColor-------------------ITS WORKING
                    AddNewColor(colorManager);
                    break;
                case 4:     //GetByColorId-------------------WORKING ON IT

                    break;
                case 5:     //GetByBrandId-------------------WORKING ON IT
                    //choiceInt = GetByBrandId(carManager, colorManager, brandManager);
                    break;
                case 6:     //GetByDailyPrice-------------------WORKING ON IT

                    break;
                case 7:     //GetByModelYears-------------------WORKING ON IT

                    break;
                case 8:     //GetAllCars-------------------ITS WORKING
                    GetCarDetail(carManager);
                    break;
                default:
                    break;

            }

          



            //carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = "2010", DailyPrice = 125, Description="Correct Example 1"});
            //carManager.Add(new Car { BrandId = 4, ColorId = 3, ModelYear = "2005", DailyPrice = 0, Description = "Failure Exapmle"});

            //brandManager.Add(new Brand { BrandName = "BMW" });
            //brandManager.Add(new Brand { BrandName = "AA" });



            //    case 4:     //GetByColorId-------------------ITS WORKING
            //        
            //        break;
            //    case 5:     //GetByBrandId-------------------ITS WORKING

            //        break;
            //    case 6:     //GetByDailyPrice-------------------ITS WORKING
            //        Console.WriteLine("Which Daily Price Range Do You Want?\n Minimum Price");
            //        var choiceMin = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine(" Maximum Price");
            //        var choiceMax = Convert.ToInt32(Console.ReadLine());
            //        foreach (var car in carManager.GetByDailyPrice(choiceMin, choiceMax))
            //        {
            //            Console.WriteLine("   " + car.CarId + "\t " + brandManager.GetById(car.BrandId).BrandName + "" + colorManager.GetById(car.ColorId).ColorName + "" + car.ModelYear + "\t   " + car.DailyPrice + "\t\t" + car.Description);
            //        }
            //        break;
            //    case 7:     //GetByModelYears-------------------ITS WORKING
            //        Console.WriteLine("Which Model Year Do You Want?");
            //        choiceString = Console.ReadLine();
            //        foreach (var car in carManager.GetByModelYear(choiceString))
            //        {
            //            Console.WriteLine("   " + car.CarId + "\t " + brandManager.GetById(car.BrandId).BrandName + "" + colorManager.GetById(car.ColorId).ColorName + "" + car.ModelYear + "\t   " + car.DailyPrice + "\t\t" + car.Description);
            //        }
            //        break;
            //    case 8:     //GetAllCars-------------------ITS WORKING
            //        foreach (var car in carManager.GetAll())
            //        {
            //            Console.WriteLine("   " + car.CarId + "\t " + brandManager.GetById(car.BrandId).BrandName + "" + colorManager.GetById(car.ColorId).ColorName + "" + car.ModelYear + "\t   " + car.DailyPrice + "\t\t" + car.Description);
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

        private static int GetByBrandId(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            int choiceInt;
            Console.WriteLine("Which Brand Id Do You Want?");
            choiceInt = Convert.ToInt32(Console.ReadLine());
            var result = carManager.GetCarsByBrandId(choiceInt);
            foreach (var car in result.Data)
            {
                Console.WriteLine("Working On It");
            }

            return choiceInt;
        }

        private static void GetCarDetail(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13} | {6,-15} ", "CarId", "CarName", "BranName", "ColorName", "ModelYear", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13} | {6,-15} ", car.CarId, car.CarName, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        private static void AddNewColor(ColorManager colorManager)
        {
            Color color1 = new Color();
            Console.WriteLine("Color Name: ");
            color1.ColorName = Console.ReadLine();
            colorManager.Add(color1);
        }

        private static void AddNewBrand(BrandManager brandManager)
        {
            Brand brand1 = new Brand();
            Console.WriteLine("Brand Name: ");
            brand1.BrandName = Console.ReadLine();
            brandManager.Add(brand1);
        }

        private static void AddNewCar(CarManager carManager)
        {
            Car car1 = new Car();


            Console.WriteLine("Car Name: ");
            car1.CarName = Console.ReadLine();
            Console.WriteLine("Brand Id: ");
            car1.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Color Id: ");
            car1.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Daily Price: ");
            car1.DailyPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Model Year: ");
            car1.ModelYear = Console.ReadLine();
            Console.WriteLine("Description: ");
            car1.Description = Console.ReadLine();
            carManager.Add(car1);

            Console.WriteLine(car1.CarName + "added");
        }
    }
}
