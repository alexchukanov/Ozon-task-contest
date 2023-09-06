//Task M. Карточки (20 баллов)

/*
 Среди ваших n
 друзей стало популярно коллекционирование редчайших карточек. Производитель выпустил m различных видов карточек, 
пронумерованных от 1 до m. Эти карточки настолько редкие, что их продает только один человек. Известно, 
что у него осталось всего m карточек, по одной каждого вида.

Вам известно, что у i-го из ваших друзей есть все карточки с номерами от 1 до ai включительно. 
Вы хотите сделать подарок всем своим друзьям, подарив i
-му из них карточку bi, которой у него еще нет, то есть такую, что bi>ai.

Входные данные:
Первая строка содержит два целых числа n и m (1≤n,m≤105) — количество друзей и количество карточек.

Вторая строка содержит n целых чисел ai (1≤ai≤m).

Решения, работающие правильно при n,m≤100, получат 10 баллов.

Выходные данные:
Выведите массив bi или −1, если ответа не существует. Если ответов несколько, выведите любой.

Примеры.
входные данные:
5 7
3 3 2 6 5
выходные данные:
5 4 3 7 6

входные данные:
4 4
2 1 2 2
выходные данные:
-1

входные данные:
5 6
3 1 2 3 5
выходные данные:
4 2 3 5 6 
*/

bool isAnswer = true;

int[] firstStrArr = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

int friendsNum = firstStrArr[0];
int giftCardNumMax = firstStrArr[1];

int[] friendsArr = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

int[] friendsGiftArr = new int[friendsNum];

for (int i = giftCardNumMax; i > 0; i--)
{
    int maxValue = friendsArr.Max();

    int maxCardIndex = Array.IndexOf(friendsArr, maxValue);

    if (maxValue == 0)
    {
        break;
    }
    if (maxCardIndex < i)
    {
        friendsGiftArr[maxCardIndex] = i;
        friendsArr[maxCardIndex] = 0;
    }
    else
    {
        isAnswer = false;
        break;
    }
}

if (isAnswer)
{
    Console.WriteLine(string.Join(" ", friendsGiftArr));
}
else
{
    Console.WriteLine(-1);
}