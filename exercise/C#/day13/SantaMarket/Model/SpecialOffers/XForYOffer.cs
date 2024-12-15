using LanguageExt;

namespace SantaMarket.Model.SpecialOffers;

public class XForYOffer(int x, int y) : IOffer
{
    public Option<Discount> CalculateDiscount(Product product, double unitPrice, int quantity)
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