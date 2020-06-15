
using System;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;
        public DateModifier(string startDate, string endDate)
        {
            this.startDate = DateTime.Parse(startDate);
            this.endDate = DateTime.Parse(endDate);
        }
        public int CalculateDifference() 
        {
            return Math.Abs((endDate - startDate).Days);
        }
    }
}
