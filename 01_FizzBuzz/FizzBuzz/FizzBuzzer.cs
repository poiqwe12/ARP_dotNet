using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
	public class FizzBuzzer
	{
		public static bool Buzzinga(List<int> numbers, int i)
		{
			if (numbers[i] % 7 == 0)
				return true;
			return false;
		}
		public static bool Fizzbuzz_(List<int> numbers, int i)
		{
			string number;
			number = numbers[i].ToString();
			number.ToLower();
			
			if (numbers[i] % 15 == 0)
				return true;
			for (int j = 1; j < number.Length; ++j)
			{
				if (number[j] == '3')
				{
					if (number[j - 1] == '5')
						return true;
				}
				if (number[j] == '5')
				{
					if (number[j - 1] == '3')
						return true;
				}
			}
			return false;
		}
		public static List<string> MillNumbers(List<int> numbers)
		{
            
            
			List<string> result = new List<string>();
			for (int i = 0; i < numbers.Count; i++)
			{
				if (Buzzinga(numbers, i))
					result.Add("Buzzinga");
				else if (Fizzbuzz_(numbers, i))
					result.Add("FizzBuzz");
				else
				{
					if (Fizz(numbers, i))
						result.Add("Fizz");
					else if (Buzz(numbers, i))
						result.Add("Buzz");
					else
						result.Add(numbers[i].ToString());
				}
			}
			return result;
		}

		public static bool Fizz(List<int> numbers, int i)
		{
			string number;
			number = numbers[i].ToString();
			if (numbers[i] % 3 == 0)
				return true;
			for (int j = 0; j < number.Length; ++j)
			{
				if (number[j] == '3')

					return true;
			}
			return false;
		}
		public static bool Buzz(List<int> numbers, int i)
		{
			string number;
			number = numbers[i].ToString();
			if (numbers[i] % 5 == 0)
				return true;
			for (int j = 0; j < number.Length; ++j)
			{
				if (number[j] == '5')

					return true;
			}
			return false;
		}
	}
}
