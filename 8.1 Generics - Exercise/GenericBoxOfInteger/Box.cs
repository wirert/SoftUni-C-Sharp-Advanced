namespace GenericBoxOfInteger
{
    public class Box<T> where T : struct
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        
        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}
