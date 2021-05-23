using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public class MemberCollection : iMemberCollection
    {
        private BinarySearchTree members;
        public int Number { get; private set; }

        public MemberCollection() {
            members = new BinarySearchTree();
        }

        /// <summary>
        /// Add a member to the collection
        /// </summary>
        /// <param name="aMember">Member to add</param>
        public void add(Member aMember) {
            members.Insert(aMember);
            Number++;
        }
        
        /// <summary>
        /// Delete a member from the collection
        /// </summary>
        /// <param name="aMember">Member to delete</param>
        public void delete(Member aMember) {
            members.Delete(aMember);
            Number--;
        }

        /// <summary>
        /// Search the collection for the provided member
        /// </summary>
        /// <param name="aMember">Member to search for</param>
        /// <returns>True if the member exists in the collection</returns>
        public bool search(Member aMember) {
            return members.Search(aMember);
        }

        /// <summary>
        /// Returns an array of the inner Member objects
        /// </summary>
        /// <returns>Member[] of the inner objects</returns>
        public Member[] toArray() {
            return members.InOrderTraverse();
        }
    }
}
