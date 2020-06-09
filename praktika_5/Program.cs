using System;

namespace praktika_5
{
    class Program
    {
        static public double InputNumber(string ForUser)
        {
            bool ok = true;
            double number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToDouble(buf);
                    ok = false;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод числа!");
                }
            } while (ok);
            return number;
        }
        static public int InputSize(string ForUser, int left = 1, int right = 100)
        {
            bool ok = true;
            int number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number <= right) ok = false;
                    else
                    {
                        Console.WriteLine("Введите число от {0} до {1}!", left, right);
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный ввод числа!");
                }
            } while (ok);
            return number;
        }
        static void Main(string[] args)
        {
            int n = InputSize("Введите размер: ");
            Random a = new Random();
            double[,] arr = new double[n, n];
            bool ok = true;
            int stringSize=0, columnSize=0;
            do
            {
                Console.WriteLine("1.Ввести [" + stringSize + "," + columnSize + "] элемент вручную: ");
                Console.WriteLine("2.Ввести [" + stringSize + "," + columnSize + "] элемент рандомом: ");
                Console.WriteLine("3.Ввести все элементы рандомом: ");
                int variant = InputSize("", 1, 3);
                switch (variant)
                {
                    case 1:
                        {
                            arr[stringSize, columnSize] = InputNumber("");
                            if (columnSize < n - 1) columnSize++;
                            else
                            {
                                columnSize = 0;
                                stringSize++;
                            }
                            if (stringSize == n) ok = false;
                            break;
                        }
                    case 2:
                        {
                            arr[stringSize, columnSize] = a.Next(-100,100);
                            if (columnSize < n-1) columnSize++;
                            else
                            {
                                columnSize = 0;
                                stringSize++;
                            }
                            if (stringSize == n) ok = false;
                            break;
                        }
                    case 3:
                        {
                            for (int i = stringSize; i < n; i++)
                                for (int j = columnSize; j <n; j++)
                                    arr[i,j] = a.Next(-100, 100);
                            ok = false;
                            break;
                        }
                }
            } while (ok);
            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < n ; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            double nizhe = 0, na = 0, vyshe=0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i, 0] < 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j < i) nizhe += arr[i, j];
                        if (j == i) na += arr[i, j];
                        if (j > i) vyshe += arr[i, j];
                    }
                }
            }
            Console.WriteLine("Сумма ниже главной диагонали: " + nizhe);
            Console.WriteLine("Сумма на главной диагонали: " + na);
            Console.WriteLine("Сумма выше главной диагонали: " + vyshe);
            Console.ReadKey();
        }
    }
}
