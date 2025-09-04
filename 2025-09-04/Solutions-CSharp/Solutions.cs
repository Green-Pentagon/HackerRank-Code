using System.Collections.Generic;

static int solveMeFirst(int a, int b)
{
    // Hint: Type return a+b; below  
    return a + b;
}

//-----------------------------------------------
//https://www.hackerrank.com/challenges/magic-square-forming
//We define a magic square to be an n x n matrix of distinct positive integers from 1 to n^2 where the sum of any row, column, or diagonal of length n is always equal to the same number: the magic constant.

//You will be given a 3x3 matrix of integers in the inclusive range [1,9].
//We can convert any digit a to any other digit b in the range [1,9] at cost of |a-b|. Given s, convert it into a magic square at minimal cost. Print this cost on a new line.

//a magic square of 3x3 is constructed as follows:

// c - b , c + (a+b) , c - a
// c - (a - b) , c , c - (a - b)
// c + a , c - (a+b) ,  c + b

// the magic constant for this table is equal to 3c
// as long as 0 < a < b < c − a and b ≠ 2a


static int formingMagicSquare(List<List<int>> s)
{

    //one solution for this is to find the b and c values for the solved square and adjust any of the values which do not match the equations for each cell.

    //Example:


    //c = 5, M = 3c = 15
    //sum of top row is 12
    // r1 = 5 - b, r2 = 5 + (a+b), r3 = 5 - a
    //3c = 15, in this case 3c = 12,therefore a value has to be increased by 2

    //check all rows and columns and diagonals to see if any of them already match the sum of 3c
    // if any of them match the sum, mark them as completed
    // check each value:
    //  - if it exists in a completed row/column/diagonal (sum == 3c), skip
    //  - if not, check the difference of the row/column/diagonal values against 3c
    //      - if the difference keeps the cell within the range [0,9], change the value of that cell to whichever row/column/diagonal has the largest difference.
    //      - (might not be a needed step?) if all of the differences causes the value to become greater than 9 or less than 0, change the value of the cell to the largest possible value.
    // - run through all cells to check their row/colum/diagonal values, until all cells are classed as completed

    bool[] locked = new bool[9];
    int[] grid = new int[9];
    int target;

    int index = 0; //populate array
    foreach (List<int> l in s)
    {
        foreach (int i in l)
        {
            grid[index] = i;
            index++;
        }
    }

    target = 3 * grid[4];

    //stores the value of each row, column, and diagonal
    //also does checks for if any values get locked.
    int[] cSums = new int[8];

    for (int i = 0; i < 3; i++)
    {
        //diagonal fills
        if (i == 0)
        {
            cSums[6] = grid[i] + grid[4] + grid[8];
            if (cSums[6] == target)
            {
                locked[i] = true;
                locked[4] = true;
                locked[8] = true;
            }
        }

        if (i == 2)
        {
            cSums[7] = grid[i] + grid[4] + grid[6];
            if (cSums[7] == target)
            {
                locked[i] = true;
                locked[4] = true;
                locked[6] = true;
            }
        }

        cSums[i] = grid[i * 3] + grid[i * 3 + 1] + grid[i * 3 + 2]; //row fill
        if (cSums[i] == target)
        {
            locked[i * 3] = true;
            locked[i * 3 + 1] = true;
            locked[i * 3 + 2] = true;
        }
        cSums[i + 3] = grid[i] + grid[i + 3] + grid[i + 6]; //column fill

        if (cSums[i + 3] == target)
        {
            locked[i] = true;
            locked[i + 3] = true;
            locked[i + 6] = true;
        }
    }


    return -1;

    
}


//===============================================
void main()
{
    //Console.WriteLine(solveMeFirst(1, 2));
    List<List<int>> magicSquareIn = new List<List<int>>()
    {
        new List<int> { 5, 3, 4 },
        new List<int> { 1, 5, 8 },
        new List<int> { 6, 4, 2 }
    };

    formingMagicSquare(magicSquareIn);

}

main();