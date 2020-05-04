using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        byte[] asciiBytes = Encoding.ASCII.GetBytes(text);

        if (shiftKey >= 26) 
            shiftKey = 0;
    
        for (int i = 0; i < asciiBytes.Length; ++i)
        {
            if (asciiBytes[i] >= 65 && asciiBytes[i] <= 90 
                || asciiBytes[i] >= 97 && asciiBytes[i] <= 122)
            {
                byte shiftResult = (byte)(asciiBytes[i] + shiftKey);
                
                // uppercase right circulation
                if (asciiBytes[i] <= 90 && shiftResult >= 90)
                {
                    shiftResult = (byte) (64 + (shiftResult - 90));
                }
                // lowercase right circulation
                else if (asciiBytes[i] <= 122 && shiftResult > 122)
                {
                    shiftResult = (byte) (96 + (shiftResult - 122));
                }

                asciiBytes[i] = shiftResult;
            }
        }

        return Encoding.ASCII.GetString(asciiBytes);
    }
}
