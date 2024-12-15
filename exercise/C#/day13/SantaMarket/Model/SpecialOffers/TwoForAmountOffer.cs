namespace SantaMarket.Model.SpecialOffers;

public class TwoForAmountOffer(double amount) : IOffer
{
    public Discount? CalculateDiscount(Product product, double unitPrice, int quantity)
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