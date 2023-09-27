using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecLibrary
{
    public class CallNumberClass
    {
        private Random random; // Random number generator 
        private List<string> deweyNumbers; // List to store values 

        // Property to access the list of Dewey Decimal numbers
        public List<string> DeweyNumbers { get => deweyNumbers; set => deweyNumbers = value; }

        // Constructor
        public CallNumberClass()
        {
            random = new Random();
            DeweyNumbers = new List<string>();
        }

        // Method that generates a random Dewey Decimal number and adds it to the list
        public string GenerateRandomDeweyDecimal()
        {
            int classNumber = random.Next(000, 1000);
            int divisionNumber = random.Next(100);

            // Generate random author initials (3 letters)
            string authorInitials = GenerateRandomInitials();

            string deweyNumber = $"{classNumber:D3}.{divisionNumber:D1} {authorInitials}"; // Constructs a string of the Dewey Number
            DeweyNumbers.Add(deweyNumber);

            return deweyNumber;
        }

        // Method to generate random initials 
        private string GenerateRandomInitials()
        {
            char[] initials = new char[3];

            for (int i = 0; i < 3; i++)
            {
                initials[i] = (char)random.Next('A', 'Z' + 1); // Generate a random uppercase letter
            }

            return new string(initials);
        }

        // Method to get all the items in the list 
        public List<string> GetDeweyNumbers()
        {
            return DeweyNumbers;
        }

        // Method to sort Dewey numbers and store them in a list 
        public List<string> SortDeweyNumbers()
        {
            DeweyNumbers.Sort((x, y) =>
            {
                // Split Dewey Decimal into components for sorting 
                string[] componentsX = x.Split(' ', '.');
                string[] componentsY = y.Split(' ', '.');

                // Compare the numerical components
                for (int i = 0; i < 2; i++)
                {
                    int xPart = int.Parse(componentsX[i]);
                    int yPart = int.Parse(componentsY[i]);

                    if (xPart != yPart)
                    {
                        return xPart.CompareTo(yPart);
                    }
                }

                // If numerical components are equal, compare the alphabeticals
                string xAlpha = componentsX[2];
                string yAlpha = componentsY[2];

                // Compare the alphabetical components
                return string.Compare(xAlpha, yAlpha);
            });

            return DeweyNumbers;
        }
    }
}
//------------------------------------------End of File-------------------------------------//
