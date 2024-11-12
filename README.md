# Mastermind
## Jacob Seikel

### Project Description
This is a C# console application containing a simple version of Mastermind. The program randomly generates an answer consisting of four digits between 1 and 6 inclusive, and the user has 10 tries to guess what this answer is. For each guess, the program provides feedback in the following way:
- For each guessed digit that is in the correct place, the program prints a plus sign (+)
- For each guessed digit that is in the answer but is in the incorrect place, the program prints a minus sign (-)

Note that the program will only print at most one sign for each digit in the correct answer. For example, if the answer is `1234` and the user guesses `4233`, the program will print `++-`, NOT `++--`.

### How to Run
In order to run this program, you will need a compatible version of .NET installed on your machine. Once you have that installed, simply run `dotnet run` while you are in the directory with the project files.