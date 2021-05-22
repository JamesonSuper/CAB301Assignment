using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private MemberCollection members;
        private ToolCollection[] GardeningTools;
        private ToolCollection[] FlooringTools;
        private ToolCollection[] FencingTools;
        private ToolCollection[] MeasuringTools;
        private ToolCollection[] CleaningTools;
        private ToolCollection[] PaintingTools;
        private ToolCollection[] ElectronicTools;
        private ToolCollection[] ElectricityTools;
        private ToolCollection[] AutomotiveTools;

        public ToolLibrarySystem()
        {
            members = new MemberCollection();
            GardeningTools = new ToolCollection[5];
            for (int i = 0; i < GardeningTools.Length; i++)
            {
                GardeningTools[i] = new ToolCollection();
            }
            FlooringTools = new ToolCollection[6];
            for (int i = 0; i < FlooringTools.Length; i++)
            {
                FlooringTools[i] = new ToolCollection();
            }
            FencingTools = new ToolCollection[5];
            for (int i = 0; i < FencingTools.Length; i++)
            {
                FencingTools[i] = new ToolCollection();
            }
            MeasuringTools = new ToolCollection[6];
            for (int i = 0; i < MeasuringTools.Length; i++)
            {
                MeasuringTools[i] = new ToolCollection();
            }
            CleaningTools = new ToolCollection[6];
            for (int i = 0; i < CleaningTools.Length; i++)
            {
                CleaningTools[i] = new ToolCollection();
            }
            PaintingTools = new ToolCollection[6];
            for (int i = 0; i < PaintingTools.Length; i++)
            {
                PaintingTools[i] = new ToolCollection();
            }
            ElectronicTools = new ToolCollection[5];
            for (int i = 0; i < ElectronicTools.Length; i++)
            {
                ElectronicTools[i] = new ToolCollection();
            }
            ElectricityTools = new ToolCollection[5];
            for (int i = 0; i < ElectricityTools.Length; i++)
            {
                ElectricityTools[i] = new ToolCollection();
            }
            AutomotiveTools = new ToolCollection[6];
            for (int i = 0; i < AutomotiveTools.Length; i++)
            {
                AutomotiveTools[i] = new ToolCollection();
            }
        }
        public void add(Tool aTool) // add a new tool to the system 
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection != null)
            {       //If the tool already exists in the category, ask for updated quantity
                if (toolCollection.search(aTool))
                {
                    Console.WriteLine(aTool.Name + " already exists in this Category.");
                    Console.Write("Please specifiy how many " + aTool.Name + " are being added - ");
                    try
                    {
                        int addedQuantity = int.Parse(Console.ReadLine());
                        toolCollection.toArray()[findToolIndex(aTool, toolCollection)].Quantity += addedQuantity;
                        toolCollection.toArray()[findToolIndex(aTool, toolCollection)].AvailableQuantity += addedQuantity;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid quantity.");
                        Console.WriteLine("Press enter to return to menu.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    toolCollection.add(aTool);
                }
                Console.WriteLine("\nSuccess! Tool added to the system.");
                printTools(toolCollection);
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
            }
        }
        public void add(Tool aTool, int quantity) //add new pieces of an existing tool to the system
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection != null)
            {      // List all tools in this category
                if (!printTools(toolCollection))
                    return;
                Console.Write("Choose a tool to increase its quantity - ");
                try
                {
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index < 0 || index >= toolCollection.Number)
                        throw new FormatException("No tool at that index");

                    Console.Write("\nPlease enter amount to be added - ");
                    int amountAdding = int.Parse(Console.ReadLine());
                    toolCollection.toArray()[index].Quantity += amountAdding;
                    toolCollection.toArray()[index].AvailableQuantity += amountAdding;
                    Console.WriteLine("\nSuccess, updated tool details below.");
                    printTool(toolCollection.toArray()[index]);
                    Console.WriteLine("Press enter to return to menu.");
                    Console.ReadKey();
                }
                catch (FormatException e)
                {
                    if (e.Message == "No tool at that index")
                        Console.WriteLine(e.Message);
                    else
                        Console.WriteLine("\nPlease only enter numeric values.");
                    Console.WriteLine("Press enter to return to menu.");
                    Console.ReadKey();
                    return;
                }
            }
        }
        public void add(Member aMember)
        {
            members.add(aMember);
        }
        public void borrowTool(Member aMember, Tool aTool)
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection != null)
            {      // List all tools in this category
                if (!printTools(toolCollection))
                    return;
                Console.Write("Choose a tool to borrow - ");
                try
                {
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index < 0 || index >= toolCollection.Number)
                        throw new FormatException("No tool at that index");
                    // If the tool has available quantity
                    if (toolCollection.toArray()[index].AvailableQuantity > 0)
                    {
                        try
                        {
                            toolCollection.toArray()[index].addBorrower(aMember);
                            Console.WriteLine("Tool borrowed successfuly.");
                            Console.WriteLine("Please see your updated list of tools below");
                            for (int i = 0; i < aMember.Tools.Length; i++)
                            {
                                Console.WriteLine(aMember.Tools[i]);
                            }
                            Console.WriteLine("Press enter to return to Member menu.");
                            Console.ReadKey();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("You already have 3 tools borrowed, return one first to borrow another.");
                            Console.WriteLine("Press enter to return to menu.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("That tool is fully booked out."); 
                        Console.WriteLine("Press enter to return to Member menu.");
                        Console.ReadKey();
                    }
                }
                catch (FormatException e)
                {
                    if (e.Message == "No tool at that index")
                        Console.WriteLine(e.Message);
                    else
                        Console.WriteLine("\nPlease only enter numeric values.");
                    Console.WriteLine("Press enter to return to menu.");
                    Console.ReadKey();
                    return;
                }
            }
        }
        public void delete(Tool aTool) // DELETE TOOL FROM COLLECTION
        {

        }
        public void delete(Tool aTool, int quantity) // REDUCE TOOL QUANTITY
        {
            // Prompts the user to choose a category and type, then returns that toolcollection
            ToolCollection toolCollection = determineToolCollection();

            // If toolCollection is null, printTools will return false
            if (!printTools(toolCollection))
                return;

            Console.Write("Choose a tool to reduce quantity - ");
            try
            {
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index < 0 || index >= toolCollection.Number)
                    throw new FormatException("No tool at that index");
                bool deleting = true;
                while (deleting)
                {
                    Console.Write("\nPlease enter amount to be removed - ");
                    int amountRemoving = int.Parse(Console.ReadLine());
                    if (toolCollection.toArray()[index].Quantity - amountRemoving < 1)
                    {
                        Console.WriteLine("Tools cannot be completely removed from the library");
                        Console.WriteLine("Please ensure remaining quantity remains above 0.");
                    }
                    else
                    {
                        toolCollection.toArray()[index].Quantity -= amountRemoving;
                        toolCollection.toArray()[index].AvailableQuantity -= amountRemoving;
                        Console.WriteLine("\nSuccess, updated tool details below.");
                        printTool(toolCollection.toArray()[index]);
                        Console.WriteLine("Press enter to return to menu.");
                        Console.ReadKey();
                        deleting = false;
                    }
                }
            }
            catch (FormatException e)
            {
                if (e.Message == "No tool at that index")
                    Console.WriteLine(e.Message);
                else
                    Console.WriteLine("\nPlease only enter numeric values.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return;
            }
        }
        public void delete(Member aMember)
        {
            members.delete(aMember);
        }
        public void displayBorrowingTools(Member aMember)
        {
            throw new NotImplementedException();
        }
        public void displayTools(string aToolType)
        {
            printTools(determineToolCollection());
            Console.WriteLine("\nPress enter to return to main menu.");
            Console.ReadKey();
        }
        public void displayTopTHree() {
            //GardeningTools[0].add(new Tool("12"));
            //ElectronicTools[0].add(new Tool("11"));
            //ElectricityTools[0].add(new Tool("21"));
            //FlooringTools[0].add(new Tool("310"));

            //GardeningTools[0].toArray()[0].NoBorrowings = 12;
            //ElectronicTools[0].toArray()[0].NoBorrowings = 11;
            //ElectricityTools[0].toArray()[0].NoBorrowings = 21;
            //FlooringTools[0].toArray()[0].NoBorrowings = 310;
            
            //GardeningTools[1].add(new Tool("1"));
            //ElectronicTools[1].add(new Tool("123456"));
            //ElectricityTools[1].add(new Tool("12345"));
            //FlooringTools[1].add(new Tool("52"));

            //GardeningTools[1].toArray()[0].NoBorrowings = 1;
            //ElectronicTools[1].toArray()[0].NoBorrowings = 123456;
            //ElectricityTools[1].toArray()[0].NoBorrowings = 12345;
            //FlooringTools[1].toArray()[0].NoBorrowings = 52;

            heapSort(getAllTools());

            printArray(getAllTools());

            Console.ReadKey();
            // heapSort(determineBorrowCounts());
        }
        public string[] listTools(Member aMember)
        {
            Member memberToCheck = aMember;
            // If the member passed in was null (Happens when option is select from staff menu)
            // Then ask user to choose a user to see their borrowed tools.
            if (aMember == null) {
                if (!printAllMembers(members)) return null; // Member collection could be empty, if so, return null.
                Console.Write("Please choose member to see their borrowed tools - ");
                try
                {
                    memberToCheck = members.toArray()[int.Parse(Console.ReadLine()) - 1];
                } catch (FormatException) {
                    Console.WriteLine("Not a valid choice.");
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadKey();
                    return null;
                }
            }
            // Check selected members toolCollection length to see if they have any borrowed tools
            if (memberToCheck.Tools.Length == 0)
            {
                Console.WriteLine("This member does not have any borrowed tools.");
                Console.WriteLine("\nPress enter to return to menu");
                Console.ReadKey();
                return null;
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine(memberToCheck.ToString() + ": Borrowed Tools");
                Console.WriteLine("--------------------------------------");
                for (int i = 0; i < memberToCheck.Tools.Length; i++)
                {
                    Console.WriteLine((i+1) + ":\t" + memberToCheck.Tools[i]);
                }
                Console.WriteLine("\nPress enter to return to menu");
                Console.ReadKey();
                return null;
            }
        }
        /// <summary>
        /// Called from the Member menu when user selects Return tool.
        /// Has user choose a category/type, displays their borrowed tools
        /// User chooses tool to return, it is removed from the members ToolCollection
        /// And the tools quantities are updated
        /// </summary>
        /// <param name="aMember"></param>
        /// <param name="aTool"></param>
        public void returnTool(Member aMember, Tool aTool)
        {
            Console.WriteLine("To return a tool, please select its category and type:");
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection == null)     return;
            Console.WriteLine("\nBorrowed tools from selected category and type:");
            int toolCounter = 0;
            for (int i = 0; i < aMember.Tools.Length; i++)
            {
                if (toolCollection.search(new Tool(aMember.Tools[i])))
                {
                    Console.WriteLine((i + 1) + ": " + aMember.Tools[i]);
                    toolCounter++;
                }
            }
            if (toolCounter == 0)
            {
                Console.WriteLine("You have no borrowed tools from the selected category.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadLine();
                return;
            }
            Console.Write("Please select a tool to return it - ");
            try
            {
                int selection = int.Parse(Console.ReadLine()) - 1;
                for (int i = 0; i < toolCollection.toArray().Length; i++)
                {
                    if (toolCollection.toArray()[i].Name == aMember.Tools[selection])
                        toolCollection.toArray()[i].deleteBorrower(aMember);
                }
                Console.WriteLine("\nSuccess, tool removed.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Please type in a tool's number to return it.");
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }
        private bool printAllMembers(MemberCollection members)
        {
            if (members.Number > 0)
            {
                Console.WriteLine("Current Members");
                Console.WriteLine("=========================");
                for (int i = 0; i < members.Number; i++)
                {
                    Console.WriteLine("Member No. " + (i + 1));
                    Console.WriteLine("FirstName:\t" + members.toArray()[i].FirstName);
                    Console.WriteLine("LastName:\t" + members.toArray()[i].LastName);
                    Console.WriteLine("ContactNumber:\t" + members.toArray()[i].ContactNumber);
                    Console.WriteLine("-------------------------");
                }
                return true;
            }
            else
            {
                Console.WriteLine("There are currently no registered members.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return false;
            }
        }
        private int findToolIndex(Tool aTool, ToolCollection toolCollection)
        {
            for (int i = 0; i < toolCollection.Number; i++)
            {
                if (toolCollection.toArray()[i].Name == aTool.Name)
                    return i;
            }
            return -1;
        }
        private ToolCollection determineToolCollection()
        {
            Console.WriteLine("\nPlease select the Tool Category");
            Console.WriteLine("===============================");
            Console.WriteLine("1 - Gardening tools");
            Console.WriteLine("2 - Flooring tools");
            Console.WriteLine("3 - Fencing tools");
            Console.WriteLine("4 - Measuring tools");
            Console.WriteLine("5 - Cleaning tools");
            Console.WriteLine("6 - Painting tools");
            Console.WriteLine("7 - Electronic tools");
            Console.WriteLine("8 - Electricity tools");
            Console.WriteLine("9 - Automotive tools");
            Console.WriteLine("0 - Cancel and return to main menu\n");

            Console.Write("Tool Category - ");
            string categoryInput = Console.ReadLine();
            int typeInput;
            Console.WriteLine("\nPlease select Tool Type");
            Console.WriteLine("===========================");
            switch (categoryInput)
            {
                case "1":
                    Console.WriteLine("1 - Line Trimmers");
                    Console.WriteLine("2 - Lawn Mowers");
                    Console.WriteLine("3 - Hand Tools");
                    Console.WriteLine("4 - Wheelbarrows");
                    Console.WriteLine("5 - Garden Power Tools");
                    Console.WriteLine("0 - Cancel and return to main menu\n");
                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return GardeningTools[typeInput];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }

                case "2":
                    Console.WriteLine("1 - Scrapers");
                    Console.WriteLine("2 - Floor Lasers");
                    Console.WriteLine("3 - Floor Levelling Tools");
                    Console.WriteLine("4 - Floor Levelling Materials");
                    Console.WriteLine("5 - Floor Hand Tools");
                    Console.WriteLine("6 - Tiling Tools");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return FlooringTools[typeInput];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "3":
                    Console.WriteLine("1 - Hand Tools");
                    Console.WriteLine("2 - Electric Fencing");
                    Console.WriteLine("3 - Steel Fencing Tools");
                    Console.WriteLine("4 - Power Tools");
                    Console.WriteLine("5 - Fencing Accessories");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return FencingTools[typeInput];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "4":
                    Console.WriteLine("1 - Distance Tools");
                    Console.WriteLine("2 - Laser Measurer");
                    Console.WriteLine("3 - Measuring Jugs");
                    Console.WriteLine("4 - Temperature & Humidity Tools");
                    Console.WriteLine("5 - Levelling Tools");
                    Console.WriteLine("6 - Markers");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return MeasuringTools[typeInput];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "5":
                    Console.WriteLine("1 - Draining");
                    Console.WriteLine("2 - Car Cleaning");
                    Console.WriteLine("3 - Vacuum");
                    Console.WriteLine("4 - Pressure Cleaners");
                    Console.WriteLine("5 - Pool Cleaning");
                    Console.WriteLine("6 - Floor Cleaning");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return CleaningTools[typeInput];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "6":
                    Console.WriteLine("1 - Sanding Tools");
                    Console.WriteLine("2 - Brushes");
                    Console.WriteLine("3 - Rollers");
                    Console.WriteLine("4 - Paint Removal Tools");
                    Console.WriteLine("5 - Paint Scrapers");
                    Console.WriteLine("6 - Sprayers");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return PaintingTools[typeInput];

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "7":
                    Console.WriteLine("1 - Voltage Tester");
                    Console.WriteLine("2 - Oscilloscopes");
                    Console.WriteLine("3 - Thermal Imaging");
                    Console.WriteLine("4 - Data Test Tool");
                    Console.WriteLine("5 - Insulation Testers");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return ElectronicTools[typeInput];

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "8":
                    Console.WriteLine("1 - Test Equipment");
                    Console.WriteLine("2 - Safety Equipment");
                    Console.WriteLine("3 - Basic Hand tools");
                    Console.WriteLine("4 - Circuit Protection");
                    Console.WriteLine("5 - Cable Tools");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return ElectricityTools[typeInput];

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.\n\n");
                        return determineToolCollection();
                    }
                case "9":
                    Console.WriteLine("1 - Jacks");
                    Console.WriteLine("2 - Air Compressors");
                    Console.WriteLine("3 - Battery Chargers");
                    Console.WriteLine("4 - Socket Tools");
                    Console.WriteLine("5 - Braking");
                    Console.WriteLine("6 - Drivetrain");
                    Console.WriteLine("0 - Cancel and return to main menu\n");

                    Console.Write("Tool Type - ");
                    try
                    {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return AutomotiveTools[typeInput];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid menu opton as a number.");
                        return determineToolCollection();
                    }
                case "0":
                    return null;
                default:
                    Console.WriteLine("Please enter a valid menu option.");
                    Console.WriteLine("Press enter to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    return determineToolCollection();
            }
        }
        private void printTool(Tool aTool)
        {
            Console.WriteLine("Name:\t\t\t" + aTool.Name);
            Console.WriteLine("Quantity:\t\t" + aTool.Quantity);
            Console.WriteLine("Available Quantity:\t" + aTool.AvailableQuantity);
            Console.WriteLine("No. Borrowings:\t\t" + aTool.NoBorrowings);
            Console.WriteLine("-------------------------------------------");
        }
        private bool printTools(ToolCollection toolCollection)
        {
            // Sometimes toolCollection is null when returned from determineToolCollection.
            if (toolCollection == null)
                return false;
            // Check if toolCollection contains any tools.
            else if (toolCollection.Number == 0)
            {
                Console.WriteLine("No tool exisits in that category type.");
                Console.WriteLine("Press enter to return to menu.");
                Console.ReadKey();
                return false;
            }
            Console.WriteLine("\nTools in selected category type:");
            Console.WriteLine("===========================================");
            for (int i = 0; i < toolCollection.Number; i++)
            {
                Console.WriteLine("Tool No:\t\t" + (i + 1));
                Console.WriteLine("Name:\t\t\t" + toolCollection.toArray()[i].Name);
                Console.WriteLine("Quantity:\t\t" + toolCollection.toArray()[i].Quantity);
                Console.WriteLine("Available Quantity:\t" + toolCollection.toArray()[i].AvailableQuantity);
                Console.WriteLine("No. Borrowings:\t\t" + toolCollection.toArray()[i].NoBorrowings);
                Console.WriteLine("-------------------------------------------");
            }
            return true;
        }


        // figure out a way to keep track of borrow counts and tool names simultaneously here.
        // you may want to change the parameter back to int[] but my guess is you want to pass in tool so you have access to both borrow counts 
        // as well as tool name.
        //if you leave it as int[] you'll have to compare the largest 3 numbers produced by the sort to the ALL TOOLS array borrow counts in order to find their names.
        // Young James, the choice is yours.
        public void heapSort(Tool[] allTools)
        {
            int n = allTools.Length;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(allTools, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                Tool temp = allTools[0];
                allTools[0] = allTools[i];
                allTools[i] = temp;

                // call max heapify on the reduced heap
                heapify(allTools, i, 0);
            }
            Console.WriteLine(allTools[0]);
            Console.WriteLine(allTools[1]);
            Console.WriteLine(allTools[2]);
            Console.WriteLine(allTools[3]);
            Console.WriteLine(allTools[4]);
            Console.WriteLine(allTools[5]);
            Console.WriteLine(allTools[6]);
            Console.WriteLine(allTools[7]);
        }

        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        void heapify(Tool[] arr, int heapSize, int rootNode)
        {
            int largest = rootNode; // Initialize largest as root
            int l = 2 * rootNode + 1; // left = 2*i + 1
            int r = 2 * rootNode + 2; // right = 2*i + 2

            // If left child is larger than root
            if (l < heapSize && arr[l].NoBorrowings > arr[largest].NoBorrowings)
                largest = l;

            // If right child is larger than largest so far
            if (r < heapSize && arr[r].NoBorrowings > arr[largest].NoBorrowings)
                largest = r;

            // If largest is not root
            if (largest != rootNode)
            {
                Tool swap = arr[rootNode];
                arr[rootNode] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree
                heapify(arr, heapSize, largest);
            }
        }
        /* A utility function to print array*/
        static void printArray(Tool[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i].Name + " " + arr[i].NoBorrowings);
        }
        private Tool[] getAllToolsInCategory(ToolCollection[] category)
        {
            int totalTool = 0;
            for (int k = 0; k < category.Length; k++) {
                totalTool += category[k].Number;
            }
            Tool[] categoryTools = new Tool[totalTool];
            int index = 0;
            for (int i = 0; i < category.Length; i++) {
                Tool[] subCategoryTools = category[i].toArray();
                for (int j = 0; j < subCategoryTools.Length; j++) {
                    categoryTools[index] = subCategoryTools[j];
                    index++;
                }
            }
            return categoryTools;
        }

        // you can now iterate over allTools and retrive the numberOfBorrows for each tool. 
        // this feels like it oculd be done a lot nicer.
        // if you are allowed to use an ARRAY LIST instead, please do.
        private Tool[] getAllTools()
        {
            Tool[] gardeningTools = getAllToolsInCategory(GardeningTools);
            Tool[] flooringTools = getAllToolsInCategory(FlooringTools);
            Tool[] fencingTools = getAllToolsInCategory(FencingTools);
            Tool[] measuringTools = getAllToolsInCategory(MeasuringTools);
            Tool[] cleaningTools = getAllToolsInCategory(CleaningTools);
            Tool[] paintingTools = getAllToolsInCategory(PaintingTools);
            Tool[] electronicTools = getAllToolsInCategory(ElectronicTools);
            Tool[] electricityTools = getAllToolsInCategory(ElectricityTools);
            Tool[] automotiveTools = getAllToolsInCategory(AutomotiveTools);

            int allToolsCount = gardeningTools.Length;
            allToolsCount += flooringTools.Length;
            allToolsCount += fencingTools.Length;
            allToolsCount += measuringTools.Length;
            allToolsCount += cleaningTools.Length;
            allToolsCount += paintingTools.Length;
            allToolsCount += electronicTools.Length;
            allToolsCount += electricityTools.Length;
            allToolsCount += automotiveTools.Length;

            Tool[] allTools = new Tool[allToolsCount]; 
            int index = 0;
            for (int i = 0; i < gardeningTools.Length; i++)
            {
                allTools[index] = gardeningTools[i];
                index++;
            }
            for (int i = 0; i < flooringTools.Length; i++)
            {
                allTools[index] = flooringTools[i];
                index++;
            }
            for (int i = 0; i < fencingTools.Length; i++)
            {
                allTools[index] = fencingTools[i];
                index++;
            }
            for (int i = 0; i < measuringTools.Length; i++)
            {
                allTools[index] = measuringTools[i];
                index++;
            }
            for (int i = 0; i < cleaningTools.Length; i++)
            {
                allTools[index] = cleaningTools[i];
                index++;
            }
            for (int i = 0; i < paintingTools.Length; i++)
            {
                allTools[index] = paintingTools[i];
                index++;
            }
            for (int i = 0; i < electronicTools.Length; i++)
            {
                allTools[index] = electronicTools[i];
                index++;
            }
            for (int i = 0; i < electricityTools.Length; i++)
            {
                allTools[index] = electricityTools[i];
                index++;
            }
            for (int i = 0; i < automotiveTools.Length; i++)
            {
                allTools[index] = automotiveTools[i];
                index++;
            }
            return allTools;
        }
    }
}