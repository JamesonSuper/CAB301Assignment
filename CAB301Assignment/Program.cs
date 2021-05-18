using System;

namespace CAB301Assignment
{
    class Program
    {
        static void Main(string[] args) {
            initialiseVariables();
            while (true) {
                drawMainMenu();
                switch (Console.ReadLine()) {
                    case "1":
                        if (staffAuthentication())
                        {
                            bool staffLoggedIn = true;
                            while (staffLoggedIn) { 
                                drawStaffMenu();
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        // Add a new tool
                                        Console.WriteLine();
                                        break;
                                    case "2":
                                        // Add new pieces of existing tool (Update quantity)
                                        Console.WriteLine();
                                        break;
                                    case "3":
                                        // Remove some pieves of existing tool (Update quantity)
                                        Console.WriteLine();
                                        break;
                                    case "4": // Register a new member
                                        addMemberMenu();
                                        break;
                                    case "5":
                                        // Remove a member
                                        Console.WriteLine();
                                        break;
                                    case "6":
                                        // Show tools member has on loan
                                        Console.WriteLine();
                                        break;
                                    case "0":
                                        staffLoggedIn = false;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid menu option");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                        }
                        else {
                            Console.Clear();
                            Console.WriteLine("Incorrect details entered, please try again.");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        if (memberAuthenticated()) {
                            drawMemberMenu();
                            switch (Console.ReadLine()) {
                                case "1":
                                    // Display Tools by Category
                                    break;
                                case "2":
                                    // Borrow Tool from the library
                                    break;
                                case "3":
                                    // Return Tool to the library
                                    break;
                                case "4":
                                    // List tools on loan
                                    break;
                                case "5":
                                    // Most frequently borrowed
                                    break;
                                case "0":
                                    // Return to main menu
                                    break;
                            }
                        }
                        else {
                            Console.Clear();
                            Console.WriteLine("No member exists with the provided details. Please try again.");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid menu option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void drawMainMenu() {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library System\n");
            Console.WriteLine("============ Main Menu ===========");
            Console.WriteLine("1. Staff Operations");
            Console.WriteLine("2. Member Operations");
            Console.WriteLine("0. Exit Application");
            Console.WriteLine("==================================");
            Console.Write("Enter Option: ");
        }
        static void drawStaffMenu() {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\n");
            Console.WriteLine("===============Staff Menu===============");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of an existing tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Show tools member has on loan");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("========================================");
            Console.Write("Enter Option: ");
        }
        static bool staffAuthentication()
        {
            Console.Clear();
            Console.Write("Enter staff login: ");
            string username = Console.ReadLine();
            Console.Write("Enter staff password: ");
            string password = Console.ReadLine();
            return (username == "staff" && password == "today123");
        }


        static void addMemberMenu() {
            Console.Clear();
            Console.WriteLine("Tool Library System - Add a new member");
            Console.WriteLine("======================================\n");
            Console.Write("Please enter the new members first name - ");
            string FirstName = Console.ReadLine();
            Console.Write("Please enter the new members last name - ");
            string LastName = Console.ReadLine();
            Console.Write("Please enter the new members contact number - ");
            string ContactNumber = Console.ReadLine();
            Console.Write("Please enter the new members 4 digit PIN - ");
            string PIN = Console.ReadLine();
            if (PIN.Length == 4) { 
                Member newmember = new Member(FirstName, LastName, ContactNumber, PIN);
                Console.WriteLine();
                Console.WriteLine("Success! New member created: " + newmember.ToString());
                Console.WriteLine("Press any key to return to staff menu");
                Console.ReadKey();
            }
            else {
                Console.WriteLine("Please ensure the PIN is 4 digits long.");
                Console.WriteLine("Press enter to try again.");
                Console.ReadKey();
                addMemberMenu();
            }
        }

        static void drawMemberMenu() {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library\n");
            Console.WriteLine("===============Member Menu===============");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display three most frequently rented tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=========================================");
        }
        static bool memberAuthenticated() {
            Console.Clear();
            Console.WriteLine("   Tool Library System - Member Login Page   ");
            Console.WriteLine("=============================================");
            Console.Write("Please enter your member login ID - ");
            string memberID = Console.ReadLine();
            Console.Write("Please enter your 4 digit PIN - ");
            string PIN = Console.ReadLine();
            //Check against membercollection for existing member with pin
            return true;
        }
        static void initialiseVariables() {
            MemberCollection users;

            string[] Categories = {
                "Gardening tools",
                "Flooring Tools",
                "Fencing Tools",
                "Measuring Tools",
                "Cleaning Tools",
                "Painting Tools",
                "Electronic Tools",
                "Electricity Tools",
                "Automotive Tools"
            };

            // This is to store the Tool types in jagged arrays of their Category.
            ToolCollection[] GardeningTools = new ToolCollection[5];
            ToolCollection[] FlooringTools = new ToolCollection[6];
            ToolCollection[] FencingTools = new ToolCollection[5];
            ToolCollection[] MeasuringTools = new ToolCollection[6];
            ToolCollection[] CleaningTools = new ToolCollection[6];
            ToolCollection[] PaintingTools = new ToolCollection[6];
            ToolCollection[] ElectronicTools = new ToolCollection[5];
            ToolCollection[] ElectricityTools = new ToolCollection[5];
            ToolCollection[] AutomotiveTools = new ToolCollection[6];

            GardeningTools[0] = new ToolCollection(); //Line Trimmers
            GardeningTools[0].add(new Tool("Trimmers", 10, 10, 0));
            GardeningTools[1] = new ToolCollection(); //Lawn Mowers
            GardeningTools[1].add(new Tool("Mowers", 10, 10, 0));
            GardeningTools[2] = new ToolCollection(); //Hand Tools
            GardeningTools[2].add(new Tool("Tools", 10, 10, 0));
            GardeningTools[3] = new ToolCollection(); //Wheelbarrows
            GardeningTools[3].add(new Tool("Wheelbarrows", 10, 10, 0));
            GardeningTools[4] = new ToolCollection(); //Garden Power Tools
            GardeningTools[4].add(new Tool("Tools", 10, 10, 0));

            FlooringTools[0] = new ToolCollection(); //Scrapers
            FlooringTools[0].add(new Tool("Scrapers", 10, 10, 0));
            FlooringTools[1] = new ToolCollection(); //Floor Lasers
            FlooringTools[1].add(new Tool("Lasers", 10, 10, 0));
            FlooringTools[2] = new ToolCollection(); //Floor Levelling Tools
            FlooringTools[2].add(new Tool("Tools", 10, 10, 0));
            FlooringTools[3] = new ToolCollection(); //Floor Levelling Materials
            FlooringTools[3].add(new Tool("Materials", 10, 10, 0));
            FlooringTools[4] = new ToolCollection(); //Floor Hand Tools
            FlooringTools[4].add(new Tool("Tools", 10, 10, 0));
            FlooringTools[5] = new ToolCollection(); //Tiling Tools
            FlooringTools[5].add(new Tool("Tools", 10, 10, 0));

            FencingTools[0] = new ToolCollection(); //Hand Tools
            FencingTools[0].add(new Tool("Tools", 10, 10, 0));
            FencingTools[1] = new ToolCollection(); //Electric Fencing
            FencingTools[1].add(new Tool("Fencing", 10, 10, 0));
            FencingTools[2] = new ToolCollection(); //Steel Fencing Tools
            FencingTools[2].add(new Tool("Tools", 10, 10, 0));
            FencingTools[3] = new ToolCollection(); //Power Tools
            FencingTools[3].add(new Tool("Tools", 10, 10, 0));
            FencingTools[4] = new ToolCollection(); //Fencing Accessories
            FencingTools[4].add(new Tool("Accessories", 10, 10, 0));

            MeasuringTools[0] = new ToolCollection(); //Distance Tools
            MeasuringTools[0].add(new Tool("Tools", 10, 10, 0));
            MeasuringTools[1] = new ToolCollection(); //Laser Measurer
            MeasuringTools[1].add(new Tool("Measurer", 10, 10, 0));
            MeasuringTools[2] = new ToolCollection(); //Measuring Jugs
            MeasuringTools[2].add(new Tool("Jugs", 10, 10, 0));
            MeasuringTools[3] = new ToolCollection(); //Temperature & Humidity Tools
            MeasuringTools[3].add(new Tool("Tools", 10, 10, 0));
            MeasuringTools[4] = new ToolCollection(); //Levelling Tools
            MeasuringTools[4].add(new Tool("Tools", 10, 10, 0));
            MeasuringTools[5] = new ToolCollection(); //Markers
            MeasuringTools[5].add(new Tool("Markers", 10, 10, 0));

            CleaningTools[0] = new ToolCollection(); //Draining
            CleaningTools[0].add(new Tool("Draining", 10, 10, 0));
            CleaningTools[1] = new ToolCollection(); //Car Cleaning
            CleaningTools[1].add(new Tool("Cleaning", 10, 10, 0));
            CleaningTools[2] = new ToolCollection(); //Vacuum
            CleaningTools[2].add(new Tool("Vacuum", 10, 10, 0));
            CleaningTools[3] = new ToolCollection(); //Pressure Cleaners
            CleaningTools[3].add(new Tool("Cleaners", 10, 10, 0));
            CleaningTools[4] = new ToolCollection(); //Pool Cleaning
            CleaningTools[4].add(new Tool("Cleaning", 10, 10, 0));
            CleaningTools[5] = new ToolCollection(); //Floor Cleaning
            CleaningTools[5].add(new Tool("Cleaning", 10, 10, 0));
            
            PaintingTools[0] = new ToolCollection(); //Sanding Tools
            PaintingTools[0].add(new Tool("Tools", 10, 10, 0));
            PaintingTools[1] = new ToolCollection(); //Brushes
            PaintingTools[1].add(new Tool("Brushes", 10, 10, 0));
            PaintingTools[2] = new ToolCollection(); //Rollers
            PaintingTools[2].add(new Tool("Rollers", 10, 10, 0));
            PaintingTools[3] = new ToolCollection(); //Paint Removal Tools
            PaintingTools[3].add(new Tool("Tools", 10, 10, 0));
            PaintingTools[4] = new ToolCollection(); //Paint Scrapers
            PaintingTools[4].add(new Tool("Scrapers", 10, 10, 0));
            PaintingTools[5] = new ToolCollection(); //Sprayers
            PaintingTools[5].add(new Tool("Sprayers", 10, 10, 0));
            
            ElectronicTools[0] = new ToolCollection(); //Voltage Tester
            ElectronicTools[0].add(new Tool("Tester", 10, 10, 0));
            ElectronicTools[1] = new ToolCollection(); //Oscilloscopes
            ElectronicTools[1].add(new Tool("Oscilloscopes", 10, 10, 0));
            ElectronicTools[2] = new ToolCollection(); //Thermal Imaging
            ElectronicTools[2].add(new Tool("Imaging", 10, 10, 0));
            ElectronicTools[3] = new ToolCollection(); //Data Test Tool
            ElectronicTools[3].add(new Tool("Tool", 10, 10, 0));
            ElectronicTools[4] = new ToolCollection(); //Insulation Testers
            ElectronicTools[4].add(new Tool("Testers", 10, 10, 0));
            
            ElectricityTools[0] = new ToolCollection(); //Test Equipment
            ElectricityTools[0].add(new Tool("Equipment", 10, 10, 0));
            ElectricityTools[1] = new ToolCollection(); //Safety Equipment
            ElectricityTools[1].add(new Tool("Equipment", 10, 10, 0));
            ElectricityTools[2] = new ToolCollection(); //Basic Hand tools
            ElectricityTools[2].add(new Tool("tools", 10, 10, 0));
            ElectricityTools[3] = new ToolCollection(); //Circuit Protection
            ElectricityTools[3].add(new Tool("Protection", 10, 10, 0));
            ElectricityTools[4] = new ToolCollection(); //Cable Tools
            ElectricityTools[4].add(new Tool("Tools", 10, 10, 0));
            
            AutomotiveTools[0] = new ToolCollection(); //Jacks
            AutomotiveTools[0].add(new Tool("Jacks", 10, 10, 0));
            AutomotiveTools[1] = new ToolCollection(); //Air Compressors
            AutomotiveTools[1].add(new Tool("Compressors", 10, 10, 0));
            AutomotiveTools[2] = new ToolCollection(); //Battery Chargers
            AutomotiveTools[2].add(new Tool("Chargers", 10, 10, 0));
            AutomotiveTools[3] = new ToolCollection(); //Socket Tools
            AutomotiveTools[3].add(new Tool("Tools", 10, 10, 0));
            AutomotiveTools[4] = new ToolCollection(); //Braking
            AutomotiveTools[4].add(new Tool("Braking", 10, 10, 0));
            AutomotiveTools[5] = new ToolCollection(); //Drivetrain
            AutomotiveTools[5].add(new Tool("Drivetrain", 10, 10, 0));

            Tool[] tools = AutomotiveTools[1].toArray();
            Console.WriteLine(tools[0].ToString());
            Console.ReadKey();
        }
    }
}
