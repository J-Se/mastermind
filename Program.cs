class Program {
    public static void Main(string[] args) {
        List<int> myList = ConvertToList("2315");
        PrintList(myList);
    }

    // converts input into List<int>; returns an empty list if input is invalid
    public static List<int> ConvertToList(string input) {
        int inputInt;
        List<int> inputList = new();

        if (input.Length != 4) {
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
                Console.WriteLine($"Invalid digit {num} detected");
                return new List<int>();
            }
        }

        return inputList;
    }

    public static void PrintList(List<int> myList) {
        foreach (int num in myList) {
            Console.Write(num.ToString() + " ");
        }
        Console.Write("\n");
    }
}