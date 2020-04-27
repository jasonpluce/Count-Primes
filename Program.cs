using System;
using System.Collections.Generic;


namespace Count_Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code determines the number of primes numbers between 2 and Prime_Check_Max. It does this by counting the number of non-prime numbers between 2 and Prime_Check_Max; the remaining numbers are taken to be prime
            int Prime_Check_Max = 1000000; // Ceiling on checking prime numbers
            int num_evens = (int)(Math.Floor(0.5 * Prime_Check_Max) - 1); // Count the number of even numbers; subtract 1 because we don't count '2', the rest are non-prime. 
            int Prime_Check_Root = (int)Math.Ceiling(Math.Sqrt(Prime_Check_Max)); // We will be counting odd numbers starting from 3,5,7, ... , sqrt(Prime_Check_Max); Refer to 'Sieve of Eratosthenes' for info on calculating primes
            int num_odds; // variable for number of odd non-prime numbers
            int num_primes; // variable for number of prime numbers 
            HashSet<int> Not_prime_set = new HashSet<int>(); // Used to keep track of our collection of non-prime numbers

            for (int i = 3; i <= Prime_Check_Root; i += 2) // Start from 3,5,7, ... , sqrt(Prime_Check_Max)
            {
                int not_prime = i;
                while (not_prime <= Prime_Check_Max)
                {
                    not_prime = not_prime + 2 * i; // determine the odd non-prime multiples of i (i = 3,5,7, etc....)
                    if (not_prime > Prime_Check_Max) // don't consider multiples of i greater than Prime_Check_Max
                    {
                        break;
                    }
                    Not_prime_set.Add(not_prime); // Add the non-prime numbers to the set
                }
            }

            num_odds = Not_prime_set.Count; // count the number of non-prime numbers in the set;
            num_primes = Prime_Check_Max - (num_evens + num_odds) - 1; // Subtract the total number of non-prime numbers for the total number of numbers; subtract 1 because we don't count '1' as a prime number

            //foreach (Object obj in Not_prime_set) //uncomment to display set of non-primes. Not recommened for large values of Prime_Check_Max.
            //    Console.Write("   {0}", obj);
            //    Console.WriteLine();

            Console.WriteLine(String.Concat("\nThe number of prime numbers between 2 and ", Prime_Check_Max, " is: ", num_primes)); // Output the number of prime numbers between 2 and Prime_Check_Max
        }
    }
}
