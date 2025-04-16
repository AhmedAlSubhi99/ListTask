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
        public static List<string> FilterPalindromes(List<string> strings)
        {
            List<string> palindromes = new List<string>();
            for (int i = 0; i < strings.Count; i++)
            {
                string str = strings[i];
                // Check if the string is a palindrome
                bool isPalindrome = true;
                for (int j = 0; j < str.Length / 2; j++) // Compare with all characters in the string
                {
                    if (str[j] != str[str.Length - 1 - j]) // Check if the characters are equal
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

            // ==========================================================
            // List Task
            // ==========================================================

            // 1. Top Most N Frequent Number(s)

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

                // Check if the input is a valid integer
                if (int.TryParse(input, out int number)) // Try to parse the input as an integer
                {
                    // Add the number to the list
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
                Console.WriteLine($"Number {i + 1} : {numbers[i]}");
            }

            // Find the most N frequent number(s)
            List<int> mostFrequentNumbers = new List<int>();
            int count = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                // Count the frequency of the current number
                int frequency = 0;
                for (int j = 0; j < numbers.Count; j++) // Compare with all numbers in the list
                {
                    if (numbers[i] == numbers[j])
                    {
                        frequency++;
                    }
                }
                // Check if the frequency is greater than the maximum frequency
                if (frequency > count)
                {
                    count = frequency;
                }
                // Check if the frequency is equal to the maximum frequency and if the number is not already in the list
                if (frequency == count && !mostFrequentNumbers.Contains(numbers[i])) // Check for duplicates
                {
                    // Add the number to the list of most frequent numbers
                    mostFrequentNumbers.Add(numbers[i]);
                }
            }
            Console.WriteLine($"The most frequent number(s) appear {count} times.");


            // Display the most frequent number(s)
            Console.WriteLine("The most frequent number(s):");
            for (int i = 0; i < mostFrequentNumbers.Count; i++)
            {
                Console.WriteLine($"Number {i + 1} is : {mostFrequentNumbers[i]}");
            }

            // =============================================================

            // 2. Palindrome Filter

            List<string> strings = new List<string>();

            // input strings from the user
            Console.WriteLine("Enter M strings (type 'exit' to finish):");
            int M = int.Parse(Console.ReadLine());

            // loop to get M strings from the user
            for (int i = 0; i < M; i++) // Loop M times
            {
                // Get the string from the user
                Console.Write($"Enter string {i + 1} : ");
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
                // Check if the string is a palindrome
                string str = strings[i]; // Get the string from the list
                bool isPalindrome = true;
                for (int j = 0; j < str.Length / 2; j++) // Compare with all characters in the string
                {
                    if (str[j] != str[str.Length - 1 - j]) // Check if the characters are equal
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
                Console.WriteLine($"String {i + 1} is : {strings[i]}");
            }

            // Filter out non-palindrome strings
            List<string> palindromes = FilterPalindromes(strings);

            // Display the palindromes
            Console.WriteLine("The palindromes are:");
            for (int i = 0; i < palindromes.Count; i++)
            {
                Console.WriteLine($"Palindrome {i + 1} is : {palindromes[i]}");
            }
            // ===========================================================

            // 3. Shift List Elements

            // Create a list of integers
            List<int> numbersToShift = new List<int>();

            // input numbers from the user
            Console.WriteLine("Enter N numbers to shift (type 'exit' to finish):");
            int K = int.Parse(Console.ReadLine());
            for (int i = 0; i < K; i++)
            {
                Console.Write($"Enter number {i + 1} : ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                if (int.TryParse(input, out int number)) // Try to parse the input as an integer
                {
                    // Add the number to the list
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
                Console.WriteLine($"Number {i + 1} : {numbersToShift[i]}");
            }

            // Rotate the elements of the list to the right by k steps
            Console.Write("Enter the number of steps to rotate: ");
            int steps = int.Parse(Console.ReadLine());
            for (int i = 0; i < steps; i++)
            {
                // Store the last element and shift the rest to the right

                int lastElement = numbersToShift[numbersToShift.Count - 1]; // Store the last element
                for (int j = numbersToShift.Count - 1; j > 0; j--) // Shift Elemnts 
                {
                    // Shift elements to the right
                    numbersToShift[j] = numbersToShift[j - 1];
                }
                numbersToShift[0] = lastElement; // Place the last element at the beginning
            }
            // Display the rotated list
            Console.WriteLine("The rotated list is:");
            for (int i = 0; i < numbersToShift.Count; i++)
            {
                Console.WriteLine($"Number {i + 1} : {numbersToShift[i]}");
            }

            // ===========================================================

            // 4. Unique Words Extractor

            // Create a list to store unique words
            List<string> uniqueWords = new List<string>();

            // input paragraph from the user
            Console.WriteLine("Enter a paragraph (type 'exit' to finish):");
            string paragraph = Console.ReadLine();
            if (paragraph.ToLower() == "exit")
            {
                return;
            }

            // Split the paragraph into words from the list
            string[] words = paragraph.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // Split by spaces

            // Display the list of words
            Console.WriteLine("You entered the following words:");
            for (int i = 0; i < words.Length; i++) 
            {
                Console.WriteLine($"Word {i + 1} : {words[i]}");
            }

            // Store only unique words in the list
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                if (!uniqueWords.Contains(word)) // Check for duplicates
                {
                    // Add the word to the list of unique words
                    uniqueWords.Add(word);
                }
                else
                {
                    // If the word is already in the list, do not add it again
                    Console.WriteLine($"Word '{word}' is already in the list.");
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
