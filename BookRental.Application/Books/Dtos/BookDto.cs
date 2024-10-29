﻿namespace BookRental.Application.Books.Dtos;

public class BookDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public bool IsRented { get; set; }
}