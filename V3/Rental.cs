namespace V3
{
    public class Rental
    {
        private Movie movie;
        private readonly int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return daysRented;
        }

        public Movie GetMovie()
        {
            return movie;
        }

        public int CountPoints()
        {
            return movie.CountPoints(daysRented);

        }

        public double CountPrice()
        {
            return movie.CountPrice(daysRented);
        }
    }
}
