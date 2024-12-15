using LanguageExt;

namespace SantaMarket.Model.SpecialOffers;

public interface IOffer
{
    public Option<Discount> CalculateDiscount(Product product, double unitPrice, int quantity);
}