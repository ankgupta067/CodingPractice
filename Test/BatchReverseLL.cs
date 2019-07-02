using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	public class LLNode
	{
		public int Data { get; set; }

		public LLNode Next { get; set; }
		public LLNode(int data)
		{
			Data = data;
		}
	}
	class BatchReverseLL
	{
		public void Init()
		{
			var ll = new LLNode(1) {
				Next = new LLNode(2)
				{
					Next = new LLNode(2)
					{
						Next = new LLNode(4)
						{
							Next = new LLNode(5)
							{
								Next = new LLNode(6)
								{
									Next = new LLNode(7)
									{
										Next = new LLNode(8)
									}
								}
							}
						}
					}
				}
			};
			var head = ReverseInBatch(ll,2);
			while (head != null)
			{
				Console.WriteLine(head.Data);
				head = head.Next;
			}

		}

		private LLNode ReverseInBatch(LLNode ll, int k)
		{
			int nk = k - 1;
			LLNode prevhead = ll;
			LLNode prevhead2 = null;
			LLNode prev = null, curr = ll, next = ll.Next,head = null;
			while (next != null)
			{
				if (nk == 0)
				{
					if (prevhead2 == null)
					{
						prevhead2 = next;
						head = curr;
					}
					else
					{
						prevhead.Next = curr;
						prevhead = prevhead2;
						prevhead2 = next;					
					}
					nk = k-1;
					prev = null;
					curr = next;
					next = next.Next;
					curr.Next = prev;
				}
				else
				{
					prev = curr;
					curr = next;
					next = next.Next;
					curr.Next = prev;
					nk--;
				}

			}
			if (prevhead != curr)
			{
				prevhead.Next = curr;
			}
			return head;
		}
	}
}
