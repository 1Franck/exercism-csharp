using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private Queue<T> buffer;
    private readonly int capacity;
    
    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        buffer = new Queue<T>(capacity);
    }

    public T Read()
    {
        return buffer.Dequeue();
    }

    public void Write(T value)
    {
        if (buffer.Count == capacity)
        {
            throw new InvalidOperationException("Buffer full");
        }
        buffer.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (buffer.Count < capacity)
        {
            buffer.Enqueue(value);
        }
        else
        {
            buffer.Dequeue();
            buffer = new Queue<T>(buffer.Append(value));
        }
    }

    public void Clear()
    {
        buffer.Clear();       
    }
}