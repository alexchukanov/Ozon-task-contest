//Task B, Сумма к оплате (10 баллов)

/* Task description

В магазине акция: «купи три одинаковых товара и заплати только за два». Конечно, каждый купленный товар может участвовать лишь в одной акции. Акцию можно использовать многократно.

Например, если будут куплены 7  товаров одного вида по цене 2 за штуку и 5  товаров другого вида по цене 3
за штуку, то вместо 7⋅2+5⋅3 надо будет оплатить 5⋅2+4⋅3=22.

Считая, что одинаковые цены имеют только одинаковые товары, найдите сумму к оплате.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные:
В первой строке записано целое число t (1≤t≤104) — количество наборов входных данных.

Далее записаны наборы входных данных. Каждый начинается строкой, которая содержит n (1≤n≤2⋅105) 
— количество купленных товаров. Следующая строка содержит их цены p1, p2,…, pn (1≤pi≤104). 
Если цены двух товаров одинаковые, то надо считать, что это один и тот товар.

Гарантируется, что сумма значений n  по всем тестам не превосходит 2⋅105.

Выходные данные:
Выведите t целых чисел — суммы к оплате для каждого из наборов входных данных.

Пример, входные данные:
6
12
2 2 2 2 2 2 2 3 3 3 3 3
12
2 3 2 3 2 2 3 2 3 2 2 3
1
10000
9
1 2 3 1 2 3 1 2 3
6
10000 10000 10000 10000 10000 10000
6
300 100 200 300 200 300

Выходные данные:
22
22
10000
12
40000
1100
*/


using System.Collections.Generic;

string? setSizeStr = Console.ReadLine();
int setSize = int.Parse(setSizeStr ?? "0");

int[] resArr = new int[setSize];

for (int i = 0; i < setSize; i++)
{
    string? setLengthStr = Console.ReadLine();
    int setLength = int.Parse(setLengthStr ?? "0");

    var setArr = Console.ReadLine().Split(' ').Select(it => short.Parse(it)).ToArray();

    Dictionary<short, int> priceSet = new Dictionary<short, int>();

    for (int j = 0; j < setLength; j++)
    {
        short price = setArr[j];

        if (priceSet.TryGetValue(price, out int count))
        {
            priceSet[price] = ++count;
        }
        else
        {
            priceSet[price] = 1;
        }
    }

    resArr[i] = CalcCost(priceSet);
}

for (int n = 0; n < resArr.Length; n++)
{
    Console.WriteLine(resArr[n]);
}

int CalcCost(Dictionary<short, int> priceSet)
{
    int cost = 0;

    foreach (KeyValuePair<short, int> entry in priceSet)
    {
        cost += entry.Key * (entry.Value - entry.Value / 3);
    }

    return cost;
}