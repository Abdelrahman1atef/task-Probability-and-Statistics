using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the number of items: ");
            int n = int.Parse(Console.ReadLine());

            
            double[] values = new double[n];

            
            Console.WriteLine("Enter the items values: ");
            for (int i = 0; i < n; i++)
            {
                values[i] = double.Parse(Console.ReadLine());
            }

            
            Array.Sort(values);

            
            double median = GetMedian(values);
            Console.WriteLine("The median of the values is: " + median);

            
            double mode = GetMode(values);
            Console.WriteLine("The mode of the values is: " + mode);

            
            double range = GetRange(values);
            Console.WriteLine("The range of the values is: " + range);
            
            
            double firstQuartile = GetQuartile(values, 0.25);
            Console.WriteLine("The first quartile of the values is: " + firstQuartile);
            
            
            double thirdQuartile = GetQuartile(values, 0.75);
            Console.WriteLine("The third quartile of the values is: " + thirdQuartile);
            
            
            double p90 = GetPercentile(values, 0.90);
            Console.WriteLine("The P90 of the values is: " + p90);
            
            
            double interquartile = thirdQuartile - firstQuartile;
            Console.WriteLine("The interquartile of the values is: " + interquartile);
            
            
            double lowerBound = firstQuartile - 1.5 * interquartile;
            double upperBound = thirdQuartile + 1.5 * interquartile;
            Console.WriteLine("The boundaries of the outlier region are: [" + lowerBound + ", " + upperBound + "]");
            
            
            Console.WriteLine("Enter a value to check if it is an outlier or not: ");
            double value = double.Parse(Console.ReadLine());

            
            bool isOutlier = IsOutlier(value, lowerBound, upperBound);
            if (isOutlier)
                Console.WriteLine("The value " + value + " is an outlier.");
            else
                Console.WriteLine("The value " + value + " is not an outlier.");
            Console.ReadKey();  
        }

        
        static double GetMedian(double[] arr)
        {
            int n = arr.Length;

           
            if (n % 2 == 1)
                return arr[n / 2];

            else
                return (arr[n / 2 - 1] + arr[n / 2]) / 2;
        }

        static double GetMode(double[] arr)
        {
            double mode = 0;
            int maxFreq = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currFreq = 1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                     if (arr[i] == arr[j])
                        currFreq++;
                }

                if (currFreq > maxFreq)
                {
                    mode = arr[i];
                    maxFreq = currFreq;
                }

                else if (currFreq == maxFreq && arr[i] < mode)
                {
                    mode = arr[i];
                }
            }

            return mode;
        }
        
                static double GetRange(double[] arr)
                {
                    return arr[arr.Length - 1] - arr[0];
                }

                static double GetQuartile(double[] arr, double fraction)
                {
                    int n = arr.Length;
                    double k = (fraction) * (n + 1);

            if (k % 1 == 0)
                    {
                        return ((arr[((int)(k - 1))] ) );
                    }
                    else 
                    {
                
                
                return ((arr[(int)(k - 1)] + arr[(int)k]) / 2);
            }

        }

                static double GetPercentile(double[] arr, double fraction)
                {
                    return GetQuartile(arr, fraction);
                }
        
                static bool IsOutlier(double value, double lowerBound, double upperBound)
                {
                    return value < lowerBound || value > upperBound;
                }


    }
}
