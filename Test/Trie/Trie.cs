using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Trie
{
	public struct TrieNode
	{	
		public TrieNode[] Childs { get; set;}

	}

	public class Trie
	{
		public TrieNode Root { get; set; }

		public Trie()
		{
			Root = GetNode();
		}
		
		private  TrieNode GetNode()
		{

			var node = new TrieNode();
			node.Childs = new TrieNode[26];
			for (int i = 0; i < 26; i++)
			{
				node.Childs[i] = default;
			}
			return node;
		}
		public void Insert(String input)
		{
			var currnode = Root;
			foreach (var item in input)
			{
				var index = item - 'a';
				if (currnode.Childs[index].Equals(default(TrieNode)))
				{
					currnode.Childs[index] = GetNode();
					currnode = currnode.Childs[index];
				}
			}
		}

		public bool Search(string key)
		{
			var currnode = Root;
			foreach (var item in key)
			{
				var index = item - 'a';
				if (currnode.Childs[index].Equals(default(TrieNode)))
				{
					return false;
				}
				else
				{
					currnode = currnode.Childs[index];
				}

			}
			return true;
		}

		public void Delete(string key)
		{
			if (!Delete(key, 0, Root))
			{
				throw new KeyNotFoundException();
			}
			
		}

		private bool Delete(string key,int index,TrieNode currnode)
		{
			if (index == key.Length)
			{
				if (!currnode.Childs.Any(x => !x.Equals(default(TrieNode))))
				{
					currnode = default;
				}
				return true;
			}
			var ch = key[index] - 'a';
			if (!currnode.Childs[ch].Equals(default(TrieNode)))
			{
				if(!Delete(key, index + 1, currnode.Childs[ch]))
				{
					return false;
				}
				if (!currnode.Childs.Any(x => !x.Equals(default(TrieNode))))
				{
					currnode = default;
				}
				return true;
			}
			return false;
		}
	}
}
