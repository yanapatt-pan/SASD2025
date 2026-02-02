using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp;

public static class StringUtil
{
    public static string Half(this string s)
    {
        return s.Substring(0, s.Length / 2);
    }

    // Exercise 7
    public static string SecondHalf(this string s)
    {
        return s.Substring(s.Length / 2);
    }
}

