﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeweyDecLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LibraryApp
{
    public partial class ReplacingBooks : UserControl
    {
        // Variables
        private int incorrectAttempts = 0;
        private CallNumberClass randomizer = new CallNumberClass();
        private ImageList imageList = new ImageList();
        private int elapsedSeconds;

        // Constructor
        public ReplacingBooks()
        {
            InitializeComponent();
            LoadTheme();

            // Set up checkboxes
            cekboxLife1.Checked = true;
            cekboxlife2.Checked = true;
            cekboxlife3.Checked = true;

            // Set up list views and columns
            listView1.View = View.LargeIcon;
            listView1.GridLines = false;
            listView1.AllowDrop = true;

            listView2.View = View.LargeIcon;
            listView2.GridLines = false;
            listView2.AllowDrop = true;

            // Create a new ImageList with larger icons
            ImageList largeImageList = new ImageList();
            largeImageList.ImageSize = new Size(64, 64);
            largeImageList.Images.Add(Properties.Resources.book);

            listView1.LargeImageList = largeImageList;
            listView2.LargeImageList = largeImageList;

            listView1.ItemDrag += ListView_ItemDrag;
            listView2.ItemDrag += ListView_ItemDrag2;

            listView1.DragEnter += ListView_DragEnter;
            listView2.DragEnter += ListView_DragEnter;

            listView1.DragDrop += ListView_DragDrop;
            listView2.DragDrop += ListView_DragDrop;

            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            // Generate initial random Dewey Decimal numbers
            for (int i = 0; i < 10; i++)
            {
                string randomDeweyDecimal = randomizer.GenerateRandomDeweyDecimal();
                ListViewItem item = new ListViewItem(randomDeweyDecimal, 0);
                listView1.Items.Add(item);
            }
        }

        // Event Handlers

        // Handles the "Check" button click event
        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<string> sortedDeweyNumbers = randomizer.SortDeweyNumbers();
            List<string> listView2Items = GetListViewItems(listView2);

            bool areListsSame = listView2Items.SequenceEqual(sortedDeweyNumbers);

            if (areListsSame)
            {
                timer1.Stop();
                MessageBox.Show("Congratulations! List is arranged in order.", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                incorrectAttempts = 0; // Reset incorrect attempts on success
            }
            else
            {
                incorrectAttempts++;
                UncheckNextCheckbox();

                if (incorrectAttempts == 3) // If 3 incorrect attempts
                {
                    MessageBox.Show("You are dead.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetGame(); // Reset the game (uncheck checkboxes, reset timer, etc.)
                }
            }
        }

        // Unchecks the next checkbox when the order is incorrect
        private void UncheckNextCheckbox()
        {
            if (cekboxlife3.Checked)
            {
                cekboxlife3.Checked = false;
            }
            else if (cekboxlife2.Checked)
            {
                cekboxlife2.Checked = false;
            }
            else if (cekboxLife1.Checked)
            {
                cekboxLife1.Checked = false;
            }
        }

        // Updates the timer display
        private void Timer1_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;

            lilTimer.Text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }

        // Handles the drag and drop operation for both list views
        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            System.Windows.Forms.ListView destinationListView = sender as System.Windows.Forms.ListView;
            ListViewItem draggedItem = e.Data.GetData(typeof(System.Windows.Forms.ListViewItem)) as ListViewItem;

            if (destinationListView != null && draggedItem != null && e.Effect == DragDropEffects.Move)
            {
                ListViewItem clonedItem = (ListViewItem)draggedItem.Clone();
                destinationListView.Items.Add(clonedItem);

                // Remove the item from the source ListView
                if (draggedItem.ListView != null)
                {
                    draggedItem.ListView.Items.Remove(draggedItem);
                }

                // Start the timer when an item is dropped
                if (!timer1.Enabled)
                {
                    elapsedSeconds = 0;
                    timer1.Start();
                }

                // Update progress bar
                UpdateProgressBar();
            }
        }

        // Updates the progress bar based on correct items
        private void UpdateProgressBar()
        {
            int progress = CalculateProgress();
            progressBar1.Value = progress;
        }

        // Calculates the progress based on correct items
        private int CalculateProgress()
        {
            List<string> sortedDeweyNumbers = randomizer.SortDeweyNumbers();
            List<string> listView2Items = GetListViewItems(listView2);

            int correctItems = 0;

            for (int i = 0; i < sortedDeweyNumbers.Count; i++)
            {
                if (i < listView2Items.Count && sortedDeweyNumbers[i] == listView2Items[i])
                {
                    correctItems++;
                }
            }

            // Calculate progress based on correct items
            int progress = (correctItems * 100) / sortedDeweyNumbers.Count;

            return progress;
        }

        // Retrieves the items from a ListView
        private List<string> GetListViewItems(ListView listView)
        {
            List<string> items = new List<string>();

            foreach (ListViewItem item in listView.Items)
            {
                items.Add(item.Text);
            }

            return items;
        }

        // Populates a ListView with Dewey Decimal numbers
        private void PopulateListView(System.Windows.Forms.ListView listView, List<string> deweyNumbers)
        {
            foreach (string deweyNumber in deweyNumbers)
            {
                ListViewItem item = new ListViewItem(deweyNumber, 0);
                listView.Items.Add(item);
            }
        }

        // Loads the theme for buttons
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        // Checks if a ListView is sorted
        private bool CheckIfListViewIsSorted(System.Windows.Forms.ListView listView)
        {
            for (int i = 0; i < listView.Items.Count - 1; i++)
            {
                if (string.Compare(listView.Items[i].Text, listView.Items[i + 1].Text) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Initiates a drag operation in listView1
        private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        // Initiates a drag operation in listView2
        private void ListView_ItemDrag2(object sender, ItemDragEventArgs e)
        {
            listView2.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        // Handles the DragEnter event for both list views
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data format is supported
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Resets the game
        private void ResetGame()
        {
            cekboxLife1.Checked = true;
            cekboxlife2.Checked = true;
            cekboxlife3.Checked = true;
            elapsedSeconds = 0;
            timer1.Stop();
            lilTimer.Text = "00:00";
            progressBar1.Value = 0;
            listView1.Items.Clear();
            listView2.Items.Clear();
            randomizer.DeweyNumbers.Clear();

            for (int i = 0; i < 10; i++)
            {
                string randomDeweyDecimal = randomizer.GenerateRandomDeweyDecimal();
                ListViewItem item = new ListViewItem(randomDeweyDecimal, 0);
                listView1.Items.Add(item);
            }
        }

        // Handles the click event for the reset button
        private void button1_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
//------------------------------------End of File----------------------------------//