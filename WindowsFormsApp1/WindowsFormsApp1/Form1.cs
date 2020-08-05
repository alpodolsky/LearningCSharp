using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Random notes:
//Process.Start("")  will launch an application whose name matches the string
//process.Kill() is inverse
namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public static string shift_choice = "";
        
        public Form1() {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            shift_choice = comboBox1.Text;
        }

        private static string[] createArray(string refer) {
            string[] array = new string[9];
            char[,] board = new char[9, 9];

            for (int i = 0; i < 9; i++) {
                //filles first row with reference/input string
                board[0, i] = refer[i];
            }
            array[0] = new string(refer);

            //most of this only works assuming the given row is the first row(for now)
            for (int i = 1; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    int shift = 1, reference = 0;
                    if (i <= 2) {
                        //left shift
                        if(shift_choice == "" || shift_choice == "Left") {
                            shift = 3;
                        }
                        else if(shift_choice == "Right") {
                            shift = 6;
                        }
                      
                        if (i == 2) {
                            reference = 1;
                        }
                        board[i, j] = board[reference, ((j + shift) % 9)];
                        continue;
                    }
                    else {
                        shift = 1;
                        if (i == 3) {
                            reference = 1;
                        }
                        if (i == 4) {
                            reference = 2;
                        }
                        if (i == 5) {
                            reference = 0;
                        }
                        if (i == 6) {
                            reference = 5;
                        }
                        if (i == 7) {
                            reference = 3;
                        }
                        if (i == 8) {
                            reference = 4;
                        }
                        board[i, j] = board[reference, (j + shift) % 9];
                        continue;
                    }
                }
            }
            for (int i = 1; i < 9; i++) {
                char[] temp = new char[9];
                //save each char to a temp string
                for (int j = 0; j < 9; j++) {
                    array[i] += board[i, j];
                }
            }
            return array;
        }

        private void button1_Click(object sender, EventArgs e) {
            //check for empty input
            char[] input;

            input = new char[9];

            int numCount = 0;
            for (int i = 0; i < textBox1.Text.Length; i++) {
                if (textBox1.Text[i] == ' ') {
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
            textBox1.Text = "";
            string result = new string(input);
            label2.Text = result;

            //ooo shiny component!
            string[] arr = createArray(result);

            for (int i = 0; i < 9; i++) {
                listBox1.Items.Add(arr[i]);
            }
            //listbox starts off invisible, only appears after filling
            listBox1.Show();
        }

        //Reset button
        private void button2_Click(object sender, EventArgs e) {
            //clear the textbox
            //later will have to probably clear other stuff
            textBox1.Text = "";
            label2.Text = "";
            comboBox1.Text = "";
            //re-hide and empty the listBox, deletes backwards
            if(listBox1.Visible == true) {
                listBox1.Hide();
                for (int i = 0; i < 9; i++) {
                    listBox1.Items.RemoveAt(8 - i);
                }
            }
        }
    }
}