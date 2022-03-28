using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Calculate : Parser
    {
        Operations operations = new Operations();

        public decimal Count(decimal x, char op, decimal y)
        {
            if (op == '*')
            {
                return operations.mul(x, y);
            }
            else if (op == '/')
            {
                return operations.div(x, y);
            }
            else if (op == '+')
            {
                return operations.sum(x, y);
            }
            else if (op == '-')
            {
                return operations.sub(x, y);
            }
            else
                throw new Exception("Невизначена дія");
        }

        public Calculate(string input)
        {
            Input(input);
            bool endFirstPriority = false;
            bool endSecondPriority = false;

            while (endFirstPriority == false) //перший пріорітет
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == '*' || arrInput[i] == '/')
                    {
                        decimal subtotal = Count(SearchLeftOperand(i), arrInput[i], SearchRightOperand(i));
                        string replaceIt = SearchLeftOperand(i).ToString() + arrInput[i] + SearchRightOperand(i).ToString();
                        string text = arrInput.ToString();
                        text = text
                            .Replace(replaceIt, subtotal.ToString());
                        arrInput = text.ToCharArray();
                        break;
                    }
                    else
                    {
                        endFirstPriority = true;
                    }
                }
            }

            while (endSecondPriority == false) //другий пріорітет
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == '+' || arrInput[i] == '-')
                    {
                        decimal subtotal = Count(SearchLeftOperand(i), arrInput[i], SearchRightOperand(i));
                        string replaceIt = SearchLeftOperand(i).ToString() + arrInput[i] + SearchRightOperand(i).ToString();
                        string text = arrInput.ToString();
                        text = text
                            .Replace(replaceIt, subtotal.ToString());
                        arrInput = text.ToCharArray();
                        break;
                    }
                    else
                    {
                        endSecondPriority = true;
                    }
                }
            }
        }

        public void Disp()
        {
            Console.WriteLine();
        }
    }
}
