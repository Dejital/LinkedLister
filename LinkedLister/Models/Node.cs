namespace LinkedLister.Models
{
    public class Node
    {
        public Node(int id, int? nextNodeId, string value)
        {
            Id = id;
            NextNodeId = nextNodeId;
            Value = value;
        }

        public int Id { get; set; }

        public int? NextNodeId { get; set; }

        public string Value { get; set; }
    }
}