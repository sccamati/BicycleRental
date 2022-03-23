﻿namespace BicycleRental.Shared
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
