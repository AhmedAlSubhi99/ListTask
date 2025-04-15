using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Xml;

namespace ListTask
{
    internal class Program
    {
        // Function to filter out non-palindrome strings
        static List<string> FilterPalindromes(List<string> strings)
        {
            List<string> palindromes = new List<string>();
            for (int i = 0; i < strings.Count; i++)
            {
                string str = strings[i];
                // Check if the string is a palindrome
                bool isPalindrome = true;
                for (int j = 0; j < str.Length / 2; j++)
                {
                    if (str[j] != str[str.Length - 1 - j])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                if (isPalindrome)
                {
                    palindromes.Add(str);
                }
            }
            return palindromes;
        }

        static void Main(string[] args)
        {

            // Create a list of integers

            List<int> numbers = new List<int>();

            // input numbers from the user
            Console.WriteLine("Enter N numbers (type 'exit' to finish):");
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                if (int.TryParse(input, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    i--; // Decrement i to repeat the iteration for invalid input
                }
            }

            // Display the list of numbers
            Console.WriteLine("You entered the following numbers:");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"Number {i + 1}: {numbers[i]}");
            }

            // Find the most N frequent number(s)
            int count = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int frequency = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        frequency++;
                    }
                }
                if (frequency > count)
                {
                    count = frequency;
                }
            }
            Console.WriteLine($"The most frequent number(s) appear {count} times.");

            // Find the most N frequent number(s)
            List<int> mostFrequentNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int frequency = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        frequency++;
                    }
                }
                if (frequency == count && !mostFrequentNumbers.Contains(numbers[i]))
                {
                    mostFrequentNumbers.Add(numbers[i]);
                }
            }

            // Display the most frequent number(s)
            Console.WriteLine("The most frequent number(s):");
            for (int i = 0; i < mostFrequentNumbers.Count; i++)
            {
                Console.WriteLine($"Number is : {mostFrequentNumbers[i]}");
            }

            // Find the least N frequent number(s)
            int minCount = int.MaxValue;
            for (int i = 0; i < numbers.Count; i++)
            {
                int frequency = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        frequency++;
                    }
                }
                if (frequency < minCount)
                {
                    minCount = frequency;
                }
            }
            Console.WriteLine($"The least frequent number(s) appear {minCount} times.");

            // Find the least N frequent number(s)
            List<int> leastFrequentNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int frequency = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        frequency++;
                    }
                }
                if (frequency == minCount && !leastFrequentNumbers.Contains(numbers[i]))
                {
                    leastFrequentNumbers.Add(numbers[i]);
                }
            }

            // Display the least frequent number(s)
            Console.WriteLine("The least frequent number(s):");
            for (int i = 0; i < leastFrequentNumbers.Count; i++)
            {
                Console.WriteLine($"Number is : {leastFrequentNumbers[i]}");
            }

            // 2. Palindrome Filter

            List<string> strings = new List<string>();

            // input strings from the user
            Console.WriteLine("Enter N strings (type 'exit' to finish):");
            int M = int.Parse(Console.ReadLine());
            for (int i = 0; i < M; i++)
            {
                Console.Write($"Enter string {i + 1}: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                strings.Add(input);
            }

            // Check if the string is a palindrome
            for (int i = 0; i < strings.Count; i++)
            {
                string str = strings[i];
                // Check if the string is a palindrome
                bool isPalindrome = true;
                for (int j = 0; j < str.Length / 2; j++)
                {
                    if (str[j] != str[str.Length - 1 - j])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                if (isPalindrome)
                {
                    Console.WriteLine($"String {i + 1} is a palindrome.");
                }
                else
                {
                    Console.WriteLine($"String {i + 1} is not a palindrome.");
                }
            }

            // Display the list of strings
            Console.WriteLine("You entered the following strings:");
            for (int i = 0; i < strings.Count; i++)
            {
                Console.WriteLine($"String is : {strings[i]}");
            }

            // Filter out non-palindrome strings
            List<string> palindromes = FilterPalindromes(strings);
            // Display the palindromes
            Console.WriteLine("The palindromes are:");
            for (int i = 0; i < palindromes.Count; i++)
            {
                Console.WriteLine($"Palindrome is : {palindromes[i]}");
            }

            // 3. Shift List Elements

            List<int> numbersToShift = new List<int>();

            // input numbers from the user
            Console.WriteLine("Enter N numbers to shift (type 'exit' to finish):");
            int K = int.Parse(Console.ReadLine());
            for (int i = 0; i < K; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                if (int.TryParse(input, out int number))
                {
                    numbersToShift.Add(number);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    i--; // Decrement i to repeat the iteration for invalid input
                }
            }

            // Display the list of numbers
            Console.WriteLine("You entered the following numbers:");
            for (int i = 0; i < numbersToShift.Count; i++)
            {
                Console.WriteLine($"Number {i + 1}: {numbersToShift[i]}");
            }

            // Rotate the elements of the list to the right by k steps
            Console.Write("Enter the number of steps to rotate: ");
            int steps = int.Parse(Console.ReadLine());
            for (int i = 0; i < steps; i++)
            {
                int lastElement = numbersToShift[numbersToShift.Count - 1];
                for (int j = numbersToShift.Count - 1; j > 0; j--)
                {
                    numbersToShift[j] = numbersToShift[j - 1];
                }
                numbersToShift[0] = lastElement;
            }
            // Display the rotated list
            Console.WriteLine("The rotated list is:");
            for (int i = 0; i < numbersToShift.Count; i++)
            {
                Console.WriteLine($"Number {i + 1}: {numbersToShift[i]}");
            }

            // 4. Unique Words Extractor
            // Write a program that takes a paragraph from the user, splits it into words, and stores only the unique words in a List<string>.Then, sort the list alphabetically and print it.
            List<string> uniqueWords = new List<string>();
            // input paragraph from the user
            Console.WriteLine("Enter a paragraph (type 'exit' to finish):");
            string paragraph = Console.ReadLine();
            if (paragraph.ToLower() == "exit")
            {
                return;
            }

            // Split the paragraph into words from the list
            string[] words = paragraph.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Display the list of words
            Console.WriteLine("You entered the following words:");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"Word {i + 1}: {words[i]}");
            }

            // Store only unique words in the list
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                if (!uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                }
            }

            // Sort the list alphabetically
            uniqueWords.Sort();

            // Display the sorted list of unique words
            Console.WriteLine("The sorted list of unique words is:");
            for (int i = 0; i < uniqueWords.Count; i++)
            {
                Console.WriteLine($"Word {i + 1}: {uniqueWords[i]}");
            }
        }
    }
}
