using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            char[] input;

            input = new char[9];

            int numCount = 0;
            for (int i = 0; i < textBox1.Text.Length; i++) {
                if (textBox1.Text[i]== ' ') {
                    continue;
                }

                else {
                    input[numCount] = textBox1.Text[i];
                    numCount++;
                    //maybe do something like a message of the input not used
                    //try to see if there is  a way to help the user out more by:
                        //try to give an example of acceptable strings
                        //take input and validate one at a time
                    if (numCount == 9) {
                        break;
                    }
                }
            }
            string result = new string(input);
            label2.Text = result;
        }

        private void button2_Click(object sender, EventArgs e) {
            //clear the textbox
                //later will have to probably clear other stuff
        }
    }
}
