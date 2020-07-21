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
    public partial class Form2 : Form {
        
        
        public Form2(string input) {
            this.Controls.Add(listBox1);
            InitializeComponent();

            //this.Controls.Add(listBox1);
            string[] arr = new string[9];
            int[,] board = new int[9, 9];

            for (int i = 0; i < 9; i++) {
                board[i, 0] = input[i];
            }
            arr[0] = input;
            //most of this only works assuming the given row is the first row(for now)
            for (int i = 1; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    int shift = 1, reference = 0;
                    if (i <= 2) {
                        shift = 3;
                        if (i == 2) {
                            reference = 1;
                        }                             
                        board[i, j] = board[reference, ((j + shift) % 9)];

                    }
                    else {
                        shift = 1;
                        if (i == 3) {
                            reference = 1;
                        }
                        else if (i == 4) {
                            reference = 2;
                        }
                        else if (i == 5) {
                            reference = 0;
                        }
                        else if (i == 6) {
                            reference = 5;
                        }
                        else if (i == 7) {
                            reference = 3;
                        }
                        else if (i == 8) {
                            reference = 4;
                        }
                        board[i, j] = board[reference, (j + shift) % 9];
                    }
                }
            }
            
            for(int i = 1; i < 9; i++) {
                char[] temp = new char[9];
                for (int j = 0; j < 9; j++) {
                    temp[j] = (char)board[i,j];
                }
                Console.WriteLine(temp);
                arr[i] = new string(temp);
            }
            listBox1.BeginUpdate();
            for (int i = 0; i < 9; i++) {
                //listView1.Items.Insert(i , arr[i]);
                listBox1.Items.Add(arr[i]);
            }
            listBox1.EndUpdate();
        }
    }
}

/**/
