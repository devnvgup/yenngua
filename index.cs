using System;

class Program
{
    static void Main()
    {
        int dong = 3;
        int cot = 4;
        int[][] arr = new int[][]
        {
            new int[] {2, 0, 5, -3},
            new int[] {8, 0, 7, 5},
            new int[] {5, 0, 11, 4}
        };

        int[][] res = new int[dong][];
        for (int i = 0; i < dong; i++)
        {
            int max = FindMax(arr[i]);
            int count = CountMax(arr[i], max);

            res[i] = new int[count * 2];
            int colIndex = 0;

            for (int j = 0; j < cot; j++)
            {
                if (arr[i][j] == max)
                {
                    res[i][colIndex++] = arr[i][j];
                    res[i][colIndex++] = j;
                }
            }
        }

        int[][] final = new int[dong][];
        int finalCount = 0;

        for (int i = 0; i < dong; i++)
        {
            for (int j = 0; j < res[i].Length; j += 2)
            {
                if (CheckCondition(res[i][j], res[i][j + 1], dong, arr))
                {
                    final[finalCount++] = new int[] { res[i][j], i, res[i][j + 1] };
                }
            }
        }

        PrintResult(final, finalCount);
    }

    static int FindMax(int[] array)
    {
        int max = array[0];
        foreach (var item in array)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }

    static int CountMax(int[] array, int max)
    {
        int count = 0;
        foreach (var item in array)
        {
            if (item == max)
            {
                count++;
            }
        }
        return count;
    }

    static bool CheckCondition(int value, int colIndex, int dong, int[][] arr)
    {
        for (int k = 0; k < dong; k++)
        {
            if (value > arr[k][colIndex])
            {
                return false;
            }
        }
        return true;
    }

    static void PrintResult(int[][] final, int finalCount)
    {
        for (int i = 0; i < finalCount; i++)
        {
            Console.WriteLine($"[{final[i][0]}, {{Row: {final[i][1]}, Col: {final[i][2]}}}]");
        }
    }
}
