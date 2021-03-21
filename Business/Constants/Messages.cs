using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        //Brand Messages
        public static string BrandAdded = "Brand Added";
        public static string BrandUpdated = "Brand Updated";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandsListed = "Brands Listed";

        //Car Messages
        public static string CarAdded = "Car Added";
        public static string CarUpdated = "Car Updated";
        public static string CarDeleted = "Car Deleted";
        public static string CarsListed = "Cars Listed";

        //Color Messages
        public static string ColorAdded = "Color Added";
        public static string ColorUpdated = "Color Updated";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorsListed = "Colors Listed";

        //User Messages
        public static string UserAdded = "User Added";
        public static string UserUpdated = "User Updated";
        public static string UserDeleted = "User Deleted";
        public static string UsersListed = "Users Listed";

        //Customer Messages
        public static string CustomerAdded = "Customer Added";
        public static string CustomerUpdated = "Customer Updated";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomersListed = "Customers Listed";

        //CarImage Messages
        public static string CarImageAdded = "Car Image Added";
        public static string CarImageUpdated = "Car Image Updated";
        public static string CarImageDeleted = "Car Image Deleted";
        public static string CarImagesListed = "Car Images Listed";

        //Rental Messages
        public static string RentalAdded = "Rent Information Added";
        public static string RentalUpdated = "Rent Information Updated";
        public static string RentalDeleted = "Rent Information Deleted";
        public static string RentalsListed = "Rent Information Listed";
        public static string RentalReturned = "Rented Car Returned Successfully";


        public static string SuccessfullyPaid = "Payment Successfully";



        //Error Messages
        public static string BrandNameInvalid = "Brand Name is Invalid";
        public static string CarNameInvalid = "Car Name is Invalid";
        public static string ColorNameInvalid = "Color Name is Invalid";
        public static string RentalInvalid = "The Car That You Wanted Isn't Available";
        public static string MaintenanceTime = "Maintenance Mode";
        public static string CarImageCountOfCarIdError="A car can have only 5 photos";
        public static string CarImagePathAlreadyExists="Car path is already existed";
        public static string AuthorizationDenied= "Access Denied. You are not authorized.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        
    }
}
