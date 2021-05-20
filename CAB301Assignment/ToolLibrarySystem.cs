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
        private Member loggedInMember;

        public ToolLibrarySystem() {
            members = new MemberCollection();
            GardeningTools = new ToolCollection[5];
            for (int i = 0; i < GardeningTools.Length; i++) {
                GardeningTools[i] = new ToolCollection();
            }
            FlooringTools = new ToolCollection[6];
            for (int i = 0; i < FlooringTools.Length; i++) {
                FlooringTools[i] = new ToolCollection();
            }
            FencingTools = new ToolCollection[5];
            for (int i = 0; i < FencingTools.Length; i++) {
                FencingTools[i] = new ToolCollection();
            }
            MeasuringTools = new ToolCollection[6];
            for (int i = 0; i < MeasuringTools.Length; i++) {
                MeasuringTools[i] = new ToolCollection();
            }
            CleaningTools = new ToolCollection[6];
            for (int i = 0; i < CleaningTools.Length; i++) {
                CleaningTools[i] = new ToolCollection();
            }
            PaintingTools = new ToolCollection[6];
            for (int i = 0; i < PaintingTools.Length; i++) {
                PaintingTools[i] = new ToolCollection();
            }
            ElectronicTools = new ToolCollection[5];
            for (int i = 0; i < ElectronicTools.Length; i++) {
                ElectronicTools[i] = new ToolCollection();
            }
            ElectricityTools = new ToolCollection[5];
            for (int i = 0; i < ElectricityTools.Length; i++) {
                ElectricityTools[i] = new ToolCollection();
            }
            AutomotiveTools = new ToolCollection[6];
            for (int i = 0; i < AutomotiveTools.Length; i++) {
                AutomotiveTools[i] = new ToolCollection();
            }
        }
        public void add(Tool aTool) // add a new tool to the system 
        {
            ToolCollection toolCollection = determineToolCollection();
            if (toolCollection != null)
            {       //If the tool already exists in the category, ask for updated quantity
                if (toolCollection.search(aTool)) {
                    Console.WriteLine(aTool.ToString() + " already exists in this Category.");
                    Console.Write("Please specifiy how many " + aTool.Name + " are being added - ");
                    try {
                        int addedQuantity = int.Parse(Console.ReadLine());
                        toolCollection.toArray()[findToolIndex(aTool, toolCollection)].Quantity += addedQuantity;
                        toolCollection.toArray()[findToolIndex(aTool, toolCollection)].AvailableQuantity += addedQuantity;
                    }
                    catch (FormatException) {
                        Console.WriteLine("Please enter a valid quantity");
                        Console.WriteLine("Press enter to return to staff menu.");
                        Console.ReadKey();
                    }
                }
                else{
                    toolCollection.add(aTool);
                }
                Console.WriteLine("\nSuccess! Tool added to the system.");
                printTools(toolCollection);
                Console.WriteLine("Press enter to return to staff menu.");
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
                try {
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index < 0 || index >= toolCollection.Number)
                        throw new FormatException("No tool at that index");

                    Console.Write("\nPlease enter amount to be added - ");
                    int amountAdding = int.Parse(Console.ReadLine());
                    toolCollection.toArray()[index].Quantity += amountAdding;
                    toolCollection.toArray()[index].AvailableQuantity += amountAdding;
                    Console.WriteLine("\nSuccess, updated tool details below.");
                    printTool(toolCollection.toArray()[index]);
                    Console.WriteLine("Press enter to return to staff menu.");
                    Console.ReadKey();
                }
                catch (FormatException e)
                {
                    if (e.Message == "No tool at that index")
                        Console.WriteLine(e.Message);
                    else
                        Console.WriteLine("\nPlease only enter numeric values.");
                    Console.WriteLine("Press enter to return to staff menu.");
                    Console.ReadKey();
                    return;
                }
            }
        }
        public void add(Member aMember) {
            members.add(aMember);
            Console.WriteLine();
            Console.WriteLine("Success! New member created: " + aMember.FirstName + " " + aMember.LastName);
            Console.WriteLine("Press any key to return to staff menu");
            Console.ReadKey();
        }
        public void borrowTool(Member aMember, Tool aTool) {
            aMember = loggedInMember;
            printAllMembers(members);
            determineToolCollection();
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
                    if (toolCollection.toArray()[index].Quantity - amountRemoving < 1) {
                        Console.WriteLine("Tools cannot be completely removed from the library");
                        Console.WriteLine("Please ensure remaining quantity remains above 0.");
                    }
                    else {
                        toolCollection.toArray()[index].Quantity -= amountRemoving;
                        toolCollection.toArray()[index].AvailableQuantity -= amountRemoving;
                        Console.WriteLine("\nSuccess, updated tool details below.");
                        printTool(toolCollection.toArray()[index]);
                        Console.WriteLine("Press enter to return to staff menu.");
                        Console.ReadKey();
                        deleting = false;
                    }
                }
            } catch (FormatException e) {
                if (e.Message == "No tool at that index")
                    Console.WriteLine(e.Message);
                else
                    Console.WriteLine("\nPlease only enter numeric values.");
                Console.WriteLine("Press enter to return to staff menu.");
                Console.ReadKey();
                return;
            }
        }
        public void delete(Member aMember) {
            if (!printAllMembers(members))
                return;
            Console.Write("Please choose member for deletion by number only - ");
            try {
                // Checking to see if selected user has any borrowed tools.
                if (members.toArray()[int.Parse(Console.ReadLine()) - 1].Tools.Length == 0)
                {
                    members.delete(members.toArray()[int.Parse(Console.ReadLine()) - 1]);
                    Console.WriteLine("Success! See new list of members below.");
                    printAllMembers(members);
                } else {
                    Console.WriteLine("That user currently has tools borrowed and cannot be deleted.");
                    Console.WriteLine("Press enter to return to staff menu");
                    Console.ReadKey();
                }
            } catch (Exception) {
                Console.WriteLine("Not a valid choice.");
                Console.WriteLine("Press enter to return to staff menu");
                Console.ReadKey();
            }
        }
        public void displayBorrowingTools(Member aMember) {
            throw new NotImplementedException();
        }
        public void displayTools(string aToolType)
        {
            printTools(determineToolCollection());
            Console.WriteLine("\nPress enter to return to main menu.");
            Console.ReadKey();
        }
        public void displayTopTHree()
        {
            throw new NotImplementedException();
        }
        public string[] listTools(Member aMember)
        {
            if (!printAllMembers(members))
                return null;
            Console.Write("Please choose member to see their borrowed tools - ");
            try {
                int memberIndex = int.Parse(Console.ReadLine()) - 1;
                if (members.toArray()[memberIndex].Tools.Length == 0) {
                    Console.WriteLine("This member does not have any borrowed tools.");
                    Console.WriteLine("Press enter to return to staff menu");
                    Console.ReadKey();
                    return null;
                }
                else {
                    Console.WriteLine("Members borrowed tools");
                    Console.WriteLine("----------------------");
                    Console.WriteLine(members.toArray()[memberIndex].ToString());
                    for (int i = 0; i < members.toArray()[memberIndex].Tools.Length; i++) {
                        Console.WriteLine(i + ":\t" + members.toArray()[memberIndex].Tools[i].ToString());
                    }
                    return null;
                }
            } catch (Exception) {
                Console.WriteLine("Not a valid choice.");
                Console.WriteLine("Press enter to return to staff menu");
                Console.ReadKey();
                return null;
            }
        }
        public void returnTool(Member aMember, Tool aTool)
        {
            throw new NotImplementedException();
        }
        private bool printAllMembers(MemberCollection members)
        {
            if (members.Number > 0) {
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
            else {
                Console.WriteLine("There are currently no registered members.");
                Console.WriteLine("Press enter to return to staff menu.");
                Console.ReadKey();
                return false;
            }
        }
        private int findToolIndex(Tool aTool, ToolCollection toolCollection) {
            for (int i = 0; i < toolCollection.Number; i++) {
                if (toolCollection.toArray()[i].Name == aTool.Name) {
                    return i;
                }
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
                    try {
                        typeInput = int.Parse(Console.ReadLine());
                        if (typeInput == 0)
                            return null;
                        typeInput--;
                        return GardeningTools[typeInput];
                    }
                    catch (FormatException) {
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
        private void printTool(Tool aTool) {
            Console.WriteLine("Name:\t\t\t" + aTool.Name);
            Console.WriteLine("Quantity:\t\t" + aTool.Quantity);
            Console.WriteLine("Available Quantity:\t" + aTool.AvailableQuantity);
            Console.WriteLine("No. Borrowings:\t\t" + aTool.NoBorrowings);
            Console.WriteLine("-------------------------------------------");
        }
        private bool printTools(ToolCollection toolCollection) {
            // Sometimes toolCollection is null when returned from determineToolCollection.
            if (toolCollection == null)
                return false;
            // Check if toolCollection contains any tools.
            else if (toolCollection.Number == 0)
            {
                Console.WriteLine("No tool exisits in that category type.");
                Console.WriteLine("Press enter to return to staff menu.");
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
        private void populateData()
        {
            GardeningTools[0].add(new Tool("Ass"));

        }
    }
}
