using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public class ToolCollection : iToolCollection
    {
        private Tool[] collection;
        public int Number { get; private set; }
        public ToolCollection()
        {
            collection = new Tool[10000000];
            Number = 0;
        }

        /// <summary>
        /// Add a tool to the collection
        /// </summary>
        /// <param name="aTool">Tool to add</param>
        public void add(Tool aTool) {
            collection[Number] = aTool;
            Number++;
        }

        /// <summary>
        /// Delete a tool to the collection
        /// </summary>
        /// <param name="aTool">Tool to Delete</param>
        public void delete(Tool aTool) {
            for (int i = 0; i < Number; i++) {
                if (collection[i].Name == aTool.Name) {
                    Console.WriteLine(aTool.Name + " - Removed from collection.");
                    for (; i < Number; i++)
                    {
                        collection[i] = collection[i + 1];
                    }
                    Number--;
                    return;
                }
            }
            Console.WriteLine(aTool.Name + " Not found in collection.");
        }

        /// <summary>
        /// Search the tool collection for a Tool based on Name.
        /// </summary>
        /// <param name="aTool">Tool to search for</param>
        /// <returns>True if tool exists</returns>
        public bool search(Tool aTool) {
            for (int i = 0; i < Number; i++) {
                if (collection[i].Name == aTool.Name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Return inner Tool objects as an array
        /// </summary>
        /// <returns>Tool[] of inner Tool objects</returns>
        public Tool[] toArray() {
            Tool[] arr = new Tool[Number];
            for (int i = 0; i < Number; i++) {
                arr[i] = collection[i];
            }
            return arr;
        }
    }
}
