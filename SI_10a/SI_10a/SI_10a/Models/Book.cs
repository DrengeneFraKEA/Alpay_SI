﻿namespace SI_10a.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}