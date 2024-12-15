namespace SantaMarket.Model.SpecialOffers;

public interface IOffer
{
    public Discount? CalculateDiscount(Product product, double unitPrice, int quantity);
}