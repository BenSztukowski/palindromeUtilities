using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palandromer
{
    class PalindromeUtils
    {
        //Function to determine whether a string is a palandrome (uses the FindPalandromes method, since I wrote it first)
        static bool IsPalandrome(string s, bool ignore)
        {
            List<string> newList = FindPalandromes(s, ignore);

            if (newList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        static List<string> FindPalandromes(string s, bool ignore)
        {
            //declare a list to populate with all palandromes from the input string
            List<string> palandromeList = new List<string>(); 

            //Alter string to ignore spaces when digging for palandromes, if user so chooses
            if (ignore == true)     
            {
                s = s.Replace(" ", String.Empty);
            }

            
            string substring = "";      //declare a variable to continuously overwrite until a palandrome reaches its edges
            for (int i = 1; i < s.Length-2; i++)       //start a loop to that runs over each char in the string until it finds the same char(s) continuing in opposite directions
            {
                int testAbove = i + 1;
                int testBelow = i - 1;


                //check for duplicate letters, and adjust bounds
                if (testAbove <= s.Length - 1 && testBelow >= 0)
                {
                    if (s[i] == s [testAbove])
                    {
                        testAbove++;
                    }
                    if (s[i] == s[testBelow])
                    {
                        testBelow--;
                    }
                }

                //this loop rewrites the 'substring' variable until it reaches the end of a detected palandrome, then adds it to the palandrome list
                if (testAbove <= s.Length-1 && testBelow >= 0)
                {
                    if (s[testAbove] == s[testBelow])
                    {
                        while (testBelow >= 0 && testAbove <= s.Length - 1 && s[testAbove] == s[testBelow])
                        { 
                             substring = s.Substring(testBelow, testAbove - testBelow + 1);
                             testAbove++;
                             testBelow--;
                        }
                        palandromeList.Add(substring);
                        
                    }
                }
            }
            return palandromeList;
            
        }
        
        static void Main(string[] args)
        {

            bool isPalandrome = false;
            bool yesNo = false;
            string ignoreSpaces = "";
            Console.WriteLine("This little program finds palandromes from a string.\nType in a string:");   //prompt for a string to parse
            string s = Console.ReadLine();
            Console.WriteLine("\nGot it. Ignore spaces? Type 'yes' or 'no' (recommended):");  //ask the user whether to ignore spaces in the string
            ignoreSpaces =(Console.ReadLine().ToUpper());
            if(ignoreSpaces.Contains("YES"))
            {
                yesNo = true;
            }

            isPalandrome = IsPalandrome(s, yesNo);

            //First display whether the string is or contains palandromes
            if (isPalandrome == true)
            {
                Console.WriteLine("\nThis string contains one or more palandromes.\n");
            }
            else
            {
                Console.WriteLine("\nThere are no palandromes in the given string.");
            }

            //Then list the palandromes
            List<string> palandromes = FindPalandromes(s, yesNo);
            foreach(string strings in palandromes)
            {
                Console.WriteLine(strings);
            }

            //Highlight the longest palandrome in the list
            string longest = "";
            foreach (string d in palandromes)
            {
                if (d.Length > longest.Length)
                {
                    longest = d;
                }
            }
            if (longest != "")
            {
                Console.WriteLine($"\nThe longest of the palandromes is: {longest}");
            }

            Console.ReadLine();
        }
    }
}
