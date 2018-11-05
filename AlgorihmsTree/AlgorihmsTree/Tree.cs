using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorihmsTree
{
    class Tree
    {
        int globalID = 1; //increments by 1 anytime a new Node is added so that no id numbers are the same
        List<Node> allNodes = new List<Node>();
        List<Node> baseNodes = new List<Node>();

        public Node GetNodeByID(int InputID)
        {
            foreach (Node n in allNodes)
            {
                if (n.id == InputID)
                {
                    return n;
                }
            }
            return null;
        }

        public List<Node> GetNodesByName(string inputString)
        {
            List<Node> tempNodeList = new List<Node>();
            foreach (Node n in allNodes)
            {
                if (n.DisplayNodeName() == inputString)
                {
                    tempNodeList.Add(n);
                }
            }
            return tempNodeList;
        }

        public void AddNode(string inputName, int inputID)
        {
            
        }

        // ==============================================================================================
        //                                  Tree and Node Creation Functions
        // ==============================================================================================
        public void ConvertStringArrayToTree(string[] inputArray)
        {
            // Takes in string array and defines the baseNodes, and all of the child nodes within
            FillOutNodeList(inputArray);
            AssignParentNodes();


            foreach (Node n in allNodes)
            {
                Console.WriteLine(n.DisplayNodeInfo());
            }

        }

        public void FillOutNodeList(string[] inputArray)
        {

            foreach (string s in inputArray)
            {
                int tempDepth = CountWhitespacesBeforeString(s);
                string tempString = RemoveWhitespacesBeforeString(s);

                Node tempNode = new Node(globalID, tempString, tempDepth);
                allNodes.Add(tempNode);
                globalID++;
            }
        }

        public void AssignParentNodes()
        {
            for (int i = 1; i < allNodes.Count(); i++)
            {
                if (allNodes[i].depth > 0)
                {
                    int parentIndex = FindParent(i, i-1);
                    allNodes[i].SetParentNode(allNodes[parentIndex]);
                }
                else
                {
                    baseNodes.Add(allNodes[i]);
                }
                
            }

        }

        public int FindParent(int inputIndex, int compareIndex)
        {
            if (allNodes[inputIndex].depth <= allNodes[compareIndex].depth) // If This node is not a child (has less or equal depth) to the previous
            {
                return FindParent(inputIndex, compareIndex - 1);
            }
            else // If compareIndex is a parent
            {
                return compareIndex;
            }

        }

        public string RemoveWhitespacesBeforeString(string s)
        {
            string outputString = "";
            char[] tempCharArray = s.ToCharArray();

            for (int j = 0; j < s.Count(); j++)
            {
                if (tempCharArray[j] != '\t' && tempCharArray[j] != ' ')
                {
                    outputString = outputString + tempCharArray[j];
                }
            }

           return outputString;
        }

        public int CountWhitespacesBeforeString(string s)
        {
            int numberOfSpaces = 0;
            char[] tempCharArray = s.ToCharArray();

            for (int j = 0; j < s.Count(); j++)
            {
                if (tempCharArray[j] == '\t') //counts the number of tabs
                {
                    numberOfSpaces += 8;
                }
                else if (tempCharArray[j] == ' ')//counts the number of spaces
                {
                    numberOfSpaces += 1;
                }
                else // Instantly returns the number of spaces when getting a non whitespace character, in case someone has a space in their name
                {
                    return numberOfSpaces;
                }

            }
            return numberOfSpaces;
        }


    }
}
