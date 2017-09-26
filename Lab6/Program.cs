/*
Program: Translate from English to PigLatin (Lab6)
Due Date: 9/26/2017 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run == true)
            {
                Console.WriteLine("Welcome to PIGLATIN Translator!");
                Console.WriteLine("Enter a line to be translated");
                var inputLine = Console.ReadLine().ToLower();// Converts user sentence to lower case
                bool validationStatus = UserInputValidatinon(inputLine);
                if (validationStatus == true)
                {
                    string[] words = Split(inputLine);
                    Console.WriteLine("Pig Latin Translation is...");
                    MakePigLatin(words);
                }

                run = Continue();
            }
        }
         
        public static bool UserInputValidatinon(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter valid sentence to be translated.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType() }  means  {ex.Message}");
                return false;
            }
        }
        public static string[] Split(string input)
        {
            //Takes input of string and splits them into separate words.
            String[] Words = input.Split(' ');
            return Words;
        }

        public static void MakePigLatin(string[] input)
        {
            string Addway = "way";
            string Adday = "ay";
            int wordLength = input.Length;

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int vowelPosition = VowelPosition(input[i]);
                    int numPosition = NumPosition(input[i]);
                    int puncPosition = PunctPosition(input[i]);
                    int specCharPosition = SpecialCharPosition(input[i]);
                    //Checks to see if first letter of a sentence starts with a vowel and translates to PigLatin.
                    if (vowelPosition == 0)
                    {                       
                        Console.Write(input[i] + Addway + " ");
                    }
                    //Checks if user entered sentence does not have a vowel and its length is one
                    else if (vowelPosition == -1 && wordLength == 1)
                    {
                        Console.Write(input[i] + " ");
                    }
                    // Checks if the sentnece has only consonants 
                    else if (vowelPosition == -1 ) 
                    {
                        Console.Write(input[i] + " ");
                    }
                    //Does not translate sentence with  numbers
                    else if( numPosition != -1)
                    {
                        Console.Write(input[i] + " ");
                    }
                    //Does not translate sentence with special characters
                    else if(specCharPosition!= -1)
                    {
                        Console.Write(input[i] + " ");
                    }
                    //Allows Punctuation
                    else if (puncPosition != -1)
                    {
                        Console.Write(input[i] + " ");
                    }
                    else
                    {
                        //Else the first word starts with a consonant.
                        
                        var part1 = input[i].Substring(vowelPosition);// Takes remaining string after a vowel                   
                        var part2 = input[i].Substring(0, vowelPosition);// Takes string part until vowel                                                                           
                        Console.Write(part1 + part2 + Adday + " ");  // Joins them along with "ay" at the end
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType().Name} means {ex.Message}");
                }
            }
        }

        public static int VowelPosition(string input)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int vowelPosition = input.IndexOfAny(vowels);
            return vowelPosition;// Returns the current positon of vowel in a sentence
        }
       
        public static int NumPosition(string input)
        {
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int numPosition = input.IndexOfAny(numbers);
            return numPosition; // Returns the current positon of numbers in a sentence
        }
        public static int PunctPosition(string input)
        {
            char[] punctuation = new char[] { ',', ':', ';', '?', '!', '.' };
            int puncPosition = input.IndexOfAny(punctuation);
            return puncPosition; // Returns the current positon of punctuation in a sentence
        }
       
        public static int SpecialCharPosition(string input)
        {
            char[] specChar = new char[] { '@', '#', '$', '%', '^', '&', '*', '(', ')', '/', '[', ']' };
            int specialCharPosition = input.IndexOfAny(specChar);
            return specialCharPosition; // Returns the current positon of special characters in a sentence
        }

        public static bool IsVowel(string input)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            for (int i = 0; i < input.Length; i++)
            {
                bool isVowel = vowels.Contains(input[i]);
                return true;
            }
            return false;
        }
        
        public static bool Continue()
        {
            Console.WriteLine("Do you want to translate another line?(y/n)");
            string input = Console.ReadLine();
            input = input.ToLower();
            bool goAhead;
            if (input == "y")
            {
                goAhead = true;
            }
            else if (input == "n")
            {
                goAhead = false;
            }
            else
            {
                Console.WriteLine("I don't understand that, please try again");
                goAhead = Continue();
            }
            return goAhead;
        }
    }
}
