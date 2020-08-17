

using System;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => _id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id can not be less or equal than 0.");
                }

                this._id = value;
            }
        }

        public string Manufacturer
        {
            get => _manufacturer;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty.");
                }

                this._manufacturer = value;
            }
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");
                }

                this._model = value;
            }
        }

        public virtual decimal Price
        {
            get => _price;
            private protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }

                this._price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => _overallPerformance;
            private protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }

                this._overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return
                $"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
