using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecLibrary
{
    /// <summary>
    /// This a portion of this code is based on a tutorial by [CodeX]
    ///The original code can be found at[https://www.youtube.com/watch?v=wykQ84cSfuM&list=PPSV]
    ///Modifications were made to the code to buid the tree in a hierarchical manner and restructure the tree
    /// </summary>
    public class FindingCallNum
    {

        public void loadtree()
        {
            string filePath = "Library.txt"; 

            // Read categories from the file
            List<TreeNode> categories = ReadCategoriesFromFile(filePath);

            // Construct the tree
            TreeNode deweyRoot = ConstructTree(categories);

            // Display the tree
            deweyRoot.DisplayTree();
        }


        //******************************************************************************//
        /// <summary>
        /// Method to read dcimal numbers from a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        //******************************************************************************//
        List<TreeNode> ReadCategoriesFromFile(string filePath)
        {
            List<TreeNode> categories = new List<TreeNode>();

            try
            {
                // Read each line from the file
                foreach (var line in File.ReadLines(filePath))
                {
                    string[] parts = line.Split(' ');
                    string code = parts[0].Trim();
                    string name = string.Join(" ", parts.Skip(1)).Trim();
                    // Create a TreeNode and add it to the list
                    categories.Add(new TreeNode(code, name));

                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"File not found: {filePath}");
                Console.WriteLine($"File not found: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return categories;
        }


        //******************************************************************************//
        /// <summary>
        /// Method to construct a tree as a multi-level list of call numbers
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        //******************************************************************************//
        TreeNode ConstructTree(List<TreeNode> categories)
        {
            TreeNode deweyRoot = new TreeNode("Dewey", "Dewey Decimal System");

            foreach (var category in categories)
            {
                string categoryCode = category.Code;

                // Check if the category code is 000, 100, 200, 300, 400, 500, 600, 700, 800, or 900
                if (categoryCode.Length == 3 && categoryCode.All(char.IsDigit))
                {
                    int mainCategoryCodeValue = int.Parse(categoryCode);

                    if (mainCategoryCodeValue % 100 == 0)
                    {
                        TreeNode mainCategoryNode = new TreeNode(category.Code, category.Name);
                        deweyRoot.AddChild(mainCategoryNode);

                       

                        // Now, let's add subcategories like 010, 020, 030, etc.
                        foreach (var subCategory in categories)
                        {
                            string subCategoryCode = subCategory.Code;
                            int currentSubCategoryCodeValue = int.Parse(subCategoryCode);

                            // Check if the subcategory code belongs to the current main category
                            if (subCategoryCode.Length == 3 && subCategoryCode.All(char.IsDigit) &&
                                currentSubCategoryCodeValue > mainCategoryCodeValue &&
                                currentSubCategoryCodeValue < mainCategoryCodeValue + 100 &&
                                currentSubCategoryCodeValue % 10 == 0)
                            {
                                TreeNode currentSubCategoryNode = new TreeNode(subCategory.Code, subCategory.Name);
                                mainCategoryNode.AddChild(currentSubCategoryNode);

                                // Now, let's check for low-level categories like 001 or 113
                                foreach (var lowCategory in categories)
                                {
                                    string lowCategoryCode = lowCategory.Code;
                                    int lowCategoryCodeValue = int.Parse(lowCategoryCode);
                                    //Console.WriteLine(lowCategoryCode);

                                    // Check if the low-level category belongs to the current subcategory or main category
                                    if ((lowCategoryCode.Length == 3 && lowCategoryCode.All(char.IsDigit) &&
                                        lowCategoryCodeValue >= currentSubCategoryCodeValue &&
                                        lowCategoryCodeValue < currentSubCategoryCodeValue + 10))
                                    {
                                        TreeNode lowCategoryNode = new TreeNode(lowCategory.Code, lowCategory.Name);
                                        currentSubCategoryNode.AddChild(lowCategoryNode);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return deweyRoot;
        }



    }
}
//----------------------------------...ooo000 END OF FILE 000ooo...----------------------------------//