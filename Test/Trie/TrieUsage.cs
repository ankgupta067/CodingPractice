using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Trie
{
	class TrieUsage
	{
		public void Init()
		{
			var dict = new Dictionary<string, int>();
			var Trie = new Trie();
			Trie.Insert("dola");
			Trie.Insert("pola");
			Console.WriteLine(Trie.Search("chola"));
			Console.WriteLine(Trie.Search("dola"));
			Trie.Delete("dola");
			//Console.WriteLine(Trie.Search("d"));
			Console.WriteLine(Trie.Search("pola"));

		}
	}
}
