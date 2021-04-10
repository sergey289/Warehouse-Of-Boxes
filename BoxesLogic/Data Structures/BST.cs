using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesLogic.Data_Structures
{
    class BST<T> where T : IComparable<T>
    {


        public Node Root { get; set; }

        public void Add(T value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value.CompareTo(after.Data) < 0)  //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value.CompareTo(after.Data) > 0) //Is new node in right tree?
                    after = after.RightNode;

            }

            Node newNode = new Node(value);
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value.CompareTo(before.Data) < 0)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }


        }

        public T Find(T value)
        {
            return this.Find(value, this.Root);
        }

        private T Find(T value, Node parent)
        {
            if (parent != null)
            {
                if (value.CompareTo(parent.Data) == 0) return parent.Data;
                if (value.CompareTo(parent.Data) < 0)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return default(T);
        }

        static T cloossetBigger = default(T);

        public T FindBestMatch(T searchValue, Node parent, out T closserVal)
        {

            closserVal = cloossetBigger;

            if (parent != null)
            {


                if (searchValue.CompareTo(parent.Data) == 0 || searchValue.CompareTo(parent.Data) < 0)
                {
                    cloossetBigger = parent.Data;
                }
                if (searchValue.CompareTo(parent.Data) < 0)
                    return FindBestMatch(searchValue, parent.LeftNode, out closserVal);
                else
                    return FindBestMatch(searchValue, parent.RightNode, out closserVal);
            }

            return default(T);
        }

        public void Remove(T value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Node Remove(Node parent, T key)
        {
            if (parent == null) return parent;

            if (key.CompareTo(parent.Data) < 0) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key.CompareTo(parent.Data) > 0)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private T MinValue(Node node)
        {
            T minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        public void displayTree(Node root)
        {

            Node temp;
            temp = root;

            if (temp == null)
                return;

            displayTree(temp.LeftNode);
            System.Console.Write(temp.Data + "");
            displayTree(temp.RightNode);


        }

        public class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public T Data { get; set; }


            public Node(T Data)
            {
                this.Data = Data;
                LeftNode = null;
                RightNode = null;

            }




        }


    }
}
