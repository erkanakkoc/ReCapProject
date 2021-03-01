using Business.Concrete;
using Core.Entities.Concrete;
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



            Console.WriteLine("What do you want to do?");
            Console.WriteLine(" 1- (Add - Update - Delete) Operations\n 2 - List Operation ");
            var choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddUpdateDeleteOperations(carManager, colorManager, brandManager, userManager, customerManager, rentalManager);
                    break;
                case 2:
                    ListOperations(carManager, colorManager, brandManager, userManager, customerManager, rentalManager);
                    break;
                default:
                    break;
            }

            

        }
        

        //------------------------------------------------ListOperations----------------------------------------------------
        private static void ListOperations(CarManager carManager, ColorManager colorManager, BrandManager brandManager, UserManager userManager, CustomerManager customerManager, RentalManager rentalManager)
        {
            Console.WriteLine("1- GetCarsByColorId\n 2- GetCarsByBrandId \n 3- GetCarsByDailyPrice \n 4- GetCarsByModelYears \n 5- GetAllCars \n 6- GetRentalByCarId \n 7- GetRentalByCustomerId \n 8- GetRentalByRentDate \n 9- GetRentalByReturnDate \n 10- RentedAllCars");
            Console.WriteLine("-----------------------------------------------------------------");
            var choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 1:     //GetCarsByColorId-------------------ITS WORKING
                    GetCarsByColorId(carManager);
                    break;
                case 2:     //GetCarsByBrandId-------------------ITS WORKING
                    GetCarsByBrandId(carManager);
                    break;
                case 3:     //GetCarsByDailyPrice-------------------ITS WORKING
                    GetByDailyPrice(carManager, colorManager, brandManager);
                    break;
                case 4:     //GetCarsByModelYears-------------------ITS WORKING
                    GetByModelYear(carManager, colorManager, brandManager);
                    break;
                case 5:     //GetCarDetail-------------------ITS WORKING
                    GetCarDetail(carManager);
                    break;
                case 6:     //GetRentalByCarId-------------------ITS WORKING
                    GetRentalByCarId(rentalManager);
                    break;
                case 7:     //GetRentalByCustomerId-------------------ITS WORKING
                    GetRentalByCustomerId(rentalManager);
                    break;
                case 8:     //GetRentalByRentDate-------------------ITS WORKING
                    GetRentalByRentDate(rentalManager);
                    break;
                case 9:     //GetRentalByReturnDate-------------------ITS WORKING                    
                    GetRentalByReturnDate(rentalManager);
                    break;
                case 10:     //RentedAllCars-------------------ITS WORKING
                    RentedAllCars(rentalManager);
                    break;
                default:
                    break;
            }
        }

        //--------------------------------------------AddUpdateDeleteOperations----------------------------------------------------
        private static void AddUpdateDeleteOperations(CarManager carManager, ColorManager colorManager, BrandManager brandManager, UserManager userManager, CustomerManager customerManager, RentalManager rentalManager)
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
                    GetCarDetail(carManager);
                    UpdateCar(carManager);
                    break;
                case 3:     //DeleteCar-------------------ITS WORKING
                    GetCarDetail(carManager);
                    DeleteCar(carManager);
                    break;
                case 4:     //AddNewBrand-------------------ITS WORKING
                    AddNewBrand(brandManager);
                    break;
                case 5:     //AddNewColor-------------------ITS WORKING
                    AddNewColor(colorManager);
                    break;
                case 6:     //AddNewUser-------------------ITS WORKING
                    AddNewUser(userManager);
                    break;
                case 7:     //AddNewCustomer-------------------ITS WORKING
                    AddNewCustomer(customerManager);
                    break;
                case 8:     //RentACar-------------------ITS WORKING
                    RentACar(rentalManager);
                    break;
                case 9:     //UpdateRentedCar-------------------ITS WORKING
                    ReturnedCar(rentalManager);
                    break;
                case 10:     //DeleteRentedCar-------------------ITS WORKING
                    DeleteRental(rentalManager);
                    break;
                default:
                    break;
            }
        }
        //-------------------------------------- ADD / UPDATE / DELETE OPERATIONS------------------------------

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

            //Console.WriteLine("Write Car ID For Update");
            //int updateCarId = Convert.ToInt32(Console.ReadLine());
            //Car updateCar = new Car();
            //Console.WriteLine("Car Name: ");
            //updateCar.CarName = Console.ReadLine();
            //Console.WriteLine("Brand Id: ");
            //updateCar.BrandId = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Color Id: ");
            //updateCar.ColorId = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Daily Price: ");
            //updateCar.DailyPrice = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Model Year: ");
            //updateCar.ModelYear = Console.ReadLine();
            //Console.WriteLine("Description: ");
            //updateCar.Description = Console.ReadLine();
            //carManager.Update(updateCar);
            //carManager.Update(carManager.GetById(updateCarId).Data);

            Console.WriteLine("Car Id: ");
            int updateCarId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Car Name: ");
            string updateCarName = Console.ReadLine();

            Console.WriteLine("Brand Id: ");
            int updateBrandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int updateColorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            decimal updateDailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Model Year: ");
            string updateModelYear = Console.ReadLine();

            Console.WriteLine("Description : ");
            string updateDescription = Console.ReadLine();

            Car updateCar = new Car { CarId = updateCarId, BrandId = updateBrandId, CarName= updateCarName, ColorId = updateColorId, DailyPrice = updateDailyPrice, Description = updateDescription, ModelYear = updateModelYear };
            carManager.Update(updateCar);
        }

        // ------------------------------- Case 2 : DeleteCar ----------------------------------------
        private static void DeleteCar(CarManager carManager)
        {
            Console.WriteLine("Write Car ID For Delete");
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
        //--------------------------------------------------- Case 6 : AddNewUser-----------------------------------------------------
        private static void AddNewUser(UserManager userManager)
        {
            User user1 = new User();
            Console.WriteLine("First Name : ");
            user1.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name : ");
            user1.LastName = Console.ReadLine();
            Console.WriteLine("E-mail : ");
            user1.Email = Console.ReadLine();
            Console.WriteLine("Password : ");
            user1.Password = Console.ReadLine();
            userManager.Add(user1);
        }
        // ------------------------------- Case 7 : AddNewCustomer ----------------------------------------
        private static void AddNewCustomer(CustomerManager customerManager)
        {

            Customer customer1 = new Customer();
            Console.WriteLine("User ID : ");
            customer1.UserId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Company Name : ");
            customer1.CompanyName = Console.ReadLine();
            customerManager.Add(customer1);
        }
        //-------------------------------------------------- Case 8 : RentACar-------------------------------------------------------
        private static void RentACar(RentalManager rentalManager)
        {
            Rental rental = new Rental();
            Console.WriteLine("Car ID : ");
            rental.CarId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer ID : ");
            rental.CustomerId = Convert.ToInt32(Console.ReadLine());
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = null;
            Console.WriteLine(rentalManager.Add(rental).Message);
        }
        //------------------------------------------------ Case 9 : ReturnedCar----------------------------------------------------
        private static void ReturnedCar(RentalManager rentalManager)
        {
            Console.WriteLine("Returned Car ID : ");
            int updateRentID = Convert.ToInt32(Console.ReadLine());
            Rental returnedCar = new Rental { CarId = updateRentID, ReturnDate = DateTime.Now };
            rentalManager.Update(returnedCar);
        }
        //------------------------------------------------ Case 10 : DeleteRental--------------------------------------------------
        private static void DeleteRental(RentalManager rentalManager)
        {
            Console.WriteLine("Write Rental ID For Delete");
            int deleteRent = Convert.ToInt32(Console.ReadLine());
            rentalManager.Delete(rentalManager.GetById(deleteRent).Data);
        }
        //----------------------------------------LIST OPERATIONS---------------------------------------------------

        // ------------------------------- Case 1 : GetCarsByColorId ----------------------------------------
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
        // ------------------------------- Case 2 : GetCarsByBrandId ----------------------------------------
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
        // ------------------------------- Case 3 : GetByDailyPrice ----------------------------------------
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
        // ------------------------------- Case 4 : GeyByModelYear ----------------------------------------
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
        // ------------------------------- Case 5 : GetCarDetails ----------------------------------------
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
        //------------------------------- Case 6 : GetRentalByCarId --------------------------------
        private static void GetRentalByCarId(RentalManager rentalManager)
        {
            Console.WriteLine("Which Car Id Do You Want?");
            var choiceInt = Convert.ToInt32(Console.ReadLine());
            var resultCarId = rentalManager.GetRentalByCarId(choiceInt);
            if (resultCarId.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-19} | {6,-15} ", "RentalId", "CarName", "FirstName", "LastName", "CompanyName", "RentDate", "ReturnDate"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                foreach (var rent in resultCarId.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-5} | {6,-15} ", rent.RentalId, rent.CarName, rent.FirstName, rent.LastName, rent.CompanyName, rent.RentDate, rent.ReturnDate));
                }
            }
        }
        //-------------------------------- Case 7 : GetRentalByCustomerId --------------------------
        private static void GetRentalByCustomerId(RentalManager rentalManager)
        {
            Console.WriteLine("Which Customer Id Do You Want?");
            var choiceInt = Convert.ToInt32(Console.ReadLine());
            var resultCustomerId = rentalManager.GetRentalByCustomerId(choiceInt);
            if (resultCustomerId.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-19} | {6,-15} ", "RentalId", "CarName", "FirstName", "LastName", "CompanyName", "RentDate", "ReturnDate"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                foreach (var rent in resultCustomerId.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-5} | {6,-15} ", rent.RentalId, rent.CarName, rent.FirstName, rent.LastName, rent.CompanyName, rent.RentDate, rent.ReturnDate));
                }
            }
        }
        //-------------------------------- Case 8 : GetRentalByRentDate -----------------------------
        private static void GetRentalByRentDate(RentalManager rentalManager)
        {
            Console.WriteLine("Which Customer Id Do You Want?");
            var choiceDate = Convert.ToDateTime(Console.ReadLine());
            var resultRentDate = rentalManager.GetRentalByRentDate(choiceDate);
            if (resultRentDate.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-19} | {6,-15} ", "RentalId", "CarName", "FirstName", "LastName", "CompanyName", "RentDate", "ReturnDate"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                foreach (var rent in resultRentDate.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-5} | {6,-15} ", rent.RentalId, rent.CarName, rent.FirstName, rent.LastName, rent.CompanyName, rent.RentDate, rent.ReturnDate));
                }
            }
        }
        //------------------------------- Case 9 : GetRentalByReturnDate ----------------------------
        private static void GetRentalByReturnDate(RentalManager rentalManager)
        {
            Console.WriteLine("Which Customer Id Do You Want?");
            var choiceDate = Convert.ToDateTime(Console.ReadLine());
            var resultReturnDate = rentalManager.GetRentalByReturnDate(choiceDate);
            if (resultReturnDate.Success == true)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-19} | {6,-15} ", "RentalId", "CarName", "FirstName", "LastName", "CompanyName", "RentDate", "ReturnDate"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                foreach (var rent in resultReturnDate.Data)
                {
                    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-5} | {6,-15} ", rent.RentalId, rent.CarName, rent.FirstName, rent.LastName, rent.CompanyName, rent.RentDate, rent.ReturnDate));
                }
            }
        }
        //-------------------------------- Case 10 : RentedAllCars --------------------------------------
        private static void RentedAllCars(RentalManager rentalManager)
        {
            Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-19} | {6,-15} ", "RentalId", "CarName", "FirstName", "LastName", "CompanyName", "RentDate", "ReturnDate"));
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            foreach (var rent in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-11} | {4,-15} | {5,-5} | {6,-15} ", rent.RentalId, rent.CarName, rent.FirstName, rent.LastName, rent.CompanyName, rent.RentDate, rent.ReturnDate));
            }
        }
    }
}
