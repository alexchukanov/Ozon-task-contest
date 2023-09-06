//Task D. Электронная таблица (10 баллов)

/*
 Вам необходимо написать часть функциональности обработки сортировок в электронных таблицах.

Задана прямоугольная таблица n×m
 (n строк по m столбцов) из целых чисел.

Если кликнуть по заголовку i-го столбца, то строки таблицы пересортируются таким образом, что в этом столбце значения будут идти по неубыванию
(то есть возрастанию или равенству). При этом, если у двух строк одинаковое значение в этом столбце, то относительный порядок строк не изменится.

Рассмотрим пример.

В этом примере сначала клик был совершен по второму столбцу, затем по первому и, наконец, по третьему.
Заметим, что если кликнуть подряд два раза в один столбец, то после второго клика таблица не изменится 
(в момент второго клика она уже отсортирована по этому столбцу).

Обработайте последовательность кликов и выведите состояние таблицы после всех кликов.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке записано целое число t (1≤t≤100) — количество наборов входных данных в файле. Далее следуют описания наборов, 
перед каждым из них записана пустая строка.

В первой строке набора записаны два целых числа n и m (1≤n,m≤30) — количество строк и столбцов в таблице.

Далее следуют n строк по m целых чисел в каждой — начальное состояние таблицы. Все элементы таблицы от 1 до 100.

Затем входные данные содержат строку с один целым числом k (1≤k≤30) — количество кликов.

Следующая строка содержит k целых чисел c1,c2,…,ck (1≤ci≤m) — номера столбцов, по которым были осуществлены клики. 
Клики даны в порядке их совершения.

Выходные данные:
Для каждого набора входных данных выведите n строк по m чисел в каждой — итоговое состояние таблицы.
После каждого набора выходных данных выводите дополнительный перевод строки.

Пример.
входные данные:
3

4 3
3 4 1
2 2 5
2 4 2
2 2 1
3
2 1 3

3 1
100
9
10
2
1 1

3 3
2 11 72
99 11 13
2 8 13
5
2 3 2 1 2

выходные данные:
2 2 1
3 4 1
2 4 2
2 2 5

9
10
100

2 8 13
2 11 72
99 11 13
  
*/


using System.Collections.Generic;

string? setSizeStr = Console.ReadLine();
int setSize = int.Parse(setSizeStr ?? "0");

List<string> printList = new List<string>();

for (int z = 0; z < setSize; z++)
{
    Console.ReadLine();
    var tableDimArr = Console.ReadLine().Split(' ').Select(it => byte.Parse(it)).ToArray();

    byte[][] table = new byte[tableDimArr[0]][];

    for (int i = 0; i < tableDimArr[0]; i++)
    {
        table[i] = Console.ReadLine().Split(' ').Select(it => byte.Parse(it)).ToArray();
    }

    string? clickNumStr = Console.ReadLine();
    int clickNum = int.Parse(clickNumStr ?? "0");

    var clickColumnArr = Console.ReadLine().Split(' ').Select(it => byte.Parse(it)).ToArray();

    foreach (byte c in clickColumnArr)
    {
        SortedList<int, byte[]> sortedList = new SortedList<int, byte[]>(new DuplicateKeyComparer<int>());

        for (int i = tableDimArr[0] - 1; i >= 0; i--)
        {
            sortedList.Add(table[i][c - 1], table[i]);
        }

        for (int i = 0; i < table.Count(); i++)
        {
            table[i] = sortedList.ElementAt(i).Value;
        }
    }

    for (int i = 0; i < tableDimArr[0]; i++)
    {
        printList.Add(string.Join(" ", table[i]));
    }
    printList.Add("");
}

foreach (string row in printList)
{
    Console.WriteLine(row);
}

public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable
{
    IComparer<TKey> Members;

    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);

        if (result == 0)
            return 1;
        else
            return result;
    }
}