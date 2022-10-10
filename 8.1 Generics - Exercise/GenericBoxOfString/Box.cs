﻿namespace GenericBoxOfString
{
    internal class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        
        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }
}
