//This solution passes all test cases.
//https://www.hackerrank.com/challenges/reduced-string

//Reduce a string of lowercase characters in range ascii[‘a’..’z’] by doing a series of operations. In each operation, select a pair of adjacent letters that match, and delete them.
//Delete as many characters as possible using this method and return the resulting string. If the final string is empty, return Empty String.

static string superReducedString(string s)
{
    string finalString = s;
    bool cleanPass = false;
    while (!cleanPass && finalString.Length > 0)
    {
        cleanPass = true;
        for (int i = finalString.Length-1; i > 0 ; i--)
        {
            if (finalString[i] == finalString[i - 1])
            {
                //remove pair
                finalString = finalString.Remove(i - 1, 2);
                cleanPass = false;
                break;
            }
        }
    }
    if (finalString.Length > 0)
    {
        return finalString;
    }

    return "Empty String";
}


Console.WriteLine(superReducedString("aaabccddd"));