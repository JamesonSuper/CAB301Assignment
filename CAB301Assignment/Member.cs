using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment
{
    public class Member : iMember, IComparable<Member> {
        private string firstName;
        private string lastName;
        private string contactNumber;
        private string pIN;
        private ToolCollection borrowedTools;

        public Member(string FirstName, string LastName, string ContactNumber, string PIN)
        {
            this.FirstName = FirstName; 
            this.LastName = LastName; 
            this.ContactNumber = ContactNumber;
            this.PIN = PIN;
            borrowedTools = new ToolCollection();
        }
        public string[] Tools { 
            get 
            {
                string[] arr = new string[borrowedTools.Number];
                for (int i = 0; i < borrowedTools.Number; i++)
                {
                    arr[i] = borrowedTools.toArray()[i].Name;
                }
                return arr;
            }
        }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }
        public string PIN { get { return pIN; } set { pIN = value; } }

        /// <summary>
        /// Adds a tool to the Members inner ToolCollection member.
        /// </summary>
        /// <param name="aTool">Tool to be added</param>
        public void addTool(Tool aTool) {
            if (borrowedTools.Number < 3)
                borrowedTools.add(aTool);
            else
                throw new FormatException("User already has 3 tools borrowed.");
        }

        /// <summary>
        /// Delete a tool from the Members inner ToolCollection member
        /// </summary>
        /// <param name="aTool">Tool to be deleted</param>
        public void deleteTool(Tool aTool) {
            if (borrowedTools.search(aTool))
                borrowedTools.delete(aTool);
            else
                throw new FormatException("Tool not present in library.");
        }

        /// <summary>
        /// Returns FirstName + " " + LastName
        /// </summary>
        /// <returns>Concatenated Firstname and Lastname</returns>
        public override string ToString() {
            return firstName + " " + lastName;
        }

        public int CompareTo(Member other) {
            if (LastName.CompareTo(other.LastName) < 0)
                return -1;
            else if (LastName.CompareTo(other.LastName) == 0)
                return FirstName.CompareTo(other.FirstName);
            return 1;
        }
    }
}
