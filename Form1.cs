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
        Queue<int> current = new Queue<int>();    // to hold values being input one by one
        Queue<int> result = new Queue<int>();       // holds only one value, the running total
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
                string received = "";
                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
                    received += getter.ToString();
                }
                // now there is a string of the numbers in order
                // convert it back to an int
                int first = Convert.ToInt32(received);

                int res = result.Dequeue(); // don't need to empty queue because only one value is being added and removed at a time

                // figure out what the last operation was and perform it on the two numbers being held by res and first
                // this makes sure the running total in result is correct
                string ops = signs.Dequeue();

                if (ops == "+")
                {
                    result.Enqueue((res + first));
                }
                if (ops == "-")
                {
                    result.Enqueue((res - first));
                }
                if (ops == "*")
                {
                    result.Enqueue((res * first));
                }
                if (ops == "/")
                {
                    // handle divide by zero errors
                    if (first == 0) {
                        output.Text = "Error! You cannot divide by zero.";
                        result.Clear();
                        signs.Clear();
                        current.Clear();
                    }
                    else {
                        result.Enqueue((res / first));
                    }
                }
            }
            
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
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

            if (result.Count > 0)
            {
                string received = "";
                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                int res = result.Dequeue(); 
                string ops = signs.Dequeue();

                if (ops == "+")
                {
                    result.Enqueue((res + first));
                }
                if (ops == "-")
                {
                    result.Enqueue((res - first));
                }
                if (ops == "*")
                {
                    result.Enqueue((res * first));
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
                    }
                }
            }
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
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
                string received = "";
                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                int res = result.Dequeue(); 
                string ops = signs.Dequeue();

                if (ops == "+")
                {
                    result.Enqueue((res + first));
                }
                if (ops == "-")
                {
                    result.Enqueue((res - first));
                }
                if (ops == "*")
                {
                    result.Enqueue((res * first));
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
                    }
                }
            }
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
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
            output.Text = " / ";
            signs.Enqueue("/");

            if (result.Count > 0)
            {
                string received = "";
                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                int res = result.Dequeue(); 
                string ops = signs.Dequeue();

                if (ops == "+")
                {
                    result.Enqueue((res + first));
                }
                if (ops == "-")
                {
                    result.Enqueue((res - first));
                }
                if (ops == "*")
                {
                    result.Enqueue((res * first));
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
                    }
                }
            }
            else
            {
                string received = "";

                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
                    received += getter.ToString();
                }

                int first = Convert.ToInt32(received);

                result.Enqueue(first);
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            if (result.Count > 0)
            {
                int poppedNum = result.Dequeue();
                int totalNum = 0;

                string received = "";

                while (current.Count != 0)
                {
                    int getter = current.Dequeue();
                    received += getter.ToString();
                }

                int lastNum = Convert.ToInt32(received);

                string sign = signs.Dequeue();

                if (sign == "+")
                {
                    totalNum = poppedNum + lastNum;
                }
                if (sign == "-")
                {
                    totalNum = poppedNum - lastNum;
                }

                if (sign == "*")
                {
                    totalNum = poppedNum * lastNum;
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
                    }
                }
                string finalNum = totalNum.ToString();

                output.Text = finalNum;

                // send it back to result and current in case the user tries to do more with it
                result.Enqueue(totalNum);
                current.Enqueue(totalNum);
            }
        }
    }
}
