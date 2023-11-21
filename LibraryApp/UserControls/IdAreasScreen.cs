using DeweyDecLibrary;
using LibraryApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace LibraryApp
{
    /// <summary>
    /// screen for the Identifying Areas game
    /// some of these functions were assisted by chatgpt such as the check1 and check2 functions
    /// </summary>
    public partial class IdAreasScreen : UserControl
    {
        //variables
        private IdAreas idAreas = new IdAreas();
        SoundPlayer sound = new SoundPlayer(Resources.Music);
        private List<string> questions = new List<string>();
        private List<string> questions2 = new List<string>();
        private List<List<string>> options = new List<List<string>>();
        private List<List<string>> options2 = new List<List<string>>();
        private int currentQuestionIndex = 0;
        private Random random = new Random();
        private bool isDisplayingSet1;
        private int elapsedSeconds;
        private int score = 0;


        /// <summary>
        /// Constructor for IdAreasScreen
        /// </summary>
        public IdAreasScreen()
        {
            InitializeComponent();
            MessageBox.Show("This application will automatically switch between call numbers and description tests");
            RunTime();
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Run time method to generate random Dewey Decimal numbers and populate the questions and options
        /// </summary>
        public void RunTime()
        {
            try
            {

                sound.PlayLooping();
                LoadTheme();// loads button theme
                idAreas.DeweyDictionary1.Clear();
                for (int i = 0; i < 20; i++)// Populate Dewey Decimal numbers
                {
                    idAreas.GenerateRandomDeweyDecimal();
                }


                // Generate questions and options
                idAreas.CategorizeDeweyNumbers(idAreas.DeweyNumbers1);
                questions = new List<string>(idAreas.CategorizedNumbers.Keys);
                questions2 = new List<string>(idAreas.CategorizedNumbers.Values);
                options = new List<List<string>>();

                // Populate options for each type 1 questions
                foreach (var deweyNumber in idAreas.CategorizedNumbers.Values)
                {
                    var optionsForQuestion = idAreas.GetRandomOptions(deweyNumber); // Get random options
                    options.Add(optionsForQuestion);
                }

                // Populate options for each type 2 questions
                foreach (var deweyNumber in idAreas.CategorizedNumbers.Keys)
                {
                    var optionsForQuestion = idAreas.GetRandomOptions2(deweyNumber); // Get random options
                    options2.Add(optionsForQuestion);
                }

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
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while initializing IdAreasScreen: {ex.Message}");
                MessageBox.Show("An error occurred. Keep pressing Identifying Areas button it will resolve it!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            elapsedSeconds++;
            var minutes = elapsedSeconds / 60;
            var seconds = elapsedSeconds % 60;

            lilTimer.Text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to restart the timer
        /// </summary>
        public void restartTimer()
        {
            elapsedSeconds = 0;
            lilTimer.Text = "00:00";
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// Method to display type 1 questions and options
        /// </summary>
        private void DisplayQuestionsAndOptions()
        {
            isDisplayingSet1 = true;

            if (currentQuestionIndex < questions.Count)
            {
                lblQ1.Text = $"1. What number falls under the {questions[currentQuestionIndex]} category?";
                lblQ2.Text = $"2. What number falls under the {questions[currentQuestionIndex + 1]} category?";
                lblQ3.Text = $"3. What number falls under the {questions[currentQuestionIndex + 2]} category?";
                lblQ4.Text = $"4. What number falls under the {questions[currentQuestionIndex + 3]} category?";

                // Display options for each question
                for (int i = 0; i < 4; i++)
                {
                    var optionsForQuestion = options[currentQuestionIndex + i];
                    var checkedListBox = Controls.Find($"checkedListBox{i + 1}", true)[0] as CheckedListBox;

                    checkedListBox.Items.Clear();
                    foreach (var option in optionsForQuestion)
                    {
                        checkedListBox.Items.Add(option);
                    }
                }
            }
            else
            {
                // Quiz finished, handle end of game logic here
                MessageBox.Show("Quiz finished!");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        /// <summary>
        /// method to display type 2 questions and options
        /// </summary>
        private void DisplayQuestionsAndOptions2()
        {
            isDisplayingSet1 = false;

            if (currentQuestionIndex < questions2.Count)
            {
                lblQ1.Text = $"1. What Category does  {questions2[currentQuestionIndex]} fall under?";
                lblQ2.Text = $"2. What Category does {questions2[currentQuestionIndex + 1]} fall under?";
                lblQ3.Text = $"3. What Category does {questions2[currentQuestionIndex + 2]} fall under?";
                lblQ4.Text = $"4. What Category does {questions2[currentQuestionIndex + 3]} fall under?";

                // Display options for each question
                for (int i = 0; i < 4; i++)
                {
                    var optionsForQuestion = options2[currentQuestionIndex + i];
                    var checkedListBox = Controls.Find($"checkedListBox{i + 1}", true)[0] as CheckedListBox;

                    checkedListBox.Items.Clear();
                    foreach (var option in optionsForQuestion)
                    {
                        checkedListBox.Items.Add(option);
                    }
                }
            }
            else
            {
                // Quiz finished, handle end of game logic here
                MessageBox.Show("Quiz finished!");
            }
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to load button theme
        /// </summary>
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

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to check type 1 and type 2 answers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click_1(object sender, EventArgs e)
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

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to check type 2 answers
        /// </summary>
        public void check2()
        {
            try
            {
                bool allQuestionsAnswered = true;

                for (int i = 1; i <= 4; i++)
                {
                    var checkedListBox = Controls.Find($"checkedListBox{i}", true)[0] as CheckedListBox;

                    if (checkedListBox.CheckedItems.Count == 0)// Check if at least one option is selected for each question
                    {
                        allQuestionsAnswered = false;
                        MessageBox.Show($"Please select an option for Question {i}.");
                        break;
                    }
                }

                if (allQuestionsAnswered)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        var checkedListBox = Controls.Find($"checkedListBox{i}", true)[0] as CheckedListBox;
                        var selectedCategory = checkedListBox.CheckedItems[0].ToString();

                        var correctCategory = questions2[currentQuestionIndex + i - 1];

                        var answer = idAreas.GetCategoryFromDewey(correctCategory);// Check if the selected option is correct

                        if (selectedCategory == answer)
                        {
                            MessageBox.Show($"Question {i} is correct!");
                            score++;
                        }
                        else
                        {
                            MessageBox.Show($"Sorry, Question {i} is wrong. The correct answer is {answer}");
                        }
                    }

                    // Move to the next set of questions
                    currentQuestionIndex += 4;

                    // Randomly choose which set of questions to display
                    isDisplayingSet1 = random.Next(2) == 0;

                    if (isDisplayingSet1)
                    {
                        DisplayQuestionsAndOptions();
                        lblScore.Text = score.ToString();
                        timer1.Stop();
                        restartTimer();
                        timer1.Start();
                    }
                    else
                    {
                        DisplayQuestionsAndOptions2();
                        lblScore.Text = score.ToString();
                        timer1.Stop();
                        restartTimer();
                        timer1.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while submitting answers: {ex.Message}");
            }
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// method to check type 1 answers
        /// </summary>
        public void check1()
        {
            try
            {
                // Check if at least one option is selected for each question
                bool allQuestionsAnswered = true;
                for (int i = 1; i <= 4; i++)
                {
                    var checkedListBox = Controls.Find($"checkedListBox{i}", true)[0] as CheckedListBox;
                    if (checkedListBox.CheckedItems.Count == 0)
                    {
                        allQuestionsAnswered = false;
                        MessageBox.Show($"Please select an option for Question {i}.");
                        break;
                    }
                }

                if (allQuestionsAnswered)
                {
                    // Check answers for each question
                    for (int i = 1; i <= 4; i++)
                    {
                        var checkedListBox = Controls.Find($"checkedListBox{i}", true)[0] as CheckedListBox;
                        var selectedOption = checkedListBox.CheckedItems[0].ToString();

                        // Check if the selected option is correct
                        var correctOption = idAreas.CategorizedNumbers[questions[currentQuestionIndex + i - 1]];
                        if (selectedOption == correctOption)
                        {
                            MessageBox.Show($"Question {i} is correct!");
                            score++;
                        }
                        else
                        {
                            MessageBox.Show($"Sorry, Question {i} is wrong. The correct answer is {correctOption}");
                        }
                    }

                    // Move to the next set of questions
                    currentQuestionIndex += 4;

                    // Randomly choose which set of questions to display
                    isDisplayingSet1 = random.Next(2) == 0;

                    if (isDisplayingSet1)
                    {
                        DisplayQuestionsAndOptions();
                        lblScore.Text = score.ToString();
                        timer1.Stop();
                        restartTimer();
                        timer1.Start();
                    }
                    else
                    {
                        DisplayQuestionsAndOptions2();
                        lblScore.Text = score.ToString();
                        timer1.Stop();
                        restartTimer();
                        timer1.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while submitting answers: {ex.Message}");

            }
        }
        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
        /// <summary>
        /// methid that gives you a hint on how to answer the questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hintsBtn_Click(object sender, EventArgs e)
        {
            string hintMessage = @"
                Category Sections
            
                000 to 099, Geology
                100 to 199, Biology
                200 to 299, Chemistry
                300 to 399, Physics
                400 to 499, Mathematics
                500 to 599, Technology
                600 to 699, Medicine
                700 to 799, Arts
                800 to 899, Literature
                900 to 999, History

                Subsections

                0 to 9,   General
                10 to 19, System Overview
                20 to 29, Processes
                30 to 39, Methods
                40 to 49, Applications
                50 to 59, Techniques
                60 to 69, Tools
                70 to 79, Materials
                80 to 89, Principles
                90 to 99, Miscellaneous
            ";

            MessageBox.Show(hintMessage, "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
/*- - - - - - - - - - - - - - - - - - - - - - ...ooo000 End of File 000ooo... - - - - - - - - - - - - - - - - - - - - - -*/