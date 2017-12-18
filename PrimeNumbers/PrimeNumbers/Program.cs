using System;
using System.IO;
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
            try
            {
                if(args.Length != 1)
                {
                    Console.WriteLine("Usage: PrimeNumbers <fileName>");
                    return;
                }
                string fileName = args[0];
                if(!File.Exists(fileName))
                {
                    Console.WriteLine(string.Format("Unable to locate file: {0}", fileName));
                }

                //Generate a collection of tasks to run in parallel.  Output is not guarneteed to match input order but results will be correct.
                List<Task> tasks = new List<Task>();
                List<ulong> data = LoadData(fileName);
                foreach (ulong value in data)
                {
                    tasks.Add(Task.Factory.StartNew(() => OutputPrimesToConsole(value)));
                }
                
                //Waite for all task to complete before exiting program.
                Task.WaitAll(tasks.ToArray());
            }
            catch(Exception e)
            {
                Console.WriteLine("Error processing file: {0}", e.Message);
            }
           
            
        }
        static List<ulong> LoadData(string fileName)
        {
            
            try
            {
                List<ulong> data = new List<ulong>();
                using (StreamReader reader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    string line = string.Empty;
                    ulong value = 0;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if(ulong.TryParse(line, out value))
                        {
                            data.Add(value);
                        }

                    }
                    reader.Close();
                }
                return data;
            }
            catch (IOException ex)
            {
                throw new IOException(string.Format("Unable to acccess {0}.{1}Reason: {2}", fileName, Environment.NewLine, ex.Message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static string GeneratePrimeStringList(List<ulong> primes, string separator)
        {
            string ret = string.Empty; 
            if(primes == null || primes.Count <= 1)
            {
                return ret;
            }
            foreach(ulong prime in primes)
            {
                ret += string.Format("{0} {1} ", prime,separator);
            }
            ret = ret.TrimEnd((" " + separator).ToCharArray());
            return ret;

        }
        static string GenerateCheck(List<ulong> primes, ulong expectedResult)
        {
            if(primes == null || primes.Count <= 1)
            {
                return string.Empty;
            }
            ulong calculatedResult = 1;

            foreach(ulong prime in primes)
            {
                calculatedResult *= prime;
            }
            bool resultMatch = (calculatedResult == expectedResult);
            string primeMultiplyString = GeneratePrimeStringList(primes, "*");
            string status = (resultMatch) ? "GOOD" : "BAD";

            return string.Format("Check ({0} = {1}  Expected Result: {2} Status: {3})", primeMultiplyString, calculatedResult, expectedResult, status);
            
        }
        static void OutputPrimesToConsole(ulong number)
        {
            List<ulong> primes = GetPrimes(number);
            string msg = string.Empty;
            if(primes == null || primes.Count == 0)
            {
                msg = string.Format("Unable to determine any primes for {0}", number);
            }
            else if (primes.Count == 1)
            {
                msg = string.Format("The number {0} is a prime number", number);
            }
            else
            {
                msg = string.Format("The prime numbers for {0} are: {1}{2}{3}{2}", number, GeneratePrimeStringList(primes,","), Environment.NewLine, GenerateCheck(primes,number));
            }
            Console.WriteLine(msg);
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
