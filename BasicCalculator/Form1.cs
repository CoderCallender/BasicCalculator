using System;
using System.Linq;
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
                var operation = new Operation();
                var leftSide = true;

                //loop through each character from the input
                //starting from the left
                for(int i = 0; i < Input.Length; i++)
                {
                    //TODO: Handle order priority (BODMAS)

                    if("0123456789.".Any(c => Input[i] == c))
                    {
                        if (leftSide)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, Input[i]);

                        else
                            operation.RightSide = AddNumberPart(operation.RightSide, Input[i]);
                    }
                    //if it is an operator, do this 
                    else if("+-/*.".Any(c => Input[i] == c))
                    {
                        //if we are on the right side already, we need to calculate what we have
                        //and set the result to the left side
                        if(!leftSide)
                        {
                            var operationType = GetOperationType(Input[i]);

                            //check if we have a right side number
                            if (operation.RightSide.Length == 0)
                            {
                                if (operationType != OperationType.Minus)
                                {
                                    //Can't have an operator except for a minus in front of the first number
                                    throw new InvalidOperationException($"Syntax error");
                                }

                                //if there is a minus in front of the number, that's ok, as it could be a negative 
                                operation.RightSide += Input[i];
                            }

                            else
                            {

                                //calculate prev equation and set to the leftside
                                operation.LeftSide = CalculateOperation(operation);

                                //set new operator
                                operation.OperationType = operationType;

                                //clear the prev right side number
                                operation.RightSide = string.Empty;
                            }
                        }

                        else
                        {
                            var operationType = GetOperationType(Input[i]);

                            if(operation.LeftSide.Length == 0)
                            {
                                if(operationType != OperationType.Minus)
                                {
                                    //Can't have an operator except for a minus in front of the first number
                                    throw new InvalidOperationException($"Syntax error");
                                }

                                //if there is a minus in front of the number, that's ok, as it could be a negative 
                                operation.LeftSide += Input[i];
                            }
                            //if we get here we have a left numer, and an operator
                            else
                            {
                                operation.OperationType = operationType;
                                leftSide = false;
                            }
                        }
                    }
                }

                //if we are done parsing with no exceptions
                //calculate 

               return CalculateOperation(operation);

                //return string.Empty;

            }
            catch(Exception ex)
            {
                return $"Invalid Equation. { ex.Message}";
            }
        }

        /// <summary>
        /// Calculate an <see cref="Operation"/> and returns the result
        /// </summary>
        /// <param name="operation">The operation to calculate</param>
        private string CalculateOperation(Operation operation)
        {
            //store the number values of the string representations
            double left = 0;
            double right = 0;

            //check if we have a valid left side number
            if (string.IsNullOrEmpty(operation.LeftSide) || !double.TryParse(operation.LeftSide, out left))
                throw new InvalidOperationException($"Syntax Error { operation.LeftSide }");

            if (string.IsNullOrEmpty(operation.RightSide) || !double.TryParse(operation.RightSide, out right))
                throw new InvalidOperationException($"Syntax Error { operation.RightSide }");

            try
            {
                switch(operation.OperationType)
                {
                    case OperationType.Add:
                        return (left + right).ToString();

                    case OperationType.Minus:
                        return (left - right).ToString();

                    case OperationType.Divide:
                        return (left / right).ToString();

                    case OperationType.Multiply:
                        return (left * right).ToString();

                    default:
                        throw new InvalidOperationException($"Unknown operator type {operation.OperationType}");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Failed to calculate operation {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }
            return string.Empty;
        }

        /// <summary>
        /// returns the known <see cref="OperationType"/>
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private OperationType GetOperationType(char character)
        {
            switch(character)
            {
                case '+':
                    return OperationType.Add;

                case '-':
                    return OperationType.Minus;

                case '/':
                    return OperationType.Divide;

                case '*':
                    return OperationType.Multiply;

                default:
                    throw new InvalidOperationException($"Unknown Operator Type {character}");
            }
        }

        /// <summary>
        /// Attempts to add new character to the current number
        /// checking if it is valid
        /// </summary>
        /// <param name="CurrentNumber">The current number string</param>
        /// <param name="NewCharacter">The next character to add</param>
        /// <returns></returns>
        private string AddNumberPart(string CurrentNumber, char NewCharacter)
        {
            //check if there is already a . in the number
            if(NewCharacter == '.' && CurrentNumber.Contains('.'))
            {
                throw new InvalidOperationException($"Number{CurrentNumber} already contains a .");
            }

            return CurrentNumber + NewCharacter;
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
