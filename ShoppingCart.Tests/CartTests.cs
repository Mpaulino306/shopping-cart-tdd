namespace ShoppingCart.Tests
{
    public class CartTests
    {
        [Fact]
        public void Cart_Should_Start_Empty()
        {
            
            var cart = new Cart();

            
            Assert.Empty(cart.Items);
            Assert.Equal(0, cart.GetTotalItemsCount());
        }

        [Fact]
        public void Should_Add_Item_To_Cart()
        {
            
            var cart = new Cart();

            
            cart.AddItem(1, "Laptop", 1200.00m);

            
            Assert.Single(cart.Items);
            Assert.Equal(1, cart.GetTotalItemsCount());
        }

        [Fact]
        public void Should_Increment_Quantity_When_Adding_Existing_Item()
        {
            
            var cart = new Cart();

            
            cart.AddItem(1, "Mouse", 25.00m, 1);
            cart.AddItem(1, "Mouse", 25.00m, 2); // Agregamos 2 más

            // Assert
            Assert.Single(cart.Items);
            Assert.Equal(3, cart.GetTotalItemsCount());
            Assert.Equal(75.00m, cart.GetTotalPrice());
        }

        [Fact]
        public void Should_Calculate_Total_Price_Correctly()
        {
            
            var cart = new Cart();

            
            cart.AddItem(1, "Teclado", 50.00m, 2); // 100
            cart.AddItem(2, "Monitor", 200.00m, 1); // 200

            
            Assert.Equal(300.00m, cart.GetTotalPrice());
        }

        [Fact]
        public void Should_Remove_Item_From_Cart()
        {
            
            var cart = new Cart();
            cart.AddItem(1, "Audifonos", 45.00m);

            
            cart.RemoveItem(1);

            
            Assert.Empty(cart.Items);
            Assert.Equal(0, cart.GetTotalItemsCount());
        }
    }
}

