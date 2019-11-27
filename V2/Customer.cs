using System.Collections.Generic;

namespace V2
{
    public class Customer
    {

        private readonly string name;
        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public string GetName()
        {
            return name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (Rental rental in rentals)
            {
                // cena za pozycje wyporzyczenia
                double thisAmount = rental.CountPrice();

                // dolicz punkty stalego klienta
                frequentRenterPoints += rental.CountPoints();

                // show figures for this rental
                result += "\t" + rental.GetMovie().GetTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }
    }
}
