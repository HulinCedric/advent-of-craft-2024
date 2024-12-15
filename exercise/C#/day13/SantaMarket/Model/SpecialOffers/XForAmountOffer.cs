using LanguageExt;

namespace SantaMarket.Model.SpecialOffers;

public class XForAmountOffer(int x, double amount) : IOffer
{
    public Option<Discount> CalculateDiscount(Product product, double unitPrice, int quantity)
    {
        Discount? discount = null;

        if (quantity >= x)
        {
            var discountTotal = unitPrice * quantity -
                                (amount * (quantity / x) + quantity % x * unitPrice);
            discount = new Discount(product, $"{x} for " + amount, -discountTotal);
        }

        return discount;
    }
}