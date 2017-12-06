using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1StreamReaderWriter
{
	class MyMethods
	{
		//Trim any blank or empty chars from strings in an array
		public string[] TrimArrayStrings(string[] myarr)
		{
			for (int j = 0; j < myarr.Length; j++)
			{
				string b = myarr[j];
				myarr[j] = b.Trim();
			}
			return myarr;
		}

		//Combine elements of a string array into a string
		public StringBuilder MyStringBuilder(string[] myArray, ref int myInt)
		{
			StringBuilder sb = new StringBuilder();
			string test = myArray[myInt];
			while (!String.IsNullOrEmpty(test) && (myInt < myArray.Length - 1))
			{
				sb.Append(myArray[myInt]);
				sb.Append("|");
				myInt++; //move to next line
				test = myArray[myInt]; //change line to test to next to next line

			}

			return sb;
		}

		//overload - combine elements of a string array into a string
		public StringBuilder MyStringBuilder(string[] myArray, ref int myCounter, int repeat)
		{
			StringBuilder sb = new StringBuilder();
			for (int y = 1; y < repeat + 1; y++)
			{
				myCounter++; //move to line after empty line
				sb.Append(myArray[myCounter] + " ");

			}

			return sb;
		}
		public int IntAtStartOfString(string testString)
		{
			int result = 0;
			string test = testString;
			System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^\d+");
			System.Text.RegularExpressions.Match match = pattern.Match(test);
			if (match.Success)
			{
				while (match.Success)
				{
					result = int.Parse(test.Substring(0, match.Length));
					match = match.NextMatch();
				}
			}

			return result;
		}

	}
}
