using System.Collections.Generic;

public class SpiralMatrix
{
    
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        int number = 1;
        int row = 0;
        int col = 0;
        char target = 'c'; // c = column, r = row
        char direction = '+'; // + or -
        int directionCount = 0; 
        
        // generate a list of lines length for the spiral
        List<int> lines = new List<int> { size };
        for (var i = (size - 1); i > 0; --i)
        {
            lines.Add(i);
            lines.Add(i);
        }

        foreach (int lineLength in lines)
        {
            for (int i = 0; i < lineLength; ++i)
            {
                matrix[row, col] = number;
                number++;

                // last item of the line, make the switch
                if (i == (lineLength - 1))
                {
                    target = target == 'c' ? 'r' : 'c';
                    directionCount++;
                    
                    // at 2, we need to switch direction operation
                    if (directionCount == 2)
                    {
                        direction = direction == '+' ? '-' : '+';
                        directionCount = 0;
                    }
                }
                
                // increment or decrement a column or a row
                if (target == 'c')
                    col = (direction == '+') ? col + 1 : col - 1;
                else
                    row = (direction == '+') ? row + 1 : row - 1;
            }
        }

        return matrix;
    }
}
