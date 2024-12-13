namespace SantaMarket.Model;

public abstract class Offer
{
    public abstract Discount? CalculateDiscount(int quantity, double unitPrice, Product product);
}

public class TwoForAmountOffer(double amount) : Offer
{
    public override Discount? CalculateDiscount(int quantity, double unitPrice, Product product)
    {
        Discount? discount = null;

        if (quantity >= 2)
        {
            var total = amount * (quantity / 2) + quantity % 2 * unitPrice;
            discount = new Discount(product, "2 for " + amount, -(unitPrice * quantity - total));
        }

        return discount;
    }
}

public class TenPercentDiscountOffer : Offer
{
    private const double DiscountPercentage = 10;
    private const double DiscountRate = DiscountPercentage / 100.0;

    public override Discount? CalculateDiscount(int quantity, double unitPrice, Product product)
        => new(
            product,
            DiscountPercentage + "% off",
            -quantity * unitPrice * DiscountRate);
}

public class FiveForAmountOffer(double amount) : Offer
{
    public override Discount? CalculateDiscount(int quantity, double unitPrice, Product product)
    {
        Discount? discount = null;

        if (quantity >= 5)
        {
            var discountTotal = unitPrice * quantity -
                                (amount * (quantity / 5) + quantity % 5 * unitPrice);
            discount = new Discount(product, "5 for " + amount, -discountTotal);
        }

        return discount;
    }
}

public class XForYOffer(int x, int y) : Offer
{
    public override Discount? CalculateDiscount(int quantity, double unitPrice, Product product)
    {
        Discount? discount = null;

        if (quantity > y)
        {
            var discountAmount = quantity * unitPrice -
                                 (quantity / x * y * unitPrice + quantity % x * unitPrice);
            discount = new Discount(product, $"{x} for {y}", -discountAmount);
        }

        return discount;
    }
}