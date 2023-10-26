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
        private Dictionary<string, string> categorizedNumbers;
        private List<string> questions;
        private List<List<string>> options;

        private int currentQuestionIndex = 0;

        public IdAreasScreen()
        {
            InitializeComponent();
           sound.PlayLooping();
            LoadTheme();

            // Populate Dewey Decimal numbers
            for (int i = 0; i < 4; i++)
            {
                idAreas.GenerateRandomDeweyDecimal();
            }

            // Generate questions and options
            categorizedNumbers = idAreas.CategorizeDeweyNumbers(idAreas.DeweyNumbers1);
            questions = new List<string>(categorizedNumbers.Keys);
            options = new List<List<string>>();

            // Populate options for each question
            foreach (var deweyNumber in categorizedNumbers.Values)
            {
                var optionsForQuestion = idAreas.GetRandomOptions(deweyNumber); // Get random options
                options.Add(optionsForQuestion);
            }

           
            // Display first set of questions and options
            DisplayQuestionsAndOptions();
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
                        string selectedOption = checkedListBox.CheckedItems[0].ToString();

                        // Check if the selected option is correct
                        string correctOption = categorizedNumbers[questions[currentQuestionIndex + i - 1]];
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
                    DisplayQuestionsAndOptions();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"An error occurred while submitting answers: {ex.Message}");

            }
        }

        private void hintsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
/*- - - - - - - - - - - - - - - - - - - - - - ...ooo000 End of File 000ooo... - - - - - - - - - - - - - - - - - - - - - -*/