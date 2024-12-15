using LanguageExt;

namespace SantaMarket.Model.SpecialOffers;

public class XForAmountOffer(int x, double amount) : IOffer
{
    public Option<Discount> CalculateDiscount(Product product, double unitPrice, int quantity)
    {
        if (CanApplyDiscount(quantity)) return Option<Discount>.None;

        var discountTotal = CalculateDiscountTotal(unitPrice, quantity);

        return new Discount(product, DiscountName(), -discountTotal);
    }

    private string DiscountName() => $"{x} for " + amount;

    private bool CanApplyDiscount(int quantity) => quantity < x;

    private double CalculateDiscountTotal(double unitPrice, int quantity)
    {
        var fullPriceTotal = unitPrice * quantity;
        var discountedPriceTotal = amount * (quantity / x) + quantity % x * unitPrice;
        return fullPriceTotal - discountedPriceTotal;
    }
}