using System;
using System.Collections.Generic;

namespace Assignment
{
	public class BinarySearchTree : iBinarySearchTree
	{
		private BinarySearchNode root;
		public BinarySearchTree()
		{
			root = null;
		}

		public bool IsEmpty()
		{
			return root == null;
		}

		public bool Search(Member item)
		{
			return Search(item, root);
		}

		private bool Search(Member item, BinarySearchNode r)
		{
			if (r != null)
			{
				if (item.CompareTo(r.Member) == 0)
					return true;
				else
					if (item.CompareTo(r.Member) < 0)
					return Search(item, r.LChild);
				else
					return Search(item, r.RChild);
			}
			else
				return false;
		}

		public void Insert(Member member)
		{
			if (root == null)
				root = new BinarySearchNode(member);
			else
				Insert(member, root);
		}

		// pre: ptr != null
		// post: item is inserted to the binary search tree rooted at ptr
		private void Insert(Member member, BinarySearchNode ptr)
		{
			if (member.CompareTo(ptr.Member) < 0)
			{
				if (ptr.LChild == null)
					ptr.LChild = new BinarySearchNode(member);
				else
					Insert(member, ptr.LChild);
			}
			else
			{
				if (ptr.RChild == null)
					ptr.RChild = new BinarySearchNode(member);
				else
					Insert(member, ptr.RChild);
			}
		}

		// there are three cases to consider:
		// 1. the node to be deleted is a leaf
		// 2. the node to be deleted has only one child 
		// 3. the node to be deleted has both left and right children
		public void Delete(Member member)
		{
			// search for item and its parent
			BinarySearchNode ptr = root; // search reference
			BinarySearchNode parent = null; // parent of ptr
			while ((ptr != null) && (member.CompareTo(ptr.Member) != 0))
			{
				parent = ptr;
				if (member.CompareTo(ptr.Member) < 0) // move to the left child of ptr
					ptr = ptr.LChild;
				else
					ptr = ptr.RChild;
			}

			if (ptr != null) {
				// case 3: item has two children
				if ((ptr.LChild != null) && (ptr.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
					{
						ptr.Member = ptr.LChild.Member;
						ptr.LChild = ptr.LChild.LChild;
					}
					else
					{
						BinarySearchNode p = ptr.LChild;
						BinarySearchNode pp = ptr; // parent of p
						while (p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						ptr.Member = p.Member;
						pp.RChild = p.LChild;
					}
				}
				else // cases 1 & 2: item has no or only one child
				{
					BinarySearchNode c;
					if (ptr.LChild != null)
						c = ptr.LChild;
					else
						c = ptr.RChild;

					// remove node ptr
					if (ptr == root) //need to change root
						root = c;
					else
					{
						if (ptr == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
				}

			}
		}
		public Member[] InOrderTraverse() {
			Member[] a;
			List<Member> l = new List<Member>();
			InOrderTraverse(root, l); 
			a = new Member[l.Count];
			for (int i = 0; i < l.Count; i++)
			{
				a[i] = l[i];
			}
			return a; 
		}

		private void InOrderTraverse(BinarySearchNode root, List<Member> l) {
			if (root != null)
			{
				InOrderTraverse(root.LChild, l);
				l.Add(root.Member);
				InOrderTraverse(root.RChild, l);
			}
		}

		public void Clear() {
			root = null;
		}
    }
}