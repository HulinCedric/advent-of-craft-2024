using SantaMarket.Model.SpecialOffers;

namespace SantaMarket.Model
{
    public class ChristmasElf(ISantamarketCatalog catalog)
    {
        private readonly Dictionary<Product, IOffer> _offers = new();

        public void AddSpecialOffer(Product product, IOffer offer)
            => _offers[product] = offer;

        public Receipt ChecksOutArticlesFrom(ShoppingSleigh thesleigh)
        {
            var receipt = new Receipt();
            var productQuantities = thesleigh.Items();

            foreach (var pq in productQuantities)
            {
                var p = pq.Product;
                var quantity = pq.Quantity;
                var unitPrice = catalog.GetUnitPrice(p);
                var price = quantity * unitPrice;
                receipt.AddProduct(p, quantity, unitPrice, price);
            }

            thesleigh.HandleOffers(receipt, _offers, catalog);

            return receipt;
        }
    }
}