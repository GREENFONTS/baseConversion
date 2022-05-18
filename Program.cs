using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;



namespace baseConverter
{
    public class Class1
    {
        static void Main()
        {
            //get binary input form user
            string input = "";
            string preparedInput = "";

            Console.Write("Which Base do you want to convert to: Hex or Oct: ");
            string  newBase = Console.ReadLine().ToLower();

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
 
            List<int> Result = DivideBinary(preparedInput, newBase);

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
            if (remainder == 0)
            {
                return preparedInput;
            }
            for (int i = 0; i < (divisor - remainder); i++)
            {
                preparedInput = "0" + preparedInput;

            }
            return preparedInput;
        }

        private static List<int> DivideBinary(string preparedInput, string newBase)
        {
            int divisor = newBase == "hex" ? 4 : 3;
            char[] binary = preparedInput.ToCharArray();

            var d = binary.Select((v, i) => new { index = i, value = v }).GroupBy(x => x.index / divisor, x =>
            {
                double pow = divisor - ((x.index % divisor) + 1);
               int c = Convert.ToInt32(Math.Pow(2, pow));
                int y = int.Parse(x.value.ToString());
                return y * c;
            }, (x, v) => v.Sum()

            );

            var v = d.ToList();
            return v;
        }

        //function to convert binary to Octal
        private static string BinaryToOctal(List<int> Result)
        {
            Console.WriteLine(Result);
            string final = "";
            for (int i = 0; i < Result.Count; i++)
            {
                final += Result[i].ToString();
            }
            return final;
        }

        private static string BinaryToHex(List<int> Result)
        {
            Console.WriteLine(Result);
            
            char[] map = { 'A', 'B', 'C', 'D', 'E', 'F' };
            string final = "";
            for (int i = 0; i < Result.Count; i++)
            {
                if (Result[i] > 9)
                {
                    int value = Result[i] - 10;
                    final += map[value].ToString();
                }
                else
                {
                    final += Result[i].ToString();
                }
            }
            return final;
        }
    }
}