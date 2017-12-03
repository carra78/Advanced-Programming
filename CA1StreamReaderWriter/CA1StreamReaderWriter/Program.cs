using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CA1StreamReaderWriter
{
	class Program
	{
		static void Main(string[] args)
		{
			string pat = @"-{72}"; //hyphen pattern
			string filepath = @"D:\Adv Prog\Advanced-Programming\commit-changes.txt";
			CommitList cl = new CommitList();
			string[] separator = { "|" };

			string[] lines = System.IO.File.ReadAllLines(filepath);
			Regex filebreakpattern = new Regex(pat);

			for (int i = 0; i < (lines.Length - 1); i++)
			{
				if (filebreakpattern.IsMatch(lines[i].ToString()))
				{

					int c = i + 1;//no of the line after hyphens

					//split the first line of each commit into components
					string split = lines[c].ToString();
					string[] myarr = split.Split(separator, StringSplitOptions.RemoveEmptyEntries);
					//trim each string stored in the array to remove extra spaces
					for (int j = 0; j < myarr.Length; j++)
					{
						string b = myarr[j];
						myarr[j] = b.Trim();
					}
					//remove extra information from date - allows for conversion to DateTime if required
					string tempDate = myarr[2].Substring(0, 19);
					myarr[2] = tempDate;
					//					
					int noOfLines = int.Parse(myarr[3].Substring(0, 1));
					//move the reader to start of file paths changed
					c = c + 2;

					//create array of paths changed
					StringBuilder sb = new StringBuilder();					
					string test = lines[c];
					while (!String.IsNullOrEmpty(test) && (c < lines.Length - 1))
					{
						sb.Append(lines[c]);
						sb.Append("|");
						c++;
						test = lines[c];

					}
					string[] changedPaths = sb.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);

					//combine all comment lines into one string
					StringBuilder comment = new StringBuilder();
					for (int y = 1; y < noOfLines + 1; y++)
					{
						c++;
						comment.Append(lines[c] + " ");

					}
					//add individual commit details to commit list
					cl.AddToList(myarr[0], myarr[1], myarr[2], noOfLines, comment.ToString(), changedPaths);

				}

			}
			//checking parsing of file before writing to file
			foreach (var commit in CommitList.commitList)
			{
				Console.WriteLine(commit.ToString());
			}
			Console.ReadLine();
		}
	}
}
