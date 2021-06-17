
using BookStoreAPI.Interface;
using System;
namespace BookStoreAPI.Models
{
    public class Review: IEntity
    {//thuoc ve 1 account va 1 book
        public string Content { get; set; }
        public DateTime CreatedAt {get;set;}
        public string Email { get; set; }
        public bool Liked { get; set; }
        
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

    }
    public class ReviewDto {
        public int AccountId { get; set; }
        public int BookId { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Liked { get; set; }
    }
    public class ReviewCreateDto
    {
        public string Content { get; set; }
        public string CreatedAt {get;set;}
        public bool Liked { get; set; }
        public string Email { get; set; }
        
        public int AccountId { get; set; }

        public int BookId { get; set; }
    }

    public class ReviewUpdateDto : ReviewCreateDto
    {
        public int Id { get; set; }
    }
}