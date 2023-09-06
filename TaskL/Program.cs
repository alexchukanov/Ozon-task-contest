﻿//Task L. Наклейки (10 баллов)

/*
Для отслеживания посылок компания NOZO использует наклейки с надписями. Иногда надпись (или её часть) на наклейке нужно исправить,
и тогда поверх старой наклейки лепят новую.

На очередной посылке появилось слишком много наклеек и теперь невозможно прочитать наклеенную надпись целиком.
Помогите это сделать по истории этих наклеек.

Входные данные:
Первая строка s  представляет собой содержимое изначальной наклейки. Гарантируется, что её длина не превышает 1000 символов.

Во второй строке записано целое число n (1≤n≤1000), обозначающее количество наклеенных поверх наклеек.

Далее идёт n строк, каждая из которых описывает очередную наклейку в порядке её применения: от самой старой к самой новой. 
Каждое описание содержит два числа starti и endi (1≤start≤end≤|s|, где |s| обозначает длину строки s) 
и через пробел строку ri, которая была записана поверх символов между starti и endi.

Гарантируется, что длина строки ri точно равна end−start+1. Эта запись обозначает, что поверх всех символов, 
начиная с символа под номером start и заканчивая символом под номером end, была наклеена строка ri.

Гарантируется, что все строки состоят только из строчных латинских букв.

Выходные данные:
Выведите итоговую строку, которая видна после применения всех наклеек.

Примеры входные данные:
somesuperlongstring
3
1 2 la
4 4 d
10 13 tiny

выходные данные:
lamdsupertinystring

входные данные:
somesuperlongstring
4
1 2 la
4 4 d
10 13 tiny
4 5 ed

выходные данные:
lamedupertinystring 
 */


using System.Text;

string firstSticker = Console.ReadLine();
StringBuilder sticker = new StringBuilder(firstSticker);

string? stickerNumStr = Console.ReadLine();
int stickerNum = int.Parse(stickerNumStr ?? "0");

for (int i = 0; i < stickerNum; i++)
{

    var newStickerArrStr = Console.ReadLine().Split(' ');

    int start = int.Parse(newStickerArrStr[0]);
    int end = int.Parse(newStickerArrStr[1]);
    string newValue = newStickerArrStr[2];

    string oldValue = sticker.ToString().Substring(start - 1, end - start + 1);

    sticker.Replace(oldValue, newValue, start - 1, end - start + 1);
}

Console.WriteLine(sticker);


