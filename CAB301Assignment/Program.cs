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
                                        // Search for member contact number
                                        numberSearch(members);
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
                                        library.displayBorrowingTools(loggedInUser);
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

        /// <summary>
        /// Takes input and searches the passed MemberCollection object 
        /// for a matching FirstName & LastName
        /// </summary>
        /// <param name="members">The Collection to be searched</param>
        private static void numberSearch(MemberCollection members)
        {
            Console.WriteLine("Search for a Members Contact Number by Name");
            Console.WriteLine("===========================================");
            Console.Write("Please enter FirstName to search - ");
            string FirstNameSearch = Console.ReadLine();
            Console.Write("Please enter LastName to search - ");
            string LastNameSearch = Console.ReadLine();
            Member[] arr = members.toArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].FirstName == FirstNameSearch && arr[i].LastName == LastNameSearch)
                {
                    Console.WriteLine("Member found!");
                    Console.WriteLine("Name: " + arr[i].ToString());
                    Console.WriteLine("Contact Number: " + arr[i].ContactNumber);
                    Console.WriteLine("Press enter to return to menu");
                    Console.ReadKey();
                    return;
                }
            }
            badInputHandler("No member found with provided search terms.");
        }

        /// <summary>
        /// Utility function to draw main menu
        /// </summary>
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

        /// <summary>
        /// Utility function to draw staff menu
        /// </summary>
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
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("========================================");
            Console.Write("Enter Option - ");
        }

        /// <summary>
        /// Utility function to print to the console each MemberMenu option.
        /// </summary>
        static void drawMemberMenu()
        {
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

        /// <summary>
        /// Prompts user for input and if matches saved staff credentials, allows login.
        /// </summary>
        /// <returns>True if passed username and pword match expected.</returns>
        static bool staffAuthentication() {
            Console.Clear();
            Console.Write("Enter staff login - ");
            string username = Console.ReadLine();
            Console.Write("Enter staff password - ");
            string password = Console.ReadLine();
            return (username == "staff" && password == "today123");
        }

        /// <summary>
        /// Prompts user for inputs to create new Tool object
        /// and returns that object.
        /// </summary>
        /// <returns>Created Tool object, or Null if input cancelled.</returns>
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
            int quantity = getNumericInput();
            if (quantity == -1) 
                return null;
            else if (quantity == 0) { 
                badInputHandler("Quantity cannot be 0.");
                return null;
            }
            else {
                return new Tool(name, quantity);
            }
        }

        /// <summary>
        /// Takes user input for new Member and updates the passed MemberCollection object
        /// and the MemberCollection inside the passed ToolLibrarySystem object
        /// </summary>
        /// <param name="members">MemberCollection object to updated</param>
        /// <param name="library">Updates the ToolLibrarySystems inner MemberCollection object</param>
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
                badInputHandler("ERROR: First Name cannot be null.");
                return;
            }

            Console.Write("Please enter the new members last name (0 to exit) - ");
            string LastName = Console.ReadLine();
            if (LastName == "0")
                return;
            if (LastName == "")
            {
                badInputHandler("ERROR: Last Name cannot be null.");
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

        /// <summary>
        /// Prompts the user to choose a member for deletion.
        /// </summary>
        /// <param name="members">MemberCollection to be searched and deleted from</param>
        /// <param name="library">Passed to have its MemberCollection updated with the changes</param>
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
                for (int i = 0; i < memberToDelete.Tools.Length; i++)
                {
                    if (memberToDelete.Tools[i] != null)
                        toolCount++;
                }
                if (toolCount == 0)
                {
                    members.delete(memberToDelete);
                    library.delete(memberToDelete);
                    Console.WriteLine("\nSuccess! See new list of members below.");
                    if (printAllMembers(members)) { 
                        Console.WriteLine("Press enter to return to menu.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    badInputHandler("That user currently has tools borrowed and cannot be deleted.");
                }
            }
            catch (Exception)
            {
                badInputHandler("Not a valid choice.");
            }
        }

        /// <summary>
        /// Prompts user for login credentials.
        /// If they match a registered member in the passed membercollection object
        /// Return that member object
        /// </summary>
        /// <param name="members">MemberCollection object to be searched</param>
        /// <returns>Member object if correct credentials supplied, null if not.</returns>
        static Member memberAuthenticated(MemberCollection members) {
            Console.Clear();
            Console.WriteLine("   Tool Library System - Member Login Page   ");
            Console.WriteLine("=============================================");
            Console.Write("Please enter your member login ID (LastnameFirstname) - ");
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

        /// <summary>
        /// Takes user input and tries to parse it to type Int
        /// </summary>
        /// <returns>-1 if the input was not an int, otherwise the entered integer value.</returns>
        private static int getNumericInput()
        {
            try
            {
                return Math.Abs(int.Parse(Console.ReadLine()));
            }
            catch (FormatException)
            {
                badInputHandler("Please enter a positive integer.");
                return -1;
            }
        }

        /// <summary>
        /// Called to display the passed error message and return to menu instructions.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        static void badInputHandler(string message) {
            Console.WriteLine(message);
            Console.WriteLine("Press enter to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints all members in the passed MemberCollection object
        /// </summary>
        /// <param name="members">MemberCollection object to be printed</param>
        /// <returns>False if the passed membercollection object is empty</returns>
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
