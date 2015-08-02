
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Queue<double> current = new Queue<double>();    // to hold values being input one by one
        Queue<double> result = new Queue<double>();       // holds only one value, the running total
        Queue<string> signs = new Queue<string>();      // to hold which sign is being used
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            output.Text += "1";
            current.Enqueue(1);

        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            output.Text += "2";
            current.Enqueue(2);

        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            output.Text += "3";
            current.Enqueue(3);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            output.Text += "4";
            current.Enqueue(4);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            output.Text += "5";
            current.Enqueue(5);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            output.Text += "6";
            current.Enqueue(6);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            output.Text += "7";
            current.Enqueue(7);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            output.Text += "8";
            current.Enqueue(8);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            output.Text += "9";
            current.Enqueue(9);
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            output.Text += "0";
            current.Enqueue(0);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            output.Text += " + ";
            signs.Enqueue("+");

            // if a calculation has already been made and result has something
            // for either statement, the total of all the numbers held in current need to be strung together
            if (result.Count > 0)   
            {
                if (current.Count > 0)
                {
                    string received = "";
                    while (current.Count != 0)
                    {
                        double getter = current.Dequeue();
                        received += getter.ToString();
                    }

                    int first = Convert.ToInt32(received);

                    double res = result.Dequeue();
                    string ops = signs.Peek();

                    // if there are more than one sign, then the sign just used should be dequeued
                    // if not, then it should stay until the second number is entered for it to evaluate against
                    if (ops == "+")
                    {
                        result.Enqueue((res + first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "-")
                    {
                        result.Enqueue((res - first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "*")
                    {
                        result.Enqueue((res * first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "/")
                    {
                        // handle divide by zero errors
                        if (first == 0)
                        {
                            output.Text = "Error! You cannot divide by zero.";
                            result.Clear();
                            signs.Clear();
                            current.Clear();
                        }
                        else
                        {
                            result.Enqueue((res / first));
                            if (signs.Count > 1)
                            {
                                signs.Dequeue();
                            }
                        }
                    }
                
                }
            }
            
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    double getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                result.Enqueue(first);
            }
        }


        private void minButton_Click(object sender, EventArgs e)
        {
            output.Text += " - ";
            signs.Enqueue("-");

            // if there is both a value in result and in count, then operations need to be performed
            // otherwise, treat it as the first entry and only current needs to be evaluated
            if (result.Count > 0)
            {
                if (current.Count > 0)
                {
                    string received = "";
                    while (current.Count != 0)
                    {
                        double getter = current.Dequeue();
                        received += getter.ToString();
                    }

                    int first = Convert.ToInt32(received);

                    double res = result.Dequeue();
                    string ops = signs.Peek();

                    if (ops == "+")
                    {
                        result.Enqueue((res + first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "-")
                    {
                        result.Enqueue((res - first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "*")
                    {
                        result.Enqueue((res * first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "/")
                    {
                        // handle divide by zero errors
                        if (first == 0)
                        {
                            output.Text = "Error! You cannot divide by zero.";
                            result.Clear();
                            signs.Clear();
                            current.Clear();
                        }
                        else
                        {
                            result.Enqueue((res / first));
                            if (signs.Count > 1)
                            {
                                signs.Dequeue();
                            }
                        }
                    }
                }
            
            }
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    double getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                result.Enqueue(first);
            }
        }

        private void multButton_Click(object sender, EventArgs e)
        {
            output.Text += " * ";
            signs.Enqueue("*");

            if (result.Count > 0)
            {
                if (current.Count > 0)
                {
                    string received = "";
                    while (current.Count != 0)
                    {
                        double getter = current.Dequeue();
                        received += getter.ToString();
                    }

                    int first = Convert.ToInt32(received);

                    double res = result.Dequeue();
                    string ops = signs.Peek();
                                       
                    if (ops == "+")
                    {
                        result.Enqueue((res + first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "-")
                    {
                        result.Enqueue((res - first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "*")
                    {
                        result.Enqueue((res * first));
                        if (signs.Count > 1)
                        {
                            signs.Dequeue();
                        }
                    }
                    if (ops == "/")
                    {
                        // handle divide by zero errors
                        if (first == 0)
                        {
                            output.Text = "Error! You cannot divide by zero.";
                            result.Clear();
                            signs.Clear();
                            current.Clear();
                        }
                        else
                        {
                            result.Enqueue((res / first));
                            if (signs.Count > 1)
                            {
                                signs.Dequeue();
                            }
                        }
                    }
                }
                 
            }
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    double getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                result.Enqueue(first);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            output.Text = "";

            // clear values from all queues
            current.Clear();
            signs.Clear();
            result.Clear();
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            output.Text += " / ";
            signs.Enqueue("/");
        
            if (result.Count > 0)
                {
                if (current.Count > 0)
                    {
                        string received = "";
                        while (current.Count != 0)
                        {
                            double getter = current.Dequeue();
                            received += getter.ToString();
                        }

                        int first = Convert.ToInt32(received);

                        double res = result.Dequeue();
                        string ops = signs.Peek();
                                           
                        if (ops == "+")
                        {
                            result.Enqueue((res + first));
                            if (signs.Count > 1)
                            {
                                signs.Dequeue();
                            }
                        }
                        if (ops == "-")
                        {
                            result.Enqueue((res - first));
                            if (signs.Count > 1)
                            {
                                signs.Dequeue();
                            }
                        }
                        if (ops == "*")
                        {
                            result.Enqueue((res * first));
                            if (signs.Count > 1)
                            {
                                signs.Dequeue();
                            }
                        }
                        if (ops == "/")
                        {
                            // handle divide by zero errors
                            if (first == 0)
                            {
                                output.Text = "Error! You cannot divide by zero.";
                                result.Clear();
                                signs.Clear();
                                current.Clear();
                            }
                            else
                            {
                                result.Enqueue((res / first));
                                if (signs.Count > 1)
                                {
                                    signs.Dequeue();
                                }
                            }
                        }
                    }
                    }
            
                else
                {
                    string received = "";

                    while (current.Count != 0)
                    {
                        double getter = current.Dequeue();
                        received += getter.ToString();
                    }

                    int first = Convert.ToInt32(received);

                    result.Enqueue(first);
                }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            // if there is no sign held in signs AND there is nothing in result, nothing should happen when equal is clicked
            if (signs.Count == 0)
            {
              
            }
            // if there is a sign, then need to calculate the final number 
            else
            {
                if (result.Count > 0)
                {
                    double poppedNum = result.Dequeue();
                    double totalNum = 0;

                    string received = "";

                    while (current.Count != 0)
                    {
                        double getter = current.Dequeue();
                        received += getter.ToString();
                    }

                    int lastNum = Convert.ToInt32(received);

                    string sign = signs.Dequeue();
                    string finalNum;
                          
                    // to enable divide by zero error to display, output and enqueuing happens within the if statements
                    // otherwise the error will be immediately overwritten by finalNum, which would have no value
                    if (sign == "+")
                    {
                        totalNum = poppedNum + lastNum;

                        finalNum = totalNum.ToString();
                        output.Text = finalNum;

                        // send it back to result in case the user tries to do more with it
                        result.Enqueue(totalNum);

                        // clear signs so that none are left over in the next round of equations
                        signs.Clear();
                    }
                    if (sign == "-")
                    {
                        totalNum = poppedNum - lastNum;

                        finalNum = totalNum.ToString();
                        output.Text = finalNum;

                        // send it back to result in case the user tries to do more with it
                        result.Enqueue(totalNum);

                        // clear signs so that none are left over in the next round of equations
                        signs.Clear();
                    }

                    if (sign == "*")
                    {
                        totalNum = poppedNum * lastNum;

                        finalNum = totalNum.ToString();
                        output.Text = finalNum;

                        // send it back to result in case the user tries to do more with it
                        result.Enqueue(totalNum);

                        // clear signs so that none are left over in the next round of equations
                        signs.Clear();
                    }

                    if (sign == "/")
                    {
                        
                        if (lastNum == 0)
                        {
                            output.Text = "Error! You cannot divide by zero.";
                            result.Clear();
                            signs.Clear();
                            current.Clear();
                        }
                        else
                        {
                            totalNum = poppedNum / lastNum;

                            finalNum = totalNum.ToString();
                            output.Text = finalNum;

                            // send it back to result in case the user tries to do more with it
                            result.Enqueue(totalNum);

                            // clear signs so that none are left over in the next round of equations
                            signs.Clear();                            
                        }
                    }
                    
                
                }
            }
            
        }
    }
}
