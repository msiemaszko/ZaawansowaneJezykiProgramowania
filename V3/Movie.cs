using System;

namespace V3
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int NEW_RELEASE = 1;
        public const int REGULAR = 0;

        private readonly String title;
        private Price price;

        public Movie(String title, int priceCode)
        {
            this.title = title;
            SetPriceCode(priceCode);
        }

        public int GetPriceCode()
        {
            return price.getPriceCode();
        }

        public void SetPriceCode(int newPriceCode)
        {
            switch (newPriceCode)
            {
                case REGULAR:
                    this.price = new RegularPrice();
                    break;

                case NEW_RELEASE:
                    price = new NewReleasePrice();
                    break;

                case CHILDRENS:
                    price = new ChildrensPrice();
                    break;

                default:
                    throw new ArgumentException("Nieprawidlowy kod Ceny");
            }
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
            return price.CountPrice(daysRented);
        }
    }
}
