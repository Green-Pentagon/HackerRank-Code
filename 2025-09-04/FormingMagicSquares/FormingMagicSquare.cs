//This solution solves 2 of 23 test cases.
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
    int cLocked = 0;
    int catcher = 100;
    int cCell = 0;
    int changeCount = 0;

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

    
    int[] cSums = new int[8];

    while (cLocked < 9 && cCell < 9 && catcher > 0)
    {
        catcher--;
        //stores the value of each row, column, and diagonal
        //also does checks for if any values get locked.
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

        cLocked = 0;
        foreach (bool b in locked)
        {
            if (b)
            {
                cLocked++;
            }
        }
        if (cLocked == 9) {  
            break;
        }
        
        //if the current value is not locked
        if (!locked[cCell])
        {
            changeCount++;

            int rowDiff = target - cSums[cCell % 3];
            int colDiff = target - cSums[3 + (cCell % 3)];
            if (((2*rowDiff))/2 > ((2 * colDiff)) / 2) {
                if (((2 * colDiff)) / 2 > (9-cCell)){
                    //if the difference is more than this single value can alter to match target
                    if (colDiff < 0)
                    {
                        grid[cCell] = 1;
                    }
                    else
                    {
                        grid[cCell] = 9;
                    }
                }
                else
                {
                    grid[cCell] += colDiff;
                }
            }
            else
            {
                if (((2 * rowDiff)) / 2 > (9 - cCell))
                {
                    //if the difference is more than this single value can alter to match target
                    if (rowDiff < 0)
                    {
                        grid[cCell] = 1;
                    }
                    else
                    {
                        grid[cCell] = 9;
                    }
                }
                else
                {
                    grid[cCell] += rowDiff;
                }
            }
            //if (cCell == 0)
            //{
            //    //check the 0th, 3rd, and 6th value in sums
            //    //see if any match?
            //    //change to have the most of them match
            //}
        }

        cCell++;
    }

    return changeCount;

    
}


//===============================================
void main()
{
    List<List<int>> magicSquareIn = new List<List<int>>()
    {
        new List<int> { 5, 3, 4 },
        new List<int> { 1, 5, 8 },
        new List<int> { 6, 4, 2 }
    };

    Console.WriteLine(formingMagicSquare(magicSquareIn));

}

main();