class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Mastermind");
        Console.WriteLine("----------\n");

        while (true) {
            PlayGame();
            Console.WriteLine("Would you like to play again? (y/n)");
            try {
                string? input = Console.ReadLine();
                if (input != "y") {
                    break;
                }
                Console.Write("\n\n\n");
            } catch {
                break;
            }
        }


        /*
        var guess1 = new List<int>{1, 2, 3, 4};
        var guess2 = new List<int>{1, 3, 5, 4};
        var guess3 = new List<int>{1, 4, 1, 4};
        var answer = new List<int>{1, 3, 5, 4};

        Console.WriteLine(ProvideFeedback(guess3, answer));
        */
    }

    
    public static void PlayGame() {
        List<int> answer = GenerateAnswer();
        List<int> guess;
        string feedback;

        // i represents the number of guesses remaining
        for (int i = 10; i > 0; i--) {
            Console.WriteLine($"Guesses remaining: {i}");
            guess = GetGuess();

            if (CheckGuess(guess, answer)) {
                Console.WriteLine($"Victory! The answer was {ListToString(answer)}.\n");
                return;
            }

            feedback = ProvideFeedback(guess, answer);
            Console.WriteLine($"Feedback: {feedback}\n");
        }

        Console.WriteLine($"Defeat... The answer was {ListToString(answer)}.\n");
    }

    // prompts user for their guess and performs input validation
    public static List<int> GetGuess() {
        List<int> inputList;

        while (true) {
            Console.Write("Input your guess: ");
            string? input = Console.ReadLine();
            Console.Write("\n");

            inputList = ConvertToList(input);
            if (inputList.Count != 0) {
                break;
            }
        }

        return inputList;
    }

    // converts input into List<int>; returns an empty list if input is invalid
    public static List<int> ConvertToList(string? input) {
        int inputInt;
        List<int> inputList = new();

        if (input == null) {
            Console.WriteLine("No input detected");
        }

        if (input!.Length != 4) {
            Console.WriteLine("Input was the wrong length");
            return new List<int>();
        }

        if (input.Contains('-') || input.Contains('+')) {
            Console.WriteLine("Non-numeric character detected");
        }

        try {
            inputInt = int.Parse(input);
        } catch {
            Console.WriteLine("Non-numeric character detected");
            return new List<int>();
        }

        for (int i = 3; i >= 0; i--) {
            inputList.Add(inputInt / (int) Math.Pow(10, i));
            inputInt %= (int) Math.Pow(10, i);
        }

        foreach (int num in inputList) {
            if (num < 1 || num > 6) {
                Console.WriteLine($"Invalid digit '{num}' detected");
                return new List<int>();
            }
        }

        return inputList;
    }

    // generates a random number to be the answer
    public static List<int> GenerateAnswer() {
        Random random = new();
        List<int> answer = new();

        for (int i = 0; i < 4; i++) {
            answer.Add(random.Next(1, 7));
        }

        return answer;
    }

    // returns true if the guess is correct, and false otherwise
    public static bool CheckGuess(List<int> guess, List<int> answer) {
        for (int i = 0; i < 4; i++) {
            if (guess[i] != answer[i]) {
                return false;
            }
        }
        return true;
    }

    // returns a string with +'s and -'s representing how accurate the guess was
    public static string ProvideFeedback(List<int> guess, List<int> answer) {
        string feedbackString = "";

        // copying the lists so we don't change the originals
        List<int> guessCopy = new(guess);
        List<int> answerCopy = new(answer);

        // adds +'s
        for (int i = 0; i < 4; i++) {
            if (guessCopy[i] == answerCopy[i]) {
                feedbackString += '+';
                guessCopy[i] = -1;
                answerCopy[i] = -1;
            }
        }

        // adds -'s
        for (int i = 0; i < 4; i++) {
            if (guessCopy[i] != -1 && answerCopy.Contains(guessCopy[i])) {
                feedbackString += '-';
                answerCopy[answerCopy.IndexOf(guessCopy[i])] = -1;
                guessCopy[i] = -1;
            }
        }

        return feedbackString;
    }

    // utility function that converts the list into a string
    public static string ListToString(List<int> myList) {
        string returnString = "";
        foreach (int num in myList) {
            returnString += num.ToString();
        }
        return returnString;
    }
}