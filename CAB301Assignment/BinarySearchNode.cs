using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
	public class BinarySearchNode
	{
        public BinarySearchNode(Member member) {
			this.Member = member;
			LChild = null;
			RChild = null;
		}

        public Member Member { get; set; }

        public BinarySearchNode LChild { get; set; }

        public BinarySearchNode RChild { get; set; }
    }
}
