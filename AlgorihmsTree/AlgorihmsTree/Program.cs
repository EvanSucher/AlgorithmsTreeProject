using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorihmsTree
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            string filePath = "names.tab";
            string[] stringArray;
            Tree nameTree = new Tree();

            stringArray = System.IO.File.ReadAllLines(filePath);

            nameTree.ConvertStringArrayToTree(stringArray);


            do
            {
                printMenu();
                string inputChoice = Console.ReadLine();
                int choice = 0;
                int.TryParse(inputChoice, out choice);

                if (choice > 0 && choice < 7) //If the user enters a valid choice
                {
                    switch(choice)
                    {
                        case 1: //Get Node by ID
                            {
                                Console.WriteLine("\nPlease enter the ID of the Node:");
                                string inputStringID = Console.ReadLine();
                                int inputID = 0;
                                int.TryParse(inputStringID, out inputID);

                                if (inputID > 0) //Valid input
                                {
                                    Node tempNode = nameTree.GetNodeByID(inputID);
                                    if (tempNode != null)
                                    {
                                        string outputString = tempNode.DisplayNodeInfo();
                                        Console.WriteLine("\n" + outputString);

                                        waitToContinue();
                                    }
                                    else
                                    {
                                        errorMessage();
                                    }
                                }
                                else //Invalid Input
                                {
                                    errorMessage();
                                }
                                break;
                            }
                        case 2: //Get Node by Content
                            {
                                Console.WriteLine("\nPlease enter the Content/Name of the Node:");
                                string inputString = Console.ReadLine();
                                List<Node> outputNodes = nameTree.GetNodesByName(inputString);

                                if(outputNodes.Count() > 0) //At least one matching node in the list
                                {
                                    foreach (Node n in outputNodes)
                                    {
                                        string outputString = n.DisplayNodeInfo();
                                        Console.WriteLine("\n" + outputString);
                                    }
                                    waitToContinue();
                                }
                                else //no matching nodes
                                {
                                    errorMessage();
                                }

                                break;
                            }
                        case 3: //Add a Node
                            {
                                Console.WriteLine("\nPlease enter the Content of the Node you want to add:");
                                string inputNameString = Console.ReadLine();

                                Console.WriteLine("\nPlease enter the ID of the Parent Node:");
                                string inputStringID = Console.ReadLine();
                                int inputID = 0;
                                int.TryParse(inputStringID, out inputID);

                                if (inputID > 0)
                                {
                                    Node tempNode = nameTree.GetNodeByID(inputID);
                                    if (tempNode != null)
                                    {
                                        nameTree.AddNode(inputNameString, inputID);
                                        Console.WriteLine("Succesfully added node");

                                        waitToContinue();
                                    }
                                }
                                else
                                {

                                }

                                break;
                            }
                        case 4:
                            {


                                break;
                            }
                        case 5:
                            {


                                break;
                            }
                        case 6:
                            {
                                isRunning = false;

                                break;
                            }
                    }
                        
                }
                else
                {
                    errorMessage();
                }

            } while (isRunning);



            void printMenu()
            {
                Console.WriteLine("\n==Enter a number and press enter to select an option==\n");
                Console.WriteLine("[1] Get Node by ID");
                Console.WriteLine("[2] Get Node by Content");
                Console.WriteLine("[3] Add a Node");
                Console.WriteLine("[4] Move a Node");
                Console.WriteLine("[5] Delete a Node");
                Console.WriteLine("[6] Quit");
            }

            void errorMessage()
            {
                Console.WriteLine("\nError: Invalid Option Entered");
                Console.WriteLine("Please try again to enter an option");
            }

            void waitToContinue()
            {
                Console.WriteLine("\nPress Enter to Continue...");
                Console.ReadLine();
            }

        }

        
    }
}
