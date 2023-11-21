using DeweyDecLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using LibraryApp.Properties;

namespace LibraryApp
{
    /// <summary>
    /// Class for the Finding Call Number game
    /// </summary>
    public partial class FindingCallNumber : UserControl
    {
        //variables
        SoundPlayer sound = new SoundPlayer(Resources.Music);
        private FindingCallNum _callNum = new FindingCallNum();
        private Random random = new Random();
        private bool isDisplayingSet1;
        private int elapsedSeconds;
        private int score = 0;
       
        /// <summary>
        /// constructor
        /// </summary>
        public FindingCallNumber()
        {
            InitializeComponent();
            _callNum.Settree();
            MessageBox.Show("This application will automatically switch between call numbers and description tests");
            RunTime();
            sound.PlayLooping();
        }

        /// <summary>
        /// method to run the game
        /// </summary>
        public void RunTime() 
        {
            try
            {
                _callNum.loadtree();
                LoadTheme();
                // Randomly choose which set of questions to display
                isDisplayingSet1 = random.Next(2) == 0;

                if (isDisplayingSet1)
                {
                    DisplayQuestionsAndOptions();
                    lblScore.Text = score.ToString();
                }
                else
                {
                    DisplayQuestionsAndOptions2();
                    lblScore.Text = score.ToString();
                }

                timer1.Interval = 1000;
                timer1.Tick += Timer1_Tick;

                timer1.Start();

                button1.Visible = false;
                button2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/

        /// <summary>
        /// method for the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                elapsedSeconds++;
                var minutes = elapsedSeconds / 60;
                var seconds = elapsedSeconds % 60;

                lilTimer.Text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to display type 1 questions and options
        /// </summary>
        private void DisplayQuestionsAndOptions()
        {
            try
            {
                isDisplayingSet1 = true;


                lblQ1.Text = $"What number falls under the [{_callNum.RandomLowCategoryNode.Name}] category?";



                checkedListBox1.Items.Clear();
                foreach (var option in _callNum.GrandparentNodes)
                {
                    checkedListBox1.Items.Add(option.Code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
           
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to load the theme
        /// </summary>
        private void LoadTheme()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to display type 2 questions and options
        /// </summary>
        private void DisplayQuestionsAndOptions2()
        {
            try
            {
                isDisplayingSet1 = false;

                lblQ1.Text = $"What Category does [{_callNum.RandomLowCategoryNode.Code}] fall under?";



                checkedListBox1.Items.Clear();
                foreach (var option in _callNum.GrandparentNodes)
                {
                    checkedListBox1.Items.Add(option.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to first check if the user has selected an answer and then check if the answer is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    if (isDisplayingSet1 == true)
                    {
                        check1();

                    }
                    else if (isDisplayingSet1 == false)
                    {
                        check2();

                    }
                }
                else
                {
                    MessageBox.Show("Please select an answer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to check if the answer is correct for type 1 questions
        /// </summary>
        private void check1()
        {
            try
            {
                var selectedCategory = checkedListBox1.CheckedItems[0].ToString();

                if (selectedCategory == _callNum.Grandparent.Code)
                {
                    score++;
                    lblScore.Text = score.ToString();
                    MessageBox.Show("Correct!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ParentNodes)
                    {
                        checkedListBox1.Items.Add(option.Code);
                    }
                    button1.Visible = true;
                    btnSubmit.Visible = false;

                    progressBar1.Increment(34);

                }
                else
                {

                    MessageBox.Show($"Incorrect! The correct answer is  {_callNum.Grandparent.Code}!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ParentNodes)
                    {
                        checkedListBox1.Items.Add(option.Code);
                    }
                    button1.Visible = true;
                    btnSubmit.Visible = false;

                    progressBar1.Increment(34);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /// <summary>
        /// method to check if the answer is correct for type 1 questions 2nd phase
        /// </summary>
        private void check1on1()
        {
            try
            {
                var selectedCategory = checkedListBox1.CheckedItems[0].ToString();

                if (selectedCategory == _callNum.Parent.Code)
                {
                    score++;
                    lblScore.Text = score.ToString();
                    MessageBox.Show("Correct!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ChildNodes)
                    {
                        checkedListBox1.Items.Add(option.Code);
                    }
                    button2.Visible = true;
                    button1.Visible = false;

                    progressBar1.Increment(33);
                }
                else
                {

                    MessageBox.Show($"Incorrect! The correct answer is  {_callNum.Parent.Code}!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ChildNodes)
                    {
                        checkedListBox1.Items.Add(option.Code);
                    }
                    button2.Visible = true;
                    button1.Visible = false;

                    progressBar1.Increment(33);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /// <summary>
        /// method to check if the answer is correct for type 1 questions 3rd phase
        /// </summary>
        private void check1on2()
        {
            try
            {
                var selectedCategory = checkedListBox1.CheckedItems[0].ToString();

                if (selectedCategory == _callNum.RandomLowCategoryNode.Code)
                {
                    score++;
                    lblScore.Text = score.ToString();
                    progressBar1.Increment(33);
                    MessageBox.Show($"Game Complete! final score is: {score}");
                    DialogResult result = MessageBox.Show("Would you like to play again?", "Question", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblScore.Text = score.ToString();
                        score = 0;
                        timer1.Stop();
                        restartTimer();
                        RunTime();
                        progressBar1.Value = 0;

                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("You can play agian if you click RESET");
                    }

                    button2.Visible = false;
                    

                }
                else
                {

                    MessageBox.Show($"Incorrect! The correct answer is  {_callNum.RandomLowCategoryNode.Code}!");
                    progressBar1.Increment(33);
                    MessageBox.Show($"Game Complete! final score is: {score}");
                    DialogResult result = MessageBox.Show("Would you like to play again?", "Question", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblScore.Text = score.ToString();
                        score = 0;
                        timer1.Stop();
                        restartTimer();
                        RunTime();
                        progressBar1.Value = 0;

                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("You can play agian if you click RESET");
                    }
                    button2.Visible = false;
                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }

        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to check if the answer is correct for type 2 questions
        /// </summary>
        private void check2()
        {
            try
            {
                var selectedCategory = checkedListBox1.CheckedItems[0].ToString();

                if (selectedCategory == _callNum.Grandparent.Name)
                {
                    score++;
                    lblScore.Text = score.ToString();
                    MessageBox.Show("Correct!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ParentNodes)
                    {
                        checkedListBox1.Items.Add(option.Name);
                    }
                    button1.Visible = true;
                    btnSubmit.Visible = false;

                    progressBar1.Increment(34);
                }
                else
                {

                    MessageBox.Show($"Incorrect! The correct answer is  {_callNum.Grandparent.Name}!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ParentNodes)
                    {
                        checkedListBox1.Items.Add(option.Name);
                    }
                    button1.Visible = true;
                    btnSubmit.Visible = false;

                    progressBar1.Increment(34);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /// <summary>
        /// method to check if the answer is correct for type 2 questions 2nd phase
        /// </summary>
        private void check2on1()
        {
            try
            {
                var selectedCategory = checkedListBox1.CheckedItems[0].ToString();

                if (selectedCategory == _callNum.Parent.Name)
                {
                    score++;
                    lblScore.Text = score.ToString();
                    MessageBox.Show("Correct!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ChildNodes)
                    {
                        checkedListBox1.Items.Add(option.Name);
                    }
                    button2.Visible = true;
                    button1.Visible = false;
                    progressBar1.Increment(33);
                }
                else
                {

                    MessageBox.Show($"Incorrect! The correct answer is  {_callNum.Parent.Name}!");
                    checkedListBox1.Items.Clear();
                    foreach (var option in _callNum.ChildNodes)
                    {
                        checkedListBox1.Items.Add(option.Name);
                    }
                    button2.Visible = true;
                    button1.Visible = false;
                    progressBar1.Increment(33);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /// <summary>
        /// method to check if the answer is correct for type 2 questions 3rd phase
        /// </summary>
        private void check2on2()
        {
            try
            {
                var selectedCategory = checkedListBox1.CheckedItems[0].ToString();

                if (selectedCategory == _callNum.RandomLowCategoryNode.Name)
                {
                    score++;
                    lblScore.Text = score.ToString();
                    MessageBox.Show($"Game Complete! final score is: {score}");
                    progressBar1.Increment(33);
                    DialogResult result = MessageBox.Show("Would you like to play again?", "Question", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblScore.Text = score.ToString();
                        score = 0;
                        timer1.Stop();
                        restartTimer();
                        RunTime();
                        progressBar1.Value = 0;

                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("You can play agian if you click RESET");
                    }

                    button2.Visible = false;

                }
                else
                {

                    MessageBox.Show($"Incorrect! The correct answer is  {_callNum.RandomLowCategoryNode.Name}!");
                    progressBar1.Increment(33);
                    MessageBox.Show($"Game Complete! final score is: {score}");
                    DialogResult result = MessageBox.Show("Would you like to play again?", "Question", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lblScore.Text = score.ToString();
                        score = 0;
                        timer1.Stop();
                        restartTimer();
                        RunTime();
                        progressBar1.Value = 0;

                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("You can play agian if you click RESET");
                    }

                    button2.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to first check if the user has selected an answer and then check if the answer is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    if (isDisplayingSet1 == true)
                    {
                        check1on1();

                    }
                    else if (isDisplayingSet1 == false)
                    {
                        check2on1();

                    }
                }
                else
                {
                    MessageBox.Show("Please select an answer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
            
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to first check if the user has selected an answer and then check if the answer is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    if (isDisplayingSet1 == true)
                    {
                        check1on2();

                    }
                    else if (isDisplayingSet1 == false)
                    {
                        check2on2();

                    }
                }
                else
                {
                    MessageBox.Show("Please select an answer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to reset timer
        /// </summary>
        public void restartTimer()
        {
            try
            {
                elapsedSeconds = 0;
                lilTimer.Text = "00:00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to reset the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hintsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                lblScore.Text = score.ToString();
                score = 0;
                timer1.Stop();
                restartTimer();
                RunTime();
                progressBar1.Value = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Running Application. check log at C:\\log.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logger.WriteLog($"Error Running Application: {ex.Message}");
            }
        }
    }
}
