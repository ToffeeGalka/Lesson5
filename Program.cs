using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lesson5
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Введите строку, содержащую буквы латинского алфавита, знаки препинания и цифры: \n");
            string text = Console.ReadLine();

            int menu;
            while (true)
            {
                Console.WriteLine("Выберите пункт меню, нажав соответствующую цифру от 1 до 3: \n" + "1 - Найти слова, содержащие максимальное количество цифр \n" +
                    "2 - Найти самое длинное слово и определить, сколько раз оно встретилось в тексте \n"
                    + "3 - Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять» \n");
                if (int.TryParse(Console.ReadLine(), out menu))
                {
                    if (menu != 1 & menu != 2 & menu != 3)
                    {
                        Console.WriteLine("Выберите предложенный пункт меню от 1 до 3!");
                        continue;
                    }
                    break;
                }
                continue;
            }

            if (menu == 1)
            {
                Menu1(text);
            }

            if (menu == 2)
            {
                Menu2(text);          
            }

            if (menu == 3)
            {
                Menu3(text);
            }
        }
        static void Menu1(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int maxCount = 0;
            string[] wordsnew = new string[0];
            foreach (string s in words)
            {
                int Count = 0;
                foreach (char s1 in s)
                {
                    if (char.IsDigit(s1))
                    {
                        Count++;
                    }
                }
                if (Count > maxCount)
                {
                    maxCount = Count;
                    wordsnew = new string[] { s };
                }
                else if (Count == maxCount)
                {
                    Array.Resize(ref wordsnew, wordsnew.Length + 1);
                    wordsnew[wordsnew.Length - 1] = s;
                }

            }
            foreach (string s in wordsnew)
            {
                Console.Write($"\n Максимальное количество цифр в слове: {s}");
            }
        }
        static void Menu2(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = 0; string newword = "";
            foreach (string s in words)
            {
                int wordCount = 0;
                foreach (string s1 in words)
                {
                    if (s == s1)
                    {
                        wordCount++;
                    }
                }
                if (s.Length > newword.Length)
                {
                    newword = s;
                    count = wordCount;
                }
                else if (s.Length == newword.Length && wordCount > count)
                {
                    count = wordCount;
                }
            }
            Console.WriteLine($"Самое длинное слово: {newword}, встречается: {count} раз(а)");
        }
        static void Menu3(string text)
        {
            var sb = new StringBuilder(text);
            sb.Replace("0", "ноль");
            sb.Replace("1", "один");
            sb.Replace("2", "два");
            sb.Replace("3", "три");
            sb.Replace("4", "четыре");
            sb.Replace("5", "пять");
            sb.Replace("6", "шесть");
            sb.Replace("7", "семь");
            sb.Replace("8", "восемь");
            sb.Replace("9", "девять");
            string textNew = sb.ToString();
            Console.WriteLine(textNew);
        }
    }
}