using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coolOrange_CandidateChallenge
{
    public class PalindromeChecker
    {
        public static bool IsPalindrome(string s)
        {
            // TODO
            s = s.ToLower();

            char[] chars= s.ToCharArray();

            for (int i = 0; i < chars.Length/2; i++)
            {
                if (chars[i] != chars[chars.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
