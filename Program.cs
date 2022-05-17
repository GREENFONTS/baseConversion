using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_Conversion
{
    internal class Program
    {
        static void Main()
        {
            //get binary input form user
            string input = "";
            string preparedInput = "";

            Console.Write("Which Base do you want to convert to: Hex or Oct: ");
            string newBase = Console.ReadLine().ToLower();

            Console.Write("Enter a binary number: ");
            string testInput = Console.ReadLine();


            //checking if input is binary
            bool checkInput = CheckInputs(testInput);
            if (checkInput)
            {
                input = testInput;
                preparedInput = input;
                
            }
            while (!checkInput)
            {
                throw new FormatException("Wrong Input, Enter a binary number: ", e);
                Console.Write("Wrong Input, Enter a binary number: ");
                testInput = Console.ReadLine();
                checkInput = CheckInputs(testInput);
                if (checkInput)
                {
                    input = testInput;
                    preparedInput = testInput;
                }
            }

            //preparing the binary input
            preparedInput = PrepareBinary(input, preparedInput, newBase);

            //dividing the binary into subsets of 3's
            List<List<char>> Result = DivideBinary(preparedInput, newBase);

            //converting binary to octal
            string finalBaseNumber = newBase == "hex" ? BinaryToHex(Result) : BinaryToOctal(Result);

            Console.WriteLine("{0} to {1} is {2}", input, newBase.ToUpper(), finalBaseNumber);
            Console.ReadLine();


        }




        //function to check if input is binary
        private static bool CheckInputs(string arg)
        {
            char[] inputList = arg.ToCharArray();
            bool check = true;
            for (int i = 0; i < inputList.Length; i++)
            {
                if (inputList[i] != '1' & inputList[i] != '0')
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        //function to prepare the binary input for octal / hexadecimal conversion
        private static string PrepareBinary(string arg, string preparedInput, string newBase)

        
        { 
           int divisor = newBase == "hex" ? 4 : 3;

            int count = arg.Count();
            int remainder = count % divisor;
            if(remainder == 0)
            {
                return preparedInput;
            }
            for (int i = 0; i < (divisor - remainder); i++)
            {
                preparedInput = "0" + preparedInput;
                
            }
            return preparedInput;
        }

        private static List<List<char>> DivideBinary(string preparedInput, string newBase)
        {
            int divisor = newBase == "hex" ? 4 : 3;
            char[] binary = preparedInput.ToCharArray();
            List<char> binaryPair = new List<char>();
            List<List<char>> result = new List<List<char>>();
            for (int i = 1; i < binary.Length + 1; i++)
            {
                if (i % divisor != 0)
                {
                    binaryPair.Add(binary[i - 1]);
                }
                else
                {
                    binaryPair.Add(binary[i - 1]);
                    List<char> clone = new List<char>(binaryPair);
                    result.Add(clone);
                    binaryPair.Clear();
 
                }

            }
            return result;
        }

        //function to convert binary to Octal
        private static string BinaryToOctal(List<List<char>> Result)
        {
            string final = "";
            for (int i = 0; i < Result.Count; i++)
            {
                int ans = int.Parse(Result[i][0].ToString()) * 4 + int.Parse(Result[i][1].ToString()) * 2 +
                    int.Parse(Result[i][2].ToString()) * 1;

                final += ans.ToString();
            }
            return final;
        }

        private static string BinaryToHex(List<List<char>> Result)
        {
            char[] map = { 'A', 'B', 'C', 'D', 'E', 'F' };
            string final = "";
            for (int i = 0; i < Result.Count; i++)
            {
                int ans = int.Parse(Result[i][0].ToString()) * 8 + int.Parse(Result[i][1].ToString()) * 4 + 
                    int.Parse(Result[i][2].ToString()) * 2 + int.Parse(Result[i][3].ToString()) * 1;
                if (ans > 9)
                {
                    int value = ans - 10;
                    final += map[value].ToString();
                }
                else
                {
                    final += ans.ToString();
                }
            }
            return final;
        }

    }
}
