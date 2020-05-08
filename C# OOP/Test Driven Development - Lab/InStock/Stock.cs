
namespace InStock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Stock
    {
        private List<Product> products;
        public Stock()
        {
            this.products = new List<Product>();
        }
        public Stock(List<Product> products)
        {
            this.products = products;
        }
        public int Count => this.products.Count;
        public void Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }
            if (this.products.Any(x => x.Label == product.Label))
            {
                throw new InvalidOperationException("Cannot add product with an existing label");
            }
            this.products.Add(product);
        }

        public bool Contains(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }
            return this.products.Any(x => x.Label == product.Label);
        }

        public Product Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            return this.products[index];
        }

        public Product FindByLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("Label cannot be null");
            }

            if (this.products.Any(x => x.Label == label))
            {
                return this.products.First(x => x.Label == label);
            }
            else
            {
                throw new InvalidOperationException("No such label exists");
            }
        }

        public List<Product> FindAllInPriceRange(decimal startPrice, decimal endPrice)
        {
            if (startPrice < 0 || endPrice < 0)
            {
                throw new InvalidOperationException("Can't search with a negative price");
            }
            if (startPrice >= endPrice)
            {
                throw new InvalidOperationException("Start price cannot be higher or equal to end price");
            }
            var withinPriceRange = new List<Product>();
            foreach (var product in this.products)
            {
                if (product.Price >= startPrice && product.Price <= endPrice)
                {
                    withinPriceRange.Add(product);
                }
            }
            return withinPriceRange;
        }

        public List<Product> FindAllByPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new InvalidOperationException("Price cannot be less or equal to zero");
            }
            var productsByPrice = new List<Product>();
            foreach (var product in products)
            {
                if (product.Price == price)
                {
                    productsByPrice.Add(product);
                }
            }
            return productsByPrice;
        }

        public Product FindMostExpensiveProduct()
        {
            if (this.products.Count == 0)
            {
                throw new InvalidOperationException("No products to find the most expensive");
            }
            decimal highestPrice = this.products[0].Price;
            var mostExpensiveProduct = new Product("Label",1,1);
            foreach (var product in this.products)
            {
                if (product.Price >= highestPrice)
                {
                    mostExpensiveProduct = product;
                }
            }
            return mostExpensiveProduct;
        }
    }
}
