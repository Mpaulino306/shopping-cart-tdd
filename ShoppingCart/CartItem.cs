namespace ShoppingCart
{
    public class CartItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public void AddItem(int id, string name, decimal price, int quantity = 1)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem { Id = id, Name = name, Price = price, Quantity = quantity });
            }
        }

        public void RemoveItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return _items.Sum(i => i.Price * i.Quantity);
        }

        public int GetTotalItemsCount()
        {
            return _items.Sum(i => i.Quantity);
        }
    }
}

