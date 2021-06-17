using System;
using BookStoreAPI.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using BookStoreAPI.Utils.DateTimeUtils;
namespace BookStoreAPI.Models
{
    public class ShoppingCart : IEntity
    {
        public int Id { get; set; }


        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string LastUpdated { get; set; }
        public virtual List<CartItem> Items { get; set; } = new List<CartItem>();
        public void AddItem(int bookId,  Book book, int quantity = 1, decimal unitPrice = 0)
        {
            var existingItem = Items.FirstOrDefault(i => i.BookId == bookId);

            if (existingItem != null)
            {
                existingItem.Quantity = existingItem.Quantity + quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice - ((decimal)existingItem.Book.Discount * (existingItem.Quantity * existingItem.UnitPrice));
            }
            else
            {
                Items.Add(
                    new CartItem()
                    {
                        BookId = bookId,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        TotalPrice = quantity * book.Price - ((decimal)book.Discount * (quantity * book.Price))
                    });
                var a = Items;
            }
        }


        public void UpdateItem(int cartItemId, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == cartItemId);
            if (quantity == 0)
            {
                Items.Remove(existingItem);

            }
            else
            {
                existingItem.Quantity = quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice - ((decimal)existingItem.Book.Discount * (existingItem.Quantity * existingItem.UnitPrice));

            }
        }

        public void RemoveItem(int cartItemId)
        {
            var removedItem = Items.FirstOrDefault(x => x.Id == cartItemId);
            if (removedItem != null)
            {
                if (removedItem.Quantity == 1)
                {
                    Items.Remove(removedItem);
                }
                removedItem.Quantity--;
            }
        }

        public void RemoveItemWithProduct(int bookId)
        {
            var removedItem = Items.FirstOrDefault(x => x.BookId == bookId);
            if (removedItem != null)
            {
                Items.Remove(removedItem);
            }
        }

        public void RemoveItemsWithId(int bookId)
        {
            foreach (var item in Items.Where(x => x.BookId == bookId).ToList())
            {
                Items.Remove(item);
            }
        }

        public void ClearItems()
        {
            Items.Clear();
        }

    }


    public class ShoppingCartCreateDto
    {
        public int AccountId { get; set; }
        public string LastUpdated { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartUpdateDto
    {
        public int cartId { get; set; }
        public int cartItemId { get; set; }
        public int quantity { get; set; }
    }
}