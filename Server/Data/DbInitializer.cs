using BicycleRental.Client.Services.Auth;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;
using System.Security.Cryptography;

namespace BicycleRental.Server.Data
{
    public class DbInitializer
    {

        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Rentals.Any())
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

            CreatePasswordHash("Password1", out byte[] passwordHash, out byte[] passwordSalt);

            User admin = new User
            {
                Email = "admin@wp.pl",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = roles[0]
            };


            CreatePasswordHash("Password1", out byte[] passwordHash2, out byte[] passwordSalt2);
            User owner = new User
            {
                Email = "owner@wp.pl",
                PasswordHash = passwordHash2,
                PasswordSalt = passwordSalt2,
                Role = roles[1]
            };



            User[] users = new User[100];
            users[0] = admin;
            users[1] = owner;

            for (int i = 2; i < 100; i++)
            {
                CreatePasswordHash("Password1", out byte[] passwordHash1, out byte[] passwordSalt1);
                User user1 = new User
                {
                    Email = $"user{i.ToString()}@wp.pl",
                    PasswordHash = passwordHash1,
                    PasswordSalt = passwordSalt1,
                    Role = roles[2]
                };

                users[i] = user1;
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            BikesType[] bikesTypes = new BikesType[]
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

            Bike[] bikes = new Bike[100];


            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                bikes[i] = new Bike
                {
                    BikesType = bikesTypes[rand.Next(0, bikesTypes.Length - 1)],
                    ProductionDate = rand.Next(2005, 2022),
                    SerialNumber = rand.Next(111111112, 999999999).ToString(),
                    Brand = brands[rand.Next(0, brands.Length - 1)],
                    PricePerHour = rand.Next(10, 50),
                };

                 
            }

            context.Bikes.AddRange(bikes);
            context.SaveChanges();

            Rental[] rentals = new Rental[1000000];

            for (int i = 0; i < 1000000; i++)
            {
                DateTime start = new DateTime(2020, 1, 1);
                int range = (DateTime.Today - start).Days;
                start = start.AddDays(rand.Next(range));

                var bike = bikes[rand.Next(0, 99)];
                int rentalHours = rand.Next(1, 10);

                Rental rental = new Rental
                {
                    User = users[rand.Next(2, 99)],
                    Bike = bike,
                    StartDate = start,
                    EndDate = start.AddHours(rentalHours),
                    Price = rentalHours * 3
                };

                rentals[i] = rental;
            }

            context.Rentals.AddRange(rentals);
            context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

    }
}
