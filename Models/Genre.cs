﻿using System.ComponentModel.DataAnnotations;

namespace BookstoreA.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required (ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Genre()
        {
            
        }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
            
        }
    }
}
