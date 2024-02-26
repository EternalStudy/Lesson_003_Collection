namespace Lesson_003_Collection
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*Задача 1
             Используя стек инвертируйте порядок следования элементов в спиcке
            Пример списка
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            Пример результата
            {5,4,3,2,1}
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            List<int> reverceList = ReveseList(ints);
            foreach (int i in reverceList)
            {
                Console.WriteLine(i);
            }*/

            /*
             * Задача 2
             * Реализуйте класс с поддержкой IEnumerable<int> - CustomEnumerale который в случае использования его в следующем коде 
                foreach (var x in new CustomEmumerable())
                        {
                            Console.WriteLine(x);
                        }
                Выведет на экран значения от 0 до 10. 
                Подумайте, возможно вам придется реализовать не только IEnumerable но и IEnumerator
            */
            /*Задача 3
            Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
            Пример лабиринта:
            1 1 1 1 1 1 1
            1 0 0 0 0 0 1
            1 0 1 1 1 0 1
            0 0 0 0 1 0 2
            1 1 0 0 1 1 1
            1 1 1 1 1 1 1
            1 1 1 1 1 1 1
            Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран  координаты точки выхода если таковые имеются.

            Пример описания лабиринта.
            int[,] labirynth1 = new int[,]
                    {
                        {1, 1, 1, 1, 1, 1, 1 },
                        {1, 0, 0, 0, 0, 0, 1 },
                        {1, 0, 1, 1, 1, 0, 1 },
                        {0, 0, 0, 0, 1, 0, 2 },
                        {1, 1, 0, 0, 1, 1, 1 },
                        {1, 1, 1, 1, 1, 1, 1 },
                        {1, 1, 1, 1, 1, 1, 1 }
                    };
            Пример заголовка функции которая должна определить наличие выхода из лабиринта:
            static bool HasExix(int startI, int startJ, int[,] l)
            startI,startJ  это точка начала пути-откуда мы начинаем проходить лабиринт. 
            l - массив описывающий лабиринт.
            */
            int[,] labirynth = new int[,]
            {
             {1, 1, 1, 2, 1, 1, 1 },
             {1, 0, 0, 0, 0, 0, 1 },
             {1, 0, 1, 1, 1, 0, 1 },
             {2, 0, 0, 0, 1, 0, 2 },
             {1, 1, 0, 0, 1, 1, 1 },
             {1, 1, 1, 1, 1, 1, 1 },
             {1, 1, 1, 1, 1, 1, 1 }
            };
            // (HasExix(1, 1, labirynth))
            Console.WriteLine(HasExix(1, 1, labirynth));
            //se Console.WriteLine("Выхода нет");
            
        }
        static int HasExix(int startI, int startJ, int[,] labirynth)
        {
            int count = 0;
            Queue<(int, int)> coords = new Queue<(int, int)>();
            if (labirynth[startI, startJ] == 2) count++;

            if (labirynth[startI, startJ] == 0)
            {
                coords.Enqueue((startI, startJ));
            }
            while (coords.Count > 0)
            {
               (var i,  var j) = coords.Dequeue();
                if (labirynth[i, j] == 2) count++;

                labirynth[i,j] = 1;
                if (i - 1 >= 0 && labirynth[i - 1, j] != 1) coords.Enqueue((i - 1, j));
                if (i + 1 < labirynth.GetLength(0) && labirynth[i + 1, j] != 1) coords.Enqueue((i + 1, j));
                if (j - 1 >= 0 && labirynth[i, j - 1] != 1) coords.Enqueue((i, j - 1));
                if (j + 1 < labirynth.GetLength(1) && labirynth[i, j + 1] != 1) coords.Enqueue((i, j + 1));
            }
            return count;
        }
        public static List<int> ReveseList(List<int> list)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var item in list)
            {
                stack.Push(item);
            }
            List<int> newList = new List<int>();
            while (stack.Count > 0)
            {
                newList.Add(stack.Pop());
            }
            return newList;
        }
    }
}
