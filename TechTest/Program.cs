using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackthonJnJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            try
            {
                var strInput1 = Console.ReadLine();
                var strInput2 = Console.ReadLine();
                
                Console.WriteLine(SumNumbers(strInput1, strInput2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error to process sum. \n" + ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        private static string SumNumbers(string pInput1, string pInput2)
        {
            if (string.IsNullOrEmpty(pInput1))
                throw new Exception("Please inform any information to input 1.");

            if (string.IsNullOrEmpty(pInput2))
                throw new Exception("Please inform any information to input 2.");

            var lstInput1 = pInput1.Split(' ').ToList();
            var lstInput2 = pInput2.Split(' ').ToList();
            int iNumberN = 0, iNumberS = 0, iSum = 0, iCount = 0;
            var lstRet = new List<int>();

            if (lstInput1.Count < 2)
                throw new Exception("Input of numbers N and S is not wrong. Must be input the numbers N [scape] S. Example: 3 1");

            if (!int.TryParse(lstInput1[0], out iNumberN))
                throw new Exception("Number N was not recognized.");

            if (!int.TryParse(lstInput1[1], out iNumberS))
                throw new Exception("Number S was not recognized.");

            foreach (var x in lstInput2)
            {
                int iNumberArray = 0;
                if (!int.TryParse(x, out iNumberArray))
                    throw new Exception(string.Format("Information at {0} position was not recognized.", x));
                else
                {
                    iSum += iNumberArray;
                    lstRet.Add(iNumberArray);
                    if (iSum >= iNumberS)
                    {
                        break;
                    }
                    iCount++;
                }
            };

            var strOutPutArray = "[";
            lstRet.ForEach(x => strOutPutArray += x + ",");
            strOutPutArray = strOutPutArray.Substring(0, strOutPutArray.Length - 1) + "]";
            return string.Format("The maximum sub - array we can get with sum equal to {0}, is the sub - array{1}", iNumberS.ToString(), strOutPutArray);

        }
    }
}
