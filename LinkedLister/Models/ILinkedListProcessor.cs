using System.Collections.Generic;

namespace LinkedLister.Models
{
    public interface ILinkedListProcessor
    {
        LinkedListResult CombineAndSortLinkedLists(ICollection<LinkedList> linkedListCollection);
    }
}