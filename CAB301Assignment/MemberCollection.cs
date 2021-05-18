using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
    public class MemberCollection : iMemberCollection
    {
        private BinarySearchTree members;
        public int Number { get; private set; }

        public MemberCollection() {
            members = new BinarySearchTree();
        }

        public void add(Member aMember)
        {
            members.Insert(aMember);
        }

        public void delete(Member aMember)
        {
            members.Delete(aMember);
        }

        public bool search(Member aMember)
        {
            return members.Search(aMember);
        }

        public Member[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
