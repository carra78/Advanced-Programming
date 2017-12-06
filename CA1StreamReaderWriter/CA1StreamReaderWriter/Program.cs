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
			//declare variables
			string pat = @"-{72}"; //hyphen pattern
			string filepath = @"D:\Adv Prog\Advanced-Programming\commit-changes.txt"; //user to update?
			string[] separator = { "|" }; //for string split functions
			string[] lines = System.IO.File.ReadAllLines(filepath);//create an array of all lines in the file
			int counter = 0; //use to move through the lines in the file
			string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\commit-changes.csv";

			//instantiate classes
			MyMethods methods = new MyMethods();
			CommitList cl = new CommitList();			
			Regex filebreakpattern = new Regex(pat);
			
			//iterate through all lines and parse into ref, author, date, comments and changedpaths
			while( counter < lines.Length-1)
			{
				if (filebreakpattern.IsMatch(lines[counter].ToString()))//check if hyphen pattern
				{
					counter = counter + 1;//no of the line after hyphens

					//split the first line of each commit into array
					string split = lines[counter].ToString();
					string[] myarr = split.Split(separator, StringSplitOptions.RemoveEmptyEntries);

					//trim each string stored in the array to remove extra spaces
					myarr = methods.TrimArrayStrings(myarr);

					//remove extra information from date - allows for conversion to DateTime if required
					myarr[2] = myarr[2].Substring(0, 19);				

					//move the reader to start of file paths changed
					counter = counter + 2;

					//create array of paths changed
					string[] changedPaths = methods.MyStringBuilder(lines, ref counter).ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
					changedPaths = methods.TrimArrayStrings(changedPaths);

					//Determine number of comment lines (all less than 10)					
					int noOfLines = methods.IntAtStartOfString(myarr[3].ToString());

					//combine all comment lines into one string
					string comment = methods.MyStringBuilder(lines, ref counter, noOfLines).ToString();
					
					//add individual commit details to commit list
					cl.AddToList(myarr[0], myarr[1], myarr[2], noOfLines, comment, changedPaths);

					counter++; //move counter to next line
				}
				else
				{
					counter++;
				}

			}
			//write out parsed data to csv file
			methods.WriteListToFile(CommitList.commitList, filePath, true);

			//confirm whether file has been successfully updated or not
			Console.WriteLine("Success");
			

			//used to check parsing of file before writing to file
			//foreach (var commit in CommitList.commitList)
			//{
			//	Console.WriteLine(commit.ToString());
			//}
			Console.ReadLine();
		}
	}
}
