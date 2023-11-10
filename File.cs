using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viselitsa
{
	internal class File
	{
		public static string Get_Secret_Word(string path)
		{
			string[] words = System.IO.File.ReadAllLines(path, Encoding.GetEncoding(1251));
			Random random = new Random();
			int index = random.Next(words.Length);
			return words[index];
		}
	}
}
