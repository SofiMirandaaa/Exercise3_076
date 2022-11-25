﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_076
{
    class Node
    {
        /*create Nodes for the circular nexted list*/
        public int rollNumber;
        public int studentnum;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.studentnum = nim;
            newNode.name = nm;

            //check if the list empty
            if (LAST == null || nim <= LAST.studentnum)
            {
                if ((LAST != null) && (nim == LAST.studentnum))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = LAST;
                if (LAST != null)
                    LAST.next = newNode;
                newNode.next = null;
                LAST = newNode;
                return;
            }
            /*if the node is to be inserted at between two node*/
            Node previous, current;
            for (current = previous = LAST;
                 current != null && nim >= current.studentnum;
                 previous = current, current = current.next)
            {
                if (nim == current.studentnum)
                {
                    Console.WriteLine("\nDuplicate numbers not allowed");
                }
            }
            /* On the execution of the above for loop, prev and
             * current will point to those nodes
             * between which the new nod is to be inserted */
            newNode.next = current;

            //if the node is to be inserted at the end of the list 
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            previous.next = newNode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); /*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false); /*returns false if the node is not found*/
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            //the begining of data 
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node between two nodes in the list
            if (current == LAST)
            {
                LAST = LAST.next;
                if (LAST != null)
                    LAST.next = null;
                return true;
            }

            /* if the to be deleted is in between the list then the following lines of is executed. */
            previous.next = current.next;
            current.next = previous;
            return true;
        }
    }
    
}
