using System.Collections.Generic;

namespace LinkedLister.Models
{
    public class LinkedListResult
    {
        public LinkedListResult(ICollection<LinkedList> inputLinkedLists, LinkedList sortedList, ICollection<string> conflicts)
        {
            InputLinkedLists = inputLinkedLists;
            SortedList = sortedList;
            Conflicts = conflicts;
        }

        public ICollection<LinkedList> InputLinkedLists { get; }

        public LinkedList SortedList { get; }

        public ICollection<string> Conflicts { get; }
    }
}