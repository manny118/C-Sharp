//Windows Form application for a C# calculator
//The caclulator utilises gRPC to perform a sqaure root operation

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLExample;
using Grpc;
using Grpc.Core;
using GreeterClient;
using System.Globalization;
using System.Runtime.InteropServices;


namespace CalculatorV2
{

    public partial class Form1 : Form
    {

        double total;//stores the total value of the operation performed
        double prevValue;//stores the previous value entered
        String prevOperation;//stores the previous operator
        bool newValue;//turns true for a new value
        string operation;//stores the next operation

        public Form1()
        {
            InitializeComponent();
            prevOperation = "+";
            newValue = true;
            total = 0.0;
            prevValue = 0.0;
        }

        [DllImport(@"Example1Client.dll")]
        public static extern float Client(float runningtotal, float input);


        //clears the display screen
        private void onClickClear(object sender, EventArgs e)
        {
            display.Text = "0";
            prevOperation = "+";
            newValue = true;
            total = 0.0;
            prevValue = 0.0;
        }

        //onClick method for the digit 0
        private void digit0_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "0"; //set the display to 0
                newValue = false;
            }
            else
            {
                display.Text += "0"; //append 0 to the display
            }
        }

        //onClick method for the digit 1
        private void digit1_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "1";
                newValue = false;
            }
            else
            {
                display.Text += "1"; //append 1 to the display
            }
        }

        //onClick method for the digit 2
        private void digit2_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "2"; //set the display to 2
                newValue = false;
            }
            else
            {
                display.Text += "2"; //append 2 to the display
            }
        }

        //onClick method for the digit 3
        private void digit3_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "3"; //set the display to 3
                newValue = false;
            }
            else
            {
                display.Text += "3"; //append 3 to the display
            }
        }

        //onClick method for the digit 4
        private void digit4_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "4"; //set the display to 4
                newValue = false;
            }
            else
            {
                display.Text += "4"; //append 4 to the display
            }
        }

        //onClick method for the digit 5
        private void digit5_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "5"; //set the display to 5
                newValue = false;
            }
            else
            {
                display.Text += "5"; //append 5 to the display
            }
        }

        //onClick method for the digit 6
        private void digit6_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            { 
                display.Text = "6"; //set the display to 6
                newValue = false;
            }
            else
            {
                display.Text += "6"; //append 6 to the display
            }
        }

        //onClick method for the digit 7
        private void digit7_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "7"; //set the display to 7
                newValue = false;
            }
            else
            {
                display.Text += "7"; //append 7 to the display
            }
        }

        //onClick method for the digit 8
        private void digit8_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "8"; //set the display to 8
                newValue = false;
            }
            else
            {
                display.Text += "8"; //append 8 to the display
            }
        }

        //onClick method for the digit 9
        private void digit9_OnClick(object sender, EventArgs e)
        {
            if (newValue == true)
            {
                display.Text = "9"; //set the display to 9
                newValue = false;
            }
            else
            {
                display.Text += "9"; //append 9 to the display
            }
        }

        //onclick method for the delete button
        private void onClickDelete(object sender, EventArgs e)
        {
            String displayValue = this.display.Text;
            int len = displayValue.Length; //obtain the length of the value displayed
            display.Text = String.Empty; 
            for (int i = 0; i < len - 1; i++)
            {
                display.Text += displayValue[i];
            }
        }

        //onclick method for the addition button
        private void addOnClick(object sender, EventArgs e)
        {
            prevValue = Convert.ToDouble(display.Text);
            operation = "+";
            checkPreviousOperation();
            display.Text = Convert.ToString(total);
            prevOperation = "+";
            newValue = true;

        }

        //onclick method for the subtraction button
        private void subOnClick(object sender, EventArgs e)
        {
            prevValue = Convert.ToDouble(display.Text);
            operation = "-";
            checkPreviousOperation();
            display.Text = Convert.ToString(total);
            prevOperation = "-";
            newValue = true;
        }

        //onclick method for the multiplication button
        private void multOnClick(object sender, EventArgs e)
        {
            prevValue = Convert.ToDouble(display.Text);
            operation = "*";
            checkPreviousOperation();
            display.Text = Convert.ToString(total);
            prevOperation = "*";
            newValue = true;
        }

        //onclick method for the division button
        private void divOnClick(object sender, EventArgs e)
        {
            prevValue = Convert.ToDouble(display.Text);
            operation = "/";
            checkPreviousOperation();
            display.Text = Convert.ToString(total);
            prevOperation = "/";
            newValue = true;
        }

        //checks the previous operation that was performed
        private void checkPreviousOperation()
        {

            if (prevOperation == "+")
            {
                //DLLExample.Class1 dll = new DLLExample.Class1();
                //total = dll.addNumber(total, prevValue);
                total += prevValue;
            }
            else if (prevOperation == "-")
            {
                total -= prevValue;
            }
            else if (prevOperation == "*")
            {
                total *= prevValue;
            }
            else if (prevOperation == "/")
            {
                total /= prevValue;
            }
        }

        //gRPC button implementation
        private void DLL_Function_OnClick(object sender, EventArgs e)
        {

            //Create an instance of gRPC_Client
            GreeterClient.gRPC_Client c1 = new GreeterClient.gRPC_Client();
            double value = Convert.ToDouble(display.Text); //store the input value
            double result = c1.client(value); //parse the value to the gRPC client
            display.Text = Convert.ToString(result); //display the result

        }
    }
}
