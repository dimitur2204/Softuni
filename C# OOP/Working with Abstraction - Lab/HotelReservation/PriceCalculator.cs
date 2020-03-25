using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    class PriceCalculator
    {
        public double GetPrice(double ppd, int days, Discount discount, Season season) 
        {
            double mainPrice = ppd * days * (int)season;
            double discountPrice = mainPrice * (int)discount / 100;
            return mainPrice - discountPrice;
        }
    }
}
