using System;
using System.Collections.Generic;
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
    public class TreeNode
    {
        public string Code { get; }
        public string Name { get; }
        public List<TreeNode> Children { get; }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        public TreeNode(string code, string name)
        {
            Code = code;
            Name = name;
            Children = new List<TreeNode>();
        }


        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to add a child node to the tree
        /// </summary>
        /// <param name="childNode"></param>
        public void AddChild(TreeNode childNode)
        {
            try
            {
                Children.Add(childNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding child node to tree. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error adding child node to tree: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetTreeString(int level)
        {
            try { 
            StringBuilder treeString = new StringBuilder();
            treeString.AppendLine($"{new string('-', level)} Code: {Code}, Name: {Name}");

            foreach (var child in Children)
            {
                treeString.AppendLine(child.GetTreeString(level + 1));
            }

            return treeString.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting tree string. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting tree string: {ex.Message}");
                return null;
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Recursive helper method to traverse the tree and collect codes and names.
        /// </summary>
        /// <param name="codes">List to store codes.</param>
        /// <param name="names">List to store names.</param>
        private void GetAllCodesAndNamesRecursive(List<string> codes, List<string> names)
        {
            try
            {
                // Add current node's code and name to the lists
                codes.Add(Code);
                names.Add(Name);

                // Recursively traverse children
                foreach (var child in Children)
                {
                    child.GetAllCodesAndNamesRecursive(codes, names);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting codes and names. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error getting codes and names: {ex.Message}");
            }
        }

    }
}
//----------------------------------...ooo000 END OF FILE 000ooo...----------------------------------//
