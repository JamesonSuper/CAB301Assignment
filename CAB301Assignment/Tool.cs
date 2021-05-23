using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Assignment;

namespace Assignment
{
    public class Tool : iTool, IComparable<Tool>
    {
        private string name;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;
        private MemberCollection Borrowers;

        public Tool(string name, int quantity = 1) {
            Name = name;
            Quantity = quantity;
            AvailableQuantity = quantity;
            NoBorrowings = 0;
            Borrowers = new MemberCollection();
        }
        public string Name { get { return name; } set { name = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int AvailableQuantity { get { return availableQuantity; } set { availableQuantity = value; } }
        public int NoBorrowings { get { return noBorrowings; } set { noBorrowings = value; } }
        public MemberCollection GetBorrowers { get { return Borrowers; } }

        /// <summary>
        /// Add a borrower to the internal borrowers class member.
        /// Increment/Decrement tool values.
        /// </summary>
        /// <param name="aMember">Member to add</param>
        public void addBorrower(Member aMember) {
            Borrowers.add(aMember);
            AvailableQuantity--;
            NoBorrowings++;
            aMember.addTool(this);
        }

        /// <summary>
        /// Remove a borrower to the internal borrowers class member.
        /// Increment/Decrement tool values.
        /// </summary>
        /// <param name="aMember">Member to add</param>
        public void deleteBorrower(Member aMember) {
            Borrowers.delete(aMember);
            AvailableQuantity++;
            aMember.deleteTool(this);
        }

        /// <summary>
        /// Lexicographic comparison on the Tool name
        /// </summary>
        /// <param name="other">Tool to be compared to.</param>
        /// <returns>Integer represnting ordering</returns>
        public int CompareTo(Tool other) {
            if (other == null) return 1;
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns formatted string of Tool data.
        /// </summary>
        /// <returns>Returns tool data in string form.</returns>
        public override string ToString() {
            return Name + " "  + Quantity + " "  + AvailableQuantity + " "  + NoBorrowings;
        }
    }
}
