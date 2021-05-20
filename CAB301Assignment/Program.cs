using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberCollection members = new MemberCollection();
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
                                string menuInput = Console.ReadLine();
                                Console.Clear();
                                switch (menuInput) 
                                {
                                    case "1":
                                        // Add a new tool
                                        Tool newtool = addToolMenu();
                                        if (newtool != null)
                                            library.add(newtool);
                                        break;
                                    case "2":
                                        // Add new pieces of existing tool (Update quantity)
                                        Console.WriteLine("Add new pieces of existing tool");
                                        Console.WriteLine("===============================");
                                        library.add(null, 1);
                                        break;
                                    case "3":
                                        // Remove some pieves of existing tool (Update quantity)
                                        Console.WriteLine("Remove some pieces of existing tool");
                                        Console.WriteLine("===================================");
                                        library.delete(null, 0);
                                        break;
                                    case "4": 
                                        // Register a new member
                                        addMemberMenu(members, library);
                                        break;
                                    case "5":
                                        // Remove a member
                                        deleteMemberMenu(members, library);
                                        break;
                                    case "6":
                                        Console.WriteLine("Show tools a member has on loan");
                                        Console.WriteLine("===============================");
                                        library.listTools(null);
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
                        if (memberAuthenticated(members)) {
                            bool memberLoggedIn = true;
                            while(memberLoggedIn) { 
                                drawMemberMenu();
                                string menuInput = Console.ReadLine();
                                Console.Clear();
                                switch (menuInput) {
                                    case "1":
                                        // Display Tools by Category
                                        library.displayTools(null);
                                        break;
                                    case "2":
                                        // Borrow Tool from the library
                                        library.borrowTool(null, null);
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
                                        memberLoggedIn = false;
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
                            Console.WriteLine("No member exists with the provided details. Please try again.");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        badInputHandler("Please enter a valid menu option");
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
            Console.WriteLine("       Welcome to the Tool Library       \n");
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
        static bool staffAuthentication() {
            Console.Clear();
            Console.Write("Enter staff login: ");
            string username = Console.ReadLine();
            Console.Write("Enter staff password: ");
            string password = Console.ReadLine();
            return (username == "staff" && password == "today123");
        }

        static Tool addToolMenu() {
            Console.Clear();
            Console.WriteLine("Tool Library System - Add a new Tool");
            Console.WriteLine("====================================\n");

            Console.Write("Please enter the new Tools Name (0 to exit) - ");
            string name = Console.ReadLine();
            if (name == "0")
                return null;
            if (name == "") {
                Console.WriteLine("ERROR: Input name must not be null.");
                return null;
            }
            Console.Write("Please enter the new Tools Quantity - ");
            try {
                int quantity = int.Parse(Console.ReadLine());
                if (quantity < 1)
                    throw new FormatException();
                return new Tool(name, quantity);
            } catch (FormatException) {
                badInputHandler("ERROR: Input must be an positive integer");
                return null;
            }
        }

        static Tool deleteToolMenu() {
            Console.Clear();
            Console.WriteLine("Tool Library System - Delete an existing Tool");
            Console.WriteLine("=============================================\n");
            return new Tool("!Tool");
        }
        
        static void addMemberMenu(MemberCollection members, ToolLibrarySystem library) {
            Console.Clear();
            Console.WriteLine("Tool Library System - Add a new member");
            Console.WriteLine("======================================\n");

            Console.Write("Please enter the new members first name (0 to exit) - ");
            string FirstName = Console.ReadLine();
            if (FirstName == "0")
                return;
            if (FirstName == "")
            {
                badInputHandler("ERROR: First Name name must not be null.");
                return;
            }

            Console.Write("Please enter the new members last name (0 to exit) - ");
            string LastName = Console.ReadLine();
            if (LastName == "0")
                return;
            if (LastName == "")
            {
                badInputHandler("ERROR: Last Name name must not be null.");
                return;
            }

            Console.Write("Please enter the new members contact number (0 to exit) - ");
            string ContactNumber = Console.ReadLine();
            if (ContactNumber == "0")
                return;
            if (ContactNumber == "")
            {
                badInputHandler("ERROR: contact number name must not be null.");
                return;
            }

            Console.Write("Please enter the new members 4 digit PIN (0 to exit) - ");
            string PIN = Console.ReadLine(); 
            if (PIN == "0")
                return;
            else if (PIN.Length == 4)
                try {
                    int.Parse(PIN);
                    library.add(new Member(FirstName, LastName, ContactNumber, PIN));
                    members.add(new Member(FirstName, LastName, ContactNumber, PIN));
                } catch (FormatException) {
                    badInputHandler("PIN must be positive integers.");
                    return;
                }
            else {
                badInputHandler("Please ensure the PIN is 4 digits long.");
                return;
            }
        }
        static void deleteMemberMenu(MemberCollection members, ToolLibrarySystem library)
        {
            Console.Clear();
            Console.WriteLine("Delete a member");
            Console.WriteLine("===============\n");
            if (!printAllMembers(members))
            {
                Console.WriteLine("No registered members exist in the system");
                return;
            }
            Console.Write("Please choose member for deletion by number only - ");
            try
            {
                Member memberToDelete = members.toArray()[int.Parse(Console.ReadLine()) - 1];
                // Checking to see if selected user has any borrowed tools.
                if (memberToDelete.Tools.Length == 0)
                {
                    members.delete(memberToDelete);
                    library.delete(memberToDelete);
                    Console.WriteLine("Success! See new list of members below.");
                    printAllMembers(members);
                }
                else
                {
                    Console.WriteLine("That user currently has tools borrowed and cannot be deleted.");
                    Console.WriteLine("Press enter to return to staff menu");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid choice.");
                Console.WriteLine("Press enter to return to staff menu");
                Console.ReadKey();
            }
        }
        static void drawMemberMenu() {
            Console.Clear();
            Console.WriteLine("       Welcome to the Tool Library       ");
            Console.WriteLine("===============Member Menu===============");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display three most frequently rented tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=========================================");
            Console.Write("Enter Option: ");
        }
        static bool memberAuthenticated(MemberCollection members) {
            Console.Clear();
            Console.WriteLine("   Tool Library System - Member Login Page   ");
            Console.WriteLine("=============================================");
            Console.Write("Please enter your member login ID - ");
            string username = Console.ReadLine();
            Console.Write("Please enter your 4 digit PIN - ");
            string PIN = Console.ReadLine();
            for (int i = 0; i < members.Number; i++)
            {
                string usernameToCompare = members.toArray()[i].LastName + members.toArray()[i].FirstName;
                if (usernameToCompare == username)
                    if (members.toArray()[i].PIN == PIN)
                        return true;
            }
            return false;
        }
        static void badInputHandler(string message) {
            Console.WriteLine(message);
            Console.WriteLine("Press enter to try again.");
            Console.ReadKey();
        }
        static bool printAllMembers(MemberCollection members)
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
                badInputHandler("There are currently no registered members.");
                return false;
            }
        }
    }
}
