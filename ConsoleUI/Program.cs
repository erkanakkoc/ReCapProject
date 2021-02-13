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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            var choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to do?");
            Console.WriteLine(" 1- Add - Update - Delete) Operations\n 2 - List Operation ");
            switch (choice)
            {
                case 1:
                    AddUpdateDeleteOperations(carManager, colorManager, brandManager);
                    break;
                case 2:
                    ListOperations(carManager, colorManager, brandManager);
                    break;
                default:
                    break;
            }

            

        }

        //------------------------------------------------ListOperations----------------------------------------------------
        private static void ListOperations(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("4- GetByColorId\n 5- GetByBrandId \n 6- GetByDailyPrice \n 7- GetByModelYears \n 8- GetAllCars");
            Console.WriteLine("-----------------------------------------------------------------");
            var choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 4:     //GetByColorId-------------------ITS WORKING
                    GetCarsByColorId(carManager);
                    break;
                case 5:     //GetByBrandId-------------------ITS WORKING
                    GetCarsByBrandId(carManager);
                    break;
                case 6:     //GetByDailyPrice-------------------ITS WORKING
                    GetByDailyPrice(carManager, colorManager, brandManager);
                    break;
                case 7:     //GetByModelYears-------------------ITS WORKING
                    GetByModelYear(carManager, colorManager, brandManager);
                    break;
                case 8:     //GetAllCars-------------------ITS WORKING
                    GetCarDetail(carManager);
                    break;
                default:
                    break;
            }
        }

        //--------------------------------------------AddUpdateDeleteOperations----------------------------------------------------
        private static void AddUpdateDeleteOperations(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine(" 1- Car - Add New\n 2- Car - Update\n 3- Car - Delete\n 4- Brand - Add New\n 5- Color - Add New\n 6- User - Add New\n 7- Customer - Add New\n 8- Rent A Car\n 9- Update Rented Car\n 10- Delete Rented Car");
            Console.WriteLine("-----------------------------------------------------------------");
            var choice1 = Convert.ToInt32(Console.ReadLine());
            //string choiceString = "";
            switch (choice1)
            {
                case 1:     //AddNewCar-------------------ITS WORKING
                    AddNewCar(carManager);
                    break;
                case 2:     //UpdateCar-------------------ITS WORKING
                    UpdateCar(carManager);
                    break;
                case 3:     //DeleteCar-------------------ITS WORKING
                    DeleteCar(carManager);
                    break;
                case 4:     //AddNewBrand-------------------ITS WORKING
                    AddNewBrand(brandManager);
                    break;
                case 5:     //AddNewColor-------------------ITS WORKING
                    AddNewColor(colorManager);
                    break;
                case 6:     //AddNewUser-------------------ITS WORKING
                    break;
                case 7:     //AddNewCustomer-------------------ITS WORKING
                    break;
                case 8:     //RentACar-------------------ITS WORKING
                    break;
                case 9:     //UpdateRentedCar-------------------ITS WORKING
                    break;
                case 10:     //DeleteRentedCar-------------------ITS WORKING
                    break;
                default:
                    break;
            }
        }
















        // ------------------------------- Case 1 : AddNewCar ----------------------------------------
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

        // ------------------------------- Case 2 : UpdateCar ----------------------------------------
        private static void UpdateCar(CarManager carManager)
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
            carManager.Update(car1);
        }

        // ------------------------------- Case 2 : DeleteCar ----------------------------------------
        private static void DeleteCar(CarManager carManager)
        {
            int deleteCar = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetById(deleteCar).Data);
        }

        // ------------------------------- Case 4 : AddNewBrand ----------------------------------------
        private static void AddNewBrand(BrandManager brandManager)
        {
            Brand brand1 = new Brand();
            Console.WriteLine("Brand Name: ");
            brand1.BrandName = Console.ReadLine();
            brandManager.Add(brand1);
        }

        // ------------------------------- Case 5 : AddNewColor ----------------------------------------
        private static void AddNewColor(ColorManager colorManager)
        {
            Color color1 = new Color();
            Console.WriteLine("Color Name: ");
            color1.ColorName = Console.ReadLine();
            colorManager.Add(color1);
        }

        // ------------------------------- Case 4 : GetCarsByColorId ----------------------------------------
        private static void GetCarsByColorId(CarManager carManager)
        {
            Console.WriteLine("Which Color Id Do You Want?");
            var choiceInt = Convert.ToInt32(Console.ReadLine());

            var resultColorId = carManager.GetCarsByColorId(choiceInt);
            if (resultColorId.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-15} | {3,-15} | {4,-13} | {5,-13} | {6,-15} ", "CarId", "CarName", "BrandName", "ColorName", "ModelYear", "DailyPrice", "Description"));
                foreach (var car in resultColorId.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13} | {6,-15} ", car.CarId, car.CarName, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));
                }
            }
        }

        // ------------------------------- Case 5 : GetCarsByBrandId ----------------------------------------
        private static void GetCarsByBrandId(CarManager carManager)
        {
            Console.WriteLine("Which Brand Id Do You Want?");
            var choiceInt = Convert.ToInt32(Console.ReadLine());

            var resultBrandId = carManager.GetCarsByBrandId(choiceInt);
            if (resultBrandId.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-15} | {3,-15} | {4,-13} | {5,-13} | {6,-15} ", "CarId", "CarName", "BrandName", "ColorName", "ModelYear", "DailyPrice", "Description"));
                foreach (var car in resultBrandId.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13} | {6,-15} ", car.CarId, car.CarName, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));
                }
            }
        }

        // ------------------------------- Case 6 : GetByDailyPrice ----------------------------------------
        private static void GetByDailyPrice(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("Which Daily Price Range Do You Want?\n Minimum Price");
            var choiceMin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Maximum Price");
            var choiceMax = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-15} | {3,-15} | {4,-13} | {5,-13} | {6,-15} ", "CarId", "CarName", "BrandName", "ColorName", "ModelYear", "DailyPrice", "Description"));
            foreach (var car in carManager.GetCarDetails(c => c.DailyPrice >= choiceMin & c.DailyPrice <= choiceMax).Data)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13} | {6,-15} ", car.CarId, car.CarName, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));
            }
        }

        // ------------------------------- Case 7 : GeyByModelYear ----------------------------------------
        private static void GetByModelYear(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.WriteLine("Which Model Year Do You Want?");
            var choiceString = Console.ReadLine();
            Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-15} | {3,-15} | {4,-13} | {5,-13} | {6,-15} ", "CarId", "CarName", "BrandName", "ColorName", "ModelYear", "DailyPrice", "Description"));
            foreach (var car in carManager.GetCarDetails(c => c.ModelYear == choiceString).Data)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13} | {6,-15} ", car.CarId, car.CarName, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));
            }
        }

        // ------------------------------- Case 8 : GetCarDetails ----------------------------------------
        private static void GetCarDetail(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-15} | {3,-15} | {4,-13} | {5,-13} | {6,-15} ", "CarId", "CarName", "BrandName", "ColorName", "ModelYear", "DailyPrice", "Description"));
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

    }
}
