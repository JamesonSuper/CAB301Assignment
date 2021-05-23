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

		/// <summary>
		/// Returns true if the root node is null
		/// </summary>
		/// <returns>True if the BST is empty</returns>
		public bool IsEmpty()
		{
			return root == null;
		}

		/// <summary>
		/// Search the BST for the passed item
		/// </summary>
		/// <param name="item">Item to search for</param>
		/// <returns>True if found within the BST</returns>
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

		/// <summary>
		/// Inserts a new member into the BST
		/// </summary>
		/// <param name="member">Member to be inserted</param>
		public void Insert(Member member)
		{
			if (root == null)
				root = new BinarySearchNode(member);
			else
				Insert(member, root);
		}

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

		/// <summary>
		/// Removes a member from the BST
		/// </summary>
		/// <param name="member">Member to be removed</param>
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

		/// <summary>
		/// Returns a Member[] of the BST In order traverse
		/// </summary>
		/// <returns>[] of ordered Members</returns>
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

		/// <summary>
		/// Clear the BST.
		/// </summary>
		public void Clear() {
			root = null;
		}
    }
}