public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        
        if (strs.Length == 1)
        {
            return strs[0];
        }
        
        string prefix = strs[0];
        
        for (int i = 1; i < strs.Length; i++)
        {
            if (prefix == "" || strs[i] == "")
            {
                return "";
            }
            
            if (prefix[0] != strs[i][0])
            {
                return "";
            }
            
            for (int j = 0; j < strs[i].Length; j++)
            {
                if (strs[i].Length == 1)
                {
                    if (strs[i][0] == prefix[0])
                    {
                        prefix = prefix.Substring(0, 1);
                        break;
                    }
                    else
                    {
                        return "";
                    }
                }
                
                if (j > prefix.Length-1)
                {
                    break;
                }
                
                if (prefix[j] != strs[i][j])
                {
                    prefix = prefix.Substring(0, j);
                    break;
                }
                
                if (strs[i].Length == j+1)
                {
                    prefix = strs[i];
                    break;
                }
            }
        }
        
        return prefix;
    }
}