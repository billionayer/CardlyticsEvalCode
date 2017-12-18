using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong initialValue = 11111;
            var primes = GetPrimes(initialValue);
            ulong value = 1;
            foreach(ulong prime in primes)
            {
                value *= prime;
            }
            if(value == initialValue)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.WriteLine("Bad");
            }

        }

        static List<ulong> GetPrimes(ulong number)
        {
            List<ulong> primes = new List<ulong>();

            //There are no prime numbers in zero, and this algorithm only handles positive integers.
            if(number == 0)
            {
                return primes;
            }
            //If number is less than 4 then it is already prime.
            if (number < 4)
            {
                primes.Add(number);
                return primes;
            }

            bool primesleft = true;
            ulong input = number;
            ulong currentprime = 2;
            while(primesleft)
            {
                if(input % currentprime == 0)
                {
                    primes.Add(currentprime);
                    input /= currentprime;
                }
                else
                {
                    while(true)
                    {
                        currentprime++;
                        if(input % currentprime == 0)
                        {
                            primes.Add(currentprime);
                            input /= currentprime;
                            break;
                        }
                    }

                }
                primesleft = (input != 1);

            }
            return primes;

        }
    }
}
