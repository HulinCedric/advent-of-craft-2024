namespace SantaMarket.Model.SpecialOffers;

public class TenPercentDiscountOffer : IOffer
{
    private const double DiscountPercentage = 10;
    private const double DiscountRate = DiscountPercentage / 100.0;

    public Discount? CalculateDiscount(Product product, double unitPrice, int quantity)
        => new(
            product,
            DiscountPercentage + "% off",
            -quantity * unitPrice * DiscountRate);
}