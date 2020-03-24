
/* https://www.codewars.com/kata/57a0e5c372292dd76d000d7e/train/csharp */
using System;



namespace Solution
{
    public static class Program
    {
        public static string repeatStr(int n, string s)
        {
            string buf = null;
            for (int i = 0; i < n; ++i)
            {
                buf = buf + s;
            }
            return buf;
        }
    }
}