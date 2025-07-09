using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeryLongIntCalculator
{
    public class VeryLongInt
    {
        private List<int> digits; // to store the digits of number in reverse order

        public VeryLongInt(string number)
        {  // constructor for input string
            digits = new List<int>();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                // reversing the numbers and storing as an array of ints
                // for later calculation
                digits.Add(int.Parse(number[i].ToString()));
            }
        }

        private VeryLongInt(List<int> digits)
        { // secondary constructor to store results
            this.digits = digits;
        }

        // overloading the + operator
        public static VeryLongInt operator +(VeryLongInt a, VeryLongInt b)
        {
            // initilaizing the resultant list
            List<int> result = new List<int>();
            int carry = 0;
            int maxLength = Math.Max(a.digits.Count, b.digits.Count);

            for (int i = 0; i < maxLength; i++)
            {
                // performing left to right digitwise addition and 
                // keeping track of carry
                int sum = carry;
                if (i < a.digits.Count) sum += a.digits[i];
                if (i < b.digits.Count) sum += b.digits[i];
                result.Add(sum % 10); // 
                carry = sum / 10;
            }

            if (carry > 0) result.Add(carry);
            // converting to VerylongInt and returning 
            return new VeryLongInt(result);
        }
        
        // method that overloads the * oeprator
        //input parametrs are VeryLongInt objects i.e. reversed also returns a VeryLongInt
        public static VeryLongInt operator *(VeryLongInt a, VeryLongInt b)
        {
            // initialzing result as VeryLongInt of value 0 in order to be able to add partial products
            VeryLongInt result = new VeryLongInt("0");

            // iterate over b
            for (int i = 0; i < b.digits.Count; i++)
            {
                // temp list to store interim results
                List<int> temp = new List<int>();
                int carry = 0;

                // adding the leading zeros
                for (int j = 0; j < i; j++)
                {
                    temp.Add(0);
                }

                // multiply each digit of a with the current digit of b
                for (int j = 0; j < a.digits.Count; j++)
                {
                    int product = a.digits[j] * b.digits[i] + carry;
                    temp.Add(product % 10); // add least significant digit of product to temp
                    carry = product / 10; // carry the overflow for next iteration
                }

                if (carry > 0)
                {
                    temp.Add(carry); // adding carry at the end if any
                }

                result += new VeryLongInt(temp); // Use the secondary constructor
                                                // and + operator already implemented above
            }

            return result;
        }

        // converting VeryLongInt to string in reverse order to print results to form
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                sb.Append(digits[i]);
            }
            return sb.ToString();
        }
    }
}
