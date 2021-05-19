using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
	public class BinarySearchNode
	{
		private Member member;
		private BinarySearchNode lchild;
		private BinarySearchNode rchild;
		public BinarySearchNode(Member member) {
			this.member = member;
			lchild = null;
			rchild = null;
		}

		public Member Member {
			get { return member; }
			set { member = value; }
		}

		public BinarySearchNode LChild {
			get { return lchild; }
			set { lchild = value; }
		}

		public BinarySearchNode RChild {
			get { return rchild; }
			set { rchild = value; }
		}
	}
}
