using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> intBox= new Box<int>();
            intBox.Put(12);
            Console.WriteLine("Number in box: " + intBox.Get());
            Box<string> stringBox= new Box<string>();
            stringBox.Put("Hello");
            Console.WriteLine("TExt in box: "+stringBox.Get());
            Console.WriteLine();
            int number1 = 5;
            int number2= 10;
            Utils.Swap(ref number1, ref number2 );
            Console.WriteLine($"Swap: {number1},{number2}");
            string text1 = "no";
            string text2 = "yes";
            Utils.Swap(ref text1, ref text2 );
            Console.WriteLine($"string Swap {text1}, {text2}") ;
            Console.ReadLine();
        }
        public class Box<T>
        {
            private T item;
            public void Put(T Item)
            {
                item = Item;
            }
            public T Get()
            {
                return item;
            }
        }
        public static class Utils
        {
            public static void Swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }
    }
}
