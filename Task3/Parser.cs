using System;

namespace Task3
{
    class Parser
    {
        public char[] arrInput;
        public void Input(string input)
        {
            input = input
                .Replace(" ", "")
                .Replace(",", ".")
                .Replace("=", "");
            arrInput = input.ToCharArray();
        }

        public static decimal ParseDecimal(string s)
        {
            return decimal.Parse(
                s,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.InvariantCulture
            );
        }

        public decimal SearchLeftOperand(int OperatPosition)
        {
            int numberOfDigits = 0;
            string leftOperand = "";
            int position = OperatPosition - 1;

            while (arrInput[position] != '+' || arrInput[position] != '-' || arrInput[position] != '*' || arrInput[position] != '/' || position != 0)
            {
                numberOfDigits++;
                position--;
            }

            for (int i = OperatPosition - numberOfDigits; i < OperatPosition; i++)
            {
                leftOperand += arrInput[i];
            }

            return ParseDecimal(leftOperand);
        }

        public decimal SearchRightOperand(int OperatPosition)
        {
            int numberOfDigits = 0;
            string rightOperand = "";
            int position = OperatPosition + 1;

            while (arrInput[position] != '+' || arrInput[position] != '-' || arrInput[position] != '*' || arrInput[position] != '/' || position != arrInput.Length + 1)
            {
                numberOfDigits++;
                position++;
            }

            for (int i = OperatPosition + 1; i <= OperatPosition + numberOfDigits; i++)
            {
                rightOperand += arrInput[i];
            }

            return ParseDecimal(rightOperand);
        }
    }
}
