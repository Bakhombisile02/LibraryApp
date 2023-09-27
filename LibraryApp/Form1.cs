using DeweyDecLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        /*
        * This a portion of this code is based on a tutorial by [RJ Code Advance EN]
        * The original code can be found at [https://www.youtube.com/watch?v=BtOEztT1Qzk&t=888s]
        * Modifications were made to the code like changing the colours and themes
        */

        // Variables
        private Button currentButton;
        private Random random;
        private int tempIndex;

        // Constructor
        public Form1()
        {
            InitializeComponent();

            // Set initial form dimensions
            this.Width = 1244;
            this.Height = 736;

            // Initialize random number generator
            random = new Random();

            // Set form properties
            this.Text = string.Empty;
            this.ControlBox = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        // PInvoke declarations for moving the form without a title bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Button Click Event Handlers

        private void btnReplaceBooks_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ReplacingBooks RB = new ReplacingBooks();
            OpenChildUserControl(RB);
        }

        private void btnIdentifiyingArea_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DisabledScreen DS = new DisabledScreen();
            OpenChildUserControl(DS);
        }

        private void btnfindCallnumbers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DisabledScreen DS = new DisabledScreen();
            OpenChildUserControl(DS);
        }

        // Helper Methods

        // Select a random theme color
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        // Activate a button by changing its appearance and theme color
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitlebar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        // Disable all buttons in the panel menu
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        // Open the corresponding child form in the panel content
        private void OpenChildUserControl(UserControl userControl)
        {
            panelContent.Controls.Clear();

            userControl.Dock = DockStyle.Fill;

            panelContent.Controls.Add(userControl);

            lblTitle.Text = userControl.Text;
        }

    }
}
//--------------------------------------End of File----------------------------------------//