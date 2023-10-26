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
    public partial class IdAreasScreen : UserControl
    {
        private IdAreas idAreas = new IdAreas();
        SoundPlayer sound = new SoundPlayer(Properties.Resources.Music);
        private List<string> questions = new List<string>();
        private List<string> questions2 = new List<string>();
        private List<List<string>> options = new List<List<string>>();
        private List<List<string>> options2 = new List<List<string>>();
        private int currentQuestionIndex = 0;
        private Random random = new Random();
        private bool isDisplayingSet1;

        public IdAreasScreen()
        {
            InitializeComponent();
            RunTime();
        }

        public void RunTime()
        {
            try
            {

                sound.PlayLooping();
                LoadTheme();

                idAreas.DeweyDictionary1.Clear();
                // Populate Dewey Decimal numbers
                for (int i = 0; i < 20; i++)
                {
                    idAreas.GenerateRandomDeweyDecimal();
                }


                // Generate questions and options
                    idAreas.CategorizeDeweyNumbers(idAreas.DeweyNumbers1);
                    questions = new List<string>(idAreas.CategorizedNumbers.Keys);
                    questions2 = new List<string>(idAreas.CategorizedNumbers.Values);
                    options = new List<List<string>>();


                    

                    // Populate options for each question
                    foreach (var deweyNumber in idAreas.CategorizedNumbers.Values)
                    {
                        var optionsForQuestion = idAreas.GetRandomOptions(deweyNumber); // Get random options
                        options.Add(optionsForQuestion);
                    }

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
                }
                else
                {
                    DisplayQuestionsAndOptions2();
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while initializing IdAreasScreen: {ex.Message}");
                MessageBox.Show("An error occurred. Please Press Identifying Areas button again to resolve it!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayQuestionsAndOptions()
        {
            if (currentQuestionIndex < questions.Count)
            {
                lblQ1.Text = $"What number falls under the {questions[currentQuestionIndex]} category?";
                lblQ2.Text = $"What number falls under the {questions[currentQuestionIndex + 1]} category?";
                lblQ3.Text = $"What number falls under the {questions[currentQuestionIndex + 2]} category?";
                lblQ4.Text = $"What number falls under the {questions[currentQuestionIndex + 3]} category?";

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
        /// 
        /// </summary>
        private void DisplayQuestionsAndOptions2()
        {
            if (currentQuestionIndex < questions2.Count)
            {
                lblQ1.Text = $"What Category does  {questions2[currentQuestionIndex]} fall under?";
                lblQ2.Text = $"What Category does {questions2[currentQuestionIndex + 1]} fall under?";
                lblQ3.Text = $"What Category does {questions2[currentQuestionIndex + 2]} fall under?";
                lblQ4.Text = $"What Category does {questions2[currentQuestionIndex + 3]} fall under?";

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

        /// <summary>
        /// method to check if the user has selected an option for each question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool allQuestionsAnswered = true;

                // Check if at least one option is selected for each question
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
                    // Check answers for the appropriate set of questions
                    List<string> currentQuestions = isDisplayingSet1 ? questions : questions2;
                    List<List<string>> currentOptions = isDisplayingSet1 ? options : options2;

                    for (int i = 1; i <= 4; i++)
                    {
                        var checkedListBox = Controls.Find($"checkedListBox{i}", true)[0] as CheckedListBox;
                        string selectedOption = checkedListBox.CheckedItems[0].ToString();

                        // Check if the selected option is correct
                        string correctOption = idAreas.CategorizedNumbers[currentQuestions[currentQuestionIndex + i - 1]];
                        if (selectedOption == correctOption)
                        {
                            MessageBox.Show($"Question {i} is correct!");
                        }
                        else
                        {
                            MessageBox.Show($"Sorry, Question {i} is wrong. The correct answer is {correctOption}");
                        }
                    }

                    // Move to the next set of questions
                    currentQuestionIndex += 4;

                    // Display the next set of questions and options
                    if (isDisplayingSet1)
                    {
                        DisplayQuestionsAndOptions();
                    }
                    else
                    {
                        DisplayQuestionsAndOptions2();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while submitting answers: {ex.Message}");
            }
        }

       
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