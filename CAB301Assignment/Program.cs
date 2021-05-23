using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // To manage member login, I have used two Membercollections, one within 
            // the tool library system, and another at the program.cs level.
            MemberCollection members = new MemberCollection();
            ToolLibrarySystem library = new ToolLibrarySystem();
            
            library.add(new Member("James", "Scott", "0431024427", "1234"));
            members.add(new Member("James", "Scott", "0431024427", "1234"));

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
                                        Console.WriteLine("Search for member by contact number");
                                        Console.WriteLine("===================================");
                                        numberSearch(members);
                                        break;
                                    case "7":
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
                        Member loggedInUser = memberAuthenticated(members);
                        if (loggedInUser != null) {
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
                                        library.borrowTool(loggedInUser, null);
                                        break;
                                    case "3":
                                        // Return Tool to the library
                                        library.returnTool(loggedInUser, null);
                                        break;
                                    case "4":
                                        // List tools on loan
                                        library.listTools(loggedInUser);
                                        break;
                                    case "5":
                                        // Most frequently borrowed
                                        library.displayTopTHree();
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

        private static void numberSearch(MemberCollection members)
        {
            Console.Write("Please enter contact number to search - ");
            try
            {
                int searchTerm = int.Parse(Console.ReadLine());
                Member[] arr = members.toArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].ContactNumber == searchTerm.ToString())
                    {
                        Console.WriteLine("Member found!");
                        Console.WriteLine("Name: " + arr[i].ToString());
                        Console.WriteLine("Contact Number: " + arr[i].ContactNumber);
                        Console.WriteLine("Press enter to return to menu");
                        Console.ReadKey();
                        return;
                    }
                }
                badInputHandler("No member found with provided search term.");
            }
            catch (FormatException)
            {
                badInputHandler("Please only enter a valid contact number.");
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
            Console.Write("Enter Option - ");
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
            Console.WriteLine("6. Contact number search");
            Console.WriteLine("7. Show tools member has on loan");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("========================================");
            Console.Write("Enter Option - ");
        }
        static bool staffAuthentication() {
            Console.Clear();
            Console.Write("Enter staff login - ");
            string username = Console.ReadLine();
            Console.Write("Enter staff password - ");
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
                    int.Parse(ContactNumber);
                    library.add(new Member(FirstName, LastName, ContactNumber, PIN));
                    members.add(new Member(FirstName, LastName, ContactNumber, PIN));
                    Console.WriteLine();
                    badInputHandler("Success! New member created: " + FirstName + " " + LastName);
                } catch (FormatException) {
                    badInputHandler("Contact Number and PIN must be positive integers.");
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
                int toolCount = 0;
                for (int i = 0; i < members.toArray().Length; i++)
                {
                    if (members.toArray()[i] != null)
                        toolCount++;
                }
                if (toolCount == 0)
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
            Console.Write("Enter Option - ");
        }
        static Member memberAuthenticated(MemberCollection members) {
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
                    if (members.toArray()[i].PIN == PIN) {
                        return members.toArray()[i]; ;
                    }
            }
            return null;
        }
        static void badInputHandler(string message) {
            Console.WriteLine(message);
            Console.WriteLine("Press enter to continue.");
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
