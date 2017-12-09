using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1StreamReaderWriter
{
	class CommitList
	{
		//local varialbes
		public static List<Commit> commitList = new List<Commit>();

		//properties

		//Constructor

		//methods

		//Add item to list
		public void AddToList(string cref, string auth, string date, /*int lines,*/ string comment, string[] paths)
		{
			Commit c = new Commit(cref, auth, date, /*lines,*/ comment, paths);
			commitList.Add(c);
		}
	}
}
