using product;
using Xunit;

namespace product.Test;

public class UnitTest1
{
    [Fact]
    public void AddTwoNumbers_ReturnSum()
    {
        var result = Product.Add(2, 7);
        Assert.Equal(5, result);
    }
}
