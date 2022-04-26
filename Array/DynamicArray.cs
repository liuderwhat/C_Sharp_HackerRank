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
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
        int lastNumber = 0;
        List<int> res = new List<int>();
        List<List<int>> arrList = new ();
        List<int> arr = new ();

        // init the answer list....
        for (int i = 0; i < n; i++)
        {
            arr = new List<int>();
            arrList.Add(arr);
        }

        for (int i = 0; i < queries.Count; i++)
        {

            if (queries[i][0] == 1)
            {
                int idx = (queries[i][1] ^ lastNumber) % n;
                Console.WriteLine(i + " : " + idx);
                arrList[idx].Add(queries[i][2]);
            }
            else
            {
                int idx = (queries[i][1] ^ lastNumber) % n;
                Console.WriteLine(i + " : " + idx);
                lastNumber = arrList[idx][queries[i][2] % arrList[idx].Count];
                res.Add(lastNumber);
            }
        }

        return res;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.dynamicArray(n, queries);

        foreach(int ele in result)
        {
            Console.WriteLine(ele);
        }
        
    }
}
