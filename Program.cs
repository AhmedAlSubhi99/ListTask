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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|                Menu Of List                 |");
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("| 1. Top Most N Frequent Number(s)            |");
                Console.WriteLine("| 2. Palindrome Filter                        |");
                Console.WriteLine("| 3. Shift List Elements                      |");
                Console.WriteLine("| 4. Unique Words Extractor                   |");
                Console.WriteLine("| 5. Exit                                     |");
                Console.WriteLine("+---------------------------------------------+");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    // Top Most N Frequent Number(s)
                    case "1":
                        Console.Clear();
                        Console.WriteLine("========= Top Most N Frequent Number(s) =========\n");
                        TopMostFrequent();
                        break;

                    // Palindrome Filter
                    case "2":
                        Console.Clear();
                        Console.WriteLine("========= Palindrome Filter =========\n");
                        PalindromeFilter();
                        break;

                    // Shift List Elements
                    case "3":
                        Console.Clear();
                        Console.WriteLine("========= Shift List Elements =========\n");
                        ShiftList();
                        break;

                    // Unique Words Extractor
                    case "4":
                        Console.Clear();
                        Console.WriteLine("========= Unique Words Extractor =========\n");
                        UniqueWords();
                        break;

                    // Exit
                    case "5":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid input. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void TopMostFrequent()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|==== 1. Top Most N Frequent Number(s) ====|");
            Console.WriteLine("============================================");

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
                    // Check if the numbers are equal
                    if (numbers[i] == numbers[j])
                    {
                        frequency++; // Increment the frequency to count the number of occurrences
                    }
                }

                // Check if the frequency is greater than the maximum frequency for the current number
                if (frequency > count) 
                {
                    // Clear the list of most frequent numbers and add the current number

                    mostFrequentNumbers.Clear(); // Clear the list of most frequent numbers
                    count = frequency; // Update the maximum frequency
                }
                // Check if the frequency is equal to the maximum frequency and if the number is not already in the list
                if (frequency == count && !mostFrequentNumbers.Contains(numbers[i])) // Check for duplicates
                {
                    // Add the number to the list of most frequent numbers
                    mostFrequentNumbers.Add(numbers[i]);
                }
            }

            // Display the maximum frequency
            for (int i = 0; i < mostFrequentNumbers.Count; i++)
            {
                Console.WriteLine($"The maximum frequency {i + 1} is : {count}");
            }

            // Display the most frequent number(s)
            Console.WriteLine("The most frequent number(s):");
            for (int i = 0; i < mostFrequentNumbers.Count; i++)
            {
                Console.WriteLine($"Number {i + 1} is : {mostFrequentNumbers[i]}");
            }
        }

        static void PalindromeFilter()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|========= 2. Palindrome Filter ============|");
            Console.WriteLine("============================================");

            // Create a list of strings
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
            // Display the non-palindromes
            Console.WriteLine("The non-palindromes are:");
            for (int i = 0; i < strings.Count; i++)
            {
                if (!palindromes.Contains(strings[i])) // Check if the string is not a palindrome
                {
                    Console.WriteLine($"Non-palindrome {i + 1} is : {strings[i]}");
                }
            }
        }

        static void ShiftList()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|========= 3. Shift List Elements ==========|");
            Console.WriteLine("============================================");

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
                Console.WriteLine($"Number {i + 1} : {numbersToShift[i]} ");
            }
        }

        static void UniqueWords()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("|========= 4. Unique Words Extractor ========|");
            Console.WriteLine("============================================");
            // Create a list of strings
            List<string> words = new List<string>();
            // input words from the user
            Console.WriteLine("Enter N words (type 'exit' to finish):");
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Enter word {i + 1} : ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }
                words.Add(input);
            }
            // Display the list of words
            Console.WriteLine("You entered the following words:");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($"Word {i + 1} : {words[i]}");
            }

            // Create a list to store unique words
            List<string> uniqueWords = new List<string>();

            // Split the paragraph into words
            string paragraph = string.Join(" ", words); // Join the words into a single string
            string[] paragraphWords = paragraph.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries); // Split the string into words
            // Loop through the words and check for uniqueness
            for (int i = 0; i < paragraphWords.Length; i++)
            {
                string word = paragraphWords[i].ToLower(); // Convert to lowercase for case-insensitive comparison
                if (!uniqueWords.Contains(word)) // Check if the word is not already in the list
                {
                    uniqueWords.Add(word); // Add the word to the list of unique words
                }
            }

            // Display the list of unique words
            Console.WriteLine("The unique words are:");
            for (int i = 0; i < uniqueWords.Count; i++)
            {
                Console.WriteLine($"Unique word {i + 1} : {uniqueWords[i]}");
            }

            // Display the list of non-unique words
            Console.WriteLine("The non-unique words are:");
            for (int i = 0; i < paragraphWords.Length; i++)
            {
                string word = paragraphWords[i].ToLower(); // Convert to lowercase for case-insensitive comparison
                if (!uniqueWords.Contains(word)) // Check if the word is not already in the list
                {
                    Console.WriteLine($"Non-unique word {i + 1} : {word}");
                }
            }
        }
    }
}
