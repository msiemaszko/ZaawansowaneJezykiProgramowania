using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V3
{
    abstract class Price
    {
        public abstract int getPriceCode();

        public abstract double CountPrice(int daysRented);

        protected double CalculatePrice(double initialPrice, int initialDays, double dailyPrice, int daysRented)
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

    class RegularPrice : Price
    {
        //cena za standardową pozycję
        override public int getPriceCode()
        {
            return Movie.REGULAR;
        }

        override public double CountPrice(int daysRented)
        {
            return CalculatePrice(2.0, 2, 1.5, daysRented);

        }
    }

    class NewReleasePrice : Price
    {
        //cena za nowość
        override public int getPriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        override public double CountPrice(int daysRented)
        {
            return daysRented * 3;
        }
    }


    class ChildrensPrice : Price
    {
        //cena za film dla dzieci  
        override public int getPriceCode()
        {
            return Movie.CHILDRENS;
        }

        override public double CountPrice(int daysRented)
        {
            return CalculatePrice(1.5, 3, 1.5, daysRented);
        }
    }

}
