public class Solution {
    public int StrongPasswordChecker(string password) {
        
        if (password.Length == 1)
        {
            if (Char.IsLetterOrDigit(password[0]))
            {
                return 5;
            }
            
            return 6;
        }
        
        int steps = 0;
        
        int missingChars = 0;
        int repeating = 0;
        int totalRepeating = 0;
        int additionalChars = 0;
        
        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        
        if (password.Length >= 2 && password.Length <= 5)
        {
            missingChars = 6 - password.Length;
        }
        
        if (password.Length > 20)
        {
            additionalChars = password.Length - 20;
        }
        
        if (Char.IsLetter(password[0]))
        {
            if (Char.IsUpper(password[0]))
            {
                hasUpper = true;
            }
            else
            {
                hasLower = true;
            }
        }

        if (Char.IsDigit(password[0]))
        {
            hasDigit = true;
        }
        
        for (int i = 1; i < password.Length; i++)
        {
            // System.Console.WriteLine(repeating);
            // System.Console.WriteLine(totalRepeating);
            // System.Console.WriteLine("---");
            
            if (password[i] == password[i-1])
            {
                repeating++;
            }
            else
            {
                if (repeating >= 2)
                {
                    totalRepeating += repeating - 1;
                }
                
                repeating = 0;
            }
            
            if (Char.IsLetter(password[i]))
            {
                if (Char.IsUpper(password[i]))
                {
                    hasUpper = true;
                }
                else
                {
                    hasLower = true;
                }
            }

            if (Char.IsDigit(password[i]))
            {
                hasDigit = true;
            }
        }
        
        if (repeating >= 2)
        {
            totalRepeating += repeating - 1;
        }
        
        int adjustedRepeating = 0;
        
        if (totalRepeating > 3)
        {
            adjustedRepeating = totalRepeating / 3;
            if (totalRepeating % 3 != 0)
            {
                adjustedRepeating++;
            }
        }
        else
        {
            adjustedRepeating = totalRepeating;
        }
        
        if (password.Length < 6)
        {
            if (hasUpper && hasLower && hasDigit)
            {
                return 6 - password.Length;
            }
        }
        
        if (password.Length > 20)
        {
            if (hasUpper && hasLower && hasDigit && totalRepeating == 0)
            {
                return password.Length - 20;
            }
        }
        
        adjustedRepeating += additionalChars;

        if (!hasUpper)
        {            
            if (missingChars > 0)
            {
                missingChars--;
            }
            
            if (adjustedRepeating > 0)
            {
                adjustedRepeating--;
            }
            
            steps++;
        }

        if (!hasLower)
        {
            if (missingChars > 0)
            {
                missingChars--;
            }
            
            if (adjustedRepeating > 0)
            {
                adjustedRepeating--;
            }
            
            steps++;
        }

        if (!hasDigit)
        {
            if (missingChars > 0)
            {
                missingChars--;
            }
            
            if (adjustedRepeating > 0)
            {
                adjustedRepeating--;
            }
            
            steps++;
        }
        
        System.Console.WriteLine(steps);
        System.Console.WriteLine(missingChars);
        System.Console.WriteLine(adjustedRepeating);
        
        return steps + missingChars + adjustedRepeating;
    }
}