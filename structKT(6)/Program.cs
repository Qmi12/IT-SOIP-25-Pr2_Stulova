using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structKT_6_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            Point p1 = new Point();
            p1.X = 1; p1.Y = 2;
            Point p2 = new Point();
            p2.X = 4; p2.Y = 6;
            double dist = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"1. Расстояние: {dist}");

            // 2
            Rectangle rect = new Rectangle();
            rect.Width = 5; rect.Height = 10;
            Console.WriteLine($"2. Площадь: {rect.GetArea()}, Периметр: {rect.GetPerimeter()}");

            // 3
            Book book = new Book();
            book.Title = "Война и мир"; book.Author = "Толстой"; book.Year = 1869;
            Console.WriteLine($"3. {book.Title} - {book.Author} ({book.Year})");

            // 4
            ComplexNumber c1 = new ComplexNumber();
            c1.Real = 1; c1.Imag = 2;
            ComplexNumber c2 = new ComplexNumber();
            c2.Real = 3; c2.Imag = 4;
            ComplexNumber cAdd = c1.Add(c2);
            ComplexNumber cSub = c1.Subtract(c2);
            ComplexNumber cMul = c1.Multiply(c2);
            Console.WriteLine($"4. Сложение: {cAdd.Real}+{cAdd.Imag}i, Вычитание: {cSub.Real}+{cSub.Imag}i, Умножение: {cMul.Real}+{cMul.Imag}i");

            // 5
            Color color = new Color();
            color.R = 255; color.G = 128; color.B = 0;
            Console.WriteLine($"5. HEX: {color.ToHex()}");

            // 6
            SimpleDate date = new SimpleDate();
            date.Day = 1; date.Month = 1; date.Year = 2024;
            Console.WriteLine($"6. Високосный? {date.IsLeapYear()}");

            // 7
            Vector2D v1 = new Vector2D();
            v1.X = 3; v1.Y = 4;
            Vector2D v2 = new Vector2D();
            v2.X = 1; v2.Y = 2;
            Vector2D vNorm = v1.Normalize();
            Console.WriteLine($"7. Длина: {v1.Length()}, Норм: ({vNorm.X}, {vNorm.Y}), Скаляр: {v1.Dot(v2)}");

            // 8
            Money m1 = new Money();
            m1.Rubles = 10; m1.Kopecks = 50;
            Money m2 = new Money();
            m2.Rubles = 5; m2.Kopecks = 70;
            Money mAdd = m1.Add(m2);
            Money mSub = m1.Subtract(m2);
            Console.WriteLine($"8. Сложение: {mAdd.Rubles}р {mAdd.Kopecks}к, Вычитание: {mSub.Rubles}р {mSub.Kopecks}к, m1>m2: {m1.IsGreaterThan(m2)}");

            // 9
            Triangle t = new Triangle();
            Point ptA = new Point(); ptA.X = 0; ptA.Y = 0;
            Point ptB = new Point(); ptB.X = 3; ptB.Y = 0;
            Point ptC = new Point(); ptC.X = 0; ptC.Y = 4;
            t.A = ptA; t.B = ptB; t.C = ptC;
            Console.WriteLine($"9. Периметр: {t.GetPerimeter()}, Площадь: {t.GetArea()}");

            // 10
            Point3D p3d1 = new Point3D();
            p3d1.X = 0; p3d1.Y = 0; p3d1.Z = 0;
            Point3D p3d2 = new Point3D();
            p3d2.X = 1; p3d2.Y = 1; p3d2.Z = 1;
            Console.WriteLine($"10. 3D Расстояние: {p3d1.GetDistance(p3d2)}");

            // 11
            ChessPiece piece = new ChessPiece();
            piece.Name = "Конь"; piece.Position = "E4";
            piece.Move("G5");
            Console.WriteLine($"11. Фигура: {piece.Name}, Новая позиция: {piece.Position}");

            // 12
            GeoPoint gp1 = new GeoPoint();
            gp1.Latitude = 55.7558; gp1.Longitude = 37.6173;
            GeoPoint gp2 = new GeoPoint();
            gp2.Latitude = 59.9343; gp2.Longitude = 30.3351;
            Console.WriteLine($"12. GPS Расстояние: {gp1.GetDistance(gp2)} км");
        }
    }
    public struct Point
        {
            private double _x;
            private double _y;

            public double X { get { return _x; } set { _x = value; } }
            public double Y { get { return _y; } set { _y = value; } }
        }

        public struct Rectangle
        {
            private double _width;
            private double _height;

            public double Width { get { return _width; } set { _width = value; } }
            public double Height { get { return _height; } set { _height = value; } }

            public double GetArea()
            {
                return _width * _height;
            }

            public double GetPerimeter()
            {
                return 2 * (_width + _height);
            }
        }

        public struct Book
        {
            private string _title;
            private string _author;
            private int _year;

            public string Title { get { return _title; } set { _title = value; } }
            public string Author { get { return _author; } set { _author = value; } }
            public int Year { get { return _year; } set { _year = value; } }
        }

        // Уровень 2
        public struct ComplexNumber
        {
            private double _real;
            private double _imag;

            public double Real { get { return _real; } set { _real = value; } }
            public double Imag { get { return _imag; } set { _imag = value; } }

            public ComplexNumber Add(ComplexNumber other)
            {
                ComplexNumber result = new ComplexNumber();
                result.Real = this._real + other.Real;
                result.Imag = this._imag + other.Imag;
                return result;
            }

            public ComplexNumber Subtract(ComplexNumber other)
            {
                ComplexNumber result = new ComplexNumber();
                result.Real = this._real - other.Real;
                result.Imag = this._imag - other.Imag;
                return result;
            }

            public ComplexNumber Multiply(ComplexNumber other)
            {
                ComplexNumber result = new ComplexNumber();
                result.Real = this._real * other.Real - this._imag * other.Imag;
                result.Imag = this._real * other.Imag + this._imag * other.Real;
                return result;
            }
        }

        public struct Color
        {
            private int _r;
            private int _g;
            private int _b;

            public int R { get { return _r; } set { _r = value; } }
            public int G { get { return _g; } set { _g = value; } }
            public int B { get { return _b; } set { _b = value; } }

            public string ToHex()
            {
                return "#" + _r.ToString("X2") + _g.ToString("X2") + _b.ToString("X2");
            }
        }

        public struct SimpleDate
        {
            private int _day;
            private int _month;
            private int _year;

            public int Day { get { return _day; } set { _day = value; } }
            public int Month { get { return _month; } set { _month = value; } }
            public int Year { get { return _year; } set { _year = value; } }

            public bool IsLeapYear()
            {
                return (_year % 4 == 0 && _year % 100 != 0) || (_year % 400 == 0);
            }
        }

        // Уровень 3
        public struct Vector2D
        {
            private double _x;
            private double _y;

            public double X { get { return _x; } set { _x = value; } }
            public double Y { get { return _y; } set { _y = value; } }

            public double Length()
            {
                return Math.Sqrt(_x * _x + _y * _y);
            }

            public Vector2D Normalize()
            {
                double len = Length();
                Vector2D result = new Vector2D();

                if (len == 0)
                {
                    result.X = 0;
                    result.Y = 0;
                    return result;
                }

                result.X = _x / len;
                result.Y = _y / len;
                return result;
            }

            public double Dot(Vector2D other)
            {
                return this._x * other.X + this._y * other.Y;
            }
        }

        public struct Money
        {
            private int _rubles;
            private int _kopecks;

            public int Rubles { get { return _rubles; } set { _rubles = value; } }
            public int Kopecks { get { return _kopecks; } set { _kopecks = value; } }

            private int GetTotalKopecks()
            {
                return _rubles * 100 + _kopecks;
            }

            public Money Add(Money other)
            {
                int total = this.GetTotalKopecks() + other.GetTotalKopecks();
                Money result = new Money();
                result.Rubles = total / 100;
                result.Kopecks = total % 100;
                return result;
            }

            public Money Subtract(Money other)
            {
                int total = this.GetTotalKopecks() - other.GetTotalKopecks();
                Money result = new Money();
                result.Rubles = total / 100;
                result.Kopecks = total % 100;
                return result;
            }

            public bool IsGreaterThan(Money other)
            {
                return this.GetTotalKopecks() > other.GetTotalKopecks();
            }

            public bool IsLessThan(Money other)
            {
                return this.GetTotalKopecks() < other.GetTotalKopecks();
            }
        }

        public struct Triangle
        {
            private Point _a;
            private Point _b;
            private Point _c;

            public Point A { get { return _a; } set { _a = value; } }
            public Point B { get { return _b; } set { _b = value; } }
            public Point C { get { return _c; } set { _c = value; } }

            public double GetSideAB()
            {
                return Math.Sqrt(Math.Pow(_b.X - _a.X, 2) + Math.Pow(_b.Y - _a.Y, 2));
            }

            public double GetSideBC()
            {
                return Math.Sqrt(Math.Pow(_c.X - _b.X, 2) + Math.Pow(_c.Y - _b.Y, 2));
            }

            public double GetSideAC()
            {
                return Math.Sqrt(Math.Pow(_c.X - _a.X, 2) + Math.Pow(_c.Y - _a.Y, 2));
            }

            public double GetPerimeter()
            {
                return GetSideAB() + GetSideBC() + GetSideAC();
            }

            public double GetArea()
            {
                double a = GetSideAB();
                double b = GetSideBC();
                double c = GetSideAC();
                double p = GetPerimeter() / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public struct Point3D
        {
            private double _x;
            private double _y;
            private double _z;

            public double X { get { return _x; } set { _x = value; } }
            public double Y { get { return _y; } set { _y = value; } }
            public double Z { get { return _z; } set { _z = value; } }

            public double GetDistance(Point3D other)
            {
                return Math.Sqrt(Math.Pow(other.X - _x, 2) + Math.Pow(other.Y - _y, 2) + Math.Pow(other.Z - _z, 2));
            }
        }

        // Дополнительное
        public struct ChessPiece
        {
            private string _name;
            private string _position;

            public string Name { get { return _name; } set { _name = value; } }
            public string Position { get { return _position; } set { _position = value; } }

            public void Move(string newPosition)
            {
                this._position = newPosition;
            }
        }

        public struct GeoPoint
        {
            private double _latitude;
            private double _longitude;

            public double Latitude { get { return _latitude; } set { _latitude = value; } }
            public double Longitude { get { return _longitude; } set { _longitude = value; } }

            public double GetDistance(GeoPoint other)
            {
                double R = 6371;
                double dLat = (other.Latitude - this._latitude) * Math.PI / 180;
                double dLon = (other.Longitude - this._longitude) * Math.PI / 180;

                double lat1 = this._latitude * Math.PI / 180;
                double lat2 = other.Latitude * Math.PI / 180;

                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                           Math.Cos(lat1) * Math.Cos(lat2) *
                           Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                return R * c;
            }
        }

}
