using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    /// <summary>
    /// This a portion of this code is based on a tutorial by [RJ Code Advance EN]
    ///The original code can be found at[https://www.youtube.com/watch?v=BtOEztT1Qzk&t=888s]
    ///Modifications were made to the code like changing the colour values and adjusting the brightness of a color
    /// </summary>
    public static class ThemeColor
    {
        

        // variables
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }

        // List of predefined color codes
        public static List<string> ColorList = new List<string>() {
            "#3F51B5", "#009688", "#FF5722", "#607D8B", "#FF9800", "#9C27B0",
            "#2196F3", "#EA676C", "#E41A4A", "#5978BB", "#018790", "#0E3441",
            "#00B0AD", "#721D47", "#EA4833", "#EF937E", "#F37521", "#A12059",
            "#126881", "#8BC240", "#364D5B", "#C7DC5B", "#0094BC", "#E4126B",
            "#43B76E", "#7BCFE9", "#B71C46"
        };

        //******************************************************************************//
        /// <summary>
        /// Method to change the brightness of a color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="correctionFactor"></param>
        /// <returns> a corrected color </returns>
        //********************************************************************************//
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            // If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            // If correction factor is greater than zero, lighten color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
//----------------------------------...ooo000 END OF FILE 000ooo...----------------------------------//