using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пара6_7_8
{
    internal class Program
    {
       unsafe static void Main(string[] args)
        {
            int x = 50;
            int* p =&x;
            Console.WriteLine($"znachenie: { x}");
            Console.WriteLine($"address iacheike: {(ulong)p:X}");
            Console.WriteLine($"znachenie cherez ukazatel: {*p}");
            *p = 100;
            Console.WriteLine($"new znachenie peremennoi: {x}");

            int** pp = &p;
            Console.WriteLine($"ukazatel na ukazatel: {**pp}");
            **pp = 999;
            Console.WriteLine($"ishodnaya peremennaya: {x}");

            int[] numbers = { 1, 2, 3, 4, 5 };
            fixed (int* ptr=numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine($"element {i}: *(p+{i})={*(ptr + i)}");
                    *(ptr + i) +=10;
                }
                Console.WriteLine("array after update:");
                Console.WriteLine(string.Join(",", numbers));
            }
        }
    }
}
