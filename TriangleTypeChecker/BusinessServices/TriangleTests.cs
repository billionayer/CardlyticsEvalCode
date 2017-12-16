using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleTypeChecker.DataObjects;

namespace TriangleTypeChecker.BusinessServices
{
    public class TriangleTests : List<TriangleTest>
    {
        public TriangleTests()
        {

        }
        private bool VerifyTokens(string[] tokens)
        {
            if (tokens == null || tokens.Length != 4)
            {
                return false;
            }
            ulong temp = 0;
            if (!ulong.TryParse(tokens[0], out temp) ||
               !ulong.TryParse(tokens[1], out temp) ||
               !ulong.TryParse(tokens[2], out temp))
            {
                return false;
            }
            TriangleTypeEnum tempTriangleType = TriangleTypeEnum.NONE;
            if (!Enum.TryParse(tokens[3].ToUpper(), out tempTriangleType))
            {
                return false;
            }
            return true;
        }

        public void Load(string fileName)
        {
            try
            {
                Clear();
                List<string[]> tokenCollection = new List<string[]>();
                using (StreamReader reader = new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    string line = string.Empty;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        string[] tokens = line.Split(",".ToCharArray());
                        if (VerifyTokens(tokens))
                        {
                            tokenCollection.Add(tokens);
                        }
                    }
                    reader.Close();
                }
                int id = 0;
                foreach (string[] tokens in tokenCollection)
                {
                    TriangleTypeEnum tempTriangleType = TriangleTypeEnum.NONE;
                    Enum.TryParse(tokens[3].ToUpper(), out tempTriangleType);
                    TriangleTest test = new TriangleTest(id++, ulong.Parse(tokens[0]),
                                                ulong.Parse(tokens[1]),
                                                ulong.Parse(tokens[2]),
                                                tempTriangleType);

                    Add(test);
                }
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
    }
}
