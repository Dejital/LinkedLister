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

            var mergedNodes = linkedListCollection
                .SelectMany(ll => ll.Nodes)
                .ToList();

            List<string> conflicts;
            var firstNode = GetFirstNode(mergedNodes, out conflicts);

            if (conflicts.Any())
            {
                return new LinkedListResult(linkedListCollection, new LinkedList(), conflicts);
            }

            var compiledNodes = new List<Node> { firstNode };
            var currentNode = firstNode;

            while (currentNode?.NextNodeId != null)
            {
                currentNode = mergedNodes.FirstOrDefault(n => n.Id == currentNode.NextNodeId);
                compiledNodes.Add(currentNode);
            }

            return new LinkedListResult(linkedListCollection, new LinkedList(compiledNodes), conflicts);
        }

        private static Node GetFirstNode(List<Node> nodes, out List<string> conflicts)
        {
            conflicts = new List<string>();

            var duplicateNodeIds = nodes.GroupBy(n => n.Id).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            if (duplicateNodeIds.Any())
            {
                conflicts.AddRange(duplicateNodeIds.Select(node => $"Node with ID {node.Id} uses a duplicate Node ID."));
            }

            var duplicateNextNodeIds = nodes.GroupBy(n => n.NextNodeId).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            if (duplicateNextNodeIds.Any())
            {
                conflicts.AddRange(duplicateNextNodeIds.Select(node => $"Node with ID {node.Id} points to the same next node as another."));
            }

            var unreferencedNodes = nodes.Where(s => !nodes.Select(n => n.NextNodeId).Contains(s.Id)).ToList();
            if (unreferencedNodes.Count > 1)
            {
                conflicts.AddRange(unreferencedNodes.Select(node => $"Node with ID {node.Id} is never referenced."));
            }

            var nonexistantNodeIds = nodes.Where(n => n.NextNodeId.HasValue).Select(n => (int) n.NextNodeId).Except(nodes.Select(n => n.Id)).ToList();
            if (nonexistantNodeIds.Any())
            {
                conflicts.AddRange(nonexistantNodeIds.Select(id => $"Node with ID {id} is referenced but does not exist."));
            }

            return unreferencedNodes.FirstOrDefault();
        }
    }
}