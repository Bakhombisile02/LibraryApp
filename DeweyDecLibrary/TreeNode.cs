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

        //******************************************************************************//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        //******************************************************************************//
        public TreeNode(string code, string name)
        {
            Code = code;
            Name = name;
            Children = new List<TreeNode>();
        }


        //******************************************************************************//
        /// <summary>
        /// Method to add a child node to the tree
        /// </summary>
        /// <param name="childNode"></param>
        //******************************************************************************//
        public void AddChild(TreeNode childNode)
        {
            Children.Add(childNode);
        }

        //******************************************************************************//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        //******************************************************************************//
        public void DisplayTree(int level = 0)
        {
            StringBuilder treeString = new StringBuilder();
            treeString.AppendLine($"{new string('-', level)} Code: {Code}, Name: {Name}");

            foreach (var child in Children)
            {
                treeString.AppendLine(child.GetTreeString(level + 1));
            }

            MessageBox.Show(treeString.ToString());
        }

        //******************************************************************************//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        //******************************************************************************//
        public string GetTreeString(int level)
        {
            StringBuilder treeString = new StringBuilder();
            treeString.AppendLine($"{new string('-', level)} Code: {Code}, Name: {Name}");

            foreach (var child in Children)
            {
                treeString.AppendLine(child.GetTreeString(level + 1));
            }

            return treeString.ToString();
        }

    }
}
//----------------------------------...ooo000 END OF FILE 000ooo...----------------------------------//
