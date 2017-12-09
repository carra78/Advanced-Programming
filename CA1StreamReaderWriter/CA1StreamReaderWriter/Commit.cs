using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1StreamReaderWriter
{
	class Commit
	{
		//local variables

		//Properties
		public string CommitRef { get; set; }
		public string Author { get; set; }
		public string CommitDate { get; set; }
		//public int CommitCommentLines { get; set; }
		public string CommitComment { get; set; }
		public string[] CommitChangedPaths { get; set; }

		//Constructor(s)
		public Commit()
		{
			//default construtor - temporarily included as overriden by addition of any other constructor 
		}

		public Commit(string cref, string auth, string date, /*int lines,*/ string comment, string[] paths)
		{
			CommitRef = cref;
			Author = auth;
			CommitDate = date;
			//CommitCommentLines = lines;
			CommitComment = comment;
			CommitChangedPaths = paths;

		}



		//Method(s)
		// string override used for testing result of string split with console.writeline
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(CommitRef);
			sb.Append(",");
			sb.Append(Author);
			sb.Append(",");
			sb.Append(CommitDate);
			sb.Append(",");
			//sb.Append(CommitCommentLines.ToString());
			//sb.Append(",");
			sb.Append(CommitComment);			
			foreach (string path in CommitChangedPaths)
			{
				sb.Append(",");
				sb.Append(path);
			}
			
			return sb.ToString();
		}



	}
}
