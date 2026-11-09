using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Core
{
    public record CartItem(string ProductId, string Name, decimal Price, int Quantity);

    public class ShoppingCart
    {
        private readonly List<CartItem> _items = new();
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public void AddItem(CartItem item)
        {
            if (item.Quantity <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                _items.Remove(existingItem);
                _items.Add(existingItem with { Quantity = existingItem.Quantity + item.Quantity });
            }
            else
            {
                _items.Add(item);
            }
        }

        public decimal GetSubTotal()
        {
            return _items.Sum(i => i.Price * i.Quantity);
        }
    }
}
