using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicCalculator
{
    /// <summary>
    /// A Basic Calculator following this video on YouTube
    /// https://www.youtube.com/watch?v=W6vJ_c9Mt6A&t=0s&list=PLrW43fNmjaQXhWOKalftye87ObZA-xNIJ&index=6
    /// </summary>
    /// 
    public partial class Form1 : Form
    {
        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Operators
        /// <summary>
        /// Clears the user input text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void CEButton_Click(object sender, EventArgs e)
        {
            this.UserInputText.Text = String.Empty; //Clear the text from the user input
            FocusInputText();   //put the cursor back to the user input box
        }

        private void DELButton_Click(object sender, EventArgs e)
        {

        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void MultButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        { 
            CalculateEquation();
        }



        #endregion

        #region Numbers

        private void PeriodButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            FocusInputText();   //put the cursor back to the user input box
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            FocusInputText();   //put the cursor back to the user input box
        }

        #endregion

        /// <summary>
        /// Calculates the given equation and outputs the answer to the label
        /// </summary>
        private void CalculateEquation()
        {
            throw new NotImplementedException();
        }

        #region Private Helpers

        /// <summary>
        /// Focus the user input text
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        private void InsertTextValue(string Value)
        {
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, Value);
        }
        #endregion
    }
}
