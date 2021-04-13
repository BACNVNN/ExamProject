using System;

namespace ExamProject
{
    class Program
    {
        static double RectInt(Func<double, double> f, double a, double b, int N)
        {
            double S = 0;
            double h = (b - a) / N;
            for (int i = 0; i < N; i++)
            {
                S += h * f(a + i * h);
            }
            return Math.Abs(S);
        }
        static double TrapInt(Func<double, double> f, double a, double b, int N)
        {
            double S = 0;
            double h = (b - a) / N;
            for (int i = 0; i < N; i++)
            {
                S += h / 2 * (f(a + i * h) + f(a + (i + 1) * h));
            }
            return Math.Abs(S);
        }
        static double SimpInt(Func<double, double> f, double a, double b, int N)
        {
            double h = ((b - a) / N);
            double S = 0;
            for (int i = 1; i < N; i += 2)
            {
                S += h / 3 * (f(a + h * (i - 1)) + 4 * f(a + i * h) + f(a + h * (i + 1)));
            }
            return Math.Abs(S);
        }
        static void Table()
        {
            Console.WriteLine("#########################################################################");
            Console.WriteLine("Номер 1 : 2x + 5 + cos(pi * x)\n" +
                "Номер 2 : 10x^4 + 2x^3 - 4x^2 - 10x + 5\n" +
                "Номер 3 : e^(1.25x) - 5x + 1\n" +
                "Номер 4 :  0.125sin(5x - 2.5) - 6x^2\n" +
                "Номер 5 : 2.5cos(2.5x)");
            Console.WriteLine("#########################################################################");
        }
        static (int num, double a, double b, int N) Inputs()
        {
            double a;
            double b;
            int N;
            int number;
            do
            {
                Console.Write("Введите номер функции > ");
                if (int.TryParse(Console.ReadLine(), out number) && number >= 1 && number <= 5)
                {
                    break;
                }
                Console.WriteLine("Это должен быть номер из списка!");
            } while (true);

            do
            {
                Console.Write("Введите левую границу > ");
                if (double.TryParse(Console.ReadLine(), out a))
                {
                    break;
                }
                Console.WriteLine("Это должно быть число!");
            } while (true);
            do
            {
                Console.Write("Введите правую границу > ");
                if (double.TryParse(Console.ReadLine(), out b))
                {
                    break;
                }
                Console.WriteLine("Это должно быть число и оно должно быть большее a!");
            } while (true);
            do
            {
                Console.Write("Введите желаемое число разбиений > ");
                if (int.TryParse(Console.ReadLine(), out N))
                {
                    break;
                }
                Console.WriteLine("Это должно быть число!");
            } while (true);
            return (number - 1, a, b, N);
        }
        static void Output(int number, double a, double b, int N)
        {
            Func<double, double>[] funcs = new Func<double, double>[5];
            funcs[0] = x => 2 * x + 5 + Math.Cos(Math.PI * x);
            funcs[1] = x => 10 * x * x * x * x * x + 2 * x * x * x - 4 * x * x - 10 * x + 5;
            funcs[2] = x => Math.Pow(Math.E, 1.25 * x) - 5 * x + 1;
            funcs[3] = x => 0.125 * Math.Sin(5 * x - 2.5) - 6 * x * x;
            funcs[4] = x => 2.5 * Math.Cos(2.5 * x);
            Console.WriteLine("#########################################################################\n" +
            "Отрезок[{0};{1}]\n" +
            "Метод прямоугольников -- площадь под графиком равна {2}\n" +
            "Метод трапеций -- площадь под графиком равна {3}\n" +
            "Метод Симпсона (парабол) -- площадь под графиком равна {4}\n" +
            "Число разбиений N равно {5}\n"+
            "#########################################################################",
            a, b,
            RectInt(funcs[number], a, b, N),
            TrapInt(funcs[number], a, b, N),
            SimpInt(funcs[number], a, b, N), N);
        }
        static void Main()
        {
            Table();
            var (number, a, b, N) = Inputs();
            Output(number, a, b, N);
            Console.Read();
        }
    }
}
