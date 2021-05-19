using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ToolLibrarySystem library = new ToolLibrarySystem();
            while (true)
            {
                drawMainMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        if (staffAuthentication())
                        {
                            bool staffLoggedIn = true;
                            while (staffLoggedIn)
                            {
                                drawStaffMenu();
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        // Add a new tool
                                        Tool newtool = addToolMenu();
                                        if (newtool != null)
                                            library.add(newtool);
                                        break;
                                    case "2":
                                        // Add new pieces of existing tool (Update quantity)

                                        //library.add(null, null);
                                        break;
                                    case "3":
                                        // Remove some pieves of existing tool (Update quantity)
                                        library.delete(deleteToolMenu());
                                        break;
                                    case "4": 
                                        // Register a new member
                                        Member newMember = addMemberMenu();
                                        if (newMember != null)
                                            library.add(newMember);
                                        break;
                                    case "5":
                                        // Remove a member
                                        library.delete(deleteMemberMenu());

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
                        else
                        {
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

        static void drawMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library System\n");
            Console.WriteLine("============ Main Menu ===========");
            Console.WriteLine("1. Staff Operations");
            Console.WriteLine("2. Member Operations");
            Console.WriteLine("0. Exit Application");
            Console.WriteLine("==================================");
            Console.Write("Enter Option: ");
        }
        static void drawStaffMenu()
        {
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

        static Tool addToolMenu(){
            Console.Clear();
            Console.WriteLine("Tool Library System - Add a new Tool");
            Console.WriteLine("====================================\n");

            Console.Write("Please enter the new Tools Name (0 to exit) - ");
            string name = Console.ReadLine();
            if (name == "0")
                return null;
            return new Tool(name);
        }
        static Tool deleteToolMenu()
        {
            Console.Clear();
            Console.WriteLine("Tool Library System - Delete an existing Tool");
            Console.WriteLine("=============================================\n");
            return new Tool("!Tool");
        }
        
        static Member addMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("Tool Library System - Add a new member");
            Console.WriteLine("======================================\n");
            Console.Write("Please enter the new members first name (0 to exit) - ");
            string FirstName = Console.ReadLine();
            if (FirstName == "0")
                return null;
            Console.Write("Please enter the new members last name (0 to exit) - ");
            string LastName = Console.ReadLine();
            if (LastName == "0")
                return null;
            Console.Write("Please enter the new members contact number (0 to exit) - ");
            string ContactNumber = Console.ReadLine();
            if (ContactNumber == "0")
                return null;
            Console.Write("Please enter the new members 4 digit PIN (0 to exit) - ");
            string PIN = Console.ReadLine();
            if (PIN == "0")
                return null;
            else if (PIN.Length == 4)
                return (new Member(FirstName, LastName, ContactNumber, PIN));
            else {
                Console.WriteLine("Please ensure the PIN is 4 digits long.");
                Console.WriteLine("Press enter to try again.");
                Console.ReadKey();
                return addMemberMenu();
            }
        }
        static Member deleteMemberMenu() {
            Console.Clear();
            Console.WriteLine("Tool Library System - Delete a member");
            Console.WriteLine("======================================\n");
            return null;
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
            //for (int i = 0; i < members.toArray().Length(); i++) {

            //}
            return true;
        }
    }
}
