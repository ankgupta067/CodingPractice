using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class DjikstraNode
    {
        public int Data;
        public DjikstraNode LeftNode;
        public DjikstraNode RightNode;
    }
    public class BinaryTree
    {
        public DjikstraNode Root;

        public bool Search(int data)
        {
            return Search(data, Root);
        }

        private bool Search(int data, DjikstraNode node)
        {
            if (node == null)
            {
                return false;
            }
            if (data == node.Data)
            {
                return true;
            }
            else if (data < node.Data)
            {
                return Search(data, node.LeftNode);
            }
            else
            {
                return Search(data, node.RightNode);
            }
        }
        public void Insert(int data)
        {
            if (Root == null)
            {
                Root = new DjikstraNode() { Data = data };
            }
            else
            {
                Insert(data, Root);
            }
            
        }
        private void Insert(int data,DjikstraNode node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Data < data)
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new DjikstraNode() { Data = data };
                }
                else
                {
                    Insert(data, node.RightNode);
                }

            }
            else if (node.Data > data)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new DjikstraNode() { Data = data };
                }
                else
                {
                    Insert(data, node.LeftNode);
                }
            }
            else
            {
                var tmp = node.RightNode;
                node.RightNode = new DjikstraNode() { Data = data };
                node.RightNode.RightNode = tmp;
            }
        }

        public void Delete(int data)
        {
            Delete(data, Root);
        }

        private void Delete(int data,DjikstraNode node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Data == data)
            {
                if (node.LeftNode == null && node.RightNode == null)
                {
                    node = null;
                }
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node = node.LeftNode;
                }

                else if (node.RightNode != null && node.LeftNode == null)
                {
                    node = node.RightNode;
                }
                else
                {
                    var currnode = node.RightNode;
                    var prevnode = node;
                    while(currnode.LeftNode != null)
                    {
                        prevnode = currnode;
                        currnode = currnode.LeftNode;
                    }
                    if (currnode.RightNode == null)
                    {
                        node.Data = currnode.Data;
                        currnode = null;
                    }
                    else
                    {
                        node.Data = currnode.Data;
                        prevnode.LeftNode = currnode.RightNode;
                        currnode = null;
                    }
                }
            }

        }
    }
}
