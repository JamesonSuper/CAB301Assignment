using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using CAB301Assignment;

namespace CAB301Assignment
{
    public class Tool : iTool, IComparable<Tool>
    {
        private string name;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;
        private MemberCollection Borrowers;

        public Tool(string name, int quantity, int availableQuantity, int noBorrowings)
        {
            Name = name;
            Quantity = quantity;
            AvailableQuantity = availableQuantity;
            NoBorrowings = noBorrowings;
            Borrowers = new MemberCollection();
        }
        public string Name { get { return name; } set { name = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int AvailableQuantity { get { return availableQuantity; } set { availableQuantity = value; } }
        public int NoBorrowings { get { return noBorrowings; } set { noBorrowings = value; } }

        public MemberCollection GetBorrowers { get { return Borrowers; } }

        public void addBorrower(Member aMember) {
            Borrowers.add(aMember);
            AvailableQuantity--;
            NoBorrowings++;
        }
        public void deleteBorrower(Member aMember) {
            Borrowers.delete(aMember);
            AvailableQuantity--;
            NoBorrowings++;
        }
        public int CompareTo(Tool other) {
            if (other == null) return 1;
            return Name.CompareTo(other.Name);
        }
        public override string ToString() {
            return Name;
        }
    }
}
