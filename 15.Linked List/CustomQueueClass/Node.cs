namespace CustomQueueClass
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
