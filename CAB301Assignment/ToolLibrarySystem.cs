using System;

namespace Assignment
{
    /// <summary>
    /// Class that plumbs together the other classes and exposes their functions.
    /// </summary>
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

        /// <summary>
        /// Add a new Tool to the selected ToolCollection 
        /// </summary>
        /// <param name="aTool">Tool to be added into the selected ToolCollection.</param>
        public void add(Tool aTool)
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

        /// <summary>
        /// add new pieces of an existing tool to the system
        /// </summary>
        /// <param name="aTool">Unused, tool decision logic is made within the function.</param>
        /// <param name="quantity">Unused, quantity is taken within function.</param>
        public void add(Tool aTool, int quantity)
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection != null)
            {      // List all tools in this category
                if (!printTools(toolCollection))
                    return;
                Console.Write("Choose a tool by its number to increase its quantity - ");
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

        /// <summary>
        /// Adds the passed Member object to the class MemberCollection
        /// </summary>
        /// <param name="aMember">Member to be added.</param>
        public void add(Member aMember)
        {
            members.add(aMember);
        }

        /// <summary>
        /// Has the user choose a tool by filtering through the Categories/Subtypes
        /// Then adds the tool to the members ToolCollection and the member to the 
        /// Tools MemberCollection
        /// </summary>
        /// <param name="aMember">Member who is borrowing the tool</param>
        /// <param name="aTool">Tool that is being borrowed</param>
        public void borrowTool(Member aMember, Tool aTool)
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection != null)
            {
                if (!printTools(toolCollection))
                    return;
                Console.Write("Choose a tool to borrow - ");
                try
                {
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index < 0 || index >= toolCollection.Number)
                        throw new FormatException("No tool at that index");
                    
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

        /// <summary>
        /// Delete the passed tool from a collection.
        /// </summary>
        /// <param name="aTool">Tool to be deleted</param>
        public void delete(Tool aTool) 
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection == null) return;
            toolCollection.delete(aTool);
        }

        /// <summary>
        /// REDUCE TOOL QUANTITY
        /// </summary>
        /// <param name="aTool">Tool to reduce quantity of</param>
        /// <param name="quantity">Quantity to reduce</param>
        public void delete(Tool aTool, int quantity)
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
                Console.Write("\nPlease enter amount to be removed - ");
                quantity = int.Parse(Console.ReadLine());
                if (toolCollection.toArray()[index].AvailableQuantity - quantity < 1)
                {
                    Console.WriteLine("Tools cannot be completely removed from the library");
                    Console.WriteLine("Please ensure remaining available quantity remains above 0.");

                }
                else
                {
                    toolCollection.toArray()[index].Quantity -= quantity;
                    toolCollection.toArray()[index].AvailableQuantity -= quantity;
                    Console.WriteLine("\nSuccess, updated tool details below.");
                    printTool(toolCollection.toArray()[index]);
                    Console.WriteLine("Press enter to return to menu.");
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

        /// <summary>
        /// Remove a member from the membercollection.
        /// </summary>
        /// <param name="aMember">Member to be deleted.</param>
        public void delete(Member aMember)
        {
            members.delete(aMember);
        }

        /// <summary>
        /// Function to display results of listTools.
        /// </summary>
        /// <param name="aMember">Member to search and return tools for</param>
        public void displayBorrowingTools(Member aMember)
        {
            Console.WriteLine("Show tools a member has on loan");
            Console.WriteLine("===============================");
                        
            string[] borrowedTools = listTools(aMember);
            if (borrowedTools == null) return;

            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < borrowedTools.Length; i++)
            {
                Console.WriteLine((i + 1) + ":\t" + borrowedTools[i]);
            }
            Console.WriteLine("\nPress enter to return to menu");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompts user to choose a Category and Sub-Type, then displays 
        /// all tools within that Sub-Type.
        /// </summary>
        /// <param name="aToolType">Unused. Category/Type decision logic is 
        /// within ToolLibrarySystem.</param>
        public void displayTools(string aToolType)
        {
            if (printTools(determineToolCollection())) { 
                Console.WriteLine("Press enter to return to menu");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Displays the top three borrowed tools in the system.
        /// </summary>
        public void displayTopTHree() {
            Console.WriteLine("The three most borrowed Tools:");
            Console.WriteLine("==============================");
            Tool[] arr = getAllTools();
            Tool[] topThree;
            heapSort(arr);
            if (arr.Length > 3)
                topThree = new Tool[3];
            else
                topThree = new Tool[arr.Length];

            for (int i = 0; i < topThree.Length; i++)
            {
                    topThree[i] = arr[i];
            }
            printArray(topThree);
            Console.ReadKey();
        }

        /// <summary>
        /// Returns string[] of the provided Members Tools.
        /// </summary>
        /// <param name="aMember">Member to have their toolCollection printed</param>
        /// <returns>String[] of the provided Members Tools</returns>
        public string[] listTools(Member aMember)
        {
            if (aMember.Tools.Length == 0)
            {
                Console.WriteLine("This member does not have any borrowed tools.");
                Console.WriteLine("\nPress enter to return to menu");
                Console.ReadKey();
                return null;
            }
            else
            {
                Console.WriteLine("\n" + aMember.ToString() + ": Borrowed Tools");
                return aMember.Tools;
            }
        }

        /// <summary>
        /// Called from the Member menu when user selects Return tool.
        /// Has user choose a category/type, displays their borrowed tools
        /// User chooses tool to return, it is removed from the members ToolCollection
        /// And the tools quantities are updated
        /// </summary>
        /// <param name="aMember">Member returning the tool</param>
        /// <param name="aTool">Tool being returned</param>
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
                for (int i = 0; i < toolCollection.Number; i++)
                {
                    if (toolCollection.toArray()[i].Name == aMember.Tools[selection])
                    {
                        toolCollection.toArray()[i].deleteBorrower(aMember);
                        Console.WriteLine("\nSuccess, tool removed.");
                        Console.WriteLine("Press enter to return to menu.");
                        Console.ReadLine();
                        return;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please type in a tool's number to return it.");
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Searches for the provided tool in the passed toolcollection
        /// returns its index or -1 if it doesnt exist.
        /// </summary>
        /// <param name="aTool">The Tool to search for</param>
        /// <param name="toolCollection">The Tool Collection to be searched</param>
        /// <returns>The resulting index, or -1 if it isnt found</returns>
        private int findToolIndex(Tool aTool, ToolCollection toolCollection)
        {
            for (int i = 0; i < toolCollection.Number; i++)
            {
                if (toolCollection.toArray()[i].Name == aTool.Name)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Utility function to print a Tool.
        /// </summary>
        /// <param name="aTool">The tool to be printed.</param>
        private void printTool(Tool aTool)
        {
            Console.WriteLine("Name:\t\t\t" + aTool.Name);
            Console.WriteLine("Quantity:\t\t" + aTool.Quantity);
            Console.WriteLine("Available Quantity:\t" + aTool.AvailableQuantity);
            Console.WriteLine("No. Borrowings:\t\t" + aTool.NoBorrowings);
            Console.WriteLine("-------------------------------------------");
        }

        /// <summary>
        /// Utility function to print all tools within a ToolCollection
        /// </summary>
        /// <param name="toolCollection">ToolCollection to be iterated through and printed.</param>
        /// <returns>False if no tools exist in passed parameter.</returns>
        private bool printTools(ToolCollection toolCollection)
        {
            if (toolCollection == null) return false;

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
                Console.WriteLine("Number:\t\t\t" + (i + 1));
                printTool(toolCollection.toArray()[i]);
            }
            return true;
        }


        /// <summary>
        /// Comparison based sorting technique using the Tools No.Borrwings member.
        /// Modifies passed array to descending order.
        /// </summary>
        /// <param name="allTools">Array to be sorted</param>
        private void heapSort(Tool[] allTools)
        {
            int n = allTools.Length;
            // Build heap
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(allTools, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end
                Tool temp = allTools[0];
                allTools[0] = allTools[i];
                allTools[i] = temp;
                heapify(allTools, i, 0);
            }
        }

        /// <summary>
        /// To heapify a subtree
        /// </summary>
        /// <param name="arr">The Subtree to be rooted</param>
        /// <param name="heapSize">The size of the heap</param>
        /// <param name="rootNode">The rooted node</param>
        private void heapify(Tool[] arr, int heapSize, int rootNode)
        {
            int smallest = rootNode;
            int l = 2 * rootNode + 1;
            int r = 2 * rootNode + 2;

            if (l < heapSize && arr[l].NoBorrowings < arr[smallest].NoBorrowings) 
                smallest = l;

            if (r < heapSize && arr[r].NoBorrowings < arr[smallest].NoBorrowings) 
                smallest = r;

            if (smallest != rootNode)
            {
                Tool swap = arr[rootNode];
                arr[rootNode] = arr[smallest];
                arr[smallest] = swap;
                heapify(arr, heapSize, smallest);
            }
        }

        /// <summary>
        /// A utility function to print a Tool array
        /// </summary>
        /// <param name="arr">Tool array to be printed.</param>
        private void printArray(Tool[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                printTool(arr[i]);
        }

        /// <summary>
        /// Takes in a ToolCollection[] and returns in a Tool[] every Tool 
        /// within each ToolCollection element of the array.
        /// </summary>
        /// <param name="category">ToolCollection[] to be returned as Tool[]</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a Tool[] containing every Tool in all of the Categories
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Utility function to return a toolCollection of the users choice
        /// by prompting the Categories and then the selected categories sub-types.
        /// </summary>
        /// <returns></returns>
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
    }
}