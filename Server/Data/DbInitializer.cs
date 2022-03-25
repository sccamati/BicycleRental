﻿namespace BicycleRental.Server.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bikes.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role{Name = "Admin" },
                new Role{Name = "Owner" },
                new Role{Name = "User" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            var users = new User[]
            {
                new User{Email = "admin@wp.pl", Password = "Password1.", Role = roles[0]},
                new User{Email = "user@wp.pl", Password = "Password1.", Role = roles[2]},
                new User{Email = "owner@wp.pl", Password = "Password1.", Role = roles[1]}
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var bikesTypes = new BikesType[]
            {
                new BikesType{Name = "Cross"},
                new BikesType{Name = "Trekking"},
                new BikesType{Name = "Mountain"},
                new BikesType{Name = "Electric"}
            };

            context.BikesType.AddRange(bikesTypes);
            context.SaveChanges();

            var brands = new string[]
            {
                "kellys",
                "grand",
                "kross",
                "giant"
            };

            var bikes = new Bike[]
            {
                new Bike{BikesType = bikesTypes[0], ProductionDate = DateTime.Now.Year, SerialNumber="123456123", Brand = brands[0]},
                new Bike{BikesType = bikesTypes[1], ProductionDate = DateTime.Now.Year, SerialNumber="123456121", Brand = brands[1]},
                new Bike{BikesType = bikesTypes[2], ProductionDate = DateTime.Now.Year, SerialNumber="123456122", Brand = brands[2]},
                new Bike{BikesType = bikesTypes[3], ProductionDate = DateTime.Now.Year, SerialNumber="123456124", Brand = brands[3]},
                new Bike{BikesType = bikesTypes[1], ProductionDate = DateTime.Now.Year, SerialNumber="123456125", Brand = brands[0]},
            };

            context.Bikes.AddRange(bikes);
            context.SaveChanges();

            var rentals = new Rental[]
            {
                new Rental{User = users[1], Bike = bikes[0], StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), Price = 100},
                new Rental{User = users[1], Bike = bikes[1], StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(4), Price = 100},
                new Rental{User = users[1], Bike = bikes[2], StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(6), Price = 200},
                new Rental{User = users[1], Bike = bikes[3], StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), Price = 120},
                new Rental{User = users[1], Bike = bikes[4], StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(11), Price = 130},
                new Rental{User = users[1], Bike = bikes[0], StartDate = DateTime.Now.AddDays(15), EndDate = DateTime.Now.AddDays(17), Price = 110},
            };

            context.Rentals.AddRange(rentals);
            context.SaveChanges();
        }
    }
}