using Xunit;
using ShoppingCart.Core;

public class CartTests
{
    [Fact]
    public void AddItem_NewProduct_CalculatesCorrectSubtotal()
    {
        
        var cart = new ShoppingCart.Core.ShoppingCart();
        var item = new CartItem("PROD-01", "Laptop", 1000.00m, 1);

        
        cart.AddItem(item);

        
        Assert.Single(cart.Items);
        Assert.Equal(1000.00m, cart.GetSubTotal());
    }
}