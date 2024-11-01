﻿namespace BookRental.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
