using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecLibrary
{
    public class CallNumberClass
    {
        // Variables
        private Random random; 
        private List<string> deweyNumbers; 

        //Getters and Setters
        public List<string> DeweyNumbers { get => deweyNumbers; set => deweyNumbers = value; }

        // Constructor
        public CallNumberClass()
        {
            random = new Random();
            DeweyNumbers = new List<string>();
        }

        //**********************************************************************************************//
        /// <summary>
        /// method that generates a random Dewey Decimal number and adds it to the list
        /// </summary>
        /// <returns> returns a randomly generated Dewey number </returns>
        /// <example> 005.73 JAM </example>
        //**********************************************************************************************//
        public string GenerateRandomDeweyDecimal()
        {
            try
            {
                
                var classNumber = random.Next(000, 1000);
                var divisionNumber = random.Next(100);

                // Generate random author initials (3 letters)
                var authorInitials = GenerateRandomInitials();

                var deweyNumber = $"{classNumber:D3}.{divisionNumber:D1} {authorInitials}"; // Constructs a string of the Dewey Number
                DeweyNumbers.Add(deweyNumber);

                return deweyNumber;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while generating Dewey Decimal: {ex.Message}");
                return null;
            }
        }

        // Method to generate random initials 
        private string GenerateRandomInitials()
        {
            try
            {
                var initials = new char[3];

                for (int i = 0; i < 3; i++)
                {
                    initials[i] = (char)random.Next('A', 'Z' + 1); // Generate a random uppercase letter
                }

                return new string(initials);
            } catch (Exception ex) 
            {
                Logger.WriteLog($"An error occurred while generating initials: {ex.Message}"); 
                return null; 
            }
        }

        //**********************************************************************************************//
        /// <summary>
        /// This method sorts the Dewey Decimal numbers using a modified version of the QuickSort algorithm
        /// </summary>
        /// <returns> sorted list of Dewey Decimal number </returns>
        //**********************************************************************************************//
        public List<string> SortDeweyNumbers()
        {
            try
            {
                QuickSort(DeweyNumbers, 0, DeweyNumbers.Count - 1);
                return DeweyNumbers;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while sorting Dewey Decimal numbers: {ex.Message}");
                return null;
            }
        }

        //**********************************************************************************************//
        /// <summary>
        /// Recursively performs Quick Sort on a list of Dewey Decimal numbers.
        /// </summary>
        /// <param name="deweyNumbers">The list of Dewey Decimal numbers to be sorted.</param>
        /// <param name="left">The left index of the subarray.</param>
        /// <param name="right">The right index of the subarray.</param>
        //**********************************************************************************************//
        private void QuickSort(List<string> deweyNumbers, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(deweyNumbers, left, right);
                QuickSort(deweyNumbers, left, pivotIndex - 1);
                QuickSort(deweyNumbers, pivotIndex + 1, right);
            }
        }

        //**********************************************************************************************//
        /// <summary>
        /// Partitions the list of Dewey Decimal numbers around a pivot.
        /// </summary>
        /// <param name="deweyNumbers">The list of Dewey Decimal numbers to be partitioned.</param>
        /// <param name="left">The left index of the subarray.</param>
        /// <param name="right">The right index of the subarray.</param>
        /// <returns>The index of the pivot after partitioning.</returns>
        //**********************************************************************************************//
        private int Partition(List<string> deweyNumbers, int left, int right)
        {
            string pivotValue = deweyNumbers[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (CompareDeweyNumbers(deweyNumbers[j], pivotValue) <= 0)
                {
                    i++;
                    Swap(deweyNumbers, i, j);
                }
            }

            Swap(deweyNumbers, i + 1, right);
            return i + 1;
        }

        //**********************************************************************************************//
        /// <summary>
        /// Compares two Dewey Decimal numbers for sorting.
        /// </summary>
        /// <param name="x">The first Dewey Decimal number.</param>
        /// <param name="y">The second Dewey Decimal number.</param>
        /// <returns>A negative integer if x is less than y, zero if they are equal, and a positive integer if x is greater than y.</returns>
        //**********************************************************************************************//

        private int CompareDeweyNumbers(string x, string y)
        {
            var componentsX = x.Split(' ', '.');
            var componentsY = y.Split(' ', '.');

            for (int i = 0; i < 2; i++)
            {
                var xPart = int.Parse(componentsX[i]);
                var yPart = int.Parse(componentsY[i]);

                if (xPart != yPart)
                {
                    return xPart.CompareTo(yPart);
                }
            }

            var xAlpha = componentsX[2];
            var yAlpha = componentsY[2];

            return string.Compare(xAlpha, yAlpha);
        }

        //**********************************************************************************************//
        /// <summary>
        /// Swaps two elements in a list of Dewey Decimal numbers.
        /// </summary>
        /// <param name="deweyNumbers">The list of Dewey Decimal numbers.</param>
        /// <param name="i">The index of the first element to be swapped.</param>
        /// <param name="j">The index of the second element to be swapped.</param>
        //**********************************************************************************************//
        private void Swap(List<string> deweyNumbers, int i, int j)
        {
            string temp = deweyNumbers[i];
            deweyNumbers[i] = deweyNumbers[j];
            deweyNumbers[j] = temp;
        }
       
    }
}
//------------------------------------------...ooo000 End of File 000ooo...----------------------------------------------------//
