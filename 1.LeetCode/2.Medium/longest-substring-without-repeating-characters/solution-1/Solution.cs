public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
        // hard code trivial cases
        if (s.Length == 0 || s.Length == 1)
        {
            return s.Length;
        }
        
        if (s.Length == 2)
        {
            if (s[0] != s[1])
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        
        string c = ""; // current longest substring
        string p = s[0].ToString(); // potential new longest substring
        int k = 1; // potential new longest substring start index
        
        // loop through characters of s
        for (int i = 1; i < s.Length; i++)
        {            
            // loop through characters of potential new longest substring
            for (int j = 0; j < p.Length; j++)
            {
                // if current character in s in found in potential new longest substring
                if (p[j] == s[i])
                {
                    // if the potential new longest substring is longer than the current longest substring
                    if (p.Length > c.Length)
                    {
                        // set the potential new longest substring as the current longest substring
                        c = p;
                    }
                    
                    // start over search
                    p = "";
                    i = k;
                    k++;
                    
                    // exit loop through characters of potential new longest substring
                    j = int.MaxValue - 1;
                }
            }
            
            // add character to potential new longest substring
            p += s[i];
        }
        
        // if potential new longest substring is longer than current longest substring
        if (p.Length > c.Length)
        {
            // potential new longest substring becomes current longest substring
            c = p;
        }
        
        return c.Length;
    }
}