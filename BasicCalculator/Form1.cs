using System;
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

        /// <summary>
        /// Constructor for the calculator class
        /// initialises all variables
        /// </summary>
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
            DeleteTextValue();  //Deletes the value in front of the current cursor position
            FocusInputText();   //put the focus back to the user input box           
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");   //inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void MultButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        { 
            CalculateEquation();    //Calculates the equation that is in the text box
        }



        #endregion

        #region Numbers

        private void PeriodButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");//inserts the given value at the current cursor location
            FocusInputText();   //put the cursor back to the user input box
        }

        #endregion

        /// <summary>
        /// Calculates the given equation and outputs the answer to the label
        /// </summary>
        private void CalculateEquation()
        {
            

            this.CalculationResultText.Text = ParseEquation();
        }

        /// <summary>
        /// Parses the user's equation and calculates the result
        /// </summary>
        /// <returns></returns>
        private string ParseEquation()
        {
            try
            {
                //get the user's equation input
                var Input = UserInputText.Text;

                //Remove all whitespaces
                Input = Input.Replace(" ", "");

                //new top level operation   
                //var operation = new Operation();

                return string.Empty;

            }
            catch(Exception ex)
            {
                return $"Invalid Equation. { ex.Message}";
            }
        }

        #region Private Helpers

        /// <summary>
        /// Focus the user input text
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        /// <summary>
        /// Insert a section of text to the user input box
        /// </summary>
        /// <param name="Value"></param>

        private void InsertTextValue(string Value)
        {
            //remember where the cursor is and save it to a variable
            var SelectionStart = this.UserInputText.SelectionStart;

            //copy text and replace with new value in
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, Value); 

            //set the cursor to a position after what we have just inserted
            this.UserInputText.SelectionStart = SelectionStart + Value.Length;
        }

        /// <summary>
        /// delete a section of text to the user input box
        /// </summary>
        /// <param name="Value"></param>

        private void DeleteTextValue()
        {
            //check if there is anything in fromt of the cursor to delete
            //if not, exit
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
                return;

            //remember where the cursor is
            var SelectionStart = this.UserInputText.SelectionStart; 

            //remove the text in front of the cursor by copying the text, and replacing with the 
            //modified version
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            //put the cursor back where it's supposed to be
            this.UserInputText.SelectionStart = SelectionStart; 

            //Ensure that we do not have any test selected
            this.UserInputText.SelectionLength = 0;
        }
        #endregion
    }
}
