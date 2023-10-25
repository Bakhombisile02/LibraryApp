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
        private Dictionary<string, string> categorizedNumbers;

        public HashSet<string> DeweyNumbers1 { get => DeweyNumbers; set => DeweyNumbers = value; }
        public Dictionary<string, string> DeweyDictionary1 { get => DeweyDictionary; set => DeweyDictionary = value; }

        public IdAreas()
        {
            random = new Random();
            DeweyNumbers1 = new HashSet<string>();
            DeweyDictionary1 = new Dictionary<string, string>();
            categorizedNumbers = new Dictionary<string, string>(); // Initialize categorizedNumbers
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
                DeweyNumbers1.Add(deweyNumber);

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
        public Dictionary<string, string> CategorizeDeweyNumbers(HashSet<string> deweyNumbers)
        {
            try
            {
                Dictionary<(int, int), string> sections = new Dictionary<(int, int), string>
            {
                {(000, 099), "Geology"},
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



                foreach (string dewey in deweyNumbers)
                {
                    string[] deweyParts = dewey.Split(' ');
                    var classNumber = int.Parse(deweyParts[0].Split('.')[0]);
                    var divisionNumber = int.Parse(deweyParts[0].Split('.')[1]);

                    string sectionName = GetCategoryName(classNumber, sections);
                    string subsectionName = GetCategoryName(divisionNumber, subsections);

                    if (sectionName != null && subsectionName != null)
                    {
                        string category = $"{sectionName}, {subsectionName}";
                        categorizedNumbers.Add(category, dewey);
                    }
                }
                return categorizedNumbers;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while categorizing Dewey Decimal: {ex.Message}");
                return null;
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

        public void StartIdentifyingAreasGame()
        {
            try
            {
                // Generate questions and present to the user
                foreach (var category in categorizedNumbers.Keys)
                {
                    var question = $"What Dewey Decimal number falls under the {category} category?";

                    // Get options with one correct answer and three wrong answers
                    var options = GetRandomOptions(categorizedNumbers[category]);

                    // Display question and options to the user

                    // User selects an option and submits their answer

                    // Check if the selected option is correct

                    // Provide feedback to the user

                    // Update the score for gamification
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while starting the Identifying Areas game: {ex.Message}");
                // Handle any exceptions or errors
            }
        }


        public List<string> GetRandomOptions(string correctOption)
        {
            List<string> options = new List<string>();

            // Get other Dewey Decimal numbers (excluding the correct one)
            var incorrectOptions = categorizedNumbers.Values
                .Where(option => option != correctOption)
                .ToList();

            // Randomly select incorrect options
            var random = new Random();
            options.Add(correctOption); // Add the correct option first

            for (int i = 0; i < 3; i++)
            {
                var randomIncorrectOption = incorrectOptions[random.Next(incorrectOptions.Count)];
                options.Add(randomIncorrectOption);
                incorrectOptions.Remove(randomIncorrectOption); // Ensure no duplicates
            }

            // Shuffle the options to randomize their order
            options = options.OrderBy(o => random.Next()).ToList();

            return options;
        }






    }
}
