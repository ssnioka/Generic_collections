using System;
using System.Collections.Generic;
using System.Collections;

namespace LABORAS3.Classes
{
    public sealed class LinkList<type> : IEnumerable<type> where type : IComparable<type>, IEquatable<type>
    {
        private Node<type> Start;
        private Node<type> End;
        private Node<type> Node;

        /// <summary>
        /// Creates liked list
        /// </summary>
        public LinkList()
        {
            Start = null;
            End = null;
            Node = null;
        }

        /// <summary>
        /// IEnumerator interface to get all the items from list 
        /// </summary>
        /// <returns>Object from list</returns>

        public IEnumerator<type> GetEnumerator()
        {
            for (Node<type> d1 = Start; d1 != null; d1 = d1.Next)
            {
                yield return d1.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sets beginning of the list
        /// </summary>
        public void Beginning()
        {
            Node = Start;
        }

        /// <summary>
        /// Sets next element in the list
        /// </summary>
        public void Next()
        {
            Node = Node.Next;
        }

        /// <summary>
        /// Checks if element exist in the list 
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return Node != null;
        }

        public type GetData()
        {
            return Node.Data;
        }

        

        /// <summary>
        /// Adds new point in the list
        /// </summary>
        /// <param name="newPoint">Point object</param>
        public void PutDataT(type newPoint)
        {
            var temp = new Node<type>(newPoint, null);
            if (Start != null)
            {
                End.Next = temp;
                End = temp;
            }

            else
            {
                Start = temp;
                End = temp;
            }
        }

        /// <summary>
        /// Sorts list by color and by coordinates in increasing order
        /// </summary>

        public void Sort()
        {
            for (Node<type> d1 = Start; d1 != null; d1 = d1.Next)
            {
                Node<type> minv = d1;
                for (Node<type> d2 = d1; d2 != null; d2 = d2.Next)
                    if (d2.Data.CompareTo(minv.Data) < 0)
                        minv = d2;

                type pt = d1.Data;
                d1.Data = minv.Data;
                minv.Data = pt;

            }
        }

        /// <summary>
        /// Adds all the items from other list to this one
        /// </summary>
        /// <param name="pointList">List of Points</param>
        public void AddList(LinkList<type> pointList)
        {
            for (pointList.Beginning(); pointList.Exist(); pointList.Next())
            {
                var temp = new Node<type>(pointList.GetData(), null);
                if (Start != null)
                {
                    End.Next = temp;
                    End = temp;
                }
                else
                {
                    Start = temp;
                    End = temp;
                }
            }
        }

        /// <summary>
        /// method to get count
        /// </summary>
        /// <returns></returns>
        public int getCount()
        {
            Node<type> temp = Start;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }
        /// <summary>
        /// method to remove a node
        /// </summary>
        /// <param name="resident"></param>
        public void Remove(Node<type> resident)
        {
            Node<type> temp = Start;
            Node<type> prev = null;

            if (temp != null && temp.Get().Equals(resident.Get()))
            {
                Start = temp.Next;
                return;
            }

            while (temp != null && !temp.Get().Equals(resident.Get()))
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
                return;

            prev.Next = temp.Next;
        }

        /// <summary>
        /// to get  anode
        /// </summary>
        /// <returns></returns>
        public Node<type> GetNode()
        {
            return Node;
        }



    }
    public sealed class Node<type> where type : IComparable<type>, IEquatable<type>
    {
        public type Data { get; set; }
        public Node<type> Next { get; set; }

        /// <summary>
        /// Creates new node
        /// </summary>
        /// <param name="value">Object</param>
        /// <param name="link">Link to next object</param>
        public Node(type value, Node<type> link)
        {
            Data = value;
            Next = link;
        }
        public type Get()
        {
            return Data;
        }
    }
}