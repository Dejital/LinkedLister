using System.Collections.Generic;

namespace LinkedLister.Models
{
    public class LinkedList
    {
        public LinkedList()
        {
            Nodes = new List<Node>();
        }

        public ICollection<Node> Nodes { get; set; }
    }
}