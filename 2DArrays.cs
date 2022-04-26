using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {

        // init max
        int max = arr[0].GetRange(0,3).Sum() + arr[1][1] + arr[2].GetRange(0, 3).Sum();

        for (int i = 0; i < arr.Count - 2; i++)
        {

            for (int j = 0; j < arr[0].Count - 2; j++)
            {
                int current = arr[i].GetRange(j, 3).Sum() + arr[i + 1][j + 1] + arr[i + 2].GetRange(j, 3).Sum();
                if (max < current)
                {
                    max = current;   
                }
            }
        }

        return max;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        Console.WriteLine(result);
    }
}
