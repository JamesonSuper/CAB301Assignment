using System;

namespace Assignment
{
	public interface iBinarySearchTree
	{
		bool IsEmpty();
		void Insert(Member item);
		void Delete(Member item);
		bool Search(Member item);
		Member[] InOrderTraverse();
		void Clear();
	}
}
