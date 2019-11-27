 namespace V1
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int getDaysRented()
        {
            return _daysRented;
        }

        public Movie getMovie()
        {
            return _movie;
        }

        public int countPoints()
        {
            // add bonus for a two day new release rental
            if ((getMovie().getPriceCode() == Movie.NEW_RELEASE) && getDaysRented() > 1)
                return 2;

            // add frequent renter points
            return 1;
        }

        public double countPrice()
        {
            double thisAmount = 0;

            //determine amounts for each position
            switch (this.getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (this.getDaysRented() > 2)
                        thisAmount += (this.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += this.getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (this.getDaysRented() > 3)
                        thisAmount += (this.getDaysRented() - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }

    }
}
