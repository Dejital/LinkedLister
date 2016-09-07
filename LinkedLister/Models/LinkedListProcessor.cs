using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedLister.Models
{
    internal sealed class LinkedListProcessor : ILinkedListProcessor
    {
        private static ILinkedListProcessor _instance;

        private LinkedListProcessor() { }

        public static ILinkedListProcessor Instance => _instance ?? (_instance = new LinkedListProcessor());

        public LinkedListResult CombineAndSortLinkedLists(ICollection<LinkedList> linkedListCollection)
        {
            if (!linkedListCollection.Any())
                throw new ArgumentException();

            var conflicts = new List<string>();
            var sortedNodes = linkedListCollection
                .ToList()
                .SelectMany(ll => ll.Nodes)
                .OrderBy(n => n.Id)
                .ToList();

            return new LinkedListResult(linkedListCollection, new LinkedList(sortedNodes), conflicts);
        }
    }
}