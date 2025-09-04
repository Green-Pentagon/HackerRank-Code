//This current solution passes 22 of 33 test cases.
//https://www.hackerrank.com/challenges/two-characters

//Given a string, remove characters until the string is made up of any two alternating characters.
//When you choose a character to remove, all instances of that character must be removed.
//Determine the longest string possible that contains just two alternating letters.

static int alternate(string s)
{
    string cString = s;
    int longestLen = 0;
    bool valid = true;

    List<char> uniqueChars = new List<char>();
    foreach(char c in s)
    {
        if (!uniqueChars.Contains(c))
        {
            uniqueChars.Add(c);
        }
    }
    if (uniqueChars.Count == 0)
    {
        return 0;
    }

    //optimisation: remove redundant runs
    for(int a = 0; a < uniqueChars.Count - 1; a++)
    {
        for (int b = uniqueChars.Count - 1; b > 0 ; b--)
        {
            cString = s;
            valid = true;
            if (a == b) { break; }

            //remove non-pair characters
            for(int i = cString.Length-1; i > 0; i--)
            {
                if (cString[i] != uniqueChars[a] && cString[i] != uniqueChars[b])
                {
                    cString = cString.Remove(i, 1);
                }
            }

            //check validity
            for (int i = 0; i < cString.Length - 1; i += 2)
            {
                if (cString[i] == cString[i + 1])
                {
                    valid = false;
                    break;
                }
            }
            //if valid, get length
            if (valid)
            {
                if (longestLen < cString.Length)
                {
                    longestLen = cString.Length;
                }
            }
        }

        
    }

    return longestLen;
}

Console.WriteLine(alternate("beabeefeab"));