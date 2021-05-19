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
        private string[] tools;
        public Member(string FirstName, string LastName, string ContactNumber, string PIN)
        {
            this.FirstName = FirstName; 
            this.LastName = LastName; 
            this.ContactNumber = ContactNumber;
            this.PIN = PIN;
            tools = new string[3];
        }
        public string[] Tools { get { return tools; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }
        public string PIN { get { return pIN; } set { pIN = value; } }

        public void addTool(Tool aTool) {
            throw new NotImplementedException();
        }

        public void deleteTool(Tool aTool) {
            throw new NotImplementedException();
        }
        public override string ToString() {
            return firstName + " " + lastName;
        }
        public int CompareTo([AllowNull] Member other) {
            if (LastName.CompareTo(other.LastName) < 0)
                return -1;
            else if (LastName.CompareTo(other.LastName) == 0)
                return FirstName.CompareTo(other.FirstName);
            return 1;
        }
    }
}
