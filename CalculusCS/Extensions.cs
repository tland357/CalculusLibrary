using System.Linq;
using System;
using System.Collections.Generic;
namespace CalculusCS
{
    public static class Extensions
    {
        public static int indexOfLast(this string s, char x)
        {
            for (int i = s.Length - 1; i >= 0; i -= 1)
            {
                if (s[i] == x) return i;
            }
            return -1;
        }
        public static string RemoveWhiteSpace(this string s)
        {
            return s.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "");
        }
        public static Tuple<string[], int> SplitFirst(this string s, char x)
        {
            for (int i = 0; i < s.Length; i += 1)
            {
                if (s[i] == x)
                {
                    try
                    {
                        if (i == 0)
                        {
                            return new Tuple<string[], int>(new string[] { s.Substring(1) },i);
                        }
                        else if (i == s.Length - 1)
                        {
                            return new Tuple<string[], int>(new string[] { s.Substring(0, s.Length - 1) },i);
                        }
                        else
                        {
                            return new Tuple<string[], int>(new string[] { s.Substring(0, i - 1), s.Substring(i + 1) },i);
                        }
                    } catch (ArgumentOutOfRangeException ex)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
