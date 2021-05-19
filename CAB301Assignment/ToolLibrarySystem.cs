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
            add(aTool, determineToolCollection());
        }
        private void add(Tool aTool, ToolCollection toolCollection) // add a tool to a specified ToolCollection
        {
            if (toolCollection != null) {
                if (toolCollection.search(aTool)) {
                    Console.WriteLine(aTool.ToString + "already exists in this Category.");
                    Console.Write("Please enter a new );
                }
                toolCollection.add(aTool);
                Console.WriteLine("Success! " + aTool.Name + " added to the system.");
            }
        }   
        public void add(Tool aTool, int quantity) //add new pieces of an existing tool to the system
        {
            throw new NotImplementedException();
        }

        public void add(Member aMember) {
            members.add(aMember);
            Console.WriteLine();
            Console.WriteLine("Success! New member created: " + aMember.FirstName + " " + aMember.LastName);
            Console.WriteLine("Press any key to return to staff menu");
            Console.ReadKey();
        }

        public void borrowTool(Member aMember, Tool aTool) {
            throw new NotImplementedException();
        }

        public void delete(Tool aTool) {
            ToolCollection toolCollection = determineToolCollection();

            // If toolCollection is null, printTools will return false
            if (!printTools(toolCollection))
                return;
            
            Console.Write("Choose a tool to delete - ");
            try {
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index < 0 || index >= toolCollection.Number)
                    throw new FormatException();

                toolCollection.delete(toolCollection.toArray()[index]);
                Console.WriteLine("Press enter to return to staff menu.");
                Console.ReadKey();
                return;
            } catch (FormatException) {
                Console.WriteLine("\nPlease enter a displayed Tool No.");
                Console.WriteLine("Press enter to return to staff menu.");
                Console.ReadKey();
                return;
            }
        }
        public void delete(Tool aTool, int quantity) {
            throw new NotImplementedException();
        }

        public void delete(Member aMember) {
            throw new NotImplementedException();
        }

        public void displayBorrowingTools(Member aMember) {
            throw new NotImplementedException();
        }

        public void displayTools(string aToolType)
        {
            throw new NotImplementedException();
        }

        public void displayTopTHree()
        {
            throw new NotImplementedException();
        }

        public string[] listTools(Member aMember)
        {
            throw new NotImplementedException();
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            throw new NotImplementedException();
        }

        private ToolCollection determineToolCollection()
        {
            Console.WriteLine("Please select the Tool Category");
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
            Console.WriteLine("\n\nPlease select the Tool Type");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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

                    Console.Write("New Tool Type - ");
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
        private bool printTools(ToolCollection toolCollection) {
            if (toolCollection.Number == 0)
            {
                Console.WriteLine("No tool exisits in that category type.");
                Console.WriteLine("Press enter to return to staff menu.");
                Console.ReadKey();
                return false;
            }
            Console.WriteLine("\nTools found in selected category and type:");
            Console.WriteLine("===========================================");
            for (int i = 0; i < toolCollection.Number; i++)
            {
                Console.WriteLine("Tool No:\t\t" + (i + 1));
                Console.WriteLine("Name:\t\t\t" + toolCollection.toArray()[i].Name);
                Console.WriteLine("Quantity:\t\t" + toolCollection.toArray()[i].Quantity);
                Console.WriteLine("Available Quantity:\t" + toolCollection.toArray()[i].AvailableQuantity);
                Console.WriteLine("No. Borrowings:\t\t" + toolColtoolCollection.toArray()[i]lection.NoBorrowings);
                Console.WriteLine("-------------------------------------------");
            }
            return true;
        }
    }
}
