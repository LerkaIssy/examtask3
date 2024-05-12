namespace Solution
{
    public class Class1
    {
        public static int insert(out int[] massupply, out int[] masdemand, out bool closeness, out int[,] mastarif)
        {

            Console.WriteLine("Введите количество поставщиков ");
            int a = Convert.ToInt32(Console.ReadLine());
            massupply = new int[a];
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Введите предложение " + (i + 1) + " поставщика");
                massupply[i] = Convert.ToInt32(Console.ReadLine());
            }
            //переменная для дальнейшей проверки на закрытость
            int sumsupply = massupply.Sum();
            Console.WriteLine();
            Console.WriteLine("Введите количество потребителей ");
            int b = Convert.ToInt32(Console.ReadLine());
            masdemand = new int[b];
            for (int i = 0; i < b; i++)
            {
                Console.WriteLine("Введите спрос " + (i + 1) + " потребителя");
                masdemand[i] = Convert.ToInt32(Console.ReadLine());

            }
            //вторая переменная для дальнейшей проверки на закрытость
            int sumdemand = masdemand.Sum();
            //определяем флаг на закрытость задачи
            if (sumdemand == sumsupply)
            {
                closeness = true;
            }
            else closeness = false;

            mastarif = new int[a, b];
            for (int i = 0; i < mastarif.GetLength(0); i++)
            {
                for (int j = 0; j < mastarif.GetLength(1); j++)
                {

                    Console.WriteLine("Введите тариф " + (i + 1) + " поставщика для " + (j + 1) + " потребителя");
                    mastarif[i, j] = Convert.ToInt32(Console.ReadLine());
                }

            }
            return 0;
        }




        //метод северо западного угла
        public static int NortWest(int[] massupply, int[] masdemand, int[,] mastarif, out int[,] result)
        {
            //результирующая матрица, количество строк равно количеству поставщиков, а число столбцов число потребителей
            result = new int[massupply.Length, masdemand.Length];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    //так как в методе северо западного угла мы идем "лесенкой"
                    //ищем минимум из спроса и предложения
                    if (massupply[i] > masdemand[j])
                    {
                        //если спрос меньше, то значение ячейки в рейзультирующей матрице равно значению спроса по этому столбцу
                        result[i, j] = masdemand[j];
                        //вычитаем поставку из склада
                        massupply[i] = massupply[i] - masdemand[j];
                        //зануляем столбец спроса
                        masdemand[j] = masdemand[j] - masdemand[j];

                    }
                    //те же самые манипуляции но наоборот
                    else
                    {
                        result[i, j] = massupply[i];
                        masdemand[j] = masdemand[j] - massupply[i];
                        massupply[i] = massupply[i] - massupply[i];

                    }
                    //таким образом если спрос или предложение обнуляется, то ячейки без поставок заполняются нулями
                }

            }
            return 0;
        }



        //функция вывода матрицы и целевой функции
        public static int output(int[,] result, int[,] mastarif, int[] OcenkaVertical, int[] OcenkaHorisontal, out bool degeneracy)
        {
            int Count = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                    if (result[i, j] != 0)
                    {
                        Count++;
                    }

                }
                Console.WriteLine("| " + OcenkaVertical[i] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("_______________");
            for (int i = 0; i < result.GetLength(1); i++)
            {


                Console.Write(OcenkaHorisontal[i] + " ");

            }
            Console.WriteLine();
            int L = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    L = L + result[i, j] * mastarif[i, j];
                }

            }
            Console.WriteLine("Целевая функция = " + L);
            if (Count == (result.GetLength(0) + result.GetLength(1) - 1))
            {
                degeneracy = true;
            }
            else degeneracy = false;
            return 0;
        }



        public static int MinimumElement(int[] massupply, int[] masdemand, int[,] mastarif, out int[,] result)
        {
            result = new int[massupply.Length, masdemand.Length];
            int[,] buffer = (int[,])mastarif.Clone();
            int min = 9999;
            int mini = 0;
            int minj = 0;
            int Count = 0;
            int n = massupply.Length;
            int m = masdemand.Length;
            while (massupply.Sum() != 0 && masdemand.Sum() != 0)
            {
                for (int i = 0; i < mastarif.GetLength(0); i++)
                {
                    for (int j = 0; j < mastarif.GetLength(1); j++)
                    {
                        if (min > buffer[i, j])
                        {
                            min = buffer[i, j];

                            mini = i;
                            minj = j;

                        }

                    }

                }

                if (massupply[mini] > masdemand[minj])
                {
                    //если спрос меньше, то значение ячейки в рейзультирующей матрице равно значению спроса по этому столбцу
                    result[mini, minj] = masdemand[minj];
                    //вычитаем поставку из склада
                    massupply[mini] = massupply[mini] - masdemand[minj];
                    //зануляем столбец спроса
                    masdemand[minj] = masdemand[minj] - masdemand[minj];

                    min = 9999;

                }
                //те же самые манипуляции но наоборот
                else
                {
                    result[mini, minj] = massupply[mini];
                    masdemand[minj] = masdemand[minj] - massupply[mini];
                    massupply[mini] = massupply[mini] - massupply[mini];

                    min = 9999;

                }
                buffer[mini, minj] = 99999;

            }



            return 0;
        }

        public static void potencial(int[,] result, int[,] tarif, out int[] OcenkaVertical, out int[] OcenkaHorisontal)
        {
            OcenkaVertical = new int[result.GetLength(0)];
            OcenkaHorisontal = new int[result.GetLength(1)];
            int[] BufferVer = new int[OcenkaVertical.Length];
            int[] BufferHor = new int[OcenkaHorisontal.Length];
            int[,] OcenkaFreePotencial = new int[result.GetLength(0), result.GetLength(1)];
            int count = result.GetLength(1);
            bool FreePotencial = true;
            bool Optimality = true;
            OcenkaVertical[0] = 0;
            while (FreePotencial)
            {
                for (int i = 0; i < OcenkaVertical.Length; i++)
                {

                    for (int j = 0; j < OcenkaHorisontal.Length; j++)
                    {
                        if (result[i, j] != 0)
                        {

                            if (i == 0)
                            {
                                OcenkaHorisontal[j] = tarif[i, j] - OcenkaVertical[i];
                                BufferHor[j] = 9999;
                                BufferVer[i] = 9999;
                            }
                            else
                            {
                                if (OcenkaVertical[i] != 0)
                                {
                                    OcenkaHorisontal[j] = tarif[i, j] - OcenkaVertical[i];
                                    BufferHor[j] = 9999;
                                }
                                else if (OcenkaHorisontal[j] != 0)
                                {
                                    OcenkaVertical[i] = tarif[i, j] - OcenkaHorisontal[j];
                                    BufferVer[i] = 9999;
                                }
                                else { continue; }
                            }

                        }
                        else { continue; }
                    }
                }
                FreePotencial = false;
                for (int i = 0; i < BufferHor.Length; i++)
                {
                    if (BufferHor[i] == 0)
                    {
                        FreePotencial = true;
                    }
                }
                for (int i = 0; i < BufferVer.Length; i++)
                {
                    if (BufferVer[i] == 0)
                    {
                        FreePotencial = true;
                    }
                }
            }

            Console.WriteLine("Оценка свободных ячеек");
            for (int i = 0; i < OcenkaFreePotencial.GetLength(0); i++)
            {
                for (int j = 0; j < OcenkaFreePotencial.GetLength(1); j++)
                {
                    if (result[i, j] == 0)
                    {
                        OcenkaFreePotencial[i, j] = (OcenkaVertical[i] + OcenkaHorisontal[j]) - tarif[i, j];
                        Console.WriteLine("Ячейка" + i + j + " = " + OcenkaFreePotencial[i, j]);
                        if (OcenkaFreePotencial[i, j] > 0)
                        {
                            Optimality = false;
                        }
                    }

                }
            }
            if (Optimality) { Console.WriteLine("Опорный план оптимальный"); }
            else { Console.WriteLine("Опорный план не оптимальный"); }
        }
    }
}


  