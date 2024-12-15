namespace SantaMarket.Model.SpecialOffers;

public class FiveForAmountOffer(double amount) : IOffer
{
    public Discount? CalculateDiscount(Product product, double unitPrice, int quantity)
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