using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООПзадание1
{
    internal class Program
    {
        static void Main(string[] args)
            {
            Car car1 = new Car("BMW", "X5", 2022, 120);
            car1.Accelerate(100);
            car1.ShowInfo();
            Car car2 = new Car("porsche", "911", 2000, 250);
            car2.ShowInfo();
            
            }
        }
        public class Car
        {
            private string brand;
            private string model;
            private int year;
            private int speed;

            public string Brand
            {
                get { return brand; }
                set { brand = value; }
            }

            public int Year
            {
                get { return year; }
                set { year = value; }
            }

            public string Model
            {
                get { return model; }
                set { model = value; }
            }

            public int Speed
        {
            get { return speed; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("speed can`t be less then 0");
                speed = value;
            }
        }
                
        public Car(string brand, string model, int year, int speed)
            {
                Brand = brand;
                Year = year;
                Model = model;
                Speed = speed;
            }
            public void Accelerate(int value)
            {
            Console.WriteLine($"The car accelerated by {value} started speed is {Speed}");
            if (value < 0)
                    throw new IndexOutOfRangeException("Accelerate can`t be less then 0.");
            Speed += value;
            }
            public void ShowInfo()
            {
                Console.WriteLine($"Brand: {Brand}");
                Console.WriteLine($"Model: {Model}");
                Console.WriteLine($"Year: {Year}");
                Console.WriteLine($"Speed: {Speed} km/h");
            Console.WriteLine();
            }

        }
    }
        