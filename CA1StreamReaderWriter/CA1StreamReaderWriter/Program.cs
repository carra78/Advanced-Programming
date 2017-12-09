using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.IO;
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
			string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
				+ System.IO.Path.DirectorySeparatorChar + @"commit-changes.csv";

			//instantiate classes
			MyMethods methods = new MyMethods();
			CommitList cl = new CommitList();			
			Regex filebreakpattern = new Regex(pat);

			try
			{
				//iterate through all lines and parse into ref, author, date, comments and changedpaths
				while (counter < lines.Length - 1)
				{
					if (filebreakpattern.IsMatch(lines[counter].ToString()))//check if hyphen pattern
					{
						counter++; //no of the line after hyphens

						//split the first line of each commit into array
						string split = lines[counter].ToString();
						string[] myarr = split.Split(separator, StringSplitOptions.RemoveEmptyEntries);

						//trim each string stored in the array to remove extra spaces
						myarr = methods.TrimArrayStrings(myarr);

						//remove extra information from date - allows for conversion to DateTime if required
						myarr[2] = myarr[2].Substring(0, 19);

						//move the reader to start of file paths changed
						counter++;
						methods.SkipLines(lines, ref counter, "Changed paths:");

						//create array of paths changed
						string[] changedPaths = methods.MyStringBuilder(lines, ref counter, pat).ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);
						changedPaths = methods.TrimArrayStrings(changedPaths);

						//move counter to start of comment section
						methods.SkipLines(lines, ref counter);						

						//combine all comment lines into one string
						string comment = methods.MyStringBuilder(lines, ref counter, pat).ToString().Trim();

						//add individual commit details to commit list
						cl.AddToList(myarr[0], myarr[1], myarr[2], /*noOfLines,*/ comment, changedPaths);

					}
					else
					{
						counter++;
					}

				}
			}//end of try for read file

			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			try
			{
				//write out parsed data to csv file
				methods.WriteListToFile(CommitList.commitList, filePath, true);

				//confirm whether file has been successfully updated or not
				Console.WriteLine("File created or updated successfully - total number of commit records is {0}", CommitList.commitList.Count());
				
				//used to check parsing of file before writing to file
				//foreach (var commit in CommitList.commitList)
				//{
				//	Console.WriteLine(commit.ToString());
				//}
				Console.ReadLine();
			}//end of write to file try

			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
