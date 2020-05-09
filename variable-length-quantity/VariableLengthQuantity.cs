using System;
using System.Collections.Generic;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        List<uint> output = new List<uint>();
        foreach (var num in numbers)
        {
            var encBytes = new List<uint>();
            encBytes.Insert(0, num & 0b_0111_1111);
            uint tmp = num;
            while (tmp >> 7 != 0)
            {
                tmp >>= 7;
                encBytes.Insert(0, (tmp | 0b_1000_0000) % 256);
            }
            output.AddRange(encBytes);
        }
        return output.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        List<uint> output = new List<uint>();
        uint tmp = 0;
        foreach (var b in bytes)
        {
            if ((b & 1 << 7) != 0)
                tmp = (tmp + (b & 0b_0111_1111)) << 7;
            else
            {
                output.Add(tmp + b);
                tmp = 0;
            }
        }

        return output.Count != 0 ? output.ToArray() : throw new InvalidOperationException();
    }
}