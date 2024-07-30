using System.Reflection.Emit;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Calc C;
        private Button[] twoParametresOperations = new Button[10];
        public Calculator()
        {
            InitializeComponent();
            C = new Calc();
            labelNumber.Text = "0";
            twoParametresOperations[0] = buttonPlus;
            twoParametresOperations[1] = buttonMinus;
            twoParametresOperations[2] = buttonMultiply;
            twoParametresOperations[3] = buttonDivision;
            twoParametresOperations[4] = buttonPercent;
            twoParametresOperations[5] = buttonOneDivideByX;
            twoParametresOperations[6] = buttonSQRT;
            twoParametresOperations[7] = buttonChangeSign;
            twoParametresOperations[8] = buttonMemorySave;
            twoParametresOperations[9] = buttonMPlus;
            memory.Enabled = false;
        }
        private string ERROR_MESSAGE = "can't divide by zero";
        private string ERROR = "isn't number";


        //________________________________________________CHECK_METHODS________________________________________________

        //удаляем лишний ноль впереди числа, если таковой имеется
        private void CorrectNumber()
        {
            //если есть знак "бесконечность" - не даёт писать цифры после него
            if (labelNumber.Text.IndexOf("∞") != -1)
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);

            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (labelNumber.Text[0] == '0' && (labelNumber.Text.IndexOf(",") != 1) && labelNumber.Text.Remove(0, 1).Length != 0)
                labelNumber.Text = labelNumber.Text.Remove(0, 1);

            //аналогично предыдущему, только для отрицательного числа
            if (labelNumber.Text[0] == '-')
                if (labelNumber.Text[1] == '0' && (labelNumber.Text.IndexOf(",") != 2))
                    labelNumber.Text = labelNumber.Text.Remove(1, 1);
        }
        private bool CanConvertToDouble(string str)
        {
            try
            {
                double a = Convert.ToDouble(str);
                return true;
            }
            catch (Exception)
            {
                BlockButtons();
                return false;
            }
        }

        private bool CanPress()
        {
            foreach (Button button in twoParametresOperations)
            {
                if (!button.Enabled)
                {
                    return false;
                }
            }
            return true;
        }

        private void BlockButtons()
        {
            foreach (Button button in twoParametresOperations)
            {
                if (!button.Equals(buttonEqual))
                    button.Enabled = false;
            }
        }

        private void FreeButtons()
        {
            foreach (Button button in twoParametresOperations)
            {
                button.Enabled = true;
            }
        }

        //________________________________________________NUMBER_BUTTONS________________________________________________


        private bool isNumberInputFinished = false;
        private void numberButton_Click(object sender, EventArgs e)
        {
            if (C.IsError)
            {
                labelNumber.Text = "";
                C.IsError = false;
                C.Put_A(null);
            }

            if (isNumberInputFinished)
            {
                labelNumber.Text = "";
                isNumberInputFinished = false;
            }


            Button? button = (Button)sender; //Button button1 = sender as Button;                
            if (button != null)
            {
                labelNumber.Text += button.Text.ToString();
                CorrectNumber();
            }
            FreeButtons();
            isInputOperation = false;
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            if (C.IsError)
            {
                labelNumber.Text = "0";
                C.IsError = false;
            }
            Button? button = (Button)sender;
            if (button != null && labelNumber.Text.IndexOf(",") == -1)
            {
                labelNumber.Text += button.Text.ToString();
                CorrectNumber();
            }
            FreeButtons();
            isInputOperation = false;
        }


        //________________________________________________MATH_OPERATIONS_BUTTONS________________________________________________

        private bool isInputOperation = false;
        private void operationAction()
        {
            if (C.IsError == false)
            {
                if (C.Get_A() != null)
                    this.calculate();
                if (this.CanConvertToDouble(labelNumber.Text)) C.Put_A(Convert.ToDouble(labelNumber.Text));
                isNumberInputFinished = true;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if (isNumberInputFinished == false)
                    this.operationAction();
                C.Put_Operation(Operations.PLUS);
                isInputOperation = true;
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if (isNumberInputFinished == false)
                    this.operationAction();
                C.Put_Operation(Operations.MINUS);
                isInputOperation = true;
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if (isNumberInputFinished == false)
                    this.operationAction();
                C.Put_Operation(Operations.MULTIPLY);
                isInputOperation = true;
            }
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if (isNumberInputFinished == false)
                    this.operationAction();
                C.Put_Operation(Operations.DIVISION);
                isInputOperation = true;
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if (isNumberInputFinished == false)
                    if (this.CanConvertToDouble(labelNumber.Text))
                    {
                        labelNumber.Text = C.Percent(Convert.ToDouble(labelNumber.Text)).ToString();
                    }
            }
        }


        private void buttonSQRT_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if (this.CanConvertToDouble(labelNumber.Text))
                    C.Put_A(Convert.ToDouble(labelNumber.Text));

                if (C.Get_A() < 0)
                {
                    labelNumber.Text = ERROR;
                    C.IsError = true;
                    BlockButtons();
                }
                else
                {
                    if (this.CanConvertToDouble(labelNumber.Text))
                        labelNumber.Text = C.Sqrt(Convert.ToDouble(labelNumber.Text)).ToString();
                }
            }
        }

        private void buttonOneDivideByX_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(1);
                try
                {
                    double a = 0;
                    if (this.CanConvertToDouble(labelNumber.Text))
                        a = Convert.ToDouble(labelNumber.Text);
                    labelNumber.Text = C.Division(Convert.ToDouble(labelNumber.Text)).ToString();
                    C.Put_A(a);
                }
                catch (DivideByZeroException)
                {
                    labelNumber.Text = ERROR_MESSAGE;
                    C.IsError = true;
                    BlockButtons();
                }
                C.Clear_A();
            }
        }
        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text != "0" && C.IsError == false)
            {
                if (labelNumber.Text[0] == '-')
                    labelNumber.Text = labelNumber.Text.Remove(0, 1);
                else
                    labelNumber.Text = "-" + labelNumber.Text;
            }
        }

        //________________________________________________MEMORY_MANAGE_BUTTONS________________________________________________

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text != ERROR_MESSAGE)
            {
                if (this.CanConvertToDouble(labelNumber.Text))
                    C.Put_A(Convert.ToDouble(labelNumber.Text));
                C.M_Sum();
                labelNumber.Text = C.Memory_Read().ToString();
                isNumberInputFinished = true;
                memory.Text = C.Memory_Read().ToString();
            }
        }

        private void buttonMemorySave_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text != ERROR_MESSAGE)
            {
                if (this.CanConvertToDouble(labelNumber.Text))
                    C.Put_A(Convert.ToDouble(labelNumber.Text));
                C.Memory_Save();
                isNumberInputFinished = true;
                memory.Text = C.Memory_Read().ToString();
            }
        }

        private void buttonMemoryClear_Click(object sender, EventArgs e)
        {
            C.Memory_Clear();
            memory.Text = C.Memory_Read().ToString();
        }

        private void buttonMemoryRead_Click(object sender, EventArgs e)
        {
            labelNumber.Text = C.Memory_Read().ToString();
            isNumberInputFinished = true;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            labelNumber.Text = "0";
            secondOperand = 0;
            C.IsError = false;
            FreeButtons();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            C.Clear_A();
            labelNumber.Text = "0";
            secondOperand = 0;
            C.IsError = false;
            FreeButtons();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            this.calculate();
        }

        private double b = 0;
        private int secondOperand = 0;

        private void calculate()
        {
            try
            {
                if (isInputOperation == true)
                {
                    if (secondOperand == 0)
                    {
                        C.Put_A(Convert.ToDouble(labelNumber.Text));
                        if (this.CanConvertToDouble(labelNumber.Text))
                            b = Convert.ToDouble(labelNumber.Text);
                    }
                    labelNumber.Text = C.calculate(b).ToString();

                    if (secondOperand != 0 && this.CanConvertToDouble(labelNumber.Text))
                    {
                        C.Put_A(Convert.ToDouble(labelNumber.Text));
                        b = Convert.ToDouble(labelNumber.Text);
                    }
                    secondOperand++;

                }
                else if (C.IsError == false && this.CanConvertToDouble(labelNumber.Text))
                {
                    if (secondOperand == 0)
                    {
                        b = Convert.ToDouble(labelNumber.Text);
                        secondOperand++;
                    }
                    labelNumber.Text = C.calculate(Convert.ToDouble(labelNumber.Text)).ToString();
                    C.Put_A(b);
                    secondOperand= 0;
                }
                else
                {
                    labelNumber.Text = "0";
                    C.Clear_A();
                }
                FreeButtons();
                isNumberInputFinished = true;
                isInputOperation = false;
            }
            catch (DivideByZeroException)
            {
                labelNumber.Text = ERROR_MESSAGE;
                C.IsError = true;
            }
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text.Length != 1 && C.IsError == false && isNumberInputFinished == false)
            {
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }
            else
            {
                labelNumber.Text = "0";
                FreeButtons();
            }
        }
    }
}