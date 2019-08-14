using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * STUDENT NAME: Tzu-Ting Wu
 * STUDENT ID: 301040475
 * DESCRIPTION: This is the Hero Generator Form
 */

namespace COMP123_S2019_FinalTestA.Views
{
    public partial class HeroGenerator : COMP123_S2019_FinalTestA.Views.MasterForm
    {
        public HeroGenerator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the HeroGenerator Form Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroGenerator_Load(object sender, EventArgs e)
        {
            GenerateNames();
        }

        /// <summary>
        /// This is the method to generate hero name randomly
        /// </summary>
        private void GenerateNames()
        {
            string FirstNameFile = @"..\..\Data\firstNames.txt";

            var ReadFirstNames = File.ReadAllLines(FirstNameFile);
            List<string> FirstNameList = ReadFirstNames.ToList();
            int FirstNameEndNumber = ReadFirstNames.Length;
            int FirstNameRadomNumber = new Random().Next(0, FirstNameEndNumber);
            FirstNameDataLabel.Text = FirstNameList[FirstNameRadomNumber];
            Program.character.FirstName = FirstNameDataLabel.Text;
            

            string LastNameFile = @"..\..\Data\lastNames.txt";

            var ReadLastNames = File.ReadAllLines(LastNameFile);
            List<string> LastNameList = ReadLastNames.ToList();
            int LastNameEndNumber = ReadLastNames.Length;
            int LastNameRadomNumber = new Random().Next(0, LastNameEndNumber);
            LastNameDataLabel.Text = LastNameList[LastNameRadomNumber];
            Program.character.LastName = LastNameList[LastNameRadomNumber];

            HeroNameTextBox.Text = FirstNameDataLabel.Text + ' ' + LastNameDataLabel.Text;
            Program.character.HeroName = HeroNameTextBox.Text;
        }


        /// <summary>
        ///  This is the event handler for the GenerateNameButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            GenerateNames();
        }
        

        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        /// <summary>
        /// This is the shared event handler for the exitToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// This is the shared event handler for the openToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configuration for openFileDialog
            CharacterOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterOpenFileDialog.FileName = "Character.txt";
            CharacterOpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            var result = CharacterOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                // open file stream to read
                using (StreamReader inputStream = new StreamReader(
                    File.Open(CharacterOpenFileDialog.FileName, FileMode.Open)))
                {
                    // read stuff from the file into the Student object
                    //Program.student.id = int.Parse(inputStream.ReadLine());
                    //Program.student.StudentID = inputStream.ReadLine();
                    //Program.student.FirstName = inputStream.ReadLine();
                    //Program.student.LastName = inputStream.ReadLine();

                    // cleanup
                    inputStream.Close();
                    inputStream.Dispose();
                }

                NextButton_Click(sender, e);
            }
        }

        /// <summary>
        /// This is the shared event handler for the saveToolStringMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // configuration for saveFileDialog
            CharacterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();  // set the default
            CharacterSaveFileDialog.FileName = "Character.txt";   // set the default
            CharacterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";


            var result = CharacterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                // open a stream to write
                using (StreamWriter outputStream = new StreamWriter(
                    File.Open(CharacterSaveFileDialog.FileName, FileMode.Create)))
                {
                    // write stuff to the file
                    //outputStream.WriteLine(Program.student.id.ToString());
                    //outputStream.WriteLine(Program.student.StudentID);
                    //outputStream.WriteLine(Program.student.FirstName);
                    //outputStream.WriteLine(Program.student.LastName);

                    // cleanup
                    outputStream.Close();
                    outputStream.Dispose();
                }

                MessageBox.Show("File Saved Successfully!", "Saving...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// This is the event handler for the aboutToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }

        /// <summary>
        /// This is the event handler for the GenerateAbilitiesButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            // Create a int list to save eight random numbers
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                int number;

                do number = new Random().Next(10, 51);
                while (randomNumbers.Contains(number));

                randomNumbers.Add(number);
            }

            // Assign each random number to the relative data label
            FightingDataLabel.Text = randomNumbers[0].ToString();
            AgilityDataLabel.Text = randomNumbers[1].ToString();
            StrengthDataLabel.Text = randomNumbers[2].ToString();
            EnduranceDataLabel.Text = randomNumbers[3].ToString();
            ReasonDataLabel.Text = randomNumbers[4].ToString();
            IntuitionDataLabel.Text = randomNumbers[5].ToString();
            PsycheDataLabel.Text = randomNumbers[6].ToString();
            PopularityDataLabel.Text = randomNumbers[7].ToString();

            // Store the data into character container
            Program.character.Fighting = FightingDataLabel.Text;
            Program.character.Agility = AgilityDataLabel.Text;
            Program.character.Strength = StrengthDataLabel.Text;
            Program.character.Endurance = EnduranceDataLabel.Text;
            Program.character.Reason = ReasonDataLabel.Text;
            Program.character.Intuition = IntuitionDataLabel.Text;
            Program.character.Psyche = PsycheDataLabel.Text;
            Program.character.Popularity = PopularityDataLabel.Text;
        }
    }
}
