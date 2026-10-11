using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ооп3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie first = new Movie();
            Movie second = new Movie();

            List<Movie> movies = new List<Movie>();
            movies.Add(first);
            movies.Add(second);

            CinemaHall hall = new CinemaHall(first, 10);

            Customer client = new Customer("Vel");

            BookingService service = new BookingService(movies, hall, client);

            service.ShowMovies();
            service.Book();
            service.Book();
            client.ShowBookings();
            service.Cancel();
            hall.ShowInfo();
        }
    }
    public class Movie
    {
        private string name;
        private int duration;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter the title!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Duration
        {
            get { return duration; }
            private set
            {
                if (value <= 0 || value > 270)
                {
                    throw new ArgumentException("Wrong duration. This is impossible.");
                }
                else
                {
                    duration = value;
                }
            }
        }

        public Movie()
        {
            Console.WriteLine("Enter the title of film.");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the duration of film (cannot be zero, or more then 270 min.).");
            Duration = Convert.ToInt32(Console.ReadLine());
        }

        public void MShowInfo()
        {
            Console.WriteLine($"Film {Name} duration {Duration} min.");
            Console.WriteLine();
        }
    }
    public class Seat
    {
        private int number;
        private bool reserve;

        public int Number
        {
            get { return number; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Seat number must be not less than 1!");
                }
                else
                {
                    number = value;
                }
            }
        }

        public bool Reserve
        {
            get { return reserve; }
            private set { reserve = value; }
        }

        public Seat(int number)
        {
            Number = number;
            Reserve = false;
        }
        public bool ReserveSeat()
        {
            if (Reserve == true)
            {
                return false;
            }
            Reserve = true;
            return true;
        }
        public void Cancel()
        {
            Reserve = false;
        }
    }

    public class CinemaHall
    {
        private List<Seat> seats;
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            private set { movie = value; }
        }

        public List<Seat> Seats
        {
            get { return seats; }
            private set { seats = value; }
        }

        public CinemaHall(Movie movie, int count)
        {
            Movie = movie;

            if (count < 1)
            {
                throw new ArgumentException("Seats must be not less than 1!");
            }

            Seats = new List<Seat>();
            for (int i = 1; i <= count; i++)
            {
                Seats.Add(new Seat(i));
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Film: {Movie.Name}");
            for (int i = 0; i < Seats.Count; i++)
            {
                Console.Write(Seats[i].Reserve ? "[X]" : "[O]");
            }
            Console.WriteLine();

        }
    }

    public class Customer
    {
        private string name;
        private List<Seat> bookings;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter the name!");
                }
                else
                {
                    name = value;
                }
            }
        }

        public List<Seat> Bookings
        {
            get { return bookings; }
            private set { bookings = value; }
        }

        public Customer(string name)
        {
            Name = name;
            Bookings = new List<Seat>();
        }

        public void AddBooking(Seat seat)
        {
            Bookings.Add(seat);
        }
        public void CancelBooking(Seat seat)
        {
            seat.Cancel();
            Bookings.Remove(seat);
        }

        public void ShowBookings()
        {
            Console.WriteLine($"Customer {Name} bookings:");
            if (Bookings.Count == 0)
            {
                Console.WriteLine("  (no bookings)");
            }
            else
            {
                for (int i = 0; i < Bookings.Count; i++)
                {
                    Console.WriteLine($"  seat {Bookings[i].Number}");
                }
            }
            Console.WriteLine();
        }
    }
    public class BookingService
    {
        private List<Movie> movies;
        private CinemaHall hall;
        private Customer customer;

        public BookingService(List<Movie> movies, CinemaHall hall, Customer customer)
        {
            this.movies = movies;
            this.hall = hall;
            this.customer = customer;
        }

        public void ShowMovies()
        {
            Console.WriteLine("Movies:");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i].Name}");
            }
            Console.WriteLine();
        }

        public void Book()
        {
            hall.ShowInfo();

            Console.WriteLine("Enter seat number:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 1 || num > hall.Seats.Count)
            {
                Console.WriteLine("There is no such seat.");
                return;
            }
            Seat seat = hall.Seats[num - 1];
            if (seat.ReserveSeat())
            {
                Console.WriteLine($"You successfully reserved seat {num}!");
                customer.AddBooking(seat);
            }
            else
            {
                Console.WriteLine($"Sorry, seat {num} is already reserved.");
            }
            Console.WriteLine();
        }
        public void Cancel()
        {
            customer.ShowBookings();

            if (customer.Bookings.Count == 0)
            {
                return;
            }

            Console.WriteLine("Enter seat number to cancel:");
            int num = Convert.ToInt32(Console.ReadLine());
            Seat found = null;
            for (int i = 0; i < customer.Bookings.Count; i++)
            {
                if (customer.Bookings[i].Number == num)
                {
                    found = customer.Bookings[i];
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine($"You have no booking for seat {num}.");
                return;
            }

            customer.CancelBooking(found);
            Console.WriteLine($"Seat {num} is now free.");
            Console.WriteLine();
        }
    }
}
