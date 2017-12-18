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
            Random rnd = new Random();
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Factory.StartNew(() => OutputPrimesToConsole(587953)));
            tasks.Add(Task.Factory.StartNew(() => OutputPrimesToConsole(12387853)));
            tasks.Add(Task.Factory.StartNew(() => OutputPrimesToConsole(7738796)));
            Task.WaitAll(tasks.ToArray());
        }

        static List<ulong> LoadData(string fileName)
        {
            string rawData = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    string line = string.Empty;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (bIntegerOrString)
                        {
                            IntegerLinkedList.Push(long.Parse(line));
                        }
                        else
                        {
                            StringLinkedList.Push(line);
                        }
                        //Add line number to text from file so we can easily reference the line in the text box.
                        rawData += string.Format("{0}: {1}{2}", lineNumber++, line, Environment.NewLine);

                    }
                    reader.Close();
                }
                txtRawData.Text = rawData;
                txtNumEntries.Text = ((lineNumber == 1) ? 1 : lineNumber - 1).ToString();

            }
            catch (IOException ex)
            {
                ClearList();
                throw new IOException(string.Format("Unable to acccess {0}.{1}Reason: {2}", fileName, Environment.NewLine, ex.Message));
            }
            catch (Exception ex)
            {
                ClearList();
                throw ex;
            }
        }

        static string GeneratePrimeStringList(List<ulong> primes)
        {
            string ret = string.Empty; 
            if(primes == null || primes.Count <= 1)
            {
                return ret;
            }
            foreach(ulong prime in primes)
            {
                ret += string.Format("{0},", prime);
            }
            ret = ret.TrimEnd(",".ToCharArray());
            return ret;

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
                msg = string.Format("The prime numbers for {0} are: {1}", number, GeneratePrimeStringList(primes));
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
