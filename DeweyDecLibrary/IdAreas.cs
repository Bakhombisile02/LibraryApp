using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecLibrary
{
    public class IdAreas
    {
        private Random random;
        private HashSet<string> DeweyNumbers;
        private Dictionary<string, string> DeweyDictionary;

        public IdAreas()
        {
            random = new Random();
            DeweyNumbers = new HashSet<string>();
            DeweyDictionary = new Dictionary<string, string>();
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
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while generating initials: {ex.Message}");
                return null;
            }
        }
        //**********************************************************************************************//
        /// <summary>
        /// Creates a dictionary of Dewey Decimal numbers and their corresponding categories
        /// </summary>
        /// <param name="dewey"></param>
        /// <returns></returns>
        //**********************************************************************************************//
        public (string, string) CategorizeDeweyDecimal(string dewey)
        {
            try
            {
                Dictionary<(int, int), string> sections = new Dictionary<(int, int), string>
            {
                {(100, 199), "Biology"},
                {(200, 299), "Chemistry"},
                {(300, 399), "Physics"},
                {(400, 499), "Mathematics"},
                {(500, 599), "Technology"},
                {(600, 699), "Medicine"},
                {(700, 799), "Arts"},
                {(800, 899), "Literature"},
                {(900, 999), "History"},
                // Add more sections as needed
            };

                Dictionary<(int, int), string> subsections = new Dictionary<(int, int), string>
            {
                {(0, 9), "General"},
                {(10, 19), "System Overview"},
                {(20, 29), "Processes"},
                {(30, 39), "Methods"},
                {(40, 49), "Applications"},
                {(50, 59), "Techniques"},
                {(60, 69), "Tools"},
                {(70, 79), "Materials"},
                {(80, 89), "Principles"},
                {(90, 99), "Miscellaneous"},
                // Add more subsections as needed
            };

                string[] deweyParts = dewey.Split(' ');
                var classNumber = int.Parse(deweyParts[0].Split('.')[0]);
                var divisionNumber = int.Parse(deweyParts[0].Split('.')[1]);
                var authorInitials = deweyParts[1];

                var sectionName = GetCategoryName(classNumber, sections);
                var subsectionName = GetCategoryName(divisionNumber, subsections);

                var category = $"{sectionName}, {subsectionName}";
                return (category, dewey);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while categorizing Dewey Decimal: {ex.Message}");
                return (null, null);
            }
        }

       

        private string GetCategoryName(int category, Dictionary<(int, int), string> categories)
        {
            foreach (var range in categories.Keys)
            {
                if (category >= range.Item1 && category <= range.Item2)
                {
                    return categories[range];
                }
            }
            return null;
        }




    }
}
