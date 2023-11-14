using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<object> CheckYenNgua()
    {
        int dong = 3;
        int cot = 4;
        int[,] arr = new int[,]
        {
            {2, 0, 5, -3},
            {8, 0, 7, 5},
            {5, 0, 11, 4}
        };

        List<object> result = new List<object>();
        Dictionary<string, int> hashMap = new Dictionary<string, int>();

        for (int i = 0; i < dong; i++)
        {
            int[,] clone = (int[,])arr.Clone();

            List<int> maxArr = new List<int>();
            for (int j = 0; j < cot; j++)
            {
                maxArr.Add(clone[i, j]);
            }
            maxArr.Sort();

            int maxVal = maxArr[cot - 1];

            for (int j = 0; j < cot; j++)
            {
                if (arr[i, j] == maxVal)
                {
                    hashMap[$"{arr[i, j]}"] = j;
                    result.Add(arr[i, j]);
                }
            }
        }

        return Check(hashMap, result, dong, arr);
    }

    static List<object> Check(Dictionary<string, int> map, List<object> res, int dong, int[,] arr)
    {
        List<object> result = new List<object>();
        int k = 0;
        while (k < res.Count)
        {
            bool conditionSmallest = true;
            int value = (int)res[k];
            int index = map[value.ToString()];

            for (int i = 0; i < dong; i++)
            {
                if (arr[i, index] < value)
                {
                    conditionSmallest = false;
                    break;
                }
            }

            if (conditionSmallest)
            {
                result.Add(value);
                result.Add(new Dictionary<string, object> { { "Position", new int[] { k, index } } });
            }

            k++;
        }

        return result;
    }

    static void Main()
    {
        var result = CheckYenNgua();
        if (!result.Any())
{
        Console.WriteLine("Khong co gia tri nao thoa man dieu kien");
        return ;
}

        foreach (var item in result)
        {
            if (item is int)
            {
                Console.Write($"value={item} ");
            }
            else if (item is Dictionary<string, object>)
            {
                var position = ((Dictionary<string, object>)item)["Position"];
                Console.WriteLine($"Position: [{((int[])position)[0]}, {((int[])position)[1]}]");
            }
        }
    }
}