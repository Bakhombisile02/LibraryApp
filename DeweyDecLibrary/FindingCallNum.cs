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
        //Variables
        private TreeNode deweyRoot;
        private TreeNode randomLowCategoryNode;
        private TreeNode parent;
        private TreeNode grandparent;
        private List<TreeNode> childNodes = new List<TreeNode>();
        private List<TreeNode> parentNodes = new List<TreeNode>();
        private List<TreeNode> grandparentNodes = new List<TreeNode>();

        //Getters and Setters
        public TreeNode RandomLowCategoryNode { get => randomLowCategoryNode; set => randomLowCategoryNode = value; }
        public List<TreeNode> ChildNodes { get => childNodes; set => childNodes = value; }
        public List<TreeNode> ParentNodes { get => parentNodes; set => parentNodes = value; }
        public List<TreeNode> GrandparentNodes { get => grandparentNodes; set => grandparentNodes = value; }
        public TreeNode Parent { get => parent; set => parent = value; }
        public TreeNode Grandparent { get => grandparent; set => grandparent = value; }

        /// <summary>
        /// Method to set data into the tree
        /// </summary>
        public void Settree()
        {
            try
            {
                string filePath = "Library.txt";

                // Read categories from the file
                var categories = ReadCategoriesFromFile(filePath);

                // Construct the tree
                deweyRoot = ConstructTree(categories); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting tree. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error setting tree: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to Get Random third level entry from the data and find its parent and grandparent
        /// </summary>
        public void loadtree()
        {
            try
            {
                // Get a random low category node
                RandomLowCategoryNode = GetRandomLowCategoryNode();

                if (RandomLowCategoryNode != null)
                {


                    // Find  the parent node
                    Parent = FindParent(deweyRoot, RandomLowCategoryNode);

                    if (Parent != null)
                    {


                        // Find  the grandparent node
                        Grandparent = FindParent(deweyRoot, Parent);

                        if (Grandparent != null)
                        {


                            // Save nodes to lists
                            ChildNodes = new List<TreeNode> { RandomLowCategoryNode };
                            ParentNodes = new List<TreeNode> { Parent };
                            GrandparentNodes = new List<TreeNode> { Grandparent };

                            // Generate random wrong answers for childNodes, parentNodes, and grandparentNodes
                            GenerateRandomWrongAnswers(ChildNodes, ParentNodes, GrandparentNodes);

                            GrandparentNodes = GrandparentNodes.OrderBy(node => int.Parse(node.Code)).ToList();
                            ParentNodes = ParentNodes.OrderBy(node => int.Parse(node.Code)).ToList();
                            ChildNodes = ChildNodes.OrderBy(node => int.Parse(node.Code)).ToList();

                        }
                        else
                        {
                            
                            MessageBox.Show("No grandparent found for the Random Low Category Node.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                            MessageBox.Show("No parent found for the Random Low Category Node.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                else
                {
                    MessageBox.Show("No random Low Category Node found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tree. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error loading tree: {ex.Message}");
            }
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to generate random wrong answers for childNodes, parentNodes, and grandparentNodes
        /// </summary>
        /// <param name="childNodes"></param>
        /// <param name="parentNodes"></param>
        /// <param name="grandparentNodes"></param>
        private void GenerateRandomWrongAnswers(List<TreeNode> childNodes, List<TreeNode> parentNodes, List<TreeNode> grandparentNodes)
        {
            try
            {
                // Generate random wrong answers for childNodes
                GenerateWrongNodes(childNodes, 4);

                // Generate random wrong answers for parentNodes

                GenerateWrongParentNodes(parentNodes, 4);

                // Generate random wrong answers for grandparentNodes

                GenerateWrongGrandparentNodes(grandparentNodes, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating random wrong answers. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error generating random wrong answers: {ex.Message}");
            }
        }

        /// <summary>
        ///  generate wrong answers for childNodes (level 3)
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="count"></param>
        private void GenerateWrongNodes(List<TreeNode> nodes, int count)
        {
            try
            {
                Random random = new Random();

                while (nodes.Count < count)
                {
                    TreeNode wrongNode = GetRandomLowCategoryNode();

                    if (wrongNode != null && !nodes.Contains(wrongNode))
                    {
                        nodes.Add(wrongNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating wrong nodes. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error generating wrong nodes: {ex.Message}");
            }
        }

        /// <summary>
        /// generate wrong answers for parentNodes (level 2)
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="count"></param>
        private void GenerateWrongParentNodes(List<TreeNode> nodes, int count)
        {
            try
            {
                Random random = new Random();

                while (nodes.Count < count)
                {
                    TreeNode wrongNode = GenerateSubCategoryNode();

                    if (wrongNode != null && !nodes.Contains(wrongNode))
                    {
                        nodes.Add(wrongNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating wrong parent nodes. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error generating wrong parent nodes: {ex.Message}");
            }
        }

        /// <summary>
        /// generate wrong answers for grandparentNodes (level 1)
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="count"></param>
        private void GenerateWrongGrandparentNodes(List<TreeNode> nodes, int count)
        {
            try
            {
                Random random = new Random();

                while (nodes.Count < count)
                {
                    TreeNode wrongNode = GenerateMainCategoryNode();

                    if (wrongNode != null && !nodes.Contains(wrongNode))
                    {
                        nodes.Add(wrongNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating wrong grandparent nodes. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error generating wrong grandparent nodes: {ex.Message}");
            }
        }


        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to read dcimal numbers from a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<TreeNode> ReadCategoriesFromFile(string filePath)
        {
            try
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
                    MessageBox.Show($"File not found: {filePath} . check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLog($"File not found: {filePath}");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLog($"Error occured: {ex.Message}");
                }

                return categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading categories from file. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error reading categories from file: {ex.Message}");
                return null;
            }
        }


        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to construct a tree as a multi-level list of call numbers
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        TreeNode ConstructTree(List<TreeNode> categories)
        {
            try
            {
                deweyRoot = new TreeNode("Dewey", "Dewey Decimal System");

                foreach (var mainCategory in categories.Where(c => c.Code.Length == 3 && c.Code.All(char.IsDigit)))
                {
                    int mainCategoryCodeValue = int.Parse(mainCategory.Code);

                    if (mainCategoryCodeValue % 100 == 0)
                    {
                        TreeNode mainCategoryNode = new TreeNode(mainCategory.Code, mainCategory.Name);
                        deweyRoot.AddChild(mainCategoryNode);

                        foreach (var subCategory in categories
                            .Where(c => c.Code.Length == 3 && c.Code.All(char.IsDigit) &&
                                        int.Parse(c.Code) > mainCategoryCodeValue &&
                                        int.Parse(c.Code) < mainCategoryCodeValue + 100 &&
                                        int.Parse(c.Code) % 10 == 0))
                        {
                            TreeNode subCategoryNode = new TreeNode(subCategory.Code, subCategory.Name);
                            mainCategoryNode.AddChild(subCategoryNode);

                            foreach (var lowCategory in categories
                                .Where(c => c.Code.Length == 3 && c.Code.All(char.IsDigit) &&
                                            int.Parse(c.Code) >= int.Parse(subCategory.Code) &&
                                            int.Parse(c.Code) < int.Parse(subCategory.Code) + 10 &&
                                            int.Parse(c.Code) % 10 != 0)) // Exclude codes divisible by 10
                            {
                                TreeNode lowCategoryNode = new TreeNode(lowCategory.Code, lowCategory.Name);
                                subCategoryNode.AddChild(lowCategoryNode);
                            }
                        }
                    }
                }

                return deweyRoot;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error constructing tree. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error constructing tree: {ex.Message}");
                return null;
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to get a random low category node
        /// </summary>
        /// <returns></returns>
        public TreeNode GetRandomLowCategoryNode()
        {
            try
            {
                List<TreeNode> lowCategoryNodes = GetAllLowCategoryNodes();

                if (lowCategoryNodes.Count > 0)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(lowCategoryNodes.Count);
                    return lowCategoryNodes[randomIndex];
                }

                return null; // No lowCategoryNode found
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting random low category node. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting random low category node: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// get all low category nodes
        /// </summary>
        /// <returns></returns>
        private List<TreeNode> GetAllLowCategoryNodes()
        {
            try
            {
                List<TreeNode> lowCategoryNodes = new List<TreeNode>();
                GetAllLowCategoryNodesRecursive(deweyRoot, lowCategoryNodes);
                return lowCategoryNodes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting all low category nodes. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting all low category nodes: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// get all low category nodes recursively. Method assited by ChatGPT 
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="lowCategoryNodes"></param>
        private void GetAllLowCategoryNodesRecursive(TreeNode currentNode, List<TreeNode> lowCategoryNodes)
        {
            try
            {
                if (currentNode.Children.Count == 0)
                {
                    // Node has no children, consider it as a lowCategoryNode
                    lowCategoryNodes.Add(currentNode);
                }
                else
                {
                    // Recursively search in children
                    foreach (var child in currentNode.Children)
                    {
                        GetAllLowCategoryNodesRecursive(child, lowCategoryNodes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting all low category nodes recursively. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting all low category nodes recursively: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to get a random sub category node
        /// </summary>
        /// <returns></returns>
        private TreeNode GenerateSubCategoryNode()
        {
            try
            {
                List<TreeNode> subCategoryNodes = GetAllSubCategoryNodes();

                return GetRandomNode(subCategoryNodes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating sub category node. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error generating sub category node: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// method to get a random main category node
        /// </summary>
        /// <returns></returns>
        private TreeNode GenerateMainCategoryNode()
        {
            try
            {
                List<TreeNode> mainCategoryNodes = GetAllMainCategoryNodes();

                return GetRandomNode(mainCategoryNodes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating main category node. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error generating main category node: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// get all main category nodes
        /// </summary>
        /// <returns></returns>
        private List<TreeNode> GetAllMainCategoryNodes()
        {
            try
            {
                return deweyRoot.Children.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting all main category nodes. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting all main category nodes: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// get all sub category nodes
        /// </summary>
        /// <returns></returns>
        private List<TreeNode> GetAllSubCategoryNodes()
        {
            try
            {
                List<TreeNode> subCategoryNodes = new List<TreeNode>();

                foreach (var mainCategoryNode in deweyRoot.Children)
                {
                    subCategoryNodes.AddRange(mainCategoryNode.Children);
                }

                return subCategoryNodes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting all sub category nodes. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting all sub category nodes: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// get a random node
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private TreeNode GetRandomNode(List<TreeNode> nodes)
        {
            try
            {
                if (nodes.Count > 0)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(nodes.Count);
                    return nodes[randomIndex];
                }

                return null; // No node found
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting random node. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting random node: {ex.Message}");
                return null;
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to find the parent of a node. Method adapted from [CodeX] youtube tutorial
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>
        public TreeNode FindParent(TreeNode root, TreeNode targetNode)
        {
            try
            {
                return FindParentRecursive(root, targetNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding parent. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error finding parent: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// method to find the parent of a node recursively. Method adapted from [CodeX] youtube tutorial
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>
        private TreeNode FindParentRecursive(TreeNode currentNode, TreeNode targetNode)
        {
            try
            {
                foreach (var child in currentNode.Children)
                {
                    // Check if the targetNode is a direct child of the currentNode
                    if (child == targetNode)
                    {
                        return currentNode; // Return the currentNode as it is the parent
                    }

                    // If not, recursively search in the children of the currentNode
                    TreeNode parent = FindParentRecursive(child, targetNode);
                    if (parent != null)
                    {
                        return parent; // If found in children, return the parent
                    }
                }

                return null; // Return null if the targetNode is not found in the subtree rooted at currentNode
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding parent recursively. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error finding parent recursively: {ex.Message}");
                return null;
            }
        }
    }
}
//----------------------------------...ooo000 END OF FILE 000ooo...----------------------------------//