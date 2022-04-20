using System;
using System.Collections.Generic;

namespace TreeViewApplication
{
    class Program
    {
        public static List<TreeElement> treeView = new List<TreeElement>();
        public static List<TreeElement> traversedTreeView = new List<TreeElement>();
        public static bool hasQuit = false;

        public static void Main(string[] args)
        {

            Code();
          
        }

        public static void Code()
        {

            // Create test data

            Folder newFolder1 = new Folder("Folder1");
            newFolder1.AddElementToContents(new Item("item 1"));
            newFolder1.AddElementToContents(new Item("item 2"));

            Folder newFolder2 = new Folder("Folder2");
            newFolder2.AddElementToContents(new Item("item 3"));
            newFolder1.AddElementToContents(newFolder2);

            Folder newFolder3= new Folder("Folder3");
            newFolder3.AddElementToContents(new Item("item 4"));
            newFolder3.AddElementToContents(new Item("item 5"));

            treeView.Add(newFolder1);
            treeView.Add(newFolder3);

            // Get traversed list of items within treeview
            GetTempTree(treeView);

            // Display all files within the tree
            DisplayTreeView(traversedTreeView);


            while (!hasQuit)
            {
                GetInput();
            }



        }

        static void GetInput()
        {


            Console.Write("\n-->");

            string command;
            string arg1 = null;
            string arg2 = null;

            string input = Console.ReadLine();

            string[] splitInput = input.Split();




            if (splitInput.Length > 2)
            {
                command = splitInput[0];
                arg1 = splitInput[1];
                arg2 = splitInput[2];
            }
            else if (splitInput.Length > 1)
            {
                command = splitInput[0];
                arg1 = splitInput[1];
            }
            else
            {
                command = splitInput[0];
            }

            switch (command)
            {
                case "goto":
                    EnterFolder(Convert.ToInt32(arg1));
                    break;
                case "search":
                    SearchForFile(arg1);
                    break;
                case "root":
                    GoToRoot();
                    break;
                case "move":
                    MoveTreeElement(Convert.ToInt32(arg1), Convert.ToInt32(arg2));
                    break;
                default:
                    Console.WriteLine("Error. Command not recognised.");
                    break;
            }

        }


        static void GetTempTree(List<TreeElement> treeViewList)
        {
            List<TreeElement> tempList = new List<TreeElement>();

            for (int x = 0; x < treeViewList.Count; x++)
            {
                if (treeViewList[x] is Folder f)
                {
                    tempList.Add(f);

                    var result = f.GetNodes();

                    tempList.AddRange(result);

                }
                else
                {
                    tempList.Add(treeViewList[x]);
                }
            }

            traversedTreeView = tempList;

        }

        static void GoToRoot()
        {
            GetTempTree(treeView);
            DisplayTreeView(traversedTreeView);
            
            
        }

        static void SearchForFile(string query)
        {
            GetTempTree(treeView);
            List<TreeElement> foundItems = new List<TreeElement>();

            for (int i = traversedTreeView.Count - 1; i >= 0; i--)
            {
                if (traversedTreeView[i].name.ToLower().Contains(query.ToLower()))
                {
                    foundItems.Add(traversedTreeView[i]);
                }
            }

            if (foundItems.Count > 0)
            {
                foreach(var item in foundItems)
                {
                    Console.WriteLine(item.name);
                }
            }
        }

        static void DisplayTreeView(List<TreeElement> treeViewList)
        {

            Console.Clear();
            for (int i = 0; i < traversedTreeView.Count; i++)
            {
                Console.Write(i);
                if (treeViewList[i] is Folder f)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Folder:" + f.name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Item: " + traversedTreeView[i].name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

           
        }

        static void MoveTreeElement(int initialItemPostion, int targetFolderIndex)
        {

            if (traversedTreeView[targetFolderIndex] is Folder f)
            {
                f.AddElementToContents(traversedTreeView[initialItemPostion]);
                traversedTreeView.RemoveAt(initialItemPostion);
            }
            else
            {
                Console.WriteLine("Target destination is not a folder.");
            }
        }

        static void EnterFolder(int index)
        {
            if (traversedTreeView[index] is Folder f)
            {
                traversedTreeView = f.ReturnContents();
                DisplayTreeView(traversedTreeView);
            }
            else
            {
                Console.WriteLine("Target destination is not a folder.");
            }

            Console.Clear();
            DisplayTreeView(traversedTreeView);
        }
        

    }
}
