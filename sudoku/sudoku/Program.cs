using System;
using System.ComponentModel.DataAnnotations;

namespace sudoku {
    class Program {
        static void Main(string[] args) {
            int[,] board = new int[9, 9];
            //will store the user input here if input passes two validating conditions
            int[] userGiven = new int[9];
            bool valid;
            Console.WriteLine("Hello, welcome to sudoku maker!");
            //take in the user input and put it into the first row
                //try to add ability to pick which row (need to check the maths for that though)
            
            for (int i =0; i < 9; i++) {
                //maybe shove some parsing in here to allow user to input as 'd d d d d d d d d'
                Console.Write("Please pick the " + (i + 1) + " number: ");

                //validates each number as the user enters it
                    //also maybe do a try/catch here for overflow errors
                int userInput = Convert.ToInt32(Console.ReadLine());
                //this way error checking(like overflow) can be done by the called method
                valid = false;
                //spin until user gives valid input
                while (!valid) {
                    if (!(validRange(userInput))) {
                        Console.WriteLine("Error, invalid number. Please input valid number: ");
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (!(validRow(userGiven, userInput))) {
                         Console.WriteLine("Error, duplicate number. Please input unique number: ");
                         userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    else {
                        valid = true;
                    }
                }

                userGiven[i] = userInput;
                board[0, i] = userGiven[i];                
            }

            Console.WriteLine();
            
            //most of this only works assuming the given row is the first row(for now)
            for (int i = 1; i < 9; i++) {
                for(int j=0; j < 9; j++) {
                    int shift = 1, reference = 0;
                    if (i <= 2) {
                        shift = 3;
                        if (i == 2) reference = 1;
                        board[i, j] = board[reference, ((j + shift) % 9)];
                    }
                    else {
                        shift = 1;
                        if (i == 3) reference = 1;
                        if (i == 4) reference = 2;
                        if (i == 5) reference = 0;
                        if (i == 6) reference = 5;
                        if (i == 7) reference = 3;
                        if (i == 8) reference = 4;

                        board[i, j] = board[reference, (j + shift) % 9];
                    }
                }             
            }
            printBoard(board);
        }
        static bool validRange (int input) {
            bool result = true;
            if (input > 9 || input < 1) {
                result = false;
            }
            return result;

        }
        static bool validRow(int[] array, int input) {
            bool result = true;
            for (int i = 0; i < 9; i++) {
                if(array[i] == input) {
                    result = false;
                }
            }
            return result;
        }
        //helper method to print the finished product
        static void printBoard(int[,] array) {
            for(int i = 0; i < 9; i++) {
                for(int j = 0; j < 9; j++) {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
