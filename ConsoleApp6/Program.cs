

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //
           
            

            bool closeness, degeneracy;
            int[] massupply;
            int[] masdemand;
            int[,] mastarif;
            int[,] result;
            int[] OcenkaVertical;
            int[] OcenkaHorisontal;
            //ввод для решения методос северо западного угла
            Solution.Class1.insert(out massupply, out masdemand, out closeness, out mastarif);
            //////проверка на закрытость
            if (closeness)
            {
                Console.WriteLine("Задача закрытая, можем составить опорный план методом северо-западного угла: ");
                Solution.Class1.NortWest(massupply, masdemand, mastarif, out result);
                Solution.Class1.potencial(result, mastarif, out OcenkaVertical, out OcenkaHorisontal);
                Solution.Class1.output(result, mastarif, OcenkaVertical, OcenkaHorisontal, out degeneracy);
                //проверка на вырожденность
                if (degeneracy)
                {
                    Console.WriteLine("Опорный план невырожденный");
                }
            }
            else
            {
                Console.WriteLine("Задача не закрытая, такие я решать не умею :(");
            }
            //ввод для решения методом минимального элемента
            Solution.Class1.insert(out massupply, out masdemand, out closeness, out mastarif);
            if (closeness)
            {
                Console.WriteLine("Задача закрытая, можем составить опорный план методом минимального элемента: ");
                Solution.Class1.MinimumElement(massupply, masdemand, mastarif, out result);
                Solution.Class1.potencial(result, mastarif, out OcenkaVertical, out OcenkaHorisontal);
                Solution.Class1.output(result, mastarif, OcenkaVertical, OcenkaHorisontal, out degeneracy);
                if (degeneracy)
                {

                    Console.WriteLine("Опорный план невырожденный");

                }
                else Console.WriteLine("Опорный план вырожденный, устранять вырожденность я пока не умею :(");
            }
            else
            {
                Console.WriteLine("Задача не закрытая, такие я решать не умею :(");
            }
        }
    }
}
