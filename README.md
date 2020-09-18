# LearningCSharp
projects created using c#

## Sudoku:
- Originally made in C, transfered to C# and created minimal user interface
- Takes one row as user input and fills out the other 8 rows
- Currently capable of creating 9!x2 boards
# To-Do:
- Ensure input validation
- Link database to store unique boards
  - Find way to use database to solve sudoku boards
- Find more ways of creating unique sudoku boards (besides left and right shift)
  - Determine if other rows besides the first row can be used to create a valid board
  - Give user ability to choose which row is the 'reference' row
  - Allow Column input(won't necessarily be unique board but gives more user control)
- Explore using multithreading to create the board
