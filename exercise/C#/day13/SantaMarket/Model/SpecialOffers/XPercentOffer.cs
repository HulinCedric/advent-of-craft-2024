namespace SantaMarket.Model.SpecialOffers;

public class XPercentOffer : IOffer
{
    private readonly double _discountPercentage;
    private readonly double _discountRate;

    public XPercentOffer(double x)
    {
        _discountPercentage = x;
        _discountRate = _discountPercentage / 100.0;
    }

    public Discount? CalculateDiscount(Product product, double unitPrice, int quantity)
        => new(
            product,
            _discountPercentage + "% off",
            -quantity * unitPrice * _discountRate);
}