using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace Lab1
{
    class Program
    {
        private static StreamReader sr;
        private static List<string> words = new List<string>();
        

        static void Main(string[] args)
        {
            char userInput;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case '1':
                        importFile();
                        break;
                    case '2':
                        BubbleSort(words);
                        break;
                    case '3':
                        LinqSort(words);
                        break;
                    case '4':
                        distinct(words);
                        break;
                    case '5':
                        firstTen(words);
                        break;
                    case '6':
                        jWords(words);
                        break;
                    case '7':
                        dWords(words);
                        break;
                    case '8':
                        fourCharLong(words);
                        break;
                    case '9':
                        lessThreeCharLong(words);
                        break;


                }

            } while (userInput != 'x');
        }
        static public char DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello world!!! My First C# App");
            Console.WriteLine("options");
            Console.WriteLine("--------");
            Console.WriteLine("1 - Import Words From File");
            Console.WriteLine("2 - Bubble Sort word");
            Console.WriteLine("3 - LINQ/Lambda sort words");
            Console.WriteLine("4 - Count the Distinct Words");
            Console.WriteLine("5 - Take the first 10 words");
            Console.WriteLine("6 - Get the number of words that start with 'j' and display the count");
            Console.WriteLine("7 -  Get and display of words that end with 'd' and display the count");
            Console.WriteLine("8 - Get and display of words that are greater than 4 characters long, and display the count");
            Console.WriteLine("9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count");
            Console.WriteLine("X - EXIT");
            Console.WriteLine("");
            Console.WriteLine("Make a selection:");
            var result = Console.ReadLine();
            return Convert.ToChar(result);
        }

        static void importFile()
        {
            Console.Clear();
            String fileName = "Words.txt";
            int count = 0;
            Console.WriteLine("Reading Words");
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File does not exist");
                }
                using(sr = new StreamReader(fileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        words.Add(sr.ReadLine());
                        count++;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("Process failed",e.ToString());
            }
            Console.WriteLine("Reading Words complete");
            Console.WriteLine("Number of words foud: "+ count);
            Console.WriteLine("\n");

        }
        static string[] BubbleSort(List<string> words)
        {
            int size = words.Count;
            string temp;
            Stopwatch sw = new Stopwatch();
            string[] str= new string [words.Capacity];
        
            sw.Start();
            for(int i = 1; i < size; i++)
            {
                for(int j = 0; j < (size - i); j++)
                {
                    if ((words[j].CompareTo(words[j+1]) > 0))
                    {
                        temp = words[j];
                        words[j] = words[j++];
                        words[j++] = temp;
                        str[j] = words[j];
                    }
                    
                }
            }
            Console.Clear();
            sw.Stop();
            Console.WriteLine("Time elapsed: "+sw.Elapsed.Milliseconds);
            return str;
            
        }

        static void LinqSort(List<string> words)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var lengths = from element in words orderby element ascending select element;
            
            sw.Stop();
            Console.Clear();
            Console.WriteLine("Time elapsed: " + sw.Elapsed.Milliseconds);
            
        }

        static void distinct(List<string> words)
        {
            var distinct = (from w in words select w).Distinct().Count();
           Console.Clear();
            Console.WriteLine("The number of distinct words is :"+ distinct);
            Console.WriteLine();
        }
        static void firstTen(List<string> words)
        {
            Console.Clear();
            var first = words.Take(10);
            foreach(string s in first)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void jWords(List<string>words)
        {
            Console.Clear();
            int i = 0;
            var result = (from w in words
                          where w.StartsWith("j") select w).Count();
      
            Console.WriteLine("Number of words that start with 'j':" + result);
            Console.WriteLine();
            Console.WriteLine();
        }
        static void dWords(List<string> words)
        {
            Console.Clear();
            int i = 0;
            var result = from w in words
                         where w.EndsWith("d")
                         select w;
            foreach (string s in result)
            {
                Console.WriteLine(s);
                i++;

            }
            Console.WriteLine("Number of words that end with 'd':" + i);
            Console.WriteLine();
            Console.WriteLine();
        }
       static void fourCharLong(List<string> words)
        {
            Console.Clear();
            int i = 0;
            var result = from w in words
                         where w.Length > 4
                         select w;
            foreach(string s in result)
            {
                Console.WriteLine(s);
                i++;
            }
            Console.WriteLine("Number of words longer than 4 character:" + i);
            Console.WriteLine();
            Console.WriteLine();
        }
        static void lessThreeCharLong(List<string> words)
        {
            Console.Clear();
            int i = 0;
            var result = from w in words
                         where w.Length < 3 && w.StartsWith("a")
                         select w;
            foreach(string s in result)
            {
                Console.WriteLine(s);
                i++;

            }
            Console.WriteLine("Number of words less than 3 character start with 'a':" + i);
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
