// Task F.Отрезки времени (20 баллов)

/*
 Вам задан набор отрезков времени. Каждый отрезок задан в формате HH:MM:SS-HH:MM:SS, то есть сначала заданы часы, 
минуты и секунды левой границы отрезка, а затем часы, минуты и секунды правой границы.

Вам необходимо выполнить валидацию заданного набора отрезков времени. Иными словами, вам нужно проверить следующие условия:

часы, минуты и секунды заданы корректно (то есть часы находятся в промежутке от 0 до 23, а минуты и секунды — в промежутке от 0 до 59);

левая граница отрезка находится не позже его правой границы (но границы могут быть равны);

никакая пара отрезков не пересекается (даже в граничных моментах времени).

Вам необходимо вывести YES, если заданный набор отрезков времени проходит валидацию, и NO в противном случае.

Вам необходимо ответить на t независимых наборов тестовых данных.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные:
Первая строка входных данных содержит одно целое число t (1≤t≤10) — количество наборов тестовых данных. 
Затем следуют t наборов.

Первая строка набора содержит одно целое число n (1≤n≤2⋅104) — количество отрезков времени. 
В следующих n строках следуют описания отрезков.

Описание отрезка времени задано в формате HH:MM:SS-HH:MM:SS, где HH, MM и SS — последовательности из двух цифр. 
Заметьте, что никаких пробелов в описании формата нет. Также ни в одном описании нет пробелов в начале и конце строки.

Выходные данные:
Для каждого набора тестовых данных выведите ответ — YES, если заданный набор отрезков времени проходит валидацию, 
и NO в противном случае. Ответы выводите в порядке следования наборов во входных данных.

Пример.
входные данные:
6
1
02:46:00-03:14:59
2
23:59:59-23:59:59
00:00:00-23:59:58
2
23:59:58-23:59:59
00:00:00-23:59:58
2
23:59:59-23:59:58
00:00:00-23:59:57
6
17:53:39-20:20:02
10:39:17-11:00:52
08:42:47-09:02:14
09:44:26-10:21:41
00:46:17-02:07:19
22:42:50-23:17:46
1
24:00:00-23:59:59

выходные данные:
YES
YES
NO
NO
YES
NO
  
 */

using System.Collections.Concurrent;
using System.Collections.Generic;

List<string> printList = new List<string>();

string? setSizeStr = Console.ReadLine();
int setSize = int.Parse(setSizeStr ?? "0");

for (int z = 0; z < setSize; z++)
{
    bool isStillCorrect = true;

    string[] segmentArrStr = null;

    List<string> segmentInputList = new List<string>();
    List<string[]> segmentStrArr = new List<string[]>();


    SortedList<TimeOnly, TimeOnly[]> segmentSortedList = new SortedList<TimeOnly, TimeOnly[]>();

    List<TimeOnly[]> segmentList = new List<TimeOnly[]>();

    string setLengthStr = Console.ReadLine();

    int setLength = int.Parse(setLengthStr);

    for (int s = 0; s < setLength; s++)
    {
        string segment = Console.ReadLine();
        segmentInputList.Add(segment);
    }


    foreach (string segment in segmentInputList)
    {
        TimeOnly[] segmentArr = null;
        try
        {
            segmentArr = new TimeOnly[] { TimeOnly.Parse(segment.Substring(0, 8)), TimeOnly.Parse(segment.Substring(9, 8)) };
        }
        catch
        {
            printList.Add("NO");
            isStillCorrect = false;
            break;
        }

        if (segmentArr[0] > segmentArr[1])
        {
            printList.Add("NO");
            isStillCorrect = false;
            break;
        }

        if (!segmentSortedList.ContainsKey(segmentArr[0]))
        {
            segmentSortedList.Add(segmentArr[0], segmentArr);
        }
        else
        {
            printList.Add("NO");
            isStillCorrect = false;
            break;
        }
    }

    if (!isStillCorrect)
    {
        continue;
    }

    bool isOverlap = false;
    int segmentSortedListKeysCount = segmentSortedList.Keys.Count();

    if (segmentSortedListKeysCount >= 2)
    {
        Parallel.For(0, segmentSortedListKeysCount - 1, new ParallelOptions() { MaxDegreeOfParallelism = 20 },
             (index, loopState) =>
             {
                 if (segmentSortedList[segmentSortedList.Keys[index + 1]][0] <= segmentSortedList[segmentSortedList.Keys[index]][1] && segmentSortedList[segmentSortedList.Keys[index + 1]][1] >= segmentSortedList[segmentSortedList.Keys[index]][0])
                 {
                     isOverlap = true;
                     loopState.Break();
                 }
             });
    }

    if (isOverlap)
    {
        printList.Add("NO");
        isStillCorrect = false;
    }

    if (isStillCorrect)
    {
        printList.Add("YES");
    }
}

printList.ForEach(x => Console.WriteLine(x));


