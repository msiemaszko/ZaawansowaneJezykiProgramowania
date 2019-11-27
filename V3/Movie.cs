using System;

namespace V3
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        private readonly String title;
        private int priceCode;

        public Movie(String title, int priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return priceCode;
        }

        public void SetPriceCode(int arg)
        {
            priceCode = arg;
        }


        public String GetTitle()
        {
            return title;
        }


        private Boolean IsNewRelease()
        {
            return GetPriceCode() == Movie.NEW_RELEASE;
        }


        public int CountPoints(int daysRented)
        {
            // add bonus for a two day new release rental
            if (IsNewRelease() && daysRented > 1)
                return 2;

            // add frequent renter points
            return 1;
        }


        public double CountPrice(int daysRented)
        {
            //determine amounts for each position
            switch (GetPriceCode())
            {
                case REGULAR:
                    return CalculatePrice(2.0, 2, 1.5, daysRented);

                case NEW_RELEASE:
                    return daysRented * 3;

                case CHILDRENS:
                    return CalculatePrice(1.5, 3, 1.5, daysRented);
            }
            return 0;
        }


        private double CalculatePrice(double initialPrice, int initialDays, double dailyPrice, int daysRented)
        {
            double thisAmount = 0;

            // nalicz standardowa dzienna oplate
            thisAmount += initialPrice;

            // jezeli czas wypozyczenia przekroczy norminalna ilisc dni
            if (daysRented > initialDays)
                thisAmount += (daysRented - initialDays) * dailyPrice;

            return thisAmount;
        }
    }
}
