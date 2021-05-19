using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
    public class ToolCollection : iToolCollection
    {
        private Tool[] collection;
        public int Number { get; private set; }
        public ToolCollection()
        {
            collection = new Tool[30];
            Number = 0;
        }
        public void add(Tool aTool) {
            collection[Number] = aTool;
            Number++;
        }
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
        public bool search(Tool aTool) {
            for (int i = 0; i < Number; i++) {
                if (collection[i].Name == aTool.Name)
                {
                    return true;
                }
            }
            return false;
        }
        public Tool[] toArray() {
            Tool[] arr = new Tool[Number];
            for (int i = 0; i < Number; i++) {
                arr[i] = collection[i];
            }
            return arr;
        }
    }
}
